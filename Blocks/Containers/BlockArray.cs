
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

using OpenSharedLibrary.Collections;
using System.IO;

namespace OpenVoxelSpec.Blocks.Containers
{
    /// <summary>
    /// Block array container class
    /// </summary>
    public class BlockArray : Array3<Block>, IBlockArray
    {
        /// <summary>
        /// Block array container size byte array size
        /// </summary>
        public const int ArraySizeByteSize = sizeof(int) * 3;

        /// <summary>
        /// Block array container byte array size
        /// </summary>
        public int ByteArraySize => ArraySizeByteSize + length * Block.ByteSize;

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
        public BlockArray(BinaryReader binaryReader) : base(binaryReader.ReadInt32(), binaryReader.ReadInt32(), binaryReader.ReadInt32())
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
            binaryWriter.Write(sizeX);
            binaryWriter.Write(sizeY);
            binaryWriter.Write(sizeZ);

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

        /// <summary>
        /// Performs block operations
        /// </summary>
        public void PerformOperations(IBlockInfos blockInfos)
        {
            for (int y = 0; y < sizeY; y++)
            {
                var itemsZ = items[y];

                for (int z = 0; z < sizeZ; z++)
                {
                    var itemsX = itemsZ[z];

                    for (int x = 0; x < sizeX; x++)
                    {
                        var blockInfo = blockInfos.Get(itemsX[x]);

                        if (blockInfo.blockOperator != null)
                            blockInfo.blockOperator.Execute(x, y, z, this);
                    }
                }
            }
        }
        /// <summary>
        /// Performs block operations
        /// </summary>
        public void PerformOperations(IBlockInfos blockInfos, IBlockArray left, IBlockArray right, IBlockArray back, IBlockArray forward)
        {
            for (int y = 0; y < sizeY; y++)
            {
                var itemsZ = items[y];

                for (int z = 0; z < sizeZ; z++)
                {
                    var itemsX = itemsZ[z];

                    for (int x = 0; x < sizeX; x++)
                    {
                        var blockInfo = blockInfos.Get(itemsX[x]);

                        if (blockInfo.blockOperator != null)
                            blockInfo.blockOperator.Execute(x, y, z, this, left, right, back, forward);
                    }
                }
            }
        }
        /// <summary>
        /// Performs block operations
        /// </summary>
        public void PerformOperations(IBlockInfos blockInfos, IBlockArray left, IBlockArray right, IBlockArray down, IBlockArray up, IBlockArray back, IBlockArray forward)
        {
            for (int y = 0; y < sizeY; y++)
            {
                var itemsZ = items[y];

                for (int z = 0; z < sizeZ; z++)
                {
                    var itemsX = itemsZ[z];

                    for (int x = 0; x < sizeX; x++)
                    {
                        var blockInfo = blockInfos.Get(itemsX[x]);

                        if (blockInfo.blockOperator != null)
                            blockInfo.blockOperator.Execute(x, y, z, this, left, right, down, up, back, forward);
                    }
                }
            }
        }
    }
}
