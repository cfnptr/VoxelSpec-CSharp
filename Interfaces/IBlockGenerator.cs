
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
using System.Numerics;

namespace OpenVoxelSpec
{
    /// <summary>
    /// Бlock array generator class interface
    /// </summary>
    public interface IBlockGenerator
    {
        /// <summary>
        /// Randomly fills block array with the specified block
        /// </summary>
        void GenerateRandom(IBlockArray array, Chance chance, Block fill);
        /// <summary>
        /// Generates grid with specified offser
        /// </summary>
        void GenerateBlockGrid(IBlockArray array, int offset, Block fill);
        /// <summary>
        /// Generates surface relief block array
        /// </summary>
        void GenerateSurface(IBlockArray array, Vector2 position, SurfaceInfo info, SurfaceBiome[] surfBiomes);
        /// <summary>
        /// Generates world block array
        /// </summary>
        void GenerateWorld(IBlockArray array, Vector2 position);
    }
}
