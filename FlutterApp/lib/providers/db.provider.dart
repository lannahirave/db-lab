import 'dart:async';

import 'package:file/local.dart';
import 'package:file_picker/file_picker.dart';
import 'package:flutter/foundation.dart';
import 'package:hooks_riverpod/hooks_riverpod.dart';
import 'package:unidb/db/base_db.dart';
import 'package:unidb/db/grpc/adapter.dart';
import 'package:unidb/db/local_db/adapter.dart';
import 'package:window_size/window_size.dart';

const fileSystem = LocalFileSystem();

class DbLoaderNotifier extends ChangeNotifier {
  DbLoaderNotifier();

  BaseDB? db;

  Future<void> openLocalDb() async {
    final result = await FilePicker.platform.pickFiles(
      dialogTitle: 'Select database file',
      allowMultiple: false,
      allowedExtensions: ['db'],
      type: FileType.custom,
    );

    if (result == null ||
        result.count < 1 ||
        result.files.firstOrNull?.path == null) {
      db = null;
      notifyListeners();
      return;
    }

    final path = result.files.first.path!;
    db = await LocalDBAdapter.load(fileSystem: fileSystem, path: path);
    setWindowTitle("DBMS - Local");
    notifyListeners();
  }

  Future<void> createLocalDb({required String name}) async {
    final result = await FilePicker.platform.saveFile(
      dialogTitle: 'Create new database file',
      fileName: '$name.db',
      allowedExtensions: ['db'],
      type: FileType.custom,
    );

    if (result == null) {
      db = null;
      notifyListeners();
      return;
    }

    db = await LocalDBAdapter.create(
        fileSystem: fileSystem, path: result, name: name);
    setWindowTitle("DBMS - Local");
    notifyListeners();
  }

  Future<void> connectGRPCDb({required String host, required int port}) async {
    db = await GRPCDBAdapter.conect(host: host, port: port);
    setWindowTitle("DBMS - GRPC");
    notifyListeners();
  }

  void closeDb() {
    db = null;
    setWindowTitle("DBMS");
    notifyListeners();
  }
}

class DbNotifierState {
  final BaseDB db;
  final List<String> tables;
  final List<ColumnType> columnTypes;
  final String dbName;

  DbNotifierState({
    required this.db,
    required this.tables,
    required this.columnTypes,
    required this.dbName,
  });
}

class DbNotifier extends AsyncNotifier<DbNotifierState> {
  DbNotifier(BaseDB db) : _db = db;

  final BaseDB _db;

  FutureOr refresh() async {
    state = await AsyncValue.guard(() async {
      return _fetchState();
    });
  }

  FutureOr<DbNotifierState> _fetchState() async {
    final tables = await _db.getTables();
    return DbNotifierState(
      db: _db,
      tables: tables,
      columnTypes: _db.supportedTypes,
      dbName: _db.dbName,
    );
  }

  @override
  FutureOr<DbNotifierState> build() {
    return _fetchState();
  }

  FutureOr addTable({
    required String name,
    required Iterable<({String name, ColumnType type})> columns,
  }) async {
    state = await AsyncValue.guard(() async {
      await _db.createTable(name: name, columns: columns);
      return _fetchState();
    });
  }

  FutureOr removeTable(String name) async {
    state = await AsyncValue.guard(() async {
      await _db.deleteTable(tableName: name);
      return _fetchState();
    });
  }
}

class TableNotifierState {
  final List<({String name, ColumnType type})> columns;
  final List<List<Object>> rows;

  TableNotifierState(this.columns, this.rows);
}

class TableNotifier
    extends AutoDisposeFamilyAsyncNotifier<TableNotifierState, String> {
  late final BaseDB _db;
  late String _tableName;

  FutureOr<TableNotifierState> _fetchState(String tableName) async {
    late List<({String name, ColumnType type})> columns;
    late List<List<Object>> rows;

    fetchColumns(String tableName) async {
      columns = await _db.getColumns(tableName: tableName);
    }

    fetchRows(String tableName) async {
      rows = await _db.getRows(tableName: tableName);
    }

    await Future.wait([
      fetchColumns(tableName),
      fetchRows(tableName),
    ]);

    return TableNotifierState(columns, rows);
  }

  @override
  FutureOr<TableNotifierState> build(String arg) async {
    _tableName = arg;

    final db = await ref.watch(dbProvider.future);
    _db = db.db;

    final table =
        db.tables.where((tableName) => tableName == _tableName).firstOrNull;

    if (table == null) {
      throw Exception('Table $_tableName does not exist');
    }
    return _fetchState(_tableName);
  }

  FutureOr addRow(Map<String, Object?> row) async {
    state = await AsyncValue.guard(() async {
      await _db.addRow(tableName: _tableName, row: row);
      return _fetchState(_tableName);
    });
  }

  FutureOr updateRow(int id, Map<String, Object?> row) async {
    state = await AsyncValue.guard(() async {
      await _db.updateRow(tableName: _tableName, id: id, row: row);
      return _fetchState(_tableName);
    });
  }

  FutureOr removeRow(int id) async {
    state = await AsyncValue.guard(() async {
      await _db.deleteRow(tableName: _tableName, id: id);
      return _fetchState(_tableName);
    });
  }

  FutureOr duplicateRow(int id) async {
    state = await AsyncValue.guard(() async {
      final table = state.asData?.value;

      if (table == null) {
        return _fetchState(_tableName);
      }
      final row = table.rows.firstWhere((element) => element[0] == id);

      await _db.addRow(
          tableName: _tableName,
          row: Map.fromEntries(table.columns
              .asMap()
              .entries
              .map((e) => MapEntry(e.value.name, row[e.key]))));

      return _fetchState(_tableName);
    });
  }
}

final dbLoaderProvider = ChangeNotifierProvider((ref) => DbLoaderNotifier());
final dbProvider = AsyncNotifierProvider<DbNotifier, DbNotifierState>(
    () => throw UnimplementedError());

final tableProvider = AutoDisposeAsyncNotifierProviderFamily<TableNotifier,
    TableNotifierState, String>(TableNotifier.new, dependencies: [dbProvider]);
