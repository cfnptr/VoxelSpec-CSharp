
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
using System.Numerics;

namespace OpenVoxelSpec
{
    /// <summary>
    /// Open voxel specification unified constants container
    /// </summary>
    public static class Unicon
    {
        /// <summary>
        /// Open voxel specification version
        /// </summary>
        public static readonly Version Version = new Version(0, 1, 0);

        /// <summary>
        /// Segment length in blocks or units along three axes
        /// </summary>
        public const int SegmentLength = 32;
        /// <summary>
        /// Segment area size in blocks or units
        /// </summary>
        public const int SegmentArea = 1024; // SegmentSize * SegmentSize
        /// <summary>
        /// Segment volume size in blocks or units
        /// </summary>
        public const int SegmentVolume = 32768; // SegmentSize * SegmentSize * SegmentSize
        /// <summary>
        /// Sector size in block or units along X, Y and Z axis
        /// </summary>
        public static readonly Vector3 SegmentSize = new Vector3(SegmentLength, SegmentLength, SegmentLength);

        /// <summary>
        /// Number of segment in one sector along the Y axis
        /// </summary>
        public const int SectorSegmentCount = 4;
        /// <summary>
        /// Sector size in blocks or units along Y axis
        /// </summary>
        public const int SectorHeight = 128; // SegmentSize * SectorSegmentCount
        /// <summary>
        /// Sector size in blocks or units along Y axis
        /// </summary>
        public const int SectorVolume = 131072; // SegmentVolume * SectorSegmentCount
        /// <summary>
        /// Sector size in block or units along X, Y and Z axis
        /// </summary>
        public static readonly Vector3 SectortSize = new Vector3(SegmentLength, SectorHeight, SegmentLength);

        /// <summary>
        /// Default player view distance in the segments
        /// </summary>
        public const int SegmentViewDistance = 4;
        /// <summary>
        /// Default player view distance in the blocks
        /// </summary>
        public const int BlockViewDistance = SegmentViewDistance * SegmentLength;

        /// <summary>
        /// Block information container array
        /// </summary>
        public static readonly IBlockInfoArray BlockInfoArray = new BlockInfoArray();
    }
}