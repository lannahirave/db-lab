import 'dart:async';

import 'package:grpc/grpc.dart';
import 'package:unidb/db/base_db.dart';
import 'package:unidb/db/base_db.dart' as db;
import 'package:unidb/db/grpc/generated/db.pb.dart';
import 'package:unidb/db/grpc/generated/db.pbgrpc.dart' as grpc;
import 'package:unidb/db/grpc/generated/google/protobuf/empty.pb.dart';

class GRPCDBAdapter extends BaseDB {
  final grpc.DBClient client;

  GRPCDBAdapter._({
    required this.client,
  });

  static Future<GRPCDBAdapter> conect({
    required String host,
    required int port,
  }) async {
    final channel = ClientChannel(
      host,
      port: port,
      options: const ChannelOptions(
        credentials: ChannelCredentials.insecure(),
        connectTimeout: Duration(seconds: 5),
        connectionTimeout: Duration(seconds: 5),
      ),
    );
    final client = grpc.DBClient(channel);
    return GRPCDBAdapter._(client: client);
  }

  static grpc.Cell _mapCell(String name, Object? value) {
    switch (value.runtimeType) {
      case int:
        return grpc.Cell(name: name, intValue: value as int);
      case double:
        return grpc.Cell(name: name, floatValue: value as double);
      case String:
        return grpc.Cell(name: name, stringValue: value as String);
      default:
        throw Exception('Unsupported type: ${value.runtimeType}');
    }
  }

  static grpc.ColumnType _mapColumnTypeToGrpc(db.ColumnType type) {
    switch (type) {
      case db.ColumnType.integer:
        return grpc.ColumnType.INTEGER;
      case db.ColumnType.real:
        return grpc.ColumnType.REAL;
      case db.ColumnType.string:
        return grpc.ColumnType.STRING;
      case db.ColumnType.char:
        return grpc.ColumnType.CHAR;
      default:
        throw Exception('Unsupported type: $type');
    }
  }

  static db.ColumnType _mapFromGrpcColumnType(grpc.ColumnType type) {
    switch (type) {
      case grpc.ColumnType.INTEGER:
        return db.ColumnType.integer;
      case grpc.ColumnType.REAL:
        return db.ColumnType.real;
      case grpc.ColumnType.STRING:
        return db.ColumnType.string;
      case grpc.ColumnType.CHAR:
        return db.ColumnType.char;
      default:
        throw Exception('Unsupported type: $type');
    }
  }

  static Object _extractCellValue(CellData cell) {
    if (cell.hasIntValue()) {
      return cell.intValue;
    }
    if (cell.hasFloatValue()) {
      return cell.floatValue;
    }
    if (cell.hasStringValue()) {
      return cell.stringValue;
    }
    if (cell.hasCharValue()) {
      return cell.charValue;
    }
    throw Exception('Unsupported type: ${cell.whichValue()}');
  }

  @override
  FutureOr<int> addRow(
      {required String tableName, required Map<String, Object?> row}) async {
    final request = grpc.AddRowRequest(tableName: tableName)
      ..row.addAll(row.entries.map((e) {
        return _mapCell(e.key, e.value);
      }));
    final resp = await client.addRow(request);
    return resp.id;
  }

  @override
  FutureOr<void> createTable(
      {required String name, required Iterable<DbColumn> columns}) async {
    final request = grpc.CreateTableRequest(tableName: name)
      ..columns.addAll(columns.map((e) =>
          grpc.Column(name: e.name, type: _mapColumnTypeToGrpc(e.type))));
    await client.createTable(request);
  }

  @override
  FutureOr<void> deleteRow({required String tableName, required int id}) async {
    await client.deleteRow(grpc.DeleteRowRequest(tableName: tableName, id: id));
  }

  @override
  FutureOr<void> deleteTable({required String tableName}) async {
    await client.deleteTable(grpc.DeleteTableRequest(tableName: tableName));
  }

  @override
  FutureOr<List<DbColumn>> getColumns({required String tableName}) async {
    final response =
        await client.getColumns(grpc.GetColumnsRequest(tableName: tableName));
    return response.columns
        .map((e) => (name: e.name, type: _mapFromGrpcColumnType(e.type)))
        .toList();
  }

  @override
  FutureOr<List<List<Object>>> getRows({required String tableName}) async {
    final request =
        grpc.GetRowsRequest(tableName: tableName, offset: 0, limit: 100);
    final response = await client.getRows(request);

    return response.rows
        .map((e) => e.data.map((cell) => _extractCellValue(cell)).toList())
        .toList();
  }

  @override
  FutureOr<List<String>> getTables() async {
    final response = await client.getTables(Empty(),
        options: CallOptions(timeout: const Duration(seconds: 5)));
    return response.tables;
  }

  @override
  FutureOr<void> updateRow(
      {required String tableName,
      required int id,
      required Map<String, Object?> row}) async {
    final request = grpc.UpdateRowRequest(tableName: tableName, id: id)
      ..row.addAll(row.entries.map((e) => _mapCell(e.key, e.value)));
    await client.updateRow(request);
  }
  
  @override
  List<db.ColumnType> get supportedTypes => [
    db.ColumnType.integer,
    db.ColumnType.string,
    db.ColumnType.real,
  ];

    @override
  String get dbName => 'gRPC';
}
