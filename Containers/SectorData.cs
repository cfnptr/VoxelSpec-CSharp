
// Copyright 2019 Nikita Fediuchin (QuantumBranch)
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.IO;
using System.IO.Compression;

namespace OpenVoxelSpec
{
    /// <summary>
    /// Sector data container class
    /// </summary>
    public sealed class SectorData : BlockArray
    {
        /// <summary>
        /// Sector data container byte array size
        /// </summary>
        public const int ByteSize = Unicon.SectorVolume * Block.ByteSize;

        /// <summary>
        /// Creates a new sector data container class instance
        /// </summary>
        public SectorData() : base(Unicon.SegmentLength, Unicon.SectorHeight, Unicon.SegmentLength) { }
        /// <summary>
        /// Creates a new sector data container class instance
        /// </summary>
        public SectorData(Block[][][] blocks) : base(blocks) { }
        /// <summary>
        /// Creates a new sector data container class instance
        /// </summary>
        public SectorData(BinaryReader binaryReader) : base(Unicon.SegmentLength, Unicon.SectorHeight, Unicon.SegmentLength, binaryReader) { }

        /// <summary>
        /// Splits sector container data to the compressed segment container data array
        /// </summary>
        public byte[][] ToCompressedSegments(IBlockInfoArray blockInfoArray)
        {
            var index = 0;
            var array = new byte[SegmentData.ByteSize];
            var compressedSegments = new byte[Unicon.SectorSegmentCount][];

            using (var decompressedStream = new MemoryStream(array))
            {
                using (var binaryWriter = new BinaryWriter(decompressedStream))
                {
                    for (int i = 0; i < Unicon.SectorSegmentCount; i++)
                    {
                        var fragment = GetFragment(Unicon.SegmentLength, Unicon.SegmentLength, Unicon.SegmentLength, 0, index, 0);
                        var segmentData = new SegmentData(fragment);

                        for (int x = 0; x < Unicon.SegmentLength; x++)
                        {
                            for (int y = 0; y < Unicon.SegmentLength; y++)
                            {
                                for (int z = 0; z < Unicon.SegmentLength; z++)
                                {
                                    try
                                    {
                                        var left = segmentData.Get(x - 1, y, z);
                                        var right = segmentData.Get(x + 1, y, z);
                                        var down = segmentData.Get(x, y - 1, z);
                                        var up = segmentData.Get(x, y + 1, z);
                                        var back = segmentData.Get(x, y, z - 1);
                                        var forward = segmentData.Get(x, y, z + 1);

                                        if (segmentData.Get(x, y, z) != BlockType.Unknown && left * right * down * up * back * forward != 0 &&
                                            blockInfoArray.GetBlockInfo(left).meshType == BlockMeshType.BlockSmart && blockInfoArray.GetBlockInfo(right).meshType == BlockMeshType.BlockSmart &&
                                            blockInfoArray.GetBlockInfo(down).meshType == BlockMeshType.BlockSmart && blockInfoArray.GetBlockInfo(up).meshType == BlockMeshType.BlockSmart &&
                                            blockInfoArray.GetBlockInfo(back).meshType == BlockMeshType.BlockSmart && blockInfoArray.GetBlockInfo(forward).meshType == BlockMeshType.BlockSmart)
                                            segmentData.Set(x, y, z, BlockType.Unknown);
                                    }
                                    catch { }
                                }
                            }
                        }

                        segmentData.ToBytes(binaryWriter);
                        decompressedStream.Position = 0;

                        using (var compressedStream = new MemoryStream())
                        {
                            using (var gzipStream = new GZipStream(compressedStream, CompressionMode.Compress))
                                decompressedStream.CopyTo(gzipStream);

                            compressedSegments[i] = compressedStream.ToArray();
                        }

                        index += Unicon.SegmentLength;
                        decompressedStream.Position = 0;
                    }

                    return compressedSegments;
                }
            }
        }
    }
}
