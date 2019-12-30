
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

namespace OpenVoxelSpec.Blocks.Containers.Fragments
{
    /// <summary>
    /// Fragment container interface
    /// </summary>
    public interface IFragment : IBlockArray
    {
        /// <summary>
        /// Fragment center along X-axis
        /// </summary>
        int CenterX { get; }
        /// <summary>
        /// Fragment center along X-axis
        /// </summary>
        int CenterY { get; }
        /// <summary>
        /// Fragment center along X-axis
        /// </summary>
        int CenterZ { get; }

        /// <summary>
        /// Returns true if this fragment fits into another array
        /// </summary>
        bool IsFragmentFitsToArray(IBlockArray array, int offsetX, int offsetY, int offsetZ);
        /// <summary>
        /// Copies this fragment to the another block array
        /// </summary>
        void CopyFragmentTo(IBlockArray array, int offsetX, int offsetY, int offsetZ);
    }
}
