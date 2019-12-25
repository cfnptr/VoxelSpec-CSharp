
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
using System.IO;

namespace OpenVoxelSpec
{
    /// <summary>
    /// Block array container class
    /// </summary>
    public class BlockArray : Array3<Block>, IBlockArray
    {
        /// <summary>
        /// Block array container byte array size
        /// </summary>
        public int ByteArraySize => length * Block.ByteSize;

        /// <summary>
        /// Creates a new block array container class instance
        /// </summary>
        public BlockArray(int sizeX, int sizeY, int sizeZ) : base(sizeX, sizeY, sizeZ) { }
        /// <summary>
        /// Creates a new block array container class instance
        /// </summary>
        public BlockArray(Block[][][] blocks) : base(blocks) { }
        /// <summary>
        /// Creates a new block array container class instance
        /// </summary>
        public BlockArray(int sizeX, int sizeY, int sizeZ, BinaryReader binaryReader) : base(sizeX, sizeY, sizeZ)
        {
            for (int y = 0; y < sizeY; y++)
            {
                var itemsZ = items[y];

                for (int z = 0; z < sizeZ; z++)
                {
                    var itemsX = itemsZ[z];

                    for (int x = 0; x < sizeX; x++)
                        itemsX[x] = new Block(binaryReader.ReadUInt16());
                }
            }    
        }

        /// <summary>
        /// Converts block array container to the byte array
        /// </summary>
        public void ToBytes(BinaryWriter binaryWriter)
        {
            for (int y = 0; y < sizeY; y++)
            {
                var itemsZ = items[y];

                for (int z = 0; z < sizeZ; z++)
                {
                    var itemsX = itemsZ[z];

                    for (int x = 0; x < sizeX; x++)
                        binaryWriter.Write(itemsX[x]);
                }
            } 
        }
    }
}
