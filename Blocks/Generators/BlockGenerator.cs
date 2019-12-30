
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

using OpenSharedLibrary.Gaming;
using OpenVoxelSpec.Blocks.Containers;
using System;

namespace OpenVoxelSpec.Blocks.Generators
{
    /// <summary>
    /// Block array generator class
    /// </summary>
    public class BlockGenerator : IBlockGenerator
    {
        /// <summary>
        /// Generator start seed
        /// </summary>
        protected readonly int seed;

        /// <summary>
        /// Creates a new block generator class instance
        /// </summary>
        public BlockGenerator(int seed = 1337)
        {
            this.seed = seed;
        }

        /// <summary>
        /// Randomly fills block array with the specified block
        /// </summary>
        public void GenerateRandom(IBlockArray array, Chance chance, Block fill)
        {
            var sizeX = array.SizeX;
            var sizeY = array.SizeY;
            var sizeZ = array.SizeZ;
            var blocks = array.GetItems();

            var random = new Random(seed);
            var chancevalue = (int)chance;

            for (int y = 0; y < sizeY; y++)
            {
                var blocksZ = blocks[y];

                for (int z = 0; z < sizeZ; z++)
                {
                    var blocksX = blocksZ[z];

                    for (int x = 0; x < sizeX; x++)
                    {
                        if (random.Next(0, 100) < chancevalue)
                            blocksX[x] = fill;
                    }
                }
            }
        }
        /// <summary>
        /// Generates grid with specified offser
        /// </summary>
        public void GenerateBlockGrid(IBlockArray array, int offset, Block fill)
        {
            var sizeX = array.SizeX;
            var sizeY = array.SizeY;
            var sizeZ = array.SizeZ;
            var blocks = array.GetItems();

            for (int y = 0; y < sizeY; y += offset)
            {
                var blocksZ = blocks[y];

                for (int z = 0; z < sizeZ; z += offset)
                {
                    var blocksX = blocksZ[z];

                    for (int x = 0; x < sizeX; x += offset)
                            blocksX[x] = fill;
                }
            }
        }
    }
}
