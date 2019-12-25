
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
    /// Segment data container class
    /// </summary>
    public sealed class SegmentData : BlockArray
    {
        /// <summary>
        /// Segment data container byte array size
        /// </summary>
        public const int ByteSize = Unicon.SegmentVolume * Block.ByteSize;

        /// <summary>
        /// Creates a new segment data container class instance
        /// </summary>
        public SegmentData() : base(Unicon.SegmentLength, Unicon.SegmentLength, Unicon.SegmentLength) { }
        /// <summary>
        /// Creates a new segment data container class instance
        /// </summary>
        public SegmentData(Block[][][] blocks) : base(blocks) { }
        /// <summary>
        /// Creates a new segment data container class instance
        /// </summary>
        public SegmentData(BinaryReader binaryReader) : base(Unicon.SegmentLength, Unicon.SegmentLength, Unicon.SegmentLength, binaryReader) { }

        /// <summary>
        /// Converts compressed segment byte array to the segment data container instance
        /// </summary>
        public static SegmentData ToSegment(byte[] bytes)
        {
            var array = new byte[ByteSize];

            using (var decompressedStream = new MemoryStream(array))
            {
                using (var compressedStream = new MemoryStream(bytes))
                {
                    using (var gzipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                        gzipStream.CopyTo(decompressedStream);
                }

                decompressedStream.Position = 0;

                using (var binaryReader = new BinaryReader(decompressedStream))
                    return new SegmentData(binaryReader);
            }
        }
    }
}
