
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

using OpenSharedLibrary;
using System;
using System.IO;
using System.IO.Compression;
using System.Numerics;

namespace OpenVoxelSpec
{
    /// <summary>
    /// Sector container class
    /// </summary>
    public class Sector : IBlockArray, IMetadataArray, IByteArray
    {
        /// <summary>
        /// Sector container byte array size
        /// </summary>
        public const int ByteSize = Unicon.SectorVolume * Block.ByteSize;

        /// <summary>
        /// Returns number of blocks in an array
        /// </summary>
        public int Length => Unicon.SectorVolume;
        /// <summary>
        /// Sector container byte array size
        /// </summary>
        public int ByteArraySize => ByteSize;

        /// <summary>
        /// Sector block array size
        /// </summary>
        public Vector3 Size => new Vector3(Unicon.SegmentSize, Unicon.SectorHeight, Unicon.SegmentSize);
        /// <summary>
        /// Sector safe block array size (size - 1)
        /// </summary>
        public Vector3 SafeSize => new Vector3(Unicon.SegmentSize - 1, Unicon.SectorHeight - 1, Unicon.SegmentSize - 1);

        /// <summary>
        /// Sector block array
        /// </summary>
        protected readonly Block[] blocks;

        /// <summary>
        /// Creates a new sector structure instance
        /// </summary>
        public Sector()
        {
            blocks = new Block[Unicon.SectorVolume];
        }
        /// <summary>
        /// Creates a new sector structure instance
        /// </summary>
        public Sector(Block[] blocks)
        {
            if (blocks.Length != Unicon.SectorVolume)
                throw new ArgumentException("Wrong block array length", nameof(blocks));
            this.blocks = blocks;
        }
        /// <summary>
        /// Creates a new sector structure instance
        /// </summary>
        public Sector(BinaryReader binaryReader)
        {
            blocks = new Block[Unicon.SectorVolume];
            for (int i = 0; i < Unicon.SectorVolume; i++)
                blocks[i] = new Block(binaryReader.ReadUInt16());
        }

        /// <summary>
        /// Returns block value from an array without checking position boundaries
        /// </summary>
        public Block GetBlockUnsafe(int x, int y, int z)
        {
            return blocks[x + z * Unicon.SegmentSize + y * Unicon.SegmentArea];
        }
        /// <summary>
        /// Returns block value from an array without checking position boundaries
        /// </summary>
        public Block GetBlockUnsafe(Vector3 position)
        {
            return blocks[(int)position.X + (int)position.Z * Unicon.SegmentSize + (int)position.Y * Unicon.SegmentArea];
        }

        /// <summary>
        /// Returns block value from an array
        /// </summary>
        public Block GetBlock(int index)
        {
            return blocks[index];
        }
        /// <summary>
        /// Returns block value from an array
        /// </summary>
        public Block GetBlock(int x, int y, int z)
        {
            if (x < 0 || x >= Unicon.SegmentSize || y < 0 || y >= Unicon.SectorHeight || z < 0 || z >= Unicon.SegmentSize)
                throw new ArgumentOutOfRangeException("x, y, or z");

            return blocks[x + z * Unicon.SegmentSize + y * Unicon.SegmentArea];
        }
        /// <summary>
        /// Returns block value from an array
        /// </summary>
        public Block GetBlock(Vector3 position)
        {
            if (position.X < 0 || position.X >= Unicon.SegmentSize || position.Y < 0 || position.Y >= Unicon.SectorHeight || position.Z < 0 || position.Z >= Unicon.SegmentSize)
                throw new ArgumentOutOfRangeException("x, y, or z");

            return blocks[(int)position.X + (int)position.Z * Unicon.SegmentSize + (int)position.Y * Unicon.SegmentArea];
        }

        /// <summary>
        /// Sets block value to an array without checking position boundaries
        /// </summary>
        public void SetBlockUnsafe(int x, int y, int z, Block block)
        {
            blocks[x + z * Unicon.SegmentSize + y * Unicon.SegmentArea] = block;
        }
        /// <summary>
        /// Sets block value to an array without checking position boundaries
        /// </summary>
        public void SetBlockUnsafe(Vector3 position, Block block)
        {
            blocks[(int)position.X + (int)position.Z * Unicon.SegmentSize + (int)position.Y * Unicon.SegmentArea] = block;
        }

        /// <summary>
        /// Sets block value to an array
        /// </summary>
        public void SetBlock(int index, Block block)
        {
            blocks[index] = block;
        }
        /// <summary>
        /// Sets block value to an array
        /// </summary>
        public void SetBlock(int x, int y, int z, Block block)
        {
            if (x < 0 || x >= Unicon.SegmentSize || y < 0 || y >= Unicon.SectorHeight || z < 0 || z >= Unicon.SegmentSize)
                throw new ArgumentOutOfRangeException("x, y, or z");

            blocks[x + z * Unicon.SegmentSize + y * Unicon.SegmentArea] = block;
        }
        /// <summary>
        /// Sets block value to an array
        /// </summary>
        public void SetBlock(Vector3 position, Block block)
        {
            if (position.X < 0 || position.X >= Unicon.SegmentSize || position.Y < 0 || position.Y >= Unicon.SectorHeight || position.Z < 0 || position.Z >= Unicon.SegmentSize)
                throw new ArgumentOutOfRangeException("x, y, or z");

            blocks[(int)position.X + (int)position.Z * Unicon.SegmentSize + (int)position.Y * Unicon.SegmentArea] = block;
        }

        /// <summary>
        /// Returns fragment from a block array
        /// </summary>
        public Block[] GetFragment(int index, int count)
        {
            var blocks = new Block[count];
            Array.Copy(this.blocks, index, blocks, 0, count);
            return blocks;
        }

        /// <summary>
        /// Converts sector container to the byte array
        /// </summary>
        public void ToBytes(BinaryWriter binaryWriter)
        {
            for (int i = 0; i < Unicon.SectorVolume; i++)
                binaryWriter.Write(blocks[i]);
        }

        /// <summary>
        /// Returns block array
        /// </summary>
        public Block[] ToBlockArray()
        {
            return blocks;
        }

        /// <summary>
        /// Splits sector to the compressed segment array
        /// </summary>
        public byte[][] ToCompressedSegments()
        {
            var index = 0;
            var array = new byte[Segment.ByteSize];
            var compressedSegments = new byte[Unicon.SectorSegmentCount][];

            using (var decompressedStream = new MemoryStream(array))
            {
                using (var binaryWriter = new BinaryWriter(decompressedStream))
                {
                    for (int i = 0; i < Unicon.SectorSegmentCount; i++)
                    {
                        var segment = new Segment(GetFragment(index, Unicon.SegmentVolume));

                        for (int x = 0; x < Unicon.SegmentSize; x++)
                        {
                            for (int y = 0; y < Unicon.SegmentSize; y++)
                            {
                                for (int z = 0; z < Unicon.SegmentSize; z++)
                                {
                                    try
                                    {
                                        if (segment.GetBlock(x, y, z) != BlockType.Unknown && segment.GetBlock(x - 1, y, z) * segment.GetBlock(x + 1, y, z) * segment.GetBlock(x, y - 1, z) * segment.GetBlock(x, y + 1, z) * segment.GetBlock(x, y, z - 1) * segment.GetBlock(x, y, z + 1) != 0)
                                            segment.SetBlock(x, y, z, BlockType.Unknown);
                                    }
                                    catch { }
                                }
                            }
                        }

                        segment.ToBytes(binaryWriter);
                        decompressedStream.Position = 0;

                        using (var compressedStream = new MemoryStream())
                        {
                            using (var gzipStream = new GZipStream(compressedStream, CompressionMode.Compress))
                                decompressedStream.CopyTo(gzipStream);

                            compressedSegments[i] = compressedStream.ToArray();
                        }

                        index += Unicon.SegmentVolume;
                        decompressedStream.Position = 0;
                    }

                    return compressedSegments;
                }
            }
        }
    }
}
