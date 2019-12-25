
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
using System.IO;

namespace OpenVoxelSpec
{
    /// <summary>
    /// Account database class
    /// </summary>
    public class AccountDatabase : IAccountDatabase
    {
        /// <summary>
        /// Account database folder path
        /// </summary>
        protected readonly string folderPath;

        /// <summary>
        /// Creates a new account database instance
        /// </summary>
        public AccountDatabase(string folderPath)
        {
            this.folderPath = folderPath;

            if (!Directory.Exists($"{folderPath}accounts/"))
                Directory.CreateDirectory($"{folderPath}accounts/");
        }

        /// <summary>
        /// Returns true if the database contains account data
        /// </summary>
        public bool Contains(Username username)
        {
            return File.Exists($"{folderPath}accounts/{username}");
        }
        /// <summary>
        /// Reads account data from the database
        /// </summary>
        public AccountData Read(Username username)
        {
            try
            {
                var array = new byte[AccountData.ByteSize];

                using (var memoryStream = new MemoryStream(array))
                {
                    using (var fileStream = new FileStream($"{folderPath}accounts/{username}", FileMode.Open, FileAccess.Read))
                        fileStream.CopyTo(memoryStream);

                    using (var binaryReader = new BinaryReader(memoryStream))
                    {
                        memoryStream.Position = 0;
                        return new AccountData(binaryReader);
                    }
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Writes account data to the database
        /// </summary>
        public bool Write(Username username, AccountData accountData)
        {
            try
            {
                var array = new byte[AccountData.ByteSize];

                using (var memoryStream = new MemoryStream(array))
                {
                    using (var binaryWriter = new BinaryWriter(memoryStream))
                    {
                        accountData.ToBytes(binaryWriter);
                        memoryStream.Position = 0;

                        using (var fileStream = new FileStream($"{folderPath}accounts/{username}", FileMode.Create, FileAccess.Write))
                        {
                            memoryStream.CopyTo(fileStream);
                            return true;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
