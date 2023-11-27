import 'dart:async';
import 'package:file/file.dart';
import 'package:unidb/db/base_db.dart';
import 'package:unidb/db/local_db/db.dart';

class LocalDBAdapter implements BaseDB {
  FileSystem fileSystem;
  Db db;

  LocalDBAdapter._({
    required this.fileSystem,
    required this.db
  });

  static Future<LocalDBAdapter> create({
    required FileSystem fileSystem,
    required String path,
    required String name,
  }) async {
    final db = await Db.create(fileSystem: fileSystem, path: path, name: name);
    return LocalDBAdapter._(fileSystem: fileSystem, db: db);
  }

  static Future<LocalDBAdapter> load({
    required FileSystem fileSystem,
    required String path,
  }) async {
    final db = await Db.load(fileSystem: fileSystem, path: path);
    return LocalDBAdapter._(fileSystem: fileSystem, db: db);
  }
  
  @override
  FutureOr<int> addRow({required String tableName, required Map<String, Object?> row}) async {
    db.schema.tables[tableName]!.addRow(row);
    await db.save(fileSystem: fileSystem);

    return -1;
  }
  
  @override
  FutureOr<void> createTable({required String name, required Iterable<({String name, ColumnType type})> columns}) async {
    db.addTable(name: name, columns: columns);
    await db.save(fileSystem: fileSystem);
  }
  
  @override
  FutureOr<void> deleteRow({required String tableName, required int id}) async {
    db.schema.tables[tableName]!.removeRow(id);
    await db.save(fileSystem: fileSystem);
  }
  
  @override
  FutureOr<void> deleteTable({required String tableName}) async {
    db.removeTable(tableName);
    await db.save(fileSystem: fileSystem);
  }
  
  @override
  FutureOr<List<({String name, ColumnType type})>> getColumns({required String tableName}) {
    final table = db.schema.tables[tableName]!;
    return table.columns.map((e) => (name: e.name, type: e.type)).toList();
  }
  
  @override
  FutureOr<List<List<Object>>> getRows({required String tableName}) {
    final table = db.schema.tables[tableName]!;
    return table.rows;
  }
  
  @override
  FutureOr<List<String>> getTables() async {
    await Future.delayed(const Duration(seconds: 1));

    return db.schema.tables.keys.toList();
  }
  
  @override
  FutureOr<void> updateRow({required String tableName, required int id, required Map<String, Object?> row}) {
    db.schema.tables[tableName]!.updateRow(id, row);
    return db.save(fileSystem: fileSystem);
  }
}
