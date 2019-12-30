
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

using OpenVoxelSpec.Blocks.Containers;

namespace OpenVoxelSpec.Blocks.Operators
{
    /// <summary>
    /// Block operator interface
    /// </summary>
    public interface IBlockOperator
    {
        /// <summary>
        /// Executes block operation
        /// </summary>
        void Execute(int x, int y, int z, IBlockArray array);
        /// <summary>
        /// Executes block operation
        /// </summary>
        void Execute(int x, int y, int z, IBlockArray array, IBlockArray left, IBlockArray right, IBlockArray back, IBlockArray forward);
        /// <summary>
        /// Executes block operation
        /// </summary>
        void Execute(int x, int y, int z, IBlockArray array, IBlockArray left, IBlockArray right, IBlockArray down, IBlockArray up, IBlockArray back, IBlockArray forward);
    }
}
