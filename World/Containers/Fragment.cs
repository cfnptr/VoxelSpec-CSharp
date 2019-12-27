
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
using System.IO;

namespace OpenVoxelSpec.World.Containers
{
    /// <summary>
    /// Fragment container class
    /// </summary>
    public class Fragment : BlockArray, IFragment
    {
        /// <summary>
        /// Fragment center along X-axis
        /// </summary>
        public int CenterX => centerX;
        /// <summary>
        /// Fragment center along X-axis
        /// </summary>
        public int CenterY => centerY;
        /// <summary>
        /// Fragment center along X-axis
        /// </summary>
        public int CenterZ => centerZ;

        /// <summary>
        /// Fragment center along axis
        /// </summary>
        protected readonly int centerX, centerY, centerZ;

        /// <summary>
        /// Creates a new fragment class instance
        /// </summary>
        public Fragment(int centerX, int centerY, int centerZ, int sizeX, int sizeY, int sizeZ) : base(sizeX, sizeY, sizeZ)
        {
            if (centerX < 0 || centerX >= sizeX || centerY < 0 || centerY >= sizeY || centerZ < 0 || centerZ >= sizeZ)
                throw new ArgumentException("Wrong fragment center values");

            this.centerX = centerX;
            this.centerY = centerY;
            this.centerZ = centerZ;
        }
        /// <summary>
        /// Creates a new fragment class instance
        /// </summary>
        public Fragment(int centerX, int centerY, int centerZ, Block[][][] blocks) : base(blocks)
        {
            if (centerX < 0 || centerX >= sizeX || centerY < 0 || centerY >= sizeY || centerZ < 0 || centerZ >= sizeZ)
                throw new ArgumentException("Wrong fragment center values");

            this.centerX = centerX;
            this.centerY = centerY;
            this.centerZ = centerZ;
        }
        /// <summary>
        /// Creates a new fragment class instance
        /// </summary>
        public Fragment(int centerX, int centerY, int centerZ, int sizeX, int sizeY, int sizeZ, BinaryReader binaryReader) : base(sizeX, sizeY, sizeZ, binaryReader)
        {
            if (centerX < 0 || centerX >= sizeX || centerY < 0 || centerY >= sizeY || centerZ < 0 || centerZ >= sizeZ)
                throw new ArgumentException("Wrong fragment center values");

            this.centerX = centerX;
            this.centerY = centerY;
            this.centerZ = centerZ;
        }

        /// <summary>
        /// Copies this fragment to the another block array
        /// </summary>
        public void CopyFragmentTo(IBlockArray array, int offsetX, int offsetY, int offsetZ)
        {
            CopyTo(array, offsetX - centerX, offsetY - centerY, offsetZ - centerZ);
        }
    }
}
