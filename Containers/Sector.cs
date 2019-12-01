
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

using QuantumBranch.OpenSharedLibrary;
using System;
using System.IO;
using System.IO.Compression;
using System.Numerics;

namespace QuantumBranch.OpenCubicSpace.Core
{
    /// <summary>
    /// Sector container class
    /// </summary>
    public class Sector : IBlockArray, IMetadataArray, IByteArray
    {
        /// <summary>
        /// Sector container byte array size
        /// </summary>
        public const int ByteSize = OCSC.SectorVolume * Block.ByteSize;

        /// <summary>
        /// Returns number of blocks in an array
        /// </summary>
        public int Length => OCSC.SectorVolume;
        /// <summary>
        /// Sector container byte array size
        /// </summary>
        public int ByteArraySize => ByteSize;

        /// <summary>
        /// Sector block array size
        /// </summary>
        public Vector3 Size => new Vector3(OCSC.SegmentSize, OCSC.SectorHeight, OCSC.SegmentSize);
        /// <summary>
        /// Sector safe block array size (size - 1)
        /// </summary>
        public Vector3 SafeSize => new Vector3(OCSC.SegmentSize - 1, OCSC.SectorHeight - 1, OCSC.SegmentSize - 1);

        /// <summary>
        /// Sector block array
        /// </summary>
        protected readonly Block[] blocks;

        /// <summary>
        /// Creates a new sector structure instance
        /// </summary>
        public Sector()
        {
            blocks = new Block[OCSC.SectorVolume];
        }
        /// <summary>
        /// Creates a new sector structure instance
        /// </summary>
        public Sector(Block[] blocks)
        {
            if (blocks.Length != OCSC.SectorVolume)
                throw new ArgumentException("Wrong block array length", nameof(blocks));
            this.blocks = blocks;
        }
        /// <summary>
        /// Creates a new sector structure instance
        /// </summary>
        public Sector(BinaryReader binaryReader)
        {
            blocks = new Block[OCSC.SectorVolume];
            for (int i = 0; i < OCSC.SectorVolume; i++)
                blocks[i] = new Block(binaryReader.ReadUInt16());
        }

        /// <summary>
        /// Returns block value from an array without checking position boundaries
        /// </summary>
        public Block GetBlockUnsafe(int x, int y, int z)
        {
            return blocks[x + z * OCSC.SegmentSize + y * OCSC.SegmentArea];
        }
        /// <summary>
        /// Returns block value from an array without checking position boundaries
        /// </summary>
        public Block GetBlockUnsafe(Vector3 position)
        {
            return blocks[(int)position.X + (int)position.Z * OCSC.SegmentSize + (int)position.Y * OCSC.SegmentArea];
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
            if (x < 0 || x >= OCSC.SegmentSize || y < 0 || y >= OCSC.SectorHeight || z < 0 || z >= OCSC.SegmentSize)
                throw new ArgumentOutOfRangeException("x, y, or z");

            return blocks[x + z * OCSC.SegmentSize + y * OCSC.SegmentArea];
        }
        /// <summary>
        /// Returns block value from an array
        /// </summary>
        public Block GetBlock(Vector3 position)
        {
            if (position.X < 0 || position.X >= OCSC.SegmentSize || position.Y < 0 || position.Y >= OCSC.SectorHeight || position.Z < 0 || position.Z >= OCSC.SegmentSize)
                throw new ArgumentOutOfRangeException("x, y, or z");

            return blocks[(int)position.X + (int)position.Z * OCSC.SegmentSize + (int)position.Y * OCSC.SegmentArea];
        }

        /// <summary>
        /// Sets block value to an array without checking position boundaries
        /// </summary>
        public void SetBlockUnsafe(int x, int y, int z, Block block)
        {
            blocks[x + z * OCSC.SegmentSize + y * OCSC.SegmentArea] = block;
        }
        /// <summary>
        /// Sets block value to an array without checking position boundaries
        /// </summary>
        public void SetBlockUnsafe(Vector3 position, Block block)
        {
            blocks[(int)position.X + (int)position.Z * OCSC.SegmentSize + (int)position.Y * OCSC.SegmentArea] = block;
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
            if (x < 0 || x >= OCSC.SegmentSize || y < 0 || y >= OCSC.SectorHeight || z < 0 || z >= OCSC.SegmentSize)
                throw new ArgumentOutOfRangeException("x, y, or z");

            blocks[x + z * OCSC.SegmentSize + y * OCSC.SegmentArea] = block;
        }
        /// <summary>
        /// Sets block value to an array
        /// </summary>
        public void SetBlock(Vector3 position, Block block)
        {
            if (position.X < 0 || position.X >= OCSC.SegmentSize || position.Y < 0 || position.Y >= OCSC.SectorHeight || position.Z < 0 || position.Z >= OCSC.SegmentSize)
                throw new ArgumentOutOfRangeException("x, y, or z");

            blocks[(int)position.X + (int)position.Z * OCSC.SegmentSize + (int)position.Y * OCSC.SegmentArea] = block;
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
            for (int i = 0; i < OCSC.SectorVolume; i++)
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
            var compressedSegments = new byte[OCSC.SectorSegmentCount][];

            using (var decompressedStream = new MemoryStream(array))
            {
                using (var binaryWriter = new BinaryWriter(decompressedStream))
                {
                    for (int i = 0; i < OCSC.SectorSegmentCount; i++)
                    {
                        var segment = new Segment(GetFragment(index, OCSC.SegmentVolume));

                        for (int x = 0; x < OCSC.SegmentSize; x++)
                        {
                            for (int y = 0; y < OCSC.SegmentSize; y++)
                            {
                                for (int z = 0; z < OCSC.SegmentSize; z++)
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

                        index += OCSC.SegmentVolume;
                        decompressedStream.Position = 0;
                    }

                    return compressedSegments;
                }
            }
        }
    }
}
