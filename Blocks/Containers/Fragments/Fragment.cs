
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

namespace OpenVoxelSpec.Blocks.Containers.Fragments
{
    /// <summary>
    /// Fragment container class
    /// </summary>
    public class Fragment : BlockArray, IFragment
    {
        /// <summary>
        /// Fragment container center byte array size
        /// </summary>
        public const int FragmentCenterByteSize = sizeof(int) * 3;

        /// <summary>
        /// Fragment container byte array size
        /// </summary>
        public new int ByteArraySize => ArraySizeByteSize + length * Block.ByteSize + FragmentCenterByteSize;

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
        public Fragment(BinaryReader binaryReader) : base(binaryReader)
        {
            centerX = binaryReader.ReadInt32();
            centerY = binaryReader.ReadInt32();
            centerZ = binaryReader.ReadInt32();

            if (centerX < 0 || centerX >= sizeX || centerY < 0 || centerY >= sizeY || centerZ < 0 || centerZ >= sizeZ)
                throw new ArgumentException("Wrong fragment center values");
        }

        /// <summary>
        /// Converts block array container to the byte array
        /// </summary>
        public new void ToBytes(BinaryWriter binaryWriter)
        {
            base.ToBytes(binaryWriter);
            binaryWriter.Write(centerX);
            binaryWriter.Write(centerY);
            binaryWriter.Write(centerZ);
        }

        /// <summary>
        /// Returns true if this fragment fits into another array
        /// </summary>
        public bool IsFragmentFitsToArray(IBlockArray array, int offsetX, int offsetY, int offsetZ)
        {
            return array.IsFits(this, offsetX - centerX, offsetY - centerY, offsetZ - centerZ);
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
