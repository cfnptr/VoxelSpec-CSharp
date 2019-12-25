
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

namespace OpenVoxelSpec
{
    /// <summary>
    /// Surface information container structure
    /// </summary>
    public struct SurfaceInfo
    {
        /// <summary>
        /// Surface noise factor
        /// </summary>
        public float surfNoiseFactor;
        /// <summary>
        /// Surface noise frequency factor
        /// </summary>
        public float surfFrequencyFactor;
        /// <summary>
        /// Surface biome noise factor
        /// </summary>
        public float surfBiomeNoiseFactor;
        /// <summary>
        /// Subsurface noise factor
        /// </summary>
        public float subsurfNoiseFactor;
        /// <summary>
        /// Subsurface noise cutout
        /// </summary>
        public float subsurfNoiseCutout;

        /// <summary>
        /// Surface core block
        /// </summary>
        public Block coreBlock;
        /// <summary>
        /// Surface stone block
        /// </summary>
        public Block stoneBlock;
        /// <summary>
        /// Surface cobble block
        /// </summary>
        public Block cobbleBlock;
        /// <summary>
        /// Surface sand block
        /// </summary>
        public Block sandBlock;

        /// <summary>
        /// Subsurface stalactite structure
        /// </summary>
        public Fragment[] stalactites;

        public static readonly Fragment ExtremeStalactite = new Fragment(0, 3, 0, new Block[4][][]
        {
            new Block[1][]{ new Block[1]{ BlockType.Stalactite28, }, },
            new Block[1][]{ new Block[1]{ BlockType.Stalactite48, }, },
            new Block[1][]{ new Block[1]{ BlockType.Stalactite68, }, },
            new Block[1][]{ new Block[1]{ BlockType.Stone, }, },
        });
        public static readonly Fragment LongStalactite = new Fragment(0, 2, 0, new Block[3][][]
        {
            new Block[1][]{ new Block[1]{ BlockType.Stalactite28, }, },
            new Block[1][]{ new Block[1]{ BlockType.Stalactite48, }, },
            new Block[1][]{ new Block[1]{ BlockType.Stalactite68, }, },
        });
        public static readonly Fragment MediumStalactite = new Fragment(0, 1, 0, new Block[2][][]
        {
            new Block[1][]{ new Block[1]{ BlockType.Stalactite28, }, },
            new Block[1][]{ new Block[1]{ BlockType.Stalactite48, }, },
        });
        public static readonly Fragment ShortStalactite = new Fragment(0, 0, 0, new Block[1][][]
        {
            new Block[1][]{ new Block[1]{ BlockType.Stalactite28, }, },
        });
        /// <summary>
        /// Standard surface info instance
        /// </summary>
        public static readonly SurfaceInfo Info = new SurfaceInfo()
        {
            surfNoiseFactor = 0.01f,
            surfFrequencyFactor = 0.02f,
            surfBiomeNoiseFactor = 0.0025f,
            subsurfNoiseFactor = 0.05f,
            subsurfNoiseCutout = 0.75f,

            coreBlock = BlockType.Core,
            stoneBlock = BlockType.Stone,
            cobbleBlock = BlockType.Cobble,
            sandBlock = BlockType.Sand,

            stalactites = new Fragment[]
            {
                ExtremeStalactite,
                LongStalactite,
                MediumStalactite,
                ShortStalactite,
            },
        };
    }
}
