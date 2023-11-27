//
//  Generated code. Do not modify.
//  source: db.proto
//
// @dart = 2.12

// ignore_for_file: annotate_overrides, camel_case_types, comment_references
// ignore_for_file: constant_identifier_names, library_prefixes
// ignore_for_file: non_constant_identifier_names, prefer_final_fields
// ignore_for_file: unnecessary_import, unnecessary_this, unused_import

import 'dart:core' as $core;

import 'package:protobuf/protobuf.dart' as $pb;

class ColumnType extends $pb.ProtobufEnum {
  static const ColumnType INTEGER = ColumnType._(0, _omitEnumNames ? '' : 'INTEGER');
  static const ColumnType REAL = ColumnType._(1, _omitEnumNames ? '' : 'REAL');
  static const ColumnType CHAR = ColumnType._(2, _omitEnumNames ? '' : 'CHAR');
  static const ColumnType STRING = ColumnType._(3, _omitEnumNames ? '' : 'STRING');
  static const ColumnType DATE_TIME = ColumnType._(4, _omitEnumNames ? '' : 'DATE_TIME');
  static const ColumnType DATE_TIME_INTERVAL = ColumnType._(5, _omitEnumNames ? '' : 'DATE_TIME_INTERVAL');

  static const $core.List<ColumnType> values = <ColumnType> [
    INTEGER,
    REAL,
    CHAR,
    STRING,
    DATE_TIME,
    DATE_TIME_INTERVAL,
  ];

  static final $core.Map<$core.int, ColumnType> _byValue = $pb.ProtobufEnum.initByValue(values);
  static ColumnType? valueOf($core.int value) => _byValue[value];

  const ColumnType._($core.int v, $core.String n) : super(v, n);
}


const _omitEnumNames = $core.bool.fromEnvironment('protobuf.omit_enum_names');
