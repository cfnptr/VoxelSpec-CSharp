
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

using OpenVoxelSpec.Blocks.Operators;
using System;
using System.Numerics;

namespace OpenVoxelSpec.Blocks
{
    /// <summary>
    /// Block information container class
    /// </summary>
    public struct BlockInfo
    {
        /// <summary>
        /// Block mesh type
        /// </summary>
        public MeshType meshType;
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
        /// Block operator
        /// </summary>
        public IBlockOperator blockOperator;

        /// <summary>
        /// Sets mesh type
        /// </summary>
        public BlockInfo SetMeshType(MeshType type)
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
        /// Sets block left and right offsets along all axis
        /// </summary>
        public BlockInfo SetOperator(IBlockOperator blockOperator = null)
        {
            this.blockOperator = blockOperator;
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

            array[index++] = new BlockInfo().SetMeshType(MeshType.Block).SetIsPassable(true).SetOffsets().SetOperator(); // Null
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // Unknown
            array[index++] = new BlockInfo().SetMeshType(MeshType.Block).SetIsPassable(false).SetOffsets().SetOperator(); // Debug
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // Core
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // Stone
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // Sandstone
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // Cobble
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // SandCobble
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // Gravel
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // Sand
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // DirtClay
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // DirtSandy
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // DirtSilty
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // DirtLoamy
            array[index++] = new BlockInfo().SetMeshType(MeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.9375f, 0.0f, 1.0f).SetOperator(); // FarmlandClayDry
            array[index++] = new BlockInfo().SetMeshType(MeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.9375f, 0.0f, 1.0f).SetOperator(); // FarmlandSandyDry
            array[index++] = new BlockInfo().SetMeshType(MeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.9375f, 0.0f, 1.0f).SetOperator(); // FarmlandSiltyDry
            array[index++] = new BlockInfo().SetMeshType(MeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.9375f, 0.0f, 1.0f).SetOperator(); // FarmlandLoamyDry
            array[index++] = new BlockInfo().SetMeshType(MeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.9375f, 0.0f, 1.0f).SetOperator(); // FarmlandClayWet
            array[index++] = new BlockInfo().SetMeshType(MeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.9375f, 0.0f, 1.0f).SetOperator(); // FarmlandSandyWet
            array[index++] = new BlockInfo().SetMeshType(MeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.9375f, 0.0f, 1.0f).SetOperator(); // FarmlandSiltyWet
            array[index++] = new BlockInfo().SetMeshType(MeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.9375f, 0.0f, 1.0f).SetOperator(); // FarmlandLoamyWet
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // Grass
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // DirtClayGrassy
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // DirtSandyGrassy
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // DirtSiltyGrassy
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // DirtLoamyGrassy
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // Snow
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // DirtClaySnowy
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // DirtSandySnowy
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // DirtSiltySnowy
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // DirtLoamySnowy
            array[index++] = new BlockInfo().SetMeshType(MeshType.BlockSmart).SetIsPassable(false).SetOffsets().SetOperator(); // Clay
            array[index++] = new BlockInfo().SetMeshType(MeshType.Cross).SetIsPassable(true).SetOffsets().SetOperator(); // PlantGrass
            array[index++] = new BlockInfo().SetMeshType(MeshType.Cross).SetIsPassable(true).SetOffsets().SetOperator(); // PlantGrassShort
            array[index++] = new BlockInfo().SetMeshType(MeshType.Cross).SetIsPassable(true).SetOffsets().SetOperator(); // PlantFern
            array[index++] = new BlockInfo().SetMeshType(MeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.125f, 0.875f, 0.0f, 1.0f, 0.125f, 0.875f).SetOperator(); // Stalactite68
            array[index++] = new BlockInfo().SetMeshType(MeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.25f, 0.75f, 0.0f, 1.0f, 0.25f, 0.75f).SetOperator(); // Stalactite48
            array[index++] = new BlockInfo().SetMeshType(MeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.375f, 0.625f, 0.0f, 1.0f, 0.375f, 0.625f).SetOperator(); // Stalactite28
            array[index++] = new BlockInfo().SetMeshType(MeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.25f, 0.0f, 1.0f).SetOperator(); // Sand28
            array[index++] = new BlockInfo().SetMeshType(MeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.125f, 0.0f, 1.0f).SetOperator(); // Sand18
            array[index++] = new BlockInfo().SetMeshType(MeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.25f, 0.0f, 1.0f).SetOperator(); // Snow28
            array[index++] = new BlockInfo().SetMeshType(MeshType.SizedSmart).SetIsPassable(false).SetOffsets(0.0f, 1.0f, 0.0f, 0.125f, 0.0f, 1.0f).SetOperator(); // Snow18

            if (index != count)
                throw new InvalidProgramException();

            return array;
        }
    }
}
