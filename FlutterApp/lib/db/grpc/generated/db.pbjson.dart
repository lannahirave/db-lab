//
//  Generated code. Do not modify.
//  source: db.proto
//
// @dart = 2.12

// ignore_for_file: annotate_overrides, camel_case_types, comment_references
// ignore_for_file: constant_identifier_names, library_prefixes
// ignore_for_file: non_constant_identifier_names, prefer_final_fields
// ignore_for_file: unnecessary_import, unnecessary_this, unused_import

import 'dart:convert' as $convert;
import 'dart:core' as $core;
import 'dart:typed_data' as $typed_data;

@$core.Deprecated('Use columnTypeDescriptor instead')
const ColumnType$json = {
  '1': 'ColumnType',
  '2': [
    {'1': 'INTEGER', '2': 0},
    {'1': 'REAL', '2': 1},
    {'1': 'CHAR', '2': 2},
    {'1': 'STRING', '2': 3},
    {'1': 'DATE_TIME', '2': 4},
    {'1': 'DATE_TIME_INTERVAL', '2': 5},
  ],
};

/// Descriptor for `ColumnType`. Decode as a `google.protobuf.EnumDescriptorProto`.
final $typed_data.Uint8List columnTypeDescriptor = $convert.base64Decode(
    'CgpDb2x1bW5UeXBlEgsKB0lOVEVHRVIQABIICgRSRUFMEAESCAoEQ0hBUhACEgoKBlNUUklORx'
    'ADEg0KCURBVEVfVElNRRAEEhYKEkRBVEVfVElNRV9JTlRFUlZBTBAF');

@$core.Deprecated('Use operationResponseDescriptor instead')
const OperationResponse$json = {
  '1': 'OperationResponse',
  '2': [
    {'1': 'success', '3': 1, '4': 1, '5': 8, '10': 'success'},
    {'1': 'message', '3': 2, '4': 1, '5': 9, '9': 0, '10': 'message', '17': true},
  ],
  '8': [
    {'1': '_message'},
  ],
};

/// Descriptor for `OperationResponse`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List operationResponseDescriptor = $convert.base64Decode(
    'ChFPcGVyYXRpb25SZXNwb25zZRIYCgdzdWNjZXNzGAEgASgIUgdzdWNjZXNzEh0KB21lc3NhZ2'
    'UYAiABKAlIAFIHbWVzc2FnZYgBAUIKCghfbWVzc2FnZQ==');

@$core.Deprecated('Use rowOperationResponseDescriptor instead')
const RowOperationResponse$json = {
  '1': 'RowOperationResponse',
  '2': [
    {'1': 'success', '3': 1, '4': 1, '5': 8, '10': 'success'},
    {'1': 'message', '3': 2, '4': 1, '5': 9, '9': 0, '10': 'message', '17': true},
    {'1': 'id', '3': 3, '4': 1, '5': 5, '9': 1, '10': 'id', '17': true},
  ],
  '8': [
    {'1': '_message'},
    {'1': '_id'},
  ],
};

/// Descriptor for `RowOperationResponse`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List rowOperationResponseDescriptor = $convert.base64Decode(
    'ChRSb3dPcGVyYXRpb25SZXNwb25zZRIYCgdzdWNjZXNzGAEgASgIUgdzdWNjZXNzEh0KB21lc3'
    'NhZ2UYAiABKAlIAFIHbWVzc2FnZYgBARITCgJpZBgDIAEoBUgBUgJpZIgBAUIKCghfbWVzc2Fn'
    'ZUIFCgNfaWQ=');

@$core.Deprecated('Use getTablesResponseDescriptor instead')
const GetTablesResponse$json = {
  '1': 'GetTablesResponse',
  '2': [
    {'1': 'tables', '3': 1, '4': 3, '5': 9, '10': 'tables'},
  ],
};

/// Descriptor for `GetTablesResponse`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List getTablesResponseDescriptor = $convert.base64Decode(
    'ChFHZXRUYWJsZXNSZXNwb25zZRIWCgZ0YWJsZXMYASADKAlSBnRhYmxlcw==');

@$core.Deprecated('Use getRowsResponseDescriptor instead')
const GetRowsResponse$json = {
  '1': 'GetRowsResponse',
  '2': [
    {'1': 'rows', '3': 1, '4': 3, '5': 11, '6': '.db.RowData', '10': 'rows'},
  ],
};

/// Descriptor for `GetRowsResponse`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List getRowsResponseDescriptor = $convert.base64Decode(
    'Cg9HZXRSb3dzUmVzcG9uc2USHwoEcm93cxgBIAMoCzILLmRiLlJvd0RhdGFSBHJvd3M=');

@$core.Deprecated('Use getColumnsResponseDescriptor instead')
const GetColumnsResponse$json = {
  '1': 'GetColumnsResponse',
  '2': [
    {'1': 'columns', '3': 1, '4': 3, '5': 11, '6': '.db.Column', '10': 'columns'},
  ],
};

/// Descriptor for `GetColumnsResponse`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List getColumnsResponseDescriptor = $convert.base64Decode(
    'ChJHZXRDb2x1bW5zUmVzcG9uc2USJAoHY29sdW1ucxgBIAMoCzIKLmRiLkNvbHVtblIHY29sdW'
    '1ucw==');

@$core.Deprecated('Use createTableRequestDescriptor instead')
const CreateTableRequest$json = {
  '1': 'CreateTableRequest',
  '2': [
    {'1': 'tableName', '3': 1, '4': 1, '5': 9, '10': 'tableName'},
    {'1': 'columns', '3': 2, '4': 3, '5': 11, '6': '.db.Column', '10': 'columns'},
  ],
};

/// Descriptor for `CreateTableRequest`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List createTableRequestDescriptor = $convert.base64Decode(
    'ChJDcmVhdGVUYWJsZVJlcXVlc3QSHAoJdGFibGVOYW1lGAEgASgJUgl0YWJsZU5hbWUSJAoHY2'
    '9sdW1ucxgCIAMoCzIKLmRiLkNvbHVtblIHY29sdW1ucw==');

@$core.Deprecated('Use getRowsRequestDescriptor instead')
const GetRowsRequest$json = {
  '1': 'GetRowsRequest',
  '2': [
    {'1': 'tableName', '3': 1, '4': 1, '5': 9, '10': 'tableName'},
    {'1': 'limit', '3': 3, '4': 1, '5': 5, '10': 'limit'},
    {'1': 'offset', '3': 4, '4': 1, '5': 5, '10': 'offset'},
  ],
};

/// Descriptor for `GetRowsRequest`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List getRowsRequestDescriptor = $convert.base64Decode(
    'Cg5HZXRSb3dzUmVxdWVzdBIcCgl0YWJsZU5hbWUYASABKAlSCXRhYmxlTmFtZRIUCgVsaW1pdB'
    'gDIAEoBVIFbGltaXQSFgoGb2Zmc2V0GAQgASgFUgZvZmZzZXQ=');

@$core.Deprecated('Use getColumnsRequestDescriptor instead')
const GetColumnsRequest$json = {
  '1': 'GetColumnsRequest',
  '2': [
    {'1': 'tableName', '3': 1, '4': 1, '5': 9, '10': 'tableName'},
  ],
};

/// Descriptor for `GetColumnsRequest`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List getColumnsRequestDescriptor = $convert.base64Decode(
    'ChFHZXRDb2x1bW5zUmVxdWVzdBIcCgl0YWJsZU5hbWUYASABKAlSCXRhYmxlTmFtZQ==');

@$core.Deprecated('Use deleteTableRequestDescriptor instead')
const DeleteTableRequest$json = {
  '1': 'DeleteTableRequest',
  '2': [
    {'1': 'tableName', '3': 1, '4': 1, '5': 9, '10': 'tableName'},
  ],
};

/// Descriptor for `DeleteTableRequest`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List deleteTableRequestDescriptor = $convert.base64Decode(
    'ChJEZWxldGVUYWJsZVJlcXVlc3QSHAoJdGFibGVOYW1lGAEgASgJUgl0YWJsZU5hbWU=');

@$core.Deprecated('Use addRowRequestDescriptor instead')
const AddRowRequest$json = {
  '1': 'AddRowRequest',
  '2': [
    {'1': 'tableName', '3': 1, '4': 1, '5': 9, '10': 'tableName'},
    {'1': 'row', '3': 2, '4': 3, '5': 11, '6': '.db.Cell', '10': 'row'},
  ],
};

/// Descriptor for `AddRowRequest`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List addRowRequestDescriptor = $convert.base64Decode(
    'Cg1BZGRSb3dSZXF1ZXN0EhwKCXRhYmxlTmFtZRgBIAEoCVIJdGFibGVOYW1lEhoKA3JvdxgCIA'
    'MoCzIILmRiLkNlbGxSA3Jvdw==');

@$core.Deprecated('Use deleteRowRequestDescriptor instead')
const DeleteRowRequest$json = {
  '1': 'DeleteRowRequest',
  '2': [
    {'1': 'tableName', '3': 1, '4': 1, '5': 9, '10': 'tableName'},
    {'1': 'id', '3': 2, '4': 1, '5': 5, '10': 'id'},
  ],
};

/// Descriptor for `DeleteRowRequest`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List deleteRowRequestDescriptor = $convert.base64Decode(
    'ChBEZWxldGVSb3dSZXF1ZXN0EhwKCXRhYmxlTmFtZRgBIAEoCVIJdGFibGVOYW1lEg4KAmlkGA'
    'IgASgFUgJpZA==');

@$core.Deprecated('Use updateRowRequestDescriptor instead')
const UpdateRowRequest$json = {
  '1': 'UpdateRowRequest',
  '2': [
    {'1': 'tableName', '3': 1, '4': 1, '5': 9, '10': 'tableName'},
    {'1': 'id', '3': 2, '4': 1, '5': 5, '10': 'id'},
    {'1': 'row', '3': 3, '4': 3, '5': 11, '6': '.db.Cell', '10': 'row'},
  ],
};

/// Descriptor for `UpdateRowRequest`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List updateRowRequestDescriptor = $convert.base64Decode(
    'ChBVcGRhdGVSb3dSZXF1ZXN0EhwKCXRhYmxlTmFtZRgBIAEoCVIJdGFibGVOYW1lEg4KAmlkGA'
    'IgASgFUgJpZBIaCgNyb3cYAyADKAsyCC5kYi5DZWxsUgNyb3c=');

@$core.Deprecated('Use columnDescriptor instead')
const Column$json = {
  '1': 'Column',
  '2': [
    {'1': 'name', '3': 1, '4': 1, '5': 9, '10': 'name'},
    {'1': 'type', '3': 2, '4': 1, '5': 14, '6': '.db.ColumnType', '10': 'type'},
  ],
};

/// Descriptor for `Column`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List columnDescriptor = $convert.base64Decode(
    'CgZDb2x1bW4SEgoEbmFtZRgBIAEoCVIEbmFtZRIiCgR0eXBlGAIgASgOMg4uZGIuQ29sdW1uVH'
    'lwZVIEdHlwZQ==');

@$core.Deprecated('Use cellDescriptor instead')
const Cell$json = {
  '1': 'Cell',
  '2': [
    {'1': 'name', '3': 1, '4': 1, '5': 9, '10': 'name'},
    {'1': 'intValue', '3': 2, '4': 1, '5': 5, '9': 0, '10': 'intValue'},
    {'1': 'floatValue', '3': 3, '4': 1, '5': 2, '9': 0, '10': 'floatValue'},
    {'1': 'stringValue', '3': 5, '4': 1, '5': 9, '9': 0, '10': 'stringValue'},
    {'1': 'dateTimeValue', '3': 6, '4': 1, '5': 11, '6': '.google.protobuf.Timestamp', '9': 0, '10': 'dateTimeValue'},
    {'1': 'dateTimeIntervalValue', '3': 7, '4': 1, '5': 11, '6': '.db.DateTimeInterval', '9': 0, '10': 'dateTimeIntervalValue'},
  ],
  '8': [
    {'1': 'value'},
  ],
};

/// Descriptor for `Cell`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List cellDescriptor = $convert.base64Decode(
    'CgRDZWxsEhIKBG5hbWUYASABKAlSBG5hbWUSHAoIaW50VmFsdWUYAiABKAVIAFIIaW50VmFsdW'
    'USIAoKZmxvYXRWYWx1ZRgDIAEoAkgAUgpmbG9hdFZhbHVlEiIKC3N0cmluZ1ZhbHVlGAUgASgJ'
    'SABSC3N0cmluZ1ZhbHVlEkIKDWRhdGVUaW1lVmFsdWUYBiABKAsyGi5nb29nbGUucHJvdG9idW'
    'YuVGltZXN0YW1wSABSDWRhdGVUaW1lVmFsdWUSTAoVZGF0ZVRpbWVJbnRlcnZhbFZhbHVlGAcg'
    'ASgLMhQuZGIuRGF0ZVRpbWVJbnRlcnZhbEgAUhVkYXRlVGltZUludGVydmFsVmFsdWVCBwoFdm'
    'FsdWU=');

@$core.Deprecated('Use rowDescriptor instead')
const Row$json = {
  '1': 'Row',
  '2': [
    {'1': 'cells', '3': 1, '4': 3, '5': 11, '6': '.db.Cell', '10': 'cells'},
  ],
};

/// Descriptor for `Row`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List rowDescriptor = $convert.base64Decode(
    'CgNSb3cSHgoFY2VsbHMYASADKAsyCC5kYi5DZWxsUgVjZWxscw==');

@$core.Deprecated('Use rowDataDescriptor instead')
const RowData$json = {
  '1': 'RowData',
  '2': [
    {'1': 'data', '3': 1, '4': 3, '5': 11, '6': '.db.CellData', '10': 'data'},
  ],
};

/// Descriptor for `RowData`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List rowDataDescriptor = $convert.base64Decode(
    'CgdSb3dEYXRhEiAKBGRhdGEYASADKAsyDC5kYi5DZWxsRGF0YVIEZGF0YQ==');

@$core.Deprecated('Use cellDataDescriptor instead')
const CellData$json = {
  '1': 'CellData',
  '2': [
    {'1': 'intValue', '3': 2, '4': 1, '5': 5, '9': 0, '10': 'intValue'},
    {'1': 'floatValue', '3': 3, '4': 1, '5': 2, '9': 0, '10': 'floatValue'},
    {'1': 'charValue', '3': 4, '4': 1, '5': 5, '9': 0, '10': 'charValue'},
    {'1': 'stringValue', '3': 5, '4': 1, '5': 9, '9': 0, '10': 'stringValue'},
    {'1': 'dateTimeValue', '3': 6, '4': 1, '5': 11, '6': '.google.protobuf.Timestamp', '9': 0, '10': 'dateTimeValue'},
    {'1': 'dateTimeIntervalValue', '3': 7, '4': 1, '5': 11, '6': '.db.DateTimeInterval', '9': 0, '10': 'dateTimeIntervalValue'},
  ],
  '8': [
    {'1': 'value'},
  ],
};

/// Descriptor for `CellData`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List cellDataDescriptor = $convert.base64Decode(
    'CghDZWxsRGF0YRIcCghpbnRWYWx1ZRgCIAEoBUgAUghpbnRWYWx1ZRIgCgpmbG9hdFZhbHVlGA'
    'MgASgCSABSCmZsb2F0VmFsdWUSHgoJY2hhclZhbHVlGAQgASgFSABSCWNoYXJWYWx1ZRIiCgtz'
    'dHJpbmdWYWx1ZRgFIAEoCUgAUgtzdHJpbmdWYWx1ZRJCCg1kYXRlVGltZVZhbHVlGAYgASgLMh'
    'ouZ29vZ2xlLnByb3RvYnVmLlRpbWVzdGFtcEgAUg1kYXRlVGltZVZhbHVlEkwKFWRhdGVUaW1l'
    'SW50ZXJ2YWxWYWx1ZRgHIAEoCzIULmRiLkRhdGVUaW1lSW50ZXJ2YWxIAFIVZGF0ZVRpbWVJbn'
    'RlcnZhbFZhbHVlQgcKBXZhbHVl');

@$core.Deprecated('Use dateTimeIntervalDescriptor instead')
const DateTimeInterval$json = {
  '1': 'DateTimeInterval',
  '2': [
    {'1': 'start', '3': 1, '4': 1, '5': 11, '6': '.google.protobuf.Timestamp', '10': 'start'},
    {'1': 'end', '3': 2, '4': 1, '5': 11, '6': '.google.protobuf.Timestamp', '10': 'end'},
  ],
};

/// Descriptor for `DateTimeInterval`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List dateTimeIntervalDescriptor = $convert.base64Decode(
    'ChBEYXRlVGltZUludGVydmFsEjAKBXN0YXJ0GAEgASgLMhouZ29vZ2xlLnByb3RvYnVmLlRpbW'
    'VzdGFtcFIFc3RhcnQSLAoDZW5kGAIgASgLMhouZ29vZ2xlLnByb3RvYnVmLlRpbWVzdGFtcFID'
    'ZW5k');

