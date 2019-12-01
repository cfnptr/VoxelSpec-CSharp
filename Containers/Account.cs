
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

using QuantumBranch.OpenSharedLibrary;
using System.IO;

namespace QuantumBranch.OpenCubicSpace.Core
{
    /// <summary>
    /// Account container class
    /// </summary>
    public class Account : IByteArray
    {
        /// <summary>
        /// Account container byte array size
        /// </summary>
        public const int ByteSize = Passhash.ByteSize + EmailAddress.ByteSize + sizeof(byte) * 2;

        /// <summary>
        /// Account container byte array size
        /// </summary>
        public int ByteArraySize => ByteSize;

        /// <summary>
        /// Account passhash
        /// </summary>
        public Passhash passhash;
        /// <summary>
        /// Account email address
        /// </summary>
        public EmailAddress emailAddress;
        /// <summary>
        /// Is account has blocked
        /// </summary>
        public bool isBlocked;
        /// <summary>
        /// Account status type
        /// </summary>
        public AccountType type;

        /// <summary>
        /// Creates a new account container class instance
        /// </summary>
        public Account(Passhash passhash, EmailAddress emailAddress, bool isBlocked = false, AccountType type = AccountType.Basic)
        {
            this.passhash = passhash;
            this.emailAddress = emailAddress;
            this.isBlocked = isBlocked;
            this.type = type;
        }
        /// <summary>
        /// Creates a new account container class instance
        /// </summary>
        public Account(BinaryReader binaryReader)
        {
            passhash = new Passhash(binaryReader);
            emailAddress = EmailAddress.FromBytes(binaryReader);
            isBlocked = binaryReader.ReadBoolean();
            type = (AccountType)binaryReader.ReadByte();
        }

        /// <summary>
        /// Converts account container to the byte array
        /// </summary>
        public void ToBytes(BinaryWriter binaryWriter)
        {
            passhash.ToBytes(binaryWriter);
            emailAddress.ToBytes(binaryWriter);
            binaryWriter.Write(isBlocked);
            binaryWriter.Write((byte)type);
        }
    }
}
