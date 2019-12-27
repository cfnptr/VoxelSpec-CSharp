
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

using OpenVoxelSpec.World.Containers;

namespace OpenVoxelSpec.World.Generator.Surface
{
    /// <summary>
    /// Surface biome information container structure
    /// </summary>
    public struct SurfaceBiome
    {
        /// <summary>
        /// Use generator surface mixing
        /// </summary>
        public bool useMixing;
        /// <summary>
        /// Surface biome block mixing chance
        /// </summary>
        public int mixingChance;

        /// <summary>
        /// Surface biome top block
        /// </summary>
        public Block top;
        /// <summary>
        /// Surface biome bottom block
        /// </summary>
        public Block bottom;
        /// <summary>
        /// Surface biome mix top block
        /// </summary>
        public Block mixTop;
        /// <summary>
        /// Surface biome mix bottom block
        /// </summary>
        public Block mixBottom;

        /// <summary>
        /// Surface structure array
        /// </summary>
        public SurfaceStruct[] surfStructures;

        public static readonly IFragment PlantGrass = new Fragment(0, 0, 0, new Block[1][][] { new Block[1][] { new Block[1] { BlockType.PlantGrass, }, }, });
        public static readonly IFragment PlantGrassShort = new Fragment(0, 0, 0, new Block[1][][] { new Block[1][] { new Block[1] { BlockType.PlantGrassShort, }, }, });
        public static readonly IFragment PlantFern = new Fragment(0, 0, 0, new Block[1][][] { new Block[1][] { new Block[1] { BlockType.PlantFern, }, }, });
        public static readonly IFragment Sand28 = new Fragment(0, 0, 0, new Block[1][][] { new Block[1][] { new Block[1] { BlockType.Sand28, }, }, });
        public static readonly IFragment Sand18 = new Fragment(0, 0, 0, new Block[1][][] { new Block[1][] { new Block[1] { BlockType.Sand18, }, }, });
        public static readonly IFragment Snow28 = new Fragment(0, 0, 0, new Block[1][][] { new Block[1][] { new Block[1] { BlockType.Snow28, }, }, });
        public static readonly IFragment Snow18 = new Fragment(0, 0, 0, new Block[1][][] { new Block[1][] { new Block[1] { BlockType.Snow18, }, }, });

        public static readonly IFragment TreeOak = new Fragment(2, 0, 2, new Block[8][][]
        {
            new Block[5][]
            {
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Debug, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
            },
            new Block[5][]
            {
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Debug, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
            },
            new Block[5][]
            {
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Debug, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
            },
            new Block[5][]
            {
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Debug, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
            },
            new Block[5][]
            {
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Debug, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
            },
            new Block[5][]
            {
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Debug, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
            },
            new Block[5][]
            {
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Debug, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
            },
            new Block[5][]
            {
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
                new Block[5] { BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, BlockType.Null, },
            },
        });

        public static readonly SurfaceBiome Frigid = new SurfaceBiome()
        {
            top = BlockType.Snow,
            bottom = BlockType.Snow,
            surfStructures = new SurfaceStruct[]
            {
                new SurfaceStruct(1, Snow28),
                new SurfaceStruct(1, Snow18),
            },
        };
        public static readonly SurfaceBiome FrigidFrigidCold = new SurfaceBiome()
        {
            useMixing = true,
            mixingChance = 4,
            top = BlockType.Snow,
            bottom = BlockType.DirtSilty,
            mixTop = BlockType.DirtSiltySnowy,
            mixBottom = BlockType.DirtSilty,
            surfStructures = new SurfaceStruct[]
            {
                new SurfaceStruct(2, Snow28),
                new SurfaceStruct(1, Snow18),
            },
        };
        public static readonly SurfaceBiome FrigidCold = new SurfaceBiome()
        {
            useMixing = true,
            mixingChance = 2,
            top = BlockType.Snow,
            bottom = BlockType.DirtSilty,
            mixTop = BlockType.DirtSiltySnowy,
            mixBottom = BlockType.DirtSilty,
            surfStructures = new SurfaceStruct[]
            {
                new SurfaceStruct(2, Snow28),
                new SurfaceStruct(1, Snow18),
            },
        };
        public static readonly SurfaceBiome FrigidColdCold = new SurfaceBiome()
        {
            useMixing = true,
            mixingChance = 4,
            top = BlockType.DirtSiltySnowy,
            bottom = BlockType.DirtSilty,
            mixTop = BlockType.Snow,
            mixBottom = BlockType.DirtSilty,
            surfStructures = new SurfaceStruct[]
            {
                new SurfaceStruct(4, Snow28),
                new SurfaceStruct(2, Snow18),
            },
        };
        public static readonly SurfaceBiome Cold = new SurfaceBiome()
        {
            top = BlockType.DirtSiltySnowy,
            bottom = BlockType.DirtSilty,
            surfStructures = new SurfaceStruct[]
            {
                new SurfaceStruct(4, Snow28),
                new SurfaceStruct(2, Snow18),
            },
        };
        public static readonly SurfaceBiome ColdColdCool = new SurfaceBiome()
        {
            useMixing = true,
            mixingChance = 4,
            top = BlockType.DirtSiltySnowy,
            bottom = BlockType.DirtSilty,
            mixTop = BlockType.DirtLoamyGrassy,
            mixBottom = BlockType.DirtLoamy,
            surfStructures = new SurfaceStruct[]
            {
                new SurfaceStruct(8, Snow28),
                new SurfaceStruct(4, Snow18),
                new SurfaceStruct(8, PlantGrassShort),
            },
        };
        public static readonly SurfaceBiome ColdCool = new SurfaceBiome()
        {
            useMixing = true,
            mixingChance = 2,
            top = BlockType.DirtSiltySnowy,
            bottom = BlockType.DirtSilty,
            mixTop = BlockType.DirtLoamyGrassy,
            mixBottom = BlockType.DirtLoamy,
            surfStructures = new SurfaceStruct[]
            {
                new SurfaceStruct(8, Snow18),
                new SurfaceStruct(8, PlantGrass),
                new SurfaceStruct(4, PlantGrassShort),
                new SurfaceStruct(4, TreeOak),
            },
        };
        public static readonly SurfaceBiome ColdCoolCool = new SurfaceBiome()
        {
            useMixing = true,
            mixingChance = 4,
            top = BlockType.DirtLoamyGrassy,
            bottom = BlockType.DirtLoamy,
            mixTop = BlockType.DirtSiltyGrassy,
            mixBottom = BlockType.DirtSilty,
            surfStructures = new SurfaceStruct[]
            {
                new SurfaceStruct(4, PlantGrass),
                new SurfaceStruct(2, PlantGrassShort),
                new SurfaceStruct(4, TreeOak),
            },
        };
        public static readonly SurfaceBiome Cool = new SurfaceBiome()
        {
            top = BlockType.DirtLoamyGrassy,
            bottom = BlockType.DirtLoamy,
            surfStructures = new SurfaceStruct[]
            {
                new SurfaceStruct(2, PlantGrass),
                new SurfaceStruct(2, PlantGrassShort),
                new SurfaceStruct(4, TreeOak),
            },
        };
        public static readonly SurfaceBiome CoolCoolWarm = new SurfaceBiome()
        {
            useMixing = true,
            mixingChance = 4,
            top = BlockType.DirtLoamyGrassy,
            bottom = BlockType.DirtLoamy,
            mixTop = BlockType.DirtClayGrassy,
            mixBottom = BlockType.DirtClay,
        };
        public static readonly SurfaceBiome CoolWarm = new SurfaceBiome()
        {
            useMixing = true,
            mixingChance = 2,
            top = BlockType.DirtLoamyGrassy,
            bottom = BlockType.DirtLoamy,
            mixTop = BlockType.DirtClayGrassy,
            mixBottom = BlockType.DirtClay,
        };
        public static readonly SurfaceBiome CoolWarmWarm = new SurfaceBiome()
        {
            useMixing = true,
            mixingChance = 4,
            top = BlockType.DirtClayGrassy,
            bottom = BlockType.DirtClay,
            mixTop = BlockType.DirtLoamyGrassy,
            mixBottom = BlockType.DirtLoamy,
        };
        public static readonly SurfaceBiome Warm = new SurfaceBiome()
        {
            top = BlockType.DirtClayGrassy,
            bottom = BlockType.DirtClay,
        };
        public static readonly SurfaceBiome WarmWarmHot = new SurfaceBiome()
        {
            useMixing = true,
            mixingChance = 4,
            top = BlockType.DirtClayGrassy,
            bottom = BlockType.DirtClay,
            mixTop = BlockType.DirtSandyGrassy,
            mixBottom = BlockType.DirtSandy,
        };
        public static readonly SurfaceBiome WarmHot = new SurfaceBiome()
        {
            useMixing = true,
            mixingChance = 2,
            top = BlockType.DirtClayGrassy,
            bottom = BlockType.DirtClay,
            mixTop = BlockType.DirtSandyGrassy,
            mixBottom = BlockType.DirtSandy,
        };
        public static readonly SurfaceBiome WarmHotHot = new SurfaceBiome()
        {
            useMixing = true,
            mixingChance = 4,
            top = BlockType.DirtSandyGrassy,
            bottom = BlockType.DirtSandy,
            mixTop = BlockType.DirtClayGrassy,
            mixBottom = BlockType.DirtClay,
        };
        public static readonly SurfaceBiome Hot = new SurfaceBiome()
        {
            top = BlockType.DirtSandyGrassy,
            bottom = BlockType.DirtSandy,
        };
        public static readonly SurfaceBiome HotHotTorrid = new SurfaceBiome()
        {
            useMixing = true,
            mixingChance = 4,
            top = BlockType.DirtSandyGrassy,
            bottom = BlockType.DirtSandy,
            mixTop = BlockType.Sand,
            mixBottom = BlockType.DirtSandy,
            surfStructures = new SurfaceStruct[]
            {
                new SurfaceStruct(4, Sand18),
            },
        };
        public static readonly SurfaceBiome HotTorrid = new SurfaceBiome()
        {
            useMixing = true,
            mixingChance = 2,
            top = BlockType.DirtSandyGrassy,
            bottom = BlockType.DirtSandy,
            mixTop = BlockType.Sand,
            mixBottom = BlockType.DirtSandy,
            surfStructures = new SurfaceStruct[]
            {
                new SurfaceStruct(4, Sand28),
                new SurfaceStruct(2, Sand18),
            },
        };
        public static readonly SurfaceBiome HotTorridTorrid = new SurfaceBiome()
        {
            useMixing = true,
            mixingChance = 4,
            top = BlockType.Sand,
            bottom = BlockType.DirtSandy,
            mixTop = BlockType.DirtSandyGrassy,
            mixBottom = BlockType.DirtSandy,
            surfStructures = new SurfaceStruct[]
            {
                new SurfaceStruct(2, Sand28),
                new SurfaceStruct(1, Sand18),
            },
        };
        public static readonly SurfaceBiome Torrid = new SurfaceBiome()
        {
            top = BlockType.Sand,
            bottom = BlockType.Sand,
            surfStructures = new SurfaceStruct[]
            {
                new SurfaceStruct(1, Sand28),
                new SurfaceStruct(1, Sand18),
            },
        };

        /// <summary>
        /// Standard surface biome array
        /// </summary>
        public static readonly SurfaceBiome[] Biomes = new SurfaceBiome[]
        {
            Frigid,
            Frigid,
            Frigid,
            Frigid,
            Frigid,
            Frigid,
            Frigid,
            Frigid,
            Frigid,
            FrigidFrigidCold,
            FrigidCold,
            FrigidColdCold,
            Cold,
            Cold,
            Cold,
            Cold,
            Cold,
            Cold,
            ColdColdCool,
            ColdCool,
            ColdCoolCool,
            Cool,
            Cool,
            Cool,
            Cool,
            Cool,
            Cool,
            CoolCoolWarm,
            CoolWarm,
            CoolWarmWarm,
            Warm,
            Warm,
            Warm,
            Warm,
            Warm,
            Warm,
            WarmWarmHot,
            WarmHot,
            WarmHotHot,
            Hot,
            Hot,
            Hot,
            Hot,
            Hot,
            Hot,
            HotHotTorrid,
            HotTorrid,
            HotTorridTorrid,
            Torrid,
            Torrid,
            Torrid,
            Torrid,
            Torrid,
            Torrid,
            Torrid,
            Torrid,
            Torrid,
            Torrid,
        };
    }
}
