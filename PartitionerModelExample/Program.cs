using System;
using FlatBuffers;
using Disk;

class Partitioner
{
    private const string partitionId1 = "AAA";
    private const string partitionId2 = "BBB";
    private const long lenValue1 = 111;
    private const long lenValue2 = 222;

    // Example how to use FlatBuffers to create and read binary buffers.
    static void Main()
    {
        var builder = new FlatBufferBuilder(1);

        // Create the PartitionModel
        var partitionIdValue1 = builder.CreateString(partitionId1);
        var lengthValue1 = lenValue1;
        var partitionTypeValue1 = builder.CreateString("MBR");

        var partitionIdValue2 = builder.CreateString(partitionId2);
        var lengthValue2 = lenValue2;
        var partitionTypeValue2 = builder.CreateString("GPT");

        // Use the `CreatePartition()` helper function to create the partitions, since we set every field.
        var partitions = new Offset<Partition>[2];
        partitions[0] = Partition.CreatePartition(builder, partitionIdValue1, lengthValue1, partitionTypeValue1);
        partitions[1] = Partition.CreatePartition(builder, partitionIdValue2, lengthValue2, partitionTypeValue2);

        // Serialize the FlatBuffer data.
        var diskId = builder.CreateString("zzzzzzz-zzzzzzz-zzzzzzz");
        var partitionsVector = DiskRoot.CreatePartitionsVector(builder, partitions);

        DiskRoot.StartDiskRoot(builder);
        DiskRoot.AddDiskId(builder, diskId);
        DiskRoot.AddDim(builder, (long)1000);
        DiskRoot.AddPartitions(builder, partitionsVector);
        var disk = DiskRoot.EndDiskRoot(builder);
        DiskRoot.FinishDiskRootBuffer(builder, disk);
        builder.Finish(disk.Value); // You could also call `DiskRoot.FinishDiskRootBuffer(builder, disk);`.

        // We now have a FlatBuffer that we could store on disk or send over a network.

        // ...Code to store to disk or send over a network goes here...

        // Instead, we are going to access it right away, as if we just received it.

        var buf = builder.DataBuffer;

        // Get access to the root:
        var diskRoot = DiskRoot.GetRootAsDiskRoot(buf);
        var diskIdForTests = "CCC";

        Assert(diskRoot.DiskId.Equals(diskIdForTests, StringComparison.Ordinal), "diskRoot.DiskId", diskRoot.DiskId,
               diskId.Value.ToString());
        Assert(diskRoot.Dim == 1000, "diskRoot.Dim", diskRoot.Dim.ToString(), Convert.ToString(1000));

        // Get and test the `Partitions`
        var expectedPartitionIds = new string[] { partitionId1, partitionId2 };
        var expectedLengths = new long[] { lengthValue1, lengthValue2 };
        var expectedPartitionTypes = new string[] { "MBR", "GPT" };

        for (int i = 0; i < diskRoot.PartitionsLength; i++)
        {
            Assert(diskRoot.Partitions(i).Value.PartitionId.Equals(expectedPartitionIds[i], StringComparison.Ordinal),
                   "diskRoot.Partitions", diskRoot.Partitions(i).Value.PartitionId, expectedPartitionIds[i]);
            Assert(diskRoot.Partitions(i).Value.Length == expectedLengths[i], "disk.GetPartitions",
                   Convert.ToString(diskRoot.Partitions(i).Value.Length),
                   Convert.ToString(expectedLengths[i]));
            Assert(diskRoot.Partitions(i).Value.PartitionType.Equals(expectedPartitionTypes[i], StringComparison.Ordinal),
       "diskRoot.PartitionType", diskRoot.Partitions(i).Value.PartitionType, expectedPartitionTypes[i]);
        }

        Console.WriteLine("The FlatBuffer was successfully created and verified!");
    }

    // A helper function to handle assertions.
    static void Assert(bool assertPassed, string codeExecuted, string actualValue,
                       string expectedValue)
    {
        if (assertPassed == false)
        {
            Console.WriteLine("Assert failed! " + codeExecuted + " (" + actualValue +
                ") was not equal to " + expectedValue + ".");
            System.Environment.Exit(1);
        }
    }
}
