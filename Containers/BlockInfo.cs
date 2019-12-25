
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

using System;
using System.Numerics;

namespace OpenVoxelSpec
{
    /// <summary>
    /// Block information container class
    /// </summary>
    public struct BlockInfo
    {
        /// <summary>
        /// Block mesh type
        /// </summary>
        public BlockMeshType meshType;
        /// <summary>
        /// Is block passable
        /// </summary>
        public bool isPassable;

        /// <summary>
        /// Block minus offset along X-axis
        /// </summary>
        public float minusOffsetX;
        /// <summary>
        /// Block plus offset along X-axis
        /// </summary>
        public float plusOffsetX;
        /// <summary>
        /// Block minus offset along Y-axis
        /// </summary>
        public float minusOffsetY;
        /// <summary>
        /// Block plus offset along Y-axis
        /// </summary>
        public float plusOffsetY;
        /// <summary>
        /// Block minus offset along Z-axis
        /// </summary>
        public float minusOffsetZ;
        /// <summary>
        /// Block plus offset along Z-axis
        /// </summary>
        public float plusOffsetZ;

        /// <summary>
        /// Sets mesh type
        /// </summary>
        public BlockInfo SetMeshType(BlockMeshType type)
        {
            meshType = type;
            return this;
        }

        /// <summary>
        /// Sets is block passable
        /// </summary>
        public BlockInfo SetIsPassable(bool value)
        {
            isPassable = value;
            return this;
        }

        /// <summary>
        /// Sets block left and right offsets along all axis
        /// </summary>
        public BlockInfo SetOffsets(float minusOffsetX = 0.0f, float plusOffsetX = 1.0f, float minusOffsetY = 0.0f, float plusOffsetY = 1.0f, float minusOffsetZ=  0.0f, float plusOffsetZ = 1.0f)
        {
            this.minusOffsetX = minusOffsetX;
            this.plusOffsetX = plusOffsetX;
            this.minusOffsetY = minusOffsetY;
            this.plusOffsetY = plusOffsetY;
            this.minusOffsetZ = minusOffsetZ;
            this.plusOffsetZ = plusOffsetZ;
            return this;
        }

        /// <summary>
        /// Returns true if point is inside the block
        /// </summary>
        public bool IsInsideBlock(Vector3 point)
        {
            return point.X >= minusOffsetX || point.X <= plusOffsetX || point.Y >= minusOffsetY || point.Y <= plusOffsetY || point.Z >= minusOffsetX || point.Z <= plusOffsetX;
        }

        /// <summary>
        /// Creates a new block information array
        /// </summary>
        public static BlockInfo[] CreateArray()
        {
            var index = 0;
            var count = (int)BlockType.Count;
            var array = new BlockInfo[count];

            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.Block).SetIsPassable(true).SetOffsets(); // Null
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // Unknown
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.Block).SetIsPassable(false).SetOffsets(); // Debug
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // Core
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // Stone
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // Sandstone
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // Cobble
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // SandCobble
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // Gravel
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // Sand
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // DirtClay
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // DirtSandy
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // DirtSilty
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // DirtLoamy
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.9375f, 0.0f, 1.0f); // FarmlandClayDry
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.9375f, 0.0f, 1.0f); // FarmlandSandyDry
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.9375f, 0.0f, 1.0f); // FarmlandSiltyDry
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.9375f, 0.0f, 1.0f); // FarmlandLoamyDry
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.9375f, 0.0f, 1.0f); // FarmlandClayWet
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.9375f, 0.0f, 1.0f); // FarmlandSandyWet
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.9375f, 0.0f, 1.0f); // FarmlandSiltyWet
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.9375f, 0.0f, 1.0f); // FarmlandLoamyWet
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // Grass
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // DirtClayGrassy
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // DirtSandyGrassy
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // DirtSiltyGrassy
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // DirtLoamyGrassy
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // Snow
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // DirtClaySnowy
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // DirtSandySnowy
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // DirtSiltySnowy
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // DirtLoamySnowy
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.BlockSmart).SetIsPassable(false).SetOffsets(); // Clay
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.Cross).SetIsPassable(true).SetOffsets(); // PlantGrass
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.Cross).SetIsPassable(true).SetOffsets(); // PlantGrassShort
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.Cross).SetIsPassable(true).SetOffsets(); // PlantFern
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.125f, 0.875f, 0.0f, 1.0f, 0.125f, 0.875f); // Stalactite68
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.25f, 0.75f, 0.0f, 1.0f, 0.25f, 0.75f); // Stalactite48
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.375f, 0.625f, 0.0f, 1.0f, 0.375f, 0.625f); // Stalactite28
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.25f, 0.0f, 1.0f); // Sand28
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.125f, 0.0f, 1.0f); // Sand18
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.25f, 0.0f, 1.0f); // Snow28
            array[index++] = new BlockInfo().SetMeshType(BlockMeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.125f, 0.0f, 1.0f); // Snow18

            if (index != count)
                throw new InvalidProgramException();

            return array;
        }
    }
}
