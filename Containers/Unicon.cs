
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

namespace OpenVoxelSpec
{
    /// <summary>
    /// Open voxel specification unified constants container
    /// </summary>
    public static class Unicon
    {
        /// <summary>
        /// Segment size in blocks or units along three axes
        /// </summary>
        public const int SegmentSize = 16;
        /// <summary>
        /// Segment area size in blocks or units
        /// </summary>
        public const int SegmentArea = 256; // SegmentSize * SegmentSize
        /// <summary>
        /// Segment volume size in blocks or units
        /// </summary>
        public const int SegmentVolume = 4096; // SegmentSize * SegmentSize * SegmentSize

        /// <summary>
        /// Number of segment in one sector along the Y axis
        /// </summary>
        public const int SectorSegmentCount = 8;
        /// <summary>
        /// Sector size in blocks or units along Y axis
        /// </summary>
        public const int SectorHeight = 128; // SegmentSize * SectorSegmentCount
        /// <summary>
        /// Sector size in blocks or units along Y axis
        /// </summary>
        public const int SectorVolume = 32768; // SegmentVolume * SectorSegmentCount
    }
}