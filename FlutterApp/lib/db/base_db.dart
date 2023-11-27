import 'dart:async';

enum ColumnType {
  integer,
  real,
  char,
  string,
  txtFile,
  intRange,
}

typedef DbColumn = ({String name, ColumnType type});

abstract class BaseDB {
  FutureOr<List<String>> getTables();
  FutureOr<void> createTable(
      {required String name,
      required Iterable<DbColumn> columns});
  FutureOr<void> deleteTable({required String tableName});
  FutureOr<int> addRow({required String tableName, required Map<String, Object?> row});
  FutureOr<void> updateRow({required String tableName, required int id, required Map<String, Object?> row});
  FutureOr<void> deleteRow({required String tableName, required int id});
  FutureOr<List<List<Object>>> getRows({required String tableName});
  FutureOr<List<DbColumn>> getColumns({required String tableName});
  List<ColumnType> get supportedTypes;
  String get dbName;
}

class IntegerRange {
  final int min;
  final int max;
  const IntegerRange({required this.min, required this.max});
}

class TextFile {
  final String path;
  final String content;
  const TextFile({required this.path, required this.content});
}
