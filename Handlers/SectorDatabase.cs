
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

using System.IO;
using System.IO.Compression;
using System.Numerics;

namespace OpenVoxelSpec
{
    /// <summary>
    /// Sector database class
    /// </summary>
    public class SectorDatabase : ISectorDatabase
    {
        /// <summary>
        /// Sector database folder path
        /// </summary>
        protected readonly string folderPath;

        /// <summary>
        /// Creates a new sector database instance
        /// </summary>
        public SectorDatabase(string folderPath)
        {
            this.folderPath = folderPath;

            if (!Directory.Exists($"{folderPath}sectors/"))
                Directory.CreateDirectory($"{folderPath}sectors/");
        }

        /// <summary>
        /// Returns true if the database contains sector data
        /// </summary>
        public bool Contains(Vector2 position)
        {
            return File.Exists($"{folderPath}sectors/{(int)position.X}_{(int)position.Y}");
        }
        /// <summary>
        /// Reads sector data from the database
        /// </summary>
        public SectorData Read(Vector2 position)
        {
            try
            {
                var array = new byte[SectorData.ByteSize];

                using (var memoryStream = new MemoryStream(array))
                {
                    using (var fileStream = new FileStream($"{folderPath}sectors/{(int)position.X}_{(int)position.Y}", FileMode.Open, FileAccess.Read))
                    {
                        using (var gzipStream = new GZipStream(fileStream, CompressionMode.Decompress))
                            gzipStream.CopyTo(memoryStream);
                    }

                    using (var binaryReader = new BinaryReader(memoryStream))
                    {
                        memoryStream.Position = 0;
                        return new SectorData(binaryReader);
                    }
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Writes sector data to the database
        /// </summary>
        public bool Write(Vector2 position, SectorData sectorData)
        {
            try
            {
                var array = new byte[SectorData.ByteSize];

                using (var memoryStream = new MemoryStream(array))
                {
                    using (var binaryWriter = new BinaryWriter(memoryStream))
                    {
                        sectorData.ToBytes(binaryWriter);
                        memoryStream.Position = 0;

                        using (var fileStream = new FileStream($"{folderPath}sectors/{(int)position.X}_{(int)position.Y}", FileMode.Create, FileAccess.Write))
                        {
                            using (var gzipStream = new GZipStream(fileStream, CompressionMode.Compress))
                            {
                                memoryStream.CopyTo(gzipStream);
                                return true;
                            }
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
