
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

using QuantumBranch.OpenCubicSpace.Core;
using QuantumBranch.OpenSharedLibrary;
using System.IO;

namespace QuantumBranch.OpenCubicSpace.Core
{
    /// <summary>
    /// Player container class
    /// </summary>
    public class Player : IByteArray
    {
        /// <summary>
        /// Player container byte array size
        /// </summary>
        public const int ByteSize = PlayerTransform.ByteSize;

        /// <summary>
        /// Player container byte array size
        /// </summary>
        public int ByteArraySize => ByteSize;

        /// <summary>
        /// Player transform value
        /// </summary>
        public PlayerTransform transform;

        /// <summary>
        /// Creates a new player container class instance
        /// </summary>
        public Player(PlayerTransform transform)
        {
            this.transform = transform;
        }
        /// <summary>
        /// Creates a new player container class instance
        /// </summary>
        public Player(BinaryReader binaryReader)
        {
            transform = new PlayerTransform(binaryReader);
        }

        /// <summary>
        /// Converts player container to the byte array
        /// </summary>
        public void ToBytes(BinaryWriter binaryWriter)
        {
            transform.ToBytes(binaryWriter);
        }
    }
}
