// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace Disk
{

using global::System;
using global::FlatBuffers;

public struct DiskRoot : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_11_1(); }
  public static DiskRoot GetRootAsDiskRoot(ByteBuffer _bb) { return GetRootAsDiskRoot(_bb, new DiskRoot()); }
  public static DiskRoot GetRootAsDiskRoot(ByteBuffer _bb, DiskRoot obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DiskRoot __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string DiskId { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetDiskIdBytes() { return __p.__vector_as_span<byte>(4, 1); }
#else
  public ArraySegment<byte>? GetDiskIdBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public byte[] GetDiskIdArray() { return __p.__vector_as_array<byte>(4); }
  public long Dim { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetLong(o + __p.bb_pos) : (long)0; } }
  public Disk.Partition? Partitions(int j) { int o = __p.__offset(8); return o != 0 ? (Disk.Partition?)(new Disk.Partition()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int PartitionsLength { get { int o = __p.__offset(8); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<Disk.DiskRoot> CreateDiskRoot(FlatBufferBuilder builder,
      StringOffset diskIdOffset = default(StringOffset),
      long dim = 0,
      VectorOffset partitionsOffset = default(VectorOffset)) {
    builder.StartTable(3);
    DiskRoot.AddDim(builder, dim);
    DiskRoot.AddPartitions(builder, partitionsOffset);
    DiskRoot.AddDiskId(builder, diskIdOffset);
    return DiskRoot.EndDiskRoot(builder);
  }

  public static void StartDiskRoot(FlatBufferBuilder builder) { builder.StartTable(3); }
  public static void AddDiskId(FlatBufferBuilder builder, StringOffset diskIdOffset) { builder.AddOffset(0, diskIdOffset.Value, 0); }
  public static void AddDim(FlatBufferBuilder builder, long dim) { builder.AddLong(1, dim, 0); }
  public static void AddPartitions(FlatBufferBuilder builder, VectorOffset partitionsOffset) { builder.AddOffset(2, partitionsOffset.Value, 0); }
  public static VectorOffset CreatePartitionsVector(FlatBufferBuilder builder, Offset<Disk.Partition>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreatePartitionsVectorBlock(FlatBufferBuilder builder, Offset<Disk.Partition>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartPartitionsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<Disk.DiskRoot> EndDiskRoot(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<Disk.DiskRoot>(o);
  }
  public static void FinishDiskRootBuffer(FlatBufferBuilder builder, Offset<Disk.DiskRoot> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedDiskRootBuffer(FlatBufferBuilder builder, Offset<Disk.DiskRoot> offset) { builder.FinishSizePrefixed(offset.Value); }
};


}