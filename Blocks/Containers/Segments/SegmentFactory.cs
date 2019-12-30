
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
using System.Numerics;

namespace OpenVoxelSpec.Blocks.Containers.Segments
{
    /// <summary>
    /// Segment value factory class
    /// </summary>
    public class SegmentFactory : ISegmentFactory<ISegment>
    {
        /// <summary>
        /// Segment data byte array size
        /// </summary>
        public int ByteArraySize => Segment.ByteSize;

        /// <summary>
        /// Creates a new segment class instance
        /// </summary>
        public ISegment Create()
        {
            return new Segment();
        }
        /// <summary>
        /// Creates a new segment class instance
        /// </summary>
        public ISegment Create(BinaryReader binaryReader)
        {
            return new Segment(binaryReader);
        }
        /// <summary>
        /// Creates a new segment class instance
        /// </summary>
        public ISegment Create(Block[][][] blocks)
        {
            return new Segment(blocks);
        }
        /// <summary>
        /// Creates a new segment class instance
        /// </summary>
        public ISegment Create(Vector3 position)
        {
            return new Segment(position);
        }
        /// <summary>
        /// Creates a new segment class instance
        /// </summary>
        public ISegment Create(Vector3 position, Block[][][] blocks)
        {
            return new Segment(position, blocks);
        }
    }
}

