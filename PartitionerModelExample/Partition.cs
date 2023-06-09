// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace Disk
{

using global::System;
using global::FlatBuffers;

public struct Partition : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_11_1(); }
  public static Partition GetRootAsPartition(ByteBuffer _bb) { return GetRootAsPartition(_bb, new Partition()); }
  public static Partition GetRootAsPartition(ByteBuffer _bb, Partition obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public Partition __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string PartitionId { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetPartitionIdBytes() { return __p.__vector_as_span<byte>(4, 1); }
#else
  public ArraySegment<byte>? GetPartitionIdBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public byte[] GetPartitionIdArray() { return __p.__vector_as_array<byte>(4); }
  public long Length { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetLong(o + __p.bb_pos) : (long)0; } }
  public string PartitionType { get { int o = __p.__offset(8); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetPartitionTypeBytes() { return __p.__vector_as_span<byte>(8, 1); }
#else
  public ArraySegment<byte>? GetPartitionTypeBytes() { return __p.__vector_as_arraysegment(8); }
#endif
  public byte[] GetPartitionTypeArray() { return __p.__vector_as_array<byte>(8); }

  public static Offset<Disk.Partition> CreatePartition(FlatBufferBuilder builder,
      StringOffset partitionIdOffset = default(StringOffset),
      long length = 0,
      StringOffset partitionTypeOffset = default(StringOffset)) {
    builder.StartTable(3);
    Partition.AddLength(builder, length);
    Partition.AddPartitionType(builder, partitionTypeOffset);
    Partition.AddPartitionId(builder, partitionIdOffset);
    return Partition.EndPartition(builder);
  }

  public static void StartPartition(FlatBufferBuilder builder) { builder.StartTable(3); }
  public static void AddPartitionId(FlatBufferBuilder builder, StringOffset partitionIdOffset) { builder.AddOffset(0, partitionIdOffset.Value, 0); }
  public static void AddLength(FlatBufferBuilder builder, long length) { builder.AddLong(1, length, 0); }
  public static void AddPartitionType(FlatBufferBuilder builder, StringOffset partitionTypeOffset) { builder.AddOffset(2, partitionTypeOffset.Value, 0); }
  public static Offset<Disk.Partition> EndPartition(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<Disk.Partition>(o);
  }
};


}
