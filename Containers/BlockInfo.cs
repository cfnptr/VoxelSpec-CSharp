
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

namespace OpenVoxelSpec
{
    /// <summary>
    /// Block information container class
    /// </summary>
    public struct BlockInfo
    {
        /// <summary>
        /// Block mesh type value
        /// </summary>
        public BlockMeshType meshType;

        /// <summary>
        /// Sets mesh type value
        /// </summary>
        public BlockInfo SetMeshType(BlockMeshType type)
        {
            meshType = type;
            return this;
        }

        /// <summary>
        /// Creates a new block information array instance
        /// </summary>
        public static BlockInfo[] CreateArray()
        {
            var index = 0;
            var count = (int)BlockType.Count;
            var array = new BlockInfo[count];

            array[index++] = new BlockInfo();
            array[index++] = new BlockInfo();
            array[index++] = new BlockInfo();

            if (index != count)
                throw new InvalidProgramException();

            return array;
        }
    }
}
