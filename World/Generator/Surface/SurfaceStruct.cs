
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
    /// Surface structure container structture
    /// </summary>
    public struct SurfaceStruct
    {
        /// <summary>
        /// Surface structure generation chance
        /// </summary>
        public int chance;

        /// <summary>
        /// Surface structure block array
        /// </summary>
        public IFragment structure;

        /// <summary>
        /// Creates a new surface structure instance
        /// </summary>
        public SurfaceStruct(int chance, IFragment structure) 
        {
            this.chance = chance;
            this.structure = structure;
        }
    }
}
