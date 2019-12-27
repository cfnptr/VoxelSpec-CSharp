
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

using OpenSharedLibrary.Containers;
using OpenVoxelSpec.World.Containers;
using System.IO;
using System.IO.Compression;
using System.Numerics;

namespace OpenVoxelSpec.World.Containers
{
    /// <summary>
    /// Sector disk database class (thread-safe)
    /// </summary>
    public class SectorDiskDatabase : DiskDatabase<Vector2, ISector>, ISectorDiskDatabase
    {
        /// <summary>
        /// Creates a new sector disk database instance
        /// </summary>
        public SectorDiskDatabase(string sectorFolderPath, ISectorDiskFactory factory) : base(sectorFolderPath, factory) { }

        /// <summary>
        /// Returns true if the database contains sector data
        /// </summary>
        public override bool Contains(Vector2 position)
        {
            lock(locker)
                return File.Exists($"{path}{(int)position.X}_{(int)position.Y}");
        }
        /// <summary>
        /// Reads sector data from the database
        /// </summary>
        public override ISector Read(Vector2 position)
        {
            try
            {
                var array = new byte[Sector.ByteSize];
                using var memoryStream = new MemoryStream(array);

                lock (locker)
                {
                    var fileStream = new FileStream($"{path}{(int)position.X}_{(int)position.Y}", FileMode.Open, FileAccess.Read);
                    using var gzipStream = new GZipStream(fileStream, CompressionMode.Decompress);
                    gzipStream.CopyTo(memoryStream);
                    fileStream.Close();
                }

                using var binaryReader = new BinaryReader(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return factory.Create(binaryReader);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Writes sector data to the database
        /// </summary>
        public override bool Write(Vector2 position, ISector sectorData)
        {
            try
            {
                var array = new byte[Sector.ByteSize];
                using var memoryStream = new MemoryStream(array);
                using var binaryWriter = new BinaryWriter(memoryStream);

                sectorData.ToBytes(binaryWriter);
                memoryStream.Seek(0, SeekOrigin.Begin);

                lock (locker)
                {
                    var fileStream = new FileStream($"{path}{(int)position.X}_{(int)position.Y}", FileMode.Create, FileAccess.Write);
                    using var gzipStream = new GZipStream(fileStream, CompressionMode.Compress);
                    memoryStream.CopyTo(gzipStream);
                    fileStream.Close();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
