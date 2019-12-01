
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
using System.Numerics;

namespace OpenVoxelSpec
{
    /// <summary>
    /// Бlock array generator class
    /// </summary>
    public class BlockGenerator : IBlockGenerator
    {
        /// <summary>
        /// Generator start seed
        /// </summary>
        protected readonly int seed;
        /// <summary>
        /// Fast noise generator instance
        /// </summary>
        protected readonly FastNoise fastNoise;

        /// <summary>
        /// Creates a new block generator class instance
        /// </summary>
        public BlockGenerator(int seed = 1337)
        {
            this.seed = seed;
            fastNoise = new FastNoise(seed);
        }

        /// <summary>
        /// Randomly fills block array with the specified block
        /// </summary>
        public void GenerateRandom(IBlockArray array, Chance chance, Block fill)
        {
            var size = array.Size;
            var sizeX = (int)size.X;
            var sizeY = (int)size.Y;
            var sizeZ = (int)size.Z;

            var random = new Random(seed);
            var chancevalue = (int)chance;

            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    for (int z = 0; z < sizeZ; z++)
                    {
                        if (random.Next(0, 100) < chancevalue)
                            array.SetBlockUnsafe(x, y, z, fill);
                    }
                }
            }
        }
        /// <summary>
        /// Generates grid with specified offser
        /// </summary>
        public void GenerateBlockGrid(IBlockArray array, int offset, Block fill)
        {
            var size = array.Size;
            var sizeX = (int)size.X;
            var sizeY = (int)size.Y;
            var sizeZ = (int)size.Z;

            for (int x = 0; x < sizeX; x += offset)
            {
                for (int y = 0; y < sizeY; y += offset)
                {
                    for (int z = 0; z < sizeZ; z += offset)
                    {
                        array.SetBlockUnsafe(x, y, z, fill);
                    }
                }
            }
        }
        /// <summary>
        /// Generates surface relief block array
        /// </summary>
        public void GenerateSurface(IBlockArray array, Vector2 position, SurfaceBiome[] surfaceBiomes, Block subsurface)
        {
            var size = array.Size;
            var sizeX = (int)size.X;
            var sizeY = (int)size.Y;
            var sizeZ = (int)size.Z;

            var halfHeight = sizeY / 2;
            var quartHeight = sizeY / 4;

            for (int x = 0; x < sizeX; x++)
            {
                for (int z = 0; z < sizeZ; z++)
                {
                    var frequency = (fastNoise.GetPerlin((x + position.X) * 2, (z + position.Y) * 2) + 1.0f) / 2.0f;
                    var y = (int)(fastNoise.GetPerlin(x + position.X, z + position.Y) * frequency * quartHeight + halfHeight);

                    if (y < 0 || y >= sizeY)
                        continue;

                    array.SetBlockUnsafe(x, y, z, surfaceBiomes[0].top);

                    if (y < 1)
                        continue;

                    array.SetBlockUnsafe(x, y - 1, z, surfaceBiomes[0].bottom);

                    for (int yy = y - 2; yy >= 0; yy--)
                        array.SetBlockUnsafe(x, yy, z, subsurface);
                }
            }
        }
        /// <summary>
        /// Generates world block array
        /// </summary>
        public void GenerateWorld(IBlockArray array, Vector2 position)
        {
            var biomeInfos = new SurfaceBiome[]
            {
                new SurfaceBiome()
                {
                    top = BlockType.Debug,
                    bottom = BlockType.Debug,
                },
            };

            GenerateSurface(array, position, biomeInfos, BlockType.Debug);
        }
    }
}
