
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

using System.Numerics;

namespace QuantumBranch.OpenCubicSpace.Core
{
    /// <summary>
    /// Block array container interface
    /// </summary>
    public interface IBlockArray : IArray3D
    {
        /// <summary>
        /// Returns block value from an array without checking position boundaries
        /// </summary>
        Block GetBlockUnsafe(int x, int y, int z);
        /// <summary>
        /// Returns block value from an array without checking position boundaries
        /// </summary>
        Block GetBlockUnsafe(Vector3 position);

        /// <summary>
        /// Returns block value from an array
        /// </summary>
        Block GetBlock(int index);
        /// <summary>
        /// Returns block value from an array
        /// </summary>
        Block GetBlock(int x, int y, int z);
        /// <summary>
        /// Returns block value from an array
        /// </summary>
        Block GetBlock(Vector3 position);

        /// <summary>
        /// Sets block value to an array without checking position boundaries
        /// </summary>
        void SetBlockUnsafe(int x, int y, int z, Block block);
        /// <summary>
        /// Sets block value to an array without checking position boundaries
        /// </summary>
        void SetBlockUnsafe(Vector3 position, Block block);

        /// <summary>
        /// Sets block value to an array
        /// </summary>
        void SetBlock(int index, Block block);
        /// <summary>
        /// Sets block value to an array
        /// </summary>
        void SetBlock(int x, int y, int z, Block block);
        /// <summary>
        /// Sets block value to an array
        /// </summary>
        void SetBlock(Vector3 position, Block block);

        /// <summary>
        /// Returns fragment from a block array
        /// </summary>
        Block[] GetFragment(int index, int count);

        /// <summary>
        /// Returns block array
        /// </summary>
        Block[] ToBlockArray();
    }
}
