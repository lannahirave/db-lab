//
//  Generated code. Do not modify.
//  source: db.proto
//
// @dart = 2.12

// ignore_for_file: annotate_overrides, camel_case_types, comment_references
// ignore_for_file: constant_identifier_names, library_prefixes
// ignore_for_file: non_constant_identifier_names, prefer_final_fields
// ignore_for_file: unnecessary_import, unnecessary_this, unused_import

import 'dart:async' as $async;
import 'dart:core' as $core;

import 'package:grpc/service_api.dart' as $grpc;
import 'package:protobuf/protobuf.dart' as $pb;

import 'db.pb.dart' as $1;
import 'google/protobuf/empty.pb.dart' as $0;

export 'db.pb.dart';

@$pb.GrpcServiceName('db.DB')
class DBClient extends $grpc.Client {
  static final _$getTables = $grpc.ClientMethod<$0.Empty, $1.GetTablesResponse>(
      '/db.DB/GetTables',
      ($0.Empty value) => value.writeToBuffer(),
      ($core.List<$core.int> value) => $1.GetTablesResponse.fromBuffer(value));
  static final _$createTable = $grpc.ClientMethod<$1.CreateTableRequest, $1.OperationResponse>(
      '/db.DB/CreateTable',
      ($1.CreateTableRequest value) => value.writeToBuffer(),
      ($core.List<$core.int> value) => $1.OperationResponse.fromBuffer(value));
  static final _$deleteTable = $grpc.ClientMethod<$1.DeleteTableRequest, $1.OperationResponse>(
      '/db.DB/DeleteTable',
      ($1.DeleteTableRequest value) => value.writeToBuffer(),
      ($core.List<$core.int> value) => $1.OperationResponse.fromBuffer(value));
  static final _$addRow = $grpc.ClientMethod<$1.AddRowRequest, $1.RowOperationResponse>(
      '/db.DB/AddRow',
      ($1.AddRowRequest value) => value.writeToBuffer(),
      ($core.List<$core.int> value) => $1.RowOperationResponse.fromBuffer(value));
  static final _$deleteRow = $grpc.ClientMethod<$1.DeleteRowRequest, $1.OperationResponse>(
      '/db.DB/DeleteRow',
      ($1.DeleteRowRequest value) => value.writeToBuffer(),
      ($core.List<$core.int> value) => $1.OperationResponse.fromBuffer(value));
  static final _$updateRow = $grpc.ClientMethod<$1.UpdateRowRequest, $1.OperationResponse>(
      '/db.DB/UpdateRow',
      ($1.UpdateRowRequest value) => value.writeToBuffer(),
      ($core.List<$core.int> value) => $1.OperationResponse.fromBuffer(value));
  static final _$getRows = $grpc.ClientMethod<$1.GetRowsRequest, $1.GetRowsResponse>(
      '/db.DB/GetRows',
      ($1.GetRowsRequest value) => value.writeToBuffer(),
      ($core.List<$core.int> value) => $1.GetRowsResponse.fromBuffer(value));
  static final _$getColumns = $grpc.ClientMethod<$1.GetColumnsRequest, $1.GetColumnsResponse>(
      '/db.DB/GetColumns',
      ($1.GetColumnsRequest value) => value.writeToBuffer(),
      ($core.List<$core.int> value) => $1.GetColumnsResponse.fromBuffer(value));

  DBClient($grpc.ClientChannel channel,
      {$grpc.CallOptions? options,
      $core.Iterable<$grpc.ClientInterceptor>? interceptors})
      : super(channel, options: options,
        interceptors: interceptors);

  $grpc.ResponseFuture<$1.GetTablesResponse> getTables($0.Empty request, {$grpc.CallOptions? options}) {
    return $createUnaryCall(_$getTables, request, options: options);
  }

  $grpc.ResponseFuture<$1.OperationResponse> createTable($1.CreateTableRequest request, {$grpc.CallOptions? options}) {
    return $createUnaryCall(_$createTable, request, options: options);
  }

  $grpc.ResponseFuture<$1.OperationResponse> deleteTable($1.DeleteTableRequest request, {$grpc.CallOptions? options}) {
    return $createUnaryCall(_$deleteTable, request, options: options);
  }

  $grpc.ResponseFuture<$1.RowOperationResponse> addRow($1.AddRowRequest request, {$grpc.CallOptions? options}) {
    return $createUnaryCall(_$addRow, request, options: options);
  }

  $grpc.ResponseFuture<$1.OperationResponse> deleteRow($1.DeleteRowRequest request, {$grpc.CallOptions? options}) {
    return $createUnaryCall(_$deleteRow, request, options: options);
  }

  $grpc.ResponseFuture<$1.OperationResponse> updateRow($1.UpdateRowRequest request, {$grpc.CallOptions? options}) {
    return $createUnaryCall(_$updateRow, request, options: options);
  }

  $grpc.ResponseFuture<$1.GetRowsResponse> getRows($1.GetRowsRequest request, {$grpc.CallOptions? options}) {
    return $createUnaryCall(_$getRows, request, options: options);
  }

  $grpc.ResponseFuture<$1.GetColumnsResponse> getColumns($1.GetColumnsRequest request, {$grpc.CallOptions? options}) {
    return $createUnaryCall(_$getColumns, request, options: options);
  }
}

@$pb.GrpcServiceName('db.DB')
abstract class DBServiceBase extends $grpc.Service {
  $core.String get $name => 'db.DB';

  DBServiceBase() {
    $addMethod($grpc.ServiceMethod<$0.Empty, $1.GetTablesResponse>(
        'GetTables',
        getTables_Pre,
        false,
        false,
        ($core.List<$core.int> value) => $0.Empty.fromBuffer(value),
        ($1.GetTablesResponse value) => value.writeToBuffer()));
    $addMethod($grpc.ServiceMethod<$1.CreateTableRequest, $1.OperationResponse>(
        'CreateTable',
        createTable_Pre,
        false,
        false,
        ($core.List<$core.int> value) => $1.CreateTableRequest.fromBuffer(value),
        ($1.OperationResponse value) => value.writeToBuffer()));
    $addMethod($grpc.ServiceMethod<$1.DeleteTableRequest, $1.OperationResponse>(
        'DeleteTable',
        deleteTable_Pre,
        false,
        false,
        ($core.List<$core.int> value) => $1.DeleteTableRequest.fromBuffer(value),
        ($1.OperationResponse value) => value.writeToBuffer()));
    $addMethod($grpc.ServiceMethod<$1.AddRowRequest, $1.RowOperationResponse>(
        'AddRow',
        addRow_Pre,
        false,
        false,
        ($core.List<$core.int> value) => $1.AddRowRequest.fromBuffer(value),
        ($1.RowOperationResponse value) => value.writeToBuffer()));
    $addMethod($grpc.ServiceMethod<$1.DeleteRowRequest, $1.OperationResponse>(
        'DeleteRow',
        deleteRow_Pre,
        false,
        false,
        ($core.List<$core.int> value) => $1.DeleteRowRequest.fromBuffer(value),
        ($1.OperationResponse value) => value.writeToBuffer()));
    $addMethod($grpc.ServiceMethod<$1.UpdateRowRequest, $1.OperationResponse>(
        'UpdateRow',
        updateRow_Pre,
        false,
        false,
        ($core.List<$core.int> value) => $1.UpdateRowRequest.fromBuffer(value),
        ($1.OperationResponse value) => value.writeToBuffer()));
    $addMethod($grpc.ServiceMethod<$1.GetRowsRequest, $1.GetRowsResponse>(
        'GetRows',
        getRows_Pre,
        false,
        false,
        ($core.List<$core.int> value) => $1.GetRowsRequest.fromBuffer(value),
        ($1.GetRowsResponse value) => value.writeToBuffer()));
    $addMethod($grpc.ServiceMethod<$1.GetColumnsRequest, $1.GetColumnsResponse>(
        'GetColumns',
        getColumns_Pre,
        false,
        false,
        ($core.List<$core.int> value) => $1.GetColumnsRequest.fromBuffer(value),
        ($1.GetColumnsResponse value) => value.writeToBuffer()));
  }

  $async.Future<$1.GetTablesResponse> getTables_Pre($grpc.ServiceCall call, $async.Future<$0.Empty> request) async {
    return getTables(call, await request);
  }

  $async.Future<$1.OperationResponse> createTable_Pre($grpc.ServiceCall call, $async.Future<$1.CreateTableRequest> request) async {
    return createTable(call, await request);
  }

  $async.Future<$1.OperationResponse> deleteTable_Pre($grpc.ServiceCall call, $async.Future<$1.DeleteTableRequest> request) async {
    return deleteTable(call, await request);
  }

  $async.Future<$1.RowOperationResponse> addRow_Pre($grpc.ServiceCall call, $async.Future<$1.AddRowRequest> request) async {
    return addRow(call, await request);
  }

  $async.Future<$1.OperationResponse> deleteRow_Pre($grpc.ServiceCall call, $async.Future<$1.DeleteRowRequest> request) async {
    return deleteRow(call, await request);
  }

  $async.Future<$1.OperationResponse> updateRow_Pre($grpc.ServiceCall call, $async.Future<$1.UpdateRowRequest> request) async {
    return updateRow(call, await request);
  }

  $async.Future<$1.GetRowsResponse> getRows_Pre($grpc.ServiceCall call, $async.Future<$1.GetRowsRequest> request) async {
    return getRows(call, await request);
  }

  $async.Future<$1.GetColumnsResponse> getColumns_Pre($grpc.ServiceCall call, $async.Future<$1.GetColumnsRequest> request) async {
    return getColumns(call, await request);
  }

  $async.Future<$1.GetTablesResponse> getTables($grpc.ServiceCall call, $0.Empty request);
  $async.Future<$1.OperationResponse> createTable($grpc.ServiceCall call, $1.CreateTableRequest request);
  $async.Future<$1.OperationResponse> deleteTable($grpc.ServiceCall call, $1.DeleteTableRequest request);
  $async.Future<$1.RowOperationResponse> addRow($grpc.ServiceCall call, $1.AddRowRequest request);
  $async.Future<$1.OperationResponse> deleteRow($grpc.ServiceCall call, $1.DeleteRowRequest request);
  $async.Future<$1.OperationResponse> updateRow($grpc.ServiceCall call, $1.UpdateRowRequest request);
  $async.Future<$1.GetRowsResponse> getRows($grpc.ServiceCall call, $1.GetRowsRequest request);
  $async.Future<$1.GetColumnsResponse> getColumns($grpc.ServiceCall call, $1.GetColumnsRequest request);
}
