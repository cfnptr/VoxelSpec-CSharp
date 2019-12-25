﻿
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
        /// <summary>
        /// Generates surface relief block array
        /// </summary>
        public void GenerateSurface(IBlockArray array, Vector2 position, SurfaceInfo info, SurfaceBiome[] surfBiomes)
        {
            var sizeX = array.SizeX;
            var sizeY = array.SizeY;
            var sizeZ = array.SizeZ;

            var halfHeight = sizeY / 2;
            var quartHeight = sizeY / 4;

            var fastNoise = new FastNoise(seed);
            fastNoise.SetCellularReturnType(FastNoise.CellularReturnType.Distance);

            for (int z = 0; z < sizeZ; z++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    fastNoise.SetFrequency(info.surfNoiseFactor);
                    var surfNoise = fastNoise.GetSimplex(x + position.X, z + position.Y);

                    fastNoise.SetFrequency(info.surfFrequencyFactor);
                    var surfFrequency = (fastNoise.GetSimplex(x + position.X, z + position.Y) + 1.0f) / 2.0f;

                    var y = (int)(surfNoise * surfFrequency * quartHeight + halfHeight);

                    if (y < 2 || y >= sizeY)
                        throw new Exception("Block array Y dimension is too small");

                    if (y < halfHeight)
                    {
                        fastNoise.SetFrequency(info.subsurfNoiseFactor);

                        if (fastNoise.GetCellular(x + position.X, y, z + position.Y) <= info.subsurfNoiseCutout)
                            array.Set(x, y, z, info.sandBlock);
                        if (fastNoise.GetCellular(x + position.X, y - 1, z + position.Y) <= info.subsurfNoiseCutout)
                            array.Set(x, y - 1, z, info.sandBlock);

                        if (fastNoise.GetCellular(x + position.X, y - 2, z + position.Y) <= info.subsurfNoiseCutout)
                        {
                            if ((int)(surfNoise * 100000000) % 2 == 0)
                                array.Set(x, y - 2, z, info.sandBlock);
                            else
                                array.Set(x, y - 2, z, info.stoneBlock);
                        }
                    }
                    else
                    {
                        fastNoise.SetFrequency(info.surfBiomeNoiseFactor);
                        var biomeNoise = fastNoise.GetSimplex(x + position.X, z + position.Y);
                        var biome = surfBiomes[(int)(surfBiomes.Length * ((biomeNoise + 1.0f) / 2.0f))];

                        Block topBlock, bottomBlock;

                        if (biome.useMixing)
                        {
                            topBlock = (int)(biomeNoise * 100000000) % biome.mixingChance == 0 ? biome.mixTop : biome.top;
                            bottomBlock = (int)(biomeNoise * 100000000) % (biome.mixingChance * 2) / 2 == 0 ? biome.mixBottom : biome.bottom;
                        }
                        else
                        {
                            topBlock = biome.top;
                            bottomBlock = biome.bottom;
                        }

                        fastNoise.SetFrequency(info.subsurfNoiseFactor);

                        if (fastNoise.GetCellular(x + position.X, y, z + position.Y) <= info.subsurfNoiseCutout)
                        {
                            array.Set(x, y, z, topBlock);

                            try
                            {
                                var surfStructure = biome.surfStructures[(int)((biomeNoise + 1.0f) * 50000000) % biome.surfStructures.Length];
                                if ((int)(surfNoise * 100000000) % surfStructure.chance == 0)
                                    surfStructure.structure.CopyFragmentTo(array, x, y + 1, z);
                            }
                            catch { }
                        }
                            
                        if (fastNoise.GetCellular(x + position.X, y - 1, z + position.Y) <= info.subsurfNoiseCutout)
                            array.Set(x, y - 1, z, bottomBlock);

                        if (fastNoise.GetCellular(x + position.X, y - 2, z + position.Y) <= info.subsurfNoiseCutout)
                        {
                            if ((int)(biomeNoise * 100000000) % 2 == 0)
                                array.Set(x, y - 2, z, bottomBlock);
                            else
                                array.Set(x, y - 2, z, info.stoneBlock);
                        }
                    }

                    fastNoise.SetFrequency(info.subsurfNoiseFactor);
                    var lastEmpty = true;

                    for (int yy = y - 3; yy >= 0; yy--)
                    {
                        var subsurfBiomeNoise = fastNoise.GetCellular(x + position.X, yy, z + position.Y);

                        if (subsurfBiomeNoise > info.subsurfNoiseCutout)
                        {
                            if (!lastEmpty)
                            {
                                try
                                {
                                    if ((int)(surfNoise * 100000000) % 8 == 0)
                                    {
                                        var stalactite = info.stalactites[(int)(subsurfBiomeNoise * 100000000) % info.stalactites.Length];
                                        stalactite.CopyFragmentTo(array, x, yy, z);
                                    }
                                }
                                catch { }
                                lastEmpty = true;
                            }
                            
                            continue;
                        }
                            
                        if (lastEmpty && (int)(subsurfBiomeNoise * 100000000) % 4 == 0)
                            array.Set(x, yy, z, info.cobbleBlock);
                        else
                            array.Set(x, yy, z, info.stoneBlock);

                        lastEmpty = false;
                    }

                    array.Set(x, 0, z, info.coreBlock);

                    if ((int)(surfNoise * 100000000) % 4 == 0)
                        array.Set(x, 1, z, info.coreBlock);
                }
            }
        }
        /// <summary>
        /// Generates world block array
        /// </summary>
        public void GenerateWorld(IBlockArray array, Vector2 position)
        {
            GenerateSurface(array, position, SurfaceInfo.Info, SurfaceBiome.Biomes);
        }
    }
}
