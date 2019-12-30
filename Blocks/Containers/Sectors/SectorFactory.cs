
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

namespace OpenVoxelSpec.Blocks.Containers.Sectors
{
    /// <summary>
    /// Sector factory class
    /// </summary>
    public class SectorFactory : ISectorFactory<ISector>
    {
        /// <summary>
        /// Sector data byte array size
        /// </summary>
        public int ByteArraySize => Sector.ByteSize;

        /// <summary>
        /// Creates a new sector class instance
        /// </summary>
        public ISector Create()
        {
            return new Sector();
        }
        /// <summary>
        /// Creates a new sector class instance
        /// </summary>
        public ISector Create(BinaryReader binaryReader)
        {
            return new Sector(binaryReader);
        }
        /// <summary>
        /// Creates a new sector class instance
        /// </summary>
        public ISector Create(Block[][][] blocks)
        {
            return new Sector(blocks);
        }
        /// <summary>
        /// Creates a new sector class instance
        /// </summary>
        public ISector Create(Vector2 position)
        {
            return new Sector(position);
        }
        /// <summary>
        /// Creates a new sector class instance
        /// </summary>
        public ISector Create(Vector2 position, Block[][][] blocks)
        {
            return new Sector(position, blocks);
        }
    }
}

