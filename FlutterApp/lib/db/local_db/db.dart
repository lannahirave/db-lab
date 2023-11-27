import 'dart:async';

import 'package:binarize/binarize.dart';
import 'package:file/file.dart';
import 'package:unidb/db/base_db.dart';
import 'package:unidb/db/local_db/columns.dart';
import 'package:unidb/db/local_db/db_schema.dart';
import 'package:unidb/db/local_db/table.dart';

class DbLoadError extends Error {
  final String message;

  DbLoadError(this.message) : super();
}

class Db {
  final String path;
  final DbSchema schema;
  DateTime lastSaved;
  int size;

  Db._({
    required this.path,
    required this.schema,
    required this.lastSaved,
    required this.size,
    File? file,
  });

  void addTable({
    required String name,
    required Iterable<({String name, ColumnType type})> columns,
  }) {
    final tableColumns =
        columns.map((e) => createColumn(name: e.name, type: e.type)).toList();
    schema.tables[name] = Table.create(name: name, columns: tableColumns);
  }

  void removeTable(String name) {
    schema.tables.remove(name);
  }

  Future<void> save({required FileSystem fileSystem}) async {
    var file = fileSystem.file(path);
    if (!await file.exists()) {
      file = await file.create(recursive: true);
    }

    lastSaved = DateTime.now();

    final payload = Payload.write();
    payload.set(dbSchemaDef, schema);
    payload.set(int64, lastSaved.millisecondsSinceEpoch);
    final bytes = binarize(payload);

    size = bytes.length;

    await file.writeAsBytes(bytes);
  }

  static Future<Db> create({
    required FileSystem fileSystem,
    required String path,
    required String name,
  }) async {
    final file = fileSystem.file(path);
    if (await file.exists()) {
      throw DbLoadError('Database already exists');
    }

    final schema = DbSchema(name: name, tables: {});
    final db = Db._(
      path: path,
      schema: schema,
      file: file,
      lastSaved: DateTime.now(),
      size: 0,
    );
    await db.save(fileSystem: fileSystem);

    return db;
  }

  static FutureOr<Db> load(
      {required FileSystem fileSystem, required String path}) async {
    final file = fileSystem.file(path);
    if (!await file.exists()) {
      throw DbLoadError('Database does not exist');
    }

    final bytes = await file.readAsBytes();
    final payload = Payload.read(bytes);
    final schema = payload.get(dbSchemaDef);
    final lastSaved = DateTime.fromMillisecondsSinceEpoch(payload.get(int64));

    return Db._(
      path: path,
      schema: schema,
      file: file,
      lastSaved: lastSaved,
      size: bytes.length,
    );
  }
}
