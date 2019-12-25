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

namespace OpenVoxelSpec
{
    /// <summary>
    /// Information array container class
    /// </summary>
    public class BlockInfoArray : IBlockInfoArray
    {
        /// <summary>
        /// Returns block information array length
        /// </summary>
        public int Length => (int)BlockType.Count;

        /// <summary>
        /// Block information array
        /// </summary>
        protected readonly BlockInfo[] blockInfos;

        /// <summary>
        /// Creates a new block information array class instance
        /// </summary>
        public BlockInfoArray()
        {
            blockInfos = BlockInfo.CreateArray();
        }

        /// <summary>
        /// Returns block information by a block value
        /// </summary>
        public BlockInfo GetBlockInfo(Block block)
        {
            try { return blockInfos[block]; }
            catch { return blockInfos[(int)BlockType.Unknown]; }
        }
    }
}
