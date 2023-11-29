import 'package:unidb/db/wsdl/src/com.example.testSoap.wcf.dart';

import 'dart:async';

import 'package:unidb/db/base_db.dart';

class WSDLDBAdapter extends BaseDB {
  final GQBBasicHttpBinding_IDbService client;

  WSDLDBAdapter._({
    required this.client,
  });

  static Future<WSDLDBAdapter> conect({
    required String url,
  }) async {
    var service = GQBBasicHttpBinding_IDbService.WithUrl(url);
    return WSDLDBAdapter._(client: service);
  }

  static GQBColumnType _toGCVColumnType(ColumnType type) {
    switch (type) {
      case ColumnType.integer:
        return GQBColumnType.Integer;
      case ColumnType.real:
        return GQBColumnType.Real;
      case ColumnType.string:
        return GQBColumnType.xString;
      default:
        throw UnimplementedError();
    }
  }

  static ColumnType _toColumnType(GQBColumnType type) {
    switch (type) {
      case GQBColumnType.Integer:
        return ColumnType.integer;
      case GQBColumnType.Real:
        return ColumnType.real;
      case GQBColumnType.xString:
        return ColumnType.string;
      default:
        throw UnimplementedError();
    }
  }

  @override
  FutureOr<int> addRow({
    required String tableName,
    required Map<String, Object?> row,
  }) async {
    await client.AddRow(
      tableName,
      GQBArrayOfRowCell()
        ..innerList = row.entries
            .map(
              (e) => GQBRowCell()
                ..Name = e.key
                ..Value = e.value.toString(),
            )
            .toList(),
    );
    return -1;
  }

  @override
  FutureOr<void> createTable({
    required String name,
    required Iterable<DbColumn> columns,
  }) async {
    await client.CreateTable(
      name,
      GQBArrayOfTableColumn()
        ..innerList = columns
            .map((e) => GQBTableColumn()
              ..Name = e.name
              ..Type = _toGCVColumnType(e.type))
            .toList(),
    );
  }

  @override
  FutureOr<void> deleteRow({required String tableName, required int id}) async {
    await client.DeleteRow(tableName, id);
  }

  @override
  FutureOr<void> deleteTable({required String tableName}) async {
    await client.DeleteTable(tableName);
  }

  @override
  FutureOr<List<DbColumn>> getColumns({required String tableName}) async {
    final response = await client.GetColumns(tableName);
    return response.innerList
        .map((e) => (name: e.Name!, type: _toColumnType(e.Type)))
        .toList();
  }

  @override
  FutureOr<List<List<Object>>> getRows({required String tableName}) async {
    final response = await client.GetRows(tableName);
    final rawRows = response.innerList;

    final delimeter = rawRows[0];
    final columnTypes = rawRows[1]
        .split(delimeter)
        .map(
          (rawType) => ColumnType.values.firstWhere(
            (type) => type.toString().toLowerCase().endsWith(rawType.toLowerCase()),
          ),
        )
        .toList();

    final rows = rawRows
        .skip(2)
        .map((rawRow) => rawRow.split(delimeter).asMap().entries.map((e) {
              final columnType = columnTypes[e.key];
              switch (columnType) {
                case ColumnType.integer:
                  return int.parse(e.value);
                case ColumnType.real:
                  return double.parse(e.value);
                case ColumnType.string:
                  return e.value;
                default:
                  throw UnimplementedError();
              }
            }).toList())
        .toList();

    return rows;
  }

  @override
  FutureOr<List<String>> getTables() async {
    final tables = await client.GetTables();
    return tables.innerList;
  }

  @override
  FutureOr<void> updateRow({
    required String tableName,
    required int id,
    required Map<String, Object?> row,
  }) async {
    await client.UpdateRow(
      tableName,
      id,
      GQBArrayOfRowCell()
        ..innerList = row.entries
            .map(
              (e) => GQBRowCell()
                ..Name = e.key
                ..Value = e.value.toString(),
            )
            .toList(),
    );
  }

  @override
  List<ColumnType> get supportedTypes => [
        ColumnType.integer,
        ColumnType.string,
        ColumnType.real,
      ];

  @override
  String get dbName => 'WSDL';
}
