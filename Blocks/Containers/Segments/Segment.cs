
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
using System;
using System.IO;
using System.IO.Compression;
using System.Numerics;

namespace OpenVoxelSpec.Blocks.Containers.Segments
{
    /// <summary>
    /// Segment container class
    /// </summary>
    public class Segment : BlockArray, ISegment
    {
        /// <summary>
        /// Segment container byte array size
        /// </summary>
        public const int ByteSize = ArraySizeByteSize + Unicon.SegmentVolume * Block.ByteSize + VectorExtension.ByteSizeVector3;

        /// <summary>
        /// Segment container byte array size
        /// </summary>
        public new int ByteArraySize => ByteSize;

        /// <summary>
        /// Segment position
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// Segment identifier
        /// </summary>
        public string ID
        {
            get { return ToString(); }
            set { throw new InvalidOperationException(); }
        }

        /// <summary>
        /// Creates a new segment class instance
        /// </summary>
        public Segment() : base(Unicon.SegmentLength, Unicon.SegmentLength, Unicon.SegmentLength)
        {
            Position = Vector3.Zero;
        }
        /// <summary>
        /// Creates a new segment class instance
        /// </summary>
        public Segment(Block[][][] blocks) : base(blocks)
        {
            Position = Vector3.Zero;
        }
        /// <summary>
        /// Creates a new segment class instance
        /// </summary>
        public Segment(Vector3 position) : base(Unicon.SegmentLength, Unicon.SegmentLength, Unicon.SegmentLength)
        {
            Position = position;
        }
        /// <summary>
        /// Creates a new segment class instance
        /// </summary>
        public Segment(Vector3 position, Block[][][] blocks) : base(blocks)
        {
            Position = position;
        }
        /// <summary>
        /// Creates a new segment class instance
        /// </summary>
        public Segment(BinaryReader binaryReader) : base(binaryReader)
        {
            Position = VectorExtension.ToVector3(binaryReader);
        }

        /// <summary>
        /// Returns true if sector is equal to the object
        /// </summary>
        public override bool Equals(object obj)
        {
            return Position.Equals(((ISegment)obj).Position);
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
            return $"{(int)Position.X}_{(int)Position.Y}_{(int)Position.Z}";
        }

        /// <summary>
        /// Compares username to the object
        /// </summary>
        public int CompareTo(object obj)
        {
            return ID.CompareTo(((ISegment)obj).ID);
        }
        /// <summary>
        /// Compares two usernames
        /// </summary>
        public int CompareTo(ISegment other)
        {
            return ID.CompareTo(other.ID);
        }
        /// <summary>
        /// Returns true if sectors is equal
        /// </summary>
        public bool Equals(ISegment other)
        {
            return Position.Equals(other.Position);
        }

        /// <summary>
        /// Converts segment container to the byte array
        /// </summary>
        public new void ToBytes(BinaryWriter binaryWriter)
        {
            base.ToBytes(binaryWriter);
            Position.ToBytes(binaryWriter);
        }

        /// <summary>
        /// Converts compressed segment byte array to the segment data container instance
        /// </summary>
        public static Segment CompressedToSegment(byte[] compressed)
        {
            var array = new byte[ByteSize];
            using var decompressedStream = new MemoryStream(array);
            using var compressedStream = new MemoryStream(compressed);
            using var gzipStream = new GZipStream(compressedStream, CompressionMode.Decompress);
            gzipStream.CopyTo(decompressedStream);
            decompressedStream.Position = 0;

            using var binaryReader = new BinaryReader(decompressedStream);
            return new Segment(binaryReader);
        }
    }
}
