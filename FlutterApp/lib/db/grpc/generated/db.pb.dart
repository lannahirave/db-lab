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

import 'db.pbenum.dart';
import 'google/protobuf/timestamp.pb.dart' as $2;

export 'db.pbenum.dart';

class OperationResponse extends $pb.GeneratedMessage {
  factory OperationResponse({
    $core.bool? success,
    $core.String? message,
  }) {
    final $result = create();
    if (success != null) {
      $result.success = success;
    }
    if (message != null) {
      $result.message = message;
    }
    return $result;
  }
  OperationResponse._() : super();
  factory OperationResponse.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory OperationResponse.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'OperationResponse', package: const $pb.PackageName(_omitMessageNames ? '' : 'db'), createEmptyInstance: create)
    ..aOB(1, _omitFieldNames ? '' : 'success')
    ..aOS(2, _omitFieldNames ? '' : 'message')
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  OperationResponse clone() => OperationResponse()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  OperationResponse copyWith(void Function(OperationResponse) updates) => super.copyWith((message) => updates(message as OperationResponse)) as OperationResponse;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static OperationResponse create() => OperationResponse._();
  OperationResponse createEmptyInstance() => create();
  static $pb.PbList<OperationResponse> createRepeated() => $pb.PbList<OperationResponse>();
  @$core.pragma('dart2js:noInline')
  static OperationResponse getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<OperationResponse>(create);
  static OperationResponse? _defaultInstance;

  @$pb.TagNumber(1)
  $core.bool get success => $_getBF(0);
  @$pb.TagNumber(1)
  set success($core.bool v) { $_setBool(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasSuccess() => $_has(0);
  @$pb.TagNumber(1)
  void clearSuccess() => clearField(1);

  @$pb.TagNumber(2)
  $core.String get message => $_getSZ(1);
  @$pb.TagNumber(2)
  set message($core.String v) { $_setString(1, v); }
  @$pb.TagNumber(2)
  $core.bool hasMessage() => $_has(1);
  @$pb.TagNumber(2)
  void clearMessage() => clearField(2);
}

class RowOperationResponse extends $pb.GeneratedMessage {
  factory RowOperationResponse({
    $core.bool? success,
    $core.String? message,
    $core.int? id,
  }) {
    final $result = create();
    if (success != null) {
      $result.success = success;
    }
    if (message != null) {
      $result.message = message;
    }
    if (id != null) {
      $result.id = id;
    }
    return $result;
  }
  RowOperationResponse._() : super();
  factory RowOperationResponse.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory RowOperationResponse.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'RowOperationResponse', package: const $pb.PackageName(_omitMessageNames ? '' : 'db'), createEmptyInstance: create)
    ..aOB(1, _omitFieldNames ? '' : 'success')
    ..aOS(2, _omitFieldNames ? '' : 'message')
    ..a<$core.int>(3, _omitFieldNames ? '' : 'id', $pb.PbFieldType.O3)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  RowOperationResponse clone() => RowOperationResponse()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  RowOperationResponse copyWith(void Function(RowOperationResponse) updates) => super.copyWith((message) => updates(message as RowOperationResponse)) as RowOperationResponse;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static RowOperationResponse create() => RowOperationResponse._();
  RowOperationResponse createEmptyInstance() => create();
  static $pb.PbList<RowOperationResponse> createRepeated() => $pb.PbList<RowOperationResponse>();
  @$core.pragma('dart2js:noInline')
  static RowOperationResponse getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<RowOperationResponse>(create);
  static RowOperationResponse? _defaultInstance;

  @$pb.TagNumber(1)
  $core.bool get success => $_getBF(0);
  @$pb.TagNumber(1)
  set success($core.bool v) { $_setBool(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasSuccess() => $_has(0);
  @$pb.TagNumber(1)
  void clearSuccess() => clearField(1);

  @$pb.TagNumber(2)
  $core.String get message => $_getSZ(1);
  @$pb.TagNumber(2)
  set message($core.String v) { $_setString(1, v); }
  @$pb.TagNumber(2)
  $core.bool hasMessage() => $_has(1);
  @$pb.TagNumber(2)
  void clearMessage() => clearField(2);

  @$pb.TagNumber(3)
  $core.int get id => $_getIZ(2);
  @$pb.TagNumber(3)
  set id($core.int v) { $_setSignedInt32(2, v); }
  @$pb.TagNumber(3)
  $core.bool hasId() => $_has(2);
  @$pb.TagNumber(3)
  void clearId() => clearField(3);
}

class GetTablesResponse extends $pb.GeneratedMessage {
  factory GetTablesResponse({
    $core.Iterable<$core.String>? tables,
  }) {
    final $result = create();
    if (tables != null) {
      $result.tables.addAll(tables);
    }
    return $result;
  }
  GetTablesResponse._() : super();
  factory GetTablesResponse.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory GetTablesResponse.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'GetTablesResponse', package: const $pb.PackageName(_omitMessageNames ? '' : 'db'), createEmptyInstance: create)
    ..pPS(1, _omitFieldNames ? '' : 'tables')
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  GetTablesResponse clone() => GetTablesResponse()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  GetTablesResponse copyWith(void Function(GetTablesResponse) updates) => super.copyWith((message) => updates(message as GetTablesResponse)) as GetTablesResponse;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static GetTablesResponse create() => GetTablesResponse._();
  GetTablesResponse createEmptyInstance() => create();
  static $pb.PbList<GetTablesResponse> createRepeated() => $pb.PbList<GetTablesResponse>();
  @$core.pragma('dart2js:noInline')
  static GetTablesResponse getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<GetTablesResponse>(create);
  static GetTablesResponse? _defaultInstance;

  @$pb.TagNumber(1)
  $core.List<$core.String> get tables => $_getList(0);
}

class GetRowsResponse extends $pb.GeneratedMessage {
  factory GetRowsResponse({
    $core.Iterable<RowData>? rows,
  }) {
    final $result = create();
    if (rows != null) {
      $result.rows.addAll(rows);
    }
    return $result;
  }
  GetRowsResponse._() : super();
  factory GetRowsResponse.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory GetRowsResponse.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'GetRowsResponse', package: const $pb.PackageName(_omitMessageNames ? '' : 'db'), createEmptyInstance: create)
    ..pc<RowData>(1, _omitFieldNames ? '' : 'rows', $pb.PbFieldType.PM, subBuilder: RowData.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  GetRowsResponse clone() => GetRowsResponse()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  GetRowsResponse copyWith(void Function(GetRowsResponse) updates) => super.copyWith((message) => updates(message as GetRowsResponse)) as GetRowsResponse;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static GetRowsResponse create() => GetRowsResponse._();
  GetRowsResponse createEmptyInstance() => create();
  static $pb.PbList<GetRowsResponse> createRepeated() => $pb.PbList<GetRowsResponse>();
  @$core.pragma('dart2js:noInline')
  static GetRowsResponse getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<GetRowsResponse>(create);
  static GetRowsResponse? _defaultInstance;

  @$pb.TagNumber(1)
  $core.List<RowData> get rows => $_getList(0);
}

class GetColumnsResponse extends $pb.GeneratedMessage {
  factory GetColumnsResponse({
    $core.Iterable<Column>? columns,
  }) {
    final $result = create();
    if (columns != null) {
      $result.columns.addAll(columns);
    }
    return $result;
  }
  GetColumnsResponse._() : super();
  factory GetColumnsResponse.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory GetColumnsResponse.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'GetColumnsResponse', package: const $pb.PackageName(_omitMessageNames ? '' : 'db'), createEmptyInstance: create)
    ..pc<Column>(1, _omitFieldNames ? '' : 'columns', $pb.PbFieldType.PM, subBuilder: Column.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  GetColumnsResponse clone() => GetColumnsResponse()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  GetColumnsResponse copyWith(void Function(GetColumnsResponse) updates) => super.copyWith((message) => updates(message as GetColumnsResponse)) as GetColumnsResponse;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static GetColumnsResponse create() => GetColumnsResponse._();
  GetColumnsResponse createEmptyInstance() => create();
  static $pb.PbList<GetColumnsResponse> createRepeated() => $pb.PbList<GetColumnsResponse>();
  @$core.pragma('dart2js:noInline')
  static GetColumnsResponse getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<GetColumnsResponse>(create);
  static GetColumnsResponse? _defaultInstance;

  @$pb.TagNumber(1)
  $core.List<Column> get columns => $_getList(0);
}

class CreateTableRequest extends $pb.GeneratedMessage {
  factory CreateTableRequest({
    $core.String? tableName,
    $core.Iterable<Column>? columns,
  }) {
    final $result = create();
    if (tableName != null) {
      $result.tableName = tableName;
    }
    if (columns != null) {
      $result.columns.addAll(columns);
    }
    return $result;
  }
  CreateTableRequest._() : super();
  factory CreateTableRequest.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory CreateTableRequest.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'CreateTableRequest', package: const $pb.PackageName(_omitMessageNames ? '' : 'db'), createEmptyInstance: create)
    ..aOS(1, _omitFieldNames ? '' : 'tableName', protoName: 'tableName')
    ..pc<Column>(2, _omitFieldNames ? '' : 'columns', $pb.PbFieldType.PM, subBuilder: Column.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  CreateTableRequest clone() => CreateTableRequest()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  CreateTableRequest copyWith(void Function(CreateTableRequest) updates) => super.copyWith((message) => updates(message as CreateTableRequest)) as CreateTableRequest;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static CreateTableRequest create() => CreateTableRequest._();
  CreateTableRequest createEmptyInstance() => create();
  static $pb.PbList<CreateTableRequest> createRepeated() => $pb.PbList<CreateTableRequest>();
  @$core.pragma('dart2js:noInline')
  static CreateTableRequest getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<CreateTableRequest>(create);
  static CreateTableRequest? _defaultInstance;

  @$pb.TagNumber(1)
  $core.String get tableName => $_getSZ(0);
  @$pb.TagNumber(1)
  set tableName($core.String v) { $_setString(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasTableName() => $_has(0);
  @$pb.TagNumber(1)
  void clearTableName() => clearField(1);

  @$pb.TagNumber(2)
  $core.List<Column> get columns => $_getList(1);
}

class GetRowsRequest extends $pb.GeneratedMessage {
  factory GetRowsRequest({
    $core.String? tableName,
    $core.int? limit,
    $core.int? offset,
  }) {
    final $result = create();
    if (tableName != null) {
      $result.tableName = tableName;
    }
    if (limit != null) {
      $result.limit = limit;
    }
    if (offset != null) {
      $result.offset = offset;
    }
    return $result;
  }
  GetRowsRequest._() : super();
  factory GetRowsRequest.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory GetRowsRequest.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'GetRowsRequest', package: const $pb.PackageName(_omitMessageNames ? '' : 'db'), createEmptyInstance: create)
    ..aOS(1, _omitFieldNames ? '' : 'tableName', protoName: 'tableName')
    ..a<$core.int>(3, _omitFieldNames ? '' : 'limit', $pb.PbFieldType.O3)
    ..a<$core.int>(4, _omitFieldNames ? '' : 'offset', $pb.PbFieldType.O3)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  GetRowsRequest clone() => GetRowsRequest()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  GetRowsRequest copyWith(void Function(GetRowsRequest) updates) => super.copyWith((message) => updates(message as GetRowsRequest)) as GetRowsRequest;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static GetRowsRequest create() => GetRowsRequest._();
  GetRowsRequest createEmptyInstance() => create();
  static $pb.PbList<GetRowsRequest> createRepeated() => $pb.PbList<GetRowsRequest>();
  @$core.pragma('dart2js:noInline')
  static GetRowsRequest getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<GetRowsRequest>(create);
  static GetRowsRequest? _defaultInstance;

  @$pb.TagNumber(1)
  $core.String get tableName => $_getSZ(0);
  @$pb.TagNumber(1)
  set tableName($core.String v) { $_setString(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasTableName() => $_has(0);
  @$pb.TagNumber(1)
  void clearTableName() => clearField(1);

  @$pb.TagNumber(3)
  $core.int get limit => $_getIZ(1);
  @$pb.TagNumber(3)
  set limit($core.int v) { $_setSignedInt32(1, v); }
  @$pb.TagNumber(3)
  $core.bool hasLimit() => $_has(1);
  @$pb.TagNumber(3)
  void clearLimit() => clearField(3);

  @$pb.TagNumber(4)
  $core.int get offset => $_getIZ(2);
  @$pb.TagNumber(4)
  set offset($core.int v) { $_setSignedInt32(2, v); }
  @$pb.TagNumber(4)
  $core.bool hasOffset() => $_has(2);
  @$pb.TagNumber(4)
  void clearOffset() => clearField(4);
}

class GetColumnsRequest extends $pb.GeneratedMessage {
  factory GetColumnsRequest({
    $core.String? tableName,
  }) {
    final $result = create();
    if (tableName != null) {
      $result.tableName = tableName;
    }
    return $result;
  }
  GetColumnsRequest._() : super();
  factory GetColumnsRequest.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory GetColumnsRequest.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'GetColumnsRequest', package: const $pb.PackageName(_omitMessageNames ? '' : 'db'), createEmptyInstance: create)
    ..aOS(1, _omitFieldNames ? '' : 'tableName', protoName: 'tableName')
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  GetColumnsRequest clone() => GetColumnsRequest()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  GetColumnsRequest copyWith(void Function(GetColumnsRequest) updates) => super.copyWith((message) => updates(message as GetColumnsRequest)) as GetColumnsRequest;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static GetColumnsRequest create() => GetColumnsRequest._();
  GetColumnsRequest createEmptyInstance() => create();
  static $pb.PbList<GetColumnsRequest> createRepeated() => $pb.PbList<GetColumnsRequest>();
  @$core.pragma('dart2js:noInline')
  static GetColumnsRequest getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<GetColumnsRequest>(create);
  static GetColumnsRequest? _defaultInstance;

  @$pb.TagNumber(1)
  $core.String get tableName => $_getSZ(0);
  @$pb.TagNumber(1)
  set tableName($core.String v) { $_setString(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasTableName() => $_has(0);
  @$pb.TagNumber(1)
  void clearTableName() => clearField(1);
}

class DeleteTableRequest extends $pb.GeneratedMessage {
  factory DeleteTableRequest({
    $core.String? tableName,
  }) {
    final $result = create();
    if (tableName != null) {
      $result.tableName = tableName;
    }
    return $result;
  }
  DeleteTableRequest._() : super();
  factory DeleteTableRequest.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory DeleteTableRequest.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'DeleteTableRequest', package: const $pb.PackageName(_omitMessageNames ? '' : 'db'), createEmptyInstance: create)
    ..aOS(1, _omitFieldNames ? '' : 'tableName', protoName: 'tableName')
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  DeleteTableRequest clone() => DeleteTableRequest()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  DeleteTableRequest copyWith(void Function(DeleteTableRequest) updates) => super.copyWith((message) => updates(message as DeleteTableRequest)) as DeleteTableRequest;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static DeleteTableRequest create() => DeleteTableRequest._();
  DeleteTableRequest createEmptyInstance() => create();
  static $pb.PbList<DeleteTableRequest> createRepeated() => $pb.PbList<DeleteTableRequest>();
  @$core.pragma('dart2js:noInline')
  static DeleteTableRequest getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<DeleteTableRequest>(create);
  static DeleteTableRequest? _defaultInstance;

  @$pb.TagNumber(1)
  $core.String get tableName => $_getSZ(0);
  @$pb.TagNumber(1)
  set tableName($core.String v) { $_setString(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasTableName() => $_has(0);
  @$pb.TagNumber(1)
  void clearTableName() => clearField(1);
}

class AddRowRequest extends $pb.GeneratedMessage {
  factory AddRowRequest({
    $core.String? tableName,
    $core.Iterable<Cell>? row,
  }) {
    final $result = create();
    if (tableName != null) {
      $result.tableName = tableName;
    }
    if (row != null) {
      $result.row.addAll(row);
    }
    return $result;
  }
  AddRowRequest._() : super();
  factory AddRowRequest.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory AddRowRequest.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'AddRowRequest', package: const $pb.PackageName(_omitMessageNames ? '' : 'db'), createEmptyInstance: create)
    ..aOS(1, _omitFieldNames ? '' : 'tableName', protoName: 'tableName')
    ..pc<Cell>(2, _omitFieldNames ? '' : 'row', $pb.PbFieldType.PM, subBuilder: Cell.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  AddRowRequest clone() => AddRowRequest()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  AddRowRequest copyWith(void Function(AddRowRequest) updates) => super.copyWith((message) => updates(message as AddRowRequest)) as AddRowRequest;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static AddRowRequest create() => AddRowRequest._();
  AddRowRequest createEmptyInstance() => create();
  static $pb.PbList<AddRowRequest> createRepeated() => $pb.PbList<AddRowRequest>();
  @$core.pragma('dart2js:noInline')
  static AddRowRequest getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<AddRowRequest>(create);
  static AddRowRequest? _defaultInstance;

  @$pb.TagNumber(1)
  $core.String get tableName => $_getSZ(0);
  @$pb.TagNumber(1)
  set tableName($core.String v) { $_setString(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasTableName() => $_has(0);
  @$pb.TagNumber(1)
  void clearTableName() => clearField(1);

  @$pb.TagNumber(2)
  $core.List<Cell> get row => $_getList(1);
}

class DeleteRowRequest extends $pb.GeneratedMessage {
  factory DeleteRowRequest({
    $core.String? tableName,
    $core.int? id,
  }) {
    final $result = create();
    if (tableName != null) {
      $result.tableName = tableName;
    }
    if (id != null) {
      $result.id = id;
    }
    return $result;
  }
  DeleteRowRequest._() : super();
  factory DeleteRowRequest.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory DeleteRowRequest.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'DeleteRowRequest', package: const $pb.PackageName(_omitMessageNames ? '' : 'db'), createEmptyInstance: create)
    ..aOS(1, _omitFieldNames ? '' : 'tableName', protoName: 'tableName')
    ..a<$core.int>(2, _omitFieldNames ? '' : 'id', $pb.PbFieldType.O3)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  DeleteRowRequest clone() => DeleteRowRequest()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  DeleteRowRequest copyWith(void Function(DeleteRowRequest) updates) => super.copyWith((message) => updates(message as DeleteRowRequest)) as DeleteRowRequest;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static DeleteRowRequest create() => DeleteRowRequest._();
  DeleteRowRequest createEmptyInstance() => create();
  static $pb.PbList<DeleteRowRequest> createRepeated() => $pb.PbList<DeleteRowRequest>();
  @$core.pragma('dart2js:noInline')
  static DeleteRowRequest getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<DeleteRowRequest>(create);
  static DeleteRowRequest? _defaultInstance;

  @$pb.TagNumber(1)
  $core.String get tableName => $_getSZ(0);
  @$pb.TagNumber(1)
  set tableName($core.String v) { $_setString(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasTableName() => $_has(0);
  @$pb.TagNumber(1)
  void clearTableName() => clearField(1);

  @$pb.TagNumber(2)
  $core.int get id => $_getIZ(1);
  @$pb.TagNumber(2)
  set id($core.int v) { $_setSignedInt32(1, v); }
  @$pb.TagNumber(2)
  $core.bool hasId() => $_has(1);
  @$pb.TagNumber(2)
  void clearId() => clearField(2);
}

class UpdateRowRequest extends $pb.GeneratedMessage {
  factory UpdateRowRequest({
    $core.String? tableName,
    $core.int? id,
    $core.Iterable<Cell>? row,
  }) {
    final $result = create();
    if (tableName != null) {
      $result.tableName = tableName;
    }
    if (id != null) {
      $result.id = id;
    }
    if (row != null) {
      $result.row.addAll(row);
    }
    return $result;
  }
  UpdateRowRequest._() : super();
  factory UpdateRowRequest.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory UpdateRowRequest.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'UpdateRowRequest', package: const $pb.PackageName(_omitMessageNames ? '' : 'db'), createEmptyInstance: create)
    ..aOS(1, _omitFieldNames ? '' : 'tableName', protoName: 'tableName')
    ..a<$core.int>(2, _omitFieldNames ? '' : 'id', $pb.PbFieldType.O3)
    ..pc<Cell>(3, _omitFieldNames ? '' : 'row', $pb.PbFieldType.PM, subBuilder: Cell.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  UpdateRowRequest clone() => UpdateRowRequest()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  UpdateRowRequest copyWith(void Function(UpdateRowRequest) updates) => super.copyWith((message) => updates(message as UpdateRowRequest)) as UpdateRowRequest;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static UpdateRowRequest create() => UpdateRowRequest._();
  UpdateRowRequest createEmptyInstance() => create();
  static $pb.PbList<UpdateRowRequest> createRepeated() => $pb.PbList<UpdateRowRequest>();
  @$core.pragma('dart2js:noInline')
  static UpdateRowRequest getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<UpdateRowRequest>(create);
  static UpdateRowRequest? _defaultInstance;

  @$pb.TagNumber(1)
  $core.String get tableName => $_getSZ(0);
  @$pb.TagNumber(1)
  set tableName($core.String v) { $_setString(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasTableName() => $_has(0);
  @$pb.TagNumber(1)
  void clearTableName() => clearField(1);

  @$pb.TagNumber(2)
  $core.int get id => $_getIZ(1);
  @$pb.TagNumber(2)
  set id($core.int v) { $_setSignedInt32(1, v); }
  @$pb.TagNumber(2)
  $core.bool hasId() => $_has(1);
  @$pb.TagNumber(2)
  void clearId() => clearField(2);

  @$pb.TagNumber(3)
  $core.List<Cell> get row => $_getList(2);
}

class Column extends $pb.GeneratedMessage {
  factory Column({
    $core.String? name,
    ColumnType? type,
  }) {
    final $result = create();
    if (name != null) {
      $result.name = name;
    }
    if (type != null) {
      $result.type = type;
    }
    return $result;
  }
  Column._() : super();
  factory Column.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory Column.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'Column', package: const $pb.PackageName(_omitMessageNames ? '' : 'db'), createEmptyInstance: create)
    ..aOS(1, _omitFieldNames ? '' : 'name')
    ..e<ColumnType>(2, _omitFieldNames ? '' : 'type', $pb.PbFieldType.OE, defaultOrMaker: ColumnType.INTEGER, valueOf: ColumnType.valueOf, enumValues: ColumnType.values)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  Column clone() => Column()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  Column copyWith(void Function(Column) updates) => super.copyWith((message) => updates(message as Column)) as Column;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static Column create() => Column._();
  Column createEmptyInstance() => create();
  static $pb.PbList<Column> createRepeated() => $pb.PbList<Column>();
  @$core.pragma('dart2js:noInline')
  static Column getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<Column>(create);
  static Column? _defaultInstance;

  @$pb.TagNumber(1)
  $core.String get name => $_getSZ(0);
  @$pb.TagNumber(1)
  set name($core.String v) { $_setString(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasName() => $_has(0);
  @$pb.TagNumber(1)
  void clearName() => clearField(1);

  @$pb.TagNumber(2)
  ColumnType get type => $_getN(1);
  @$pb.TagNumber(2)
  set type(ColumnType v) { setField(2, v); }
  @$pb.TagNumber(2)
  $core.bool hasType() => $_has(1);
  @$pb.TagNumber(2)
  void clearType() => clearField(2);
}

enum Cell_Value {
  intValue, 
  floatValue, 
  stringValue, 
  dateTimeValue, 
  dateTimeIntervalValue, 
  notSet
}

class Cell extends $pb.GeneratedMessage {
  factory Cell({
    $core.String? name,
    $core.int? intValue,
    $core.double? floatValue,
    $core.String? stringValue,
    $2.Timestamp? dateTimeValue,
    DateTimeInterval? dateTimeIntervalValue,
  }) {
    final $result = create();
    if (name != null) {
      $result.name = name;
    }
    if (intValue != null) {
      $result.intValue = intValue;
    }
    if (floatValue != null) {
      $result.floatValue = floatValue;
    }
    if (stringValue != null) {
      $result.stringValue = stringValue;
    }
    if (dateTimeValue != null) {
      $result.dateTimeValue = dateTimeValue;
    }
    if (dateTimeIntervalValue != null) {
      $result.dateTimeIntervalValue = dateTimeIntervalValue;
    }
    return $result;
  }
  Cell._() : super();
  factory Cell.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory Cell.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static const $core.Map<$core.int, Cell_Value> _Cell_ValueByTag = {
    2 : Cell_Value.intValue,
    3 : Cell_Value.floatValue,
    5 : Cell_Value.stringValue,
    6 : Cell_Value.dateTimeValue,
    7 : Cell_Value.dateTimeIntervalValue,
    0 : Cell_Value.notSet
  };
  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'Cell', package: const $pb.PackageName(_omitMessageNames ? '' : 'db'), createEmptyInstance: create)
    ..oo(0, [2, 3, 5, 6, 7])
    ..aOS(1, _omitFieldNames ? '' : 'name')
    ..a<$core.int>(2, _omitFieldNames ? '' : 'intValue', $pb.PbFieldType.O3, protoName: 'intValue')
    ..a<$core.double>(3, _omitFieldNames ? '' : 'floatValue', $pb.PbFieldType.OF, protoName: 'floatValue')
    ..aOS(5, _omitFieldNames ? '' : 'stringValue', protoName: 'stringValue')
    ..aOM<$2.Timestamp>(6, _omitFieldNames ? '' : 'dateTimeValue', protoName: 'dateTimeValue', subBuilder: $2.Timestamp.create)
    ..aOM<DateTimeInterval>(7, _omitFieldNames ? '' : 'dateTimeIntervalValue', protoName: 'dateTimeIntervalValue', subBuilder: DateTimeInterval.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  Cell clone() => Cell()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  Cell copyWith(void Function(Cell) updates) => super.copyWith((message) => updates(message as Cell)) as Cell;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static Cell create() => Cell._();
  Cell createEmptyInstance() => create();
  static $pb.PbList<Cell> createRepeated() => $pb.PbList<Cell>();
  @$core.pragma('dart2js:noInline')
  static Cell getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<Cell>(create);
  static Cell? _defaultInstance;

  Cell_Value whichValue() => _Cell_ValueByTag[$_whichOneof(0)]!;
  void clearValue() => clearField($_whichOneof(0));

  @$pb.TagNumber(1)
  $core.String get name => $_getSZ(0);
  @$pb.TagNumber(1)
  set name($core.String v) { $_setString(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasName() => $_has(0);
  @$pb.TagNumber(1)
  void clearName() => clearField(1);

  @$pb.TagNumber(2)
  $core.int get intValue => $_getIZ(1);
  @$pb.TagNumber(2)
  set intValue($core.int v) { $_setSignedInt32(1, v); }
  @$pb.TagNumber(2)
  $core.bool hasIntValue() => $_has(1);
  @$pb.TagNumber(2)
  void clearIntValue() => clearField(2);

  @$pb.TagNumber(3)
  $core.double get floatValue => $_getN(2);
  @$pb.TagNumber(3)
  set floatValue($core.double v) { $_setFloat(2, v); }
  @$pb.TagNumber(3)
  $core.bool hasFloatValue() => $_has(2);
  @$pb.TagNumber(3)
  void clearFloatValue() => clearField(3);

  @$pb.TagNumber(5)
  $core.String get stringValue => $_getSZ(3);
  @$pb.TagNumber(5)
  set stringValue($core.String v) { $_setString(3, v); }
  @$pb.TagNumber(5)
  $core.bool hasStringValue() => $_has(3);
  @$pb.TagNumber(5)
  void clearStringValue() => clearField(5);

  @$pb.TagNumber(6)
  $2.Timestamp get dateTimeValue => $_getN(4);
  @$pb.TagNumber(6)
  set dateTimeValue($2.Timestamp v) { setField(6, v); }
  @$pb.TagNumber(6)
  $core.bool hasDateTimeValue() => $_has(4);
  @$pb.TagNumber(6)
  void clearDateTimeValue() => clearField(6);
  @$pb.TagNumber(6)
  $2.Timestamp ensureDateTimeValue() => $_ensure(4);

  @$pb.TagNumber(7)
  DateTimeInterval get dateTimeIntervalValue => $_getN(5);
  @$pb.TagNumber(7)
  set dateTimeIntervalValue(DateTimeInterval v) { setField(7, v); }
  @$pb.TagNumber(7)
  $core.bool hasDateTimeIntervalValue() => $_has(5);
  @$pb.TagNumber(7)
  void clearDateTimeIntervalValue() => clearField(7);
  @$pb.TagNumber(7)
  DateTimeInterval ensureDateTimeIntervalValue() => $_ensure(5);
}

class Row extends $pb.GeneratedMessage {
  factory Row({
    $core.Iterable<Cell>? cells,
  }) {
    final $result = create();
    if (cells != null) {
      $result.cells.addAll(cells);
    }
    return $result;
  }
  Row._() : super();
  factory Row.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory Row.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'Row', package: const $pb.PackageName(_omitMessageNames ? '' : 'db'), createEmptyInstance: create)
    ..pc<Cell>(1, _omitFieldNames ? '' : 'cells', $pb.PbFieldType.PM, subBuilder: Cell.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  Row clone() => Row()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  Row copyWith(void Function(Row) updates) => super.copyWith((message) => updates(message as Row)) as Row;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static Row create() => Row._();
  Row createEmptyInstance() => create();
  static $pb.PbList<Row> createRepeated() => $pb.PbList<Row>();
  @$core.pragma('dart2js:noInline')
  static Row getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<Row>(create);
  static Row? _defaultInstance;

  @$pb.TagNumber(1)
  $core.List<Cell> get cells => $_getList(0);
}

class RowData extends $pb.GeneratedMessage {
  factory RowData({
    $core.Iterable<CellData>? data,
  }) {
    final $result = create();
    if (data != null) {
      $result.data.addAll(data);
    }
    return $result;
  }
  RowData._() : super();
  factory RowData.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory RowData.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'RowData', package: const $pb.PackageName(_omitMessageNames ? '' : 'db'), createEmptyInstance: create)
    ..pc<CellData>(1, _omitFieldNames ? '' : 'data', $pb.PbFieldType.PM, subBuilder: CellData.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  RowData clone() => RowData()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  RowData copyWith(void Function(RowData) updates) => super.copyWith((message) => updates(message as RowData)) as RowData;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static RowData create() => RowData._();
  RowData createEmptyInstance() => create();
  static $pb.PbList<RowData> createRepeated() => $pb.PbList<RowData>();
  @$core.pragma('dart2js:noInline')
  static RowData getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<RowData>(create);
  static RowData? _defaultInstance;

  @$pb.TagNumber(1)
  $core.List<CellData> get data => $_getList(0);
}

enum CellData_Value {
  intValue, 
  floatValue, 
  charValue, 
  stringValue, 
  dateTimeValue, 
  dateTimeIntervalValue, 
  notSet
}

class CellData extends $pb.GeneratedMessage {
  factory CellData({
    $core.int? intValue,
    $core.double? floatValue,
    $core.int? charValue,
    $core.String? stringValue,
    $2.Timestamp? dateTimeValue,
    DateTimeInterval? dateTimeIntervalValue,
  }) {
    final $result = create();
    if (intValue != null) {
      $result.intValue = intValue;
    }
    if (floatValue != null) {
      $result.floatValue = floatValue;
    }
    if (charValue != null) {
      $result.charValue = charValue;
    }
    if (stringValue != null) {
      $result.stringValue = stringValue;
    }
    if (dateTimeValue != null) {
      $result.dateTimeValue = dateTimeValue;
    }
    if (dateTimeIntervalValue != null) {
      $result.dateTimeIntervalValue = dateTimeIntervalValue;
    }
    return $result;
  }
  CellData._() : super();
  factory CellData.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory CellData.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static const $core.Map<$core.int, CellData_Value> _CellData_ValueByTag = {
    2 : CellData_Value.intValue,
    3 : CellData_Value.floatValue,
    4 : CellData_Value.charValue,
    5 : CellData_Value.stringValue,
    6 : CellData_Value.dateTimeValue,
    7 : CellData_Value.dateTimeIntervalValue,
    0 : CellData_Value.notSet
  };
  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'CellData', package: const $pb.PackageName(_omitMessageNames ? '' : 'db'), createEmptyInstance: create)
    ..oo(0, [2, 3, 4, 5, 6, 7])
    ..a<$core.int>(2, _omitFieldNames ? '' : 'intValue', $pb.PbFieldType.O3, protoName: 'intValue')
    ..a<$core.double>(3, _omitFieldNames ? '' : 'floatValue', $pb.PbFieldType.OF, protoName: 'floatValue')
    ..a<$core.int>(4, _omitFieldNames ? '' : 'charValue', $pb.PbFieldType.O3, protoName: 'charValue')
    ..aOS(5, _omitFieldNames ? '' : 'stringValue', protoName: 'stringValue')
    ..aOM<$2.Timestamp>(6, _omitFieldNames ? '' : 'dateTimeValue', protoName: 'dateTimeValue', subBuilder: $2.Timestamp.create)
    ..aOM<DateTimeInterval>(7, _omitFieldNames ? '' : 'dateTimeIntervalValue', protoName: 'dateTimeIntervalValue', subBuilder: DateTimeInterval.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  CellData clone() => CellData()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  CellData copyWith(void Function(CellData) updates) => super.copyWith((message) => updates(message as CellData)) as CellData;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static CellData create() => CellData._();
  CellData createEmptyInstance() => create();
  static $pb.PbList<CellData> createRepeated() => $pb.PbList<CellData>();
  @$core.pragma('dart2js:noInline')
  static CellData getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<CellData>(create);
  static CellData? _defaultInstance;

  CellData_Value whichValue() => _CellData_ValueByTag[$_whichOneof(0)]!;
  void clearValue() => clearField($_whichOneof(0));

  @$pb.TagNumber(2)
  $core.int get intValue => $_getIZ(0);
  @$pb.TagNumber(2)
  set intValue($core.int v) { $_setSignedInt32(0, v); }
  @$pb.TagNumber(2)
  $core.bool hasIntValue() => $_has(0);
  @$pb.TagNumber(2)
  void clearIntValue() => clearField(2);

  @$pb.TagNumber(3)
  $core.double get floatValue => $_getN(1);
  @$pb.TagNumber(3)
  set floatValue($core.double v) { $_setFloat(1, v); }
  @$pb.TagNumber(3)
  $core.bool hasFloatValue() => $_has(1);
  @$pb.TagNumber(3)
  void clearFloatValue() => clearField(3);

  @$pb.TagNumber(4)
  $core.int get charValue => $_getIZ(2);
  @$pb.TagNumber(4)
  set charValue($core.int v) { $_setSignedInt32(2, v); }
  @$pb.TagNumber(4)
  $core.bool hasCharValue() => $_has(2);
  @$pb.TagNumber(4)
  void clearCharValue() => clearField(4);

  @$pb.TagNumber(5)
  $core.String get stringValue => $_getSZ(3);
  @$pb.TagNumber(5)
  set stringValue($core.String v) { $_setString(3, v); }
  @$pb.TagNumber(5)
  $core.bool hasStringValue() => $_has(3);
  @$pb.TagNumber(5)
  void clearStringValue() => clearField(5);

  @$pb.TagNumber(6)
  $2.Timestamp get dateTimeValue => $_getN(4);
  @$pb.TagNumber(6)
  set dateTimeValue($2.Timestamp v) { setField(6, v); }
  @$pb.TagNumber(6)
  $core.bool hasDateTimeValue() => $_has(4);
  @$pb.TagNumber(6)
  void clearDateTimeValue() => clearField(6);
  @$pb.TagNumber(6)
  $2.Timestamp ensureDateTimeValue() => $_ensure(4);

  @$pb.TagNumber(7)
  DateTimeInterval get dateTimeIntervalValue => $_getN(5);
  @$pb.TagNumber(7)
  set dateTimeIntervalValue(DateTimeInterval v) { setField(7, v); }
  @$pb.TagNumber(7)
  $core.bool hasDateTimeIntervalValue() => $_has(5);
  @$pb.TagNumber(7)
  void clearDateTimeIntervalValue() => clearField(7);
  @$pb.TagNumber(7)
  DateTimeInterval ensureDateTimeIntervalValue() => $_ensure(5);
}

class DateTimeInterval extends $pb.GeneratedMessage {
  factory DateTimeInterval({
    $2.Timestamp? start,
    $2.Timestamp? end,
  }) {
    final $result = create();
    if (start != null) {
      $result.start = start;
    }
    if (end != null) {
      $result.end = end;
    }
    return $result;
  }
  DateTimeInterval._() : super();
  factory DateTimeInterval.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory DateTimeInterval.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'DateTimeInterval', package: const $pb.PackageName(_omitMessageNames ? '' : 'db'), createEmptyInstance: create)
    ..aOM<$2.Timestamp>(1, _omitFieldNames ? '' : 'start', subBuilder: $2.Timestamp.create)
    ..aOM<$2.Timestamp>(2, _omitFieldNames ? '' : 'end', subBuilder: $2.Timestamp.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  DateTimeInterval clone() => DateTimeInterval()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  DateTimeInterval copyWith(void Function(DateTimeInterval) updates) => super.copyWith((message) => updates(message as DateTimeInterval)) as DateTimeInterval;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static DateTimeInterval create() => DateTimeInterval._();
  DateTimeInterval createEmptyInstance() => create();
  static $pb.PbList<DateTimeInterval> createRepeated() => $pb.PbList<DateTimeInterval>();
  @$core.pragma('dart2js:noInline')
  static DateTimeInterval getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<DateTimeInterval>(create);
  static DateTimeInterval? _defaultInstance;

  @$pb.TagNumber(1)
  $2.Timestamp get start => $_getN(0);
  @$pb.TagNumber(1)
  set start($2.Timestamp v) { setField(1, v); }
  @$pb.TagNumber(1)
  $core.bool hasStart() => $_has(0);
  @$pb.TagNumber(1)
  void clearStart() => clearField(1);
  @$pb.TagNumber(1)
  $2.Timestamp ensureStart() => $_ensure(0);

  @$pb.TagNumber(2)
  $2.Timestamp get end => $_getN(1);
  @$pb.TagNumber(2)
  set end($2.Timestamp v) { setField(2, v); }
  @$pb.TagNumber(2)
  $core.bool hasEnd() => $_has(1);
  @$pb.TagNumber(2)
  void clearEnd() => clearField(2);
  @$pb.TagNumber(2)
  $2.Timestamp ensureEnd() => $_ensure(1);
}


const _omitFieldNames = $core.bool.fromEnvironment('protobuf.omit_field_names');
const _omitMessageNames = $core.bool.fromEnvironment('protobuf.omit_message_names');
