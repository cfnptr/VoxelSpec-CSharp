
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

using OpenSharedLibrary.Extensions;
using OpenVoxelSpec.Blocks.Containers.Segments;
using System;
using System.IO;
using System.IO.Compression;
using System.Numerics;

namespace OpenVoxelSpec.Blocks.Containers.Sectors
{
    /// <summary>
    /// Sector container class
    /// </summary>
    public class Sector : BlockArray, ISector
    {
        /// <summary>
        /// Sector container byte array size
        /// </summary>
        public const int ByteSize = ArraySizeByteSize + Unicon.SectorVolume * Block.ByteSize + VectorExtension.ByteSizeVector2;

        /// <summary>
        /// Sector container byte array size
        /// </summary>
        public new int ByteArraySize => ByteSize;

        /// <summary>
        /// Sector position
        /// </summary>
        public Vector2 Position { get; set; }

        // TODO:
        // Add locks to other methods
        // Add lock to variables

        /// <summary>
        /// Sector identifier
        /// </summary>
        public string ID
        {
            get { return ToString(); }
            set { throw new InvalidOperationException(); }
        }

        /// <summary>
        /// Creates a new sector class instance
        /// </summary>
        public Sector() : base(Unicon.SegmentLength, Unicon.SectorHeight, Unicon.SegmentLength) { }
        /// <summary>
        /// Creates a new sector class instance
        /// </summary>
        public Sector(Block[][][] blocks) : base(blocks) { }
        /// <summary>
        /// Creates a new sector class instance
        /// </summary>
        public Sector(Vector2 position) : base(Unicon.SegmentLength, Unicon.SectorHeight, Unicon.SegmentLength)
        {
            Position = position;
        }
        /// <summary>
        /// Creates a new sector class instance
        /// </summary>
        public Sector(Vector2 position, Block[][][] blocks) : base(blocks)
        {
            Position = position;
        }
        /// <summary>
        /// Creates a new sector class instance
        /// </summary>
        public Sector(BinaryReader binaryReader) : base(binaryReader)
        {
            Position = VectorExtension.ToVector2(binaryReader);
        }

        /// <summary>
        /// Returns true if sector is equal to the object
        /// </summary>
        public override bool Equals(object obj)
        {
            return Position.Equals(((ISector)obj).Position);
        }
        /// <summary>
        /// Returns sector hash code
        /// </summary>
        public override int GetHashCode()
        {
            return Position.GetHashCode();
        }
        /// <summary>
        /// Returns sector position string value
        /// </summary>
        public override string ToString()
        {
            return $"{(int)Position.X}_{(int)Position.Y}";
        }

        /// <summary>
        /// Compares username to the object
        /// </summary>
        public int CompareTo(object obj)
        {
            return ID.CompareTo(((ISector)obj).ID);
        }
        /// <summary>
        /// Compares two usernames
        /// </summary>
        public int CompareTo(ISector other)
        {
            return ID.CompareTo(other.ID);
        }
        /// <summary>
        /// Returns true if sectors is equal
        /// </summary>
        public bool Equals(ISector other)
        {
            return Position.Equals(other.Position);
        }

        /// <summary>
        /// Converts sector container to the byte array
        /// </summary>
        public new void ToBytes(BinaryWriter binaryWriter)
        {
            base.ToBytes(binaryWriter);
            Position.ToBytes(binaryWriter);
        }

        /// <summary>
        /// Splits sector container data to the compressed segment container data array
        /// </summary>
        public static byte[][] SectorToCompressed(ISector sector, IBlockInfos blockInfos)
        {
            var index = 0;
            var position = sector.Position;
            var array = new byte[Segment.ByteSize];
            var compressedSegments = new byte[Unicon.SectorSegmentCount][];
            using var decompressedStream = new MemoryStream(array);
            using var binaryWriter = new BinaryWriter(decompressedStream);

            for (int i = 0; i < Unicon.SectorSegmentCount; i++)
            {
                var fragment = sector.GetFragment(Unicon.SegmentLength, Unicon.SegmentLength, Unicon.SegmentLength, 0, index, 0);
                var segmentData = new Segment(new Vector3(position.X, index, position.Y), fragment);

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
                                    blockInfos.Get(left).meshType == MeshType.BlockSmart && blockInfos.Get(right).meshType == MeshType.BlockSmart &&
                                    blockInfos.Get(down).meshType == MeshType.BlockSmart && blockInfos.Get(up).meshType == MeshType.BlockSmart &&
                                    blockInfos.Get(back).meshType == MeshType.BlockSmart && blockInfos.Get(forward).meshType == MeshType.BlockSmart)
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
