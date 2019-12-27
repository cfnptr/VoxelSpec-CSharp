
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

namespace OpenVoxelSpec.World
{
    /// <summary>
    /// Block container structure
    /// </summary>
    public struct Block
    {
        /// <summary>
        /// Size in bytes of the block
        /// </summary>
        public const int ByteSize = sizeof(ushort);

        /// <summary>
        /// Block identifier value
        /// </summary>
        private readonly ushort id;

        /// <summary>
        /// Creates a new block structure instance
        /// </summary>
        public Block(ushort id)
        {
            this.id = id;
        }
        /// <summary>
        /// Creates a new block structure instance
        /// </summary>
        public Block(BlockType type)
        {
            id = (ushort)type;
        }

        /// <summary>
        /// Returns true if block equal to the object
        /// </summary>
        public override bool Equals(object obj) { return this == (Block)obj; }
        /// <summary>
        /// Returns block hash code
        /// </summary>
        public override int GetHashCode() { return id; }
        /// <summary>
        /// Returns block type name string value
        /// </summary>
        public override string ToString() { return GetSafeType().ToString(); }

        /// <summary>
        /// Returns block type if it is in a range, otherwise an Unknown block type
        /// </summary>
        public BlockType GetSafeType()
        {
            try { return (BlockType)id; }
            catch { return BlockType.Unknown; }
        }

        public static bool operator ==(Block a, Block b) { return a.id == b.id; }
        public static bool operator ==(Block i, ushort value) { return i.id == value; }
        public static bool operator ==(ushort value, Block i) { return value == i.id; }
        public static bool operator ==(Block i, BlockType value) { return i.id == (int)value; }
        public static bool operator ==(BlockType value, Block i) { return (int)value == i.id; }
        public static bool operator !=(Block a, Block b) { return a.id != b.id; }
        public static bool operator !=(Block i, ushort value) { return i.id != value; }
        public static bool operator !=(ushort value, Block i) { return value != i.id; }
        public static bool operator !=(Block i, BlockType value) { return i.id != (int)value; }
        public static bool operator !=(BlockType value, Block i) { return (int)value != i.id; }

        public static implicit operator ushort(Block value) { return value.id; }
        public static implicit operator uint(Block value) { return value.id; }
        public static implicit operator int(Block value) { return value.id; }
        public static implicit operator ulong(Block value) { return value.id; }
        public static implicit operator long(Block value) { return value.id; }
        public static implicit operator decimal(Block value) { return value.id; }
        public static implicit operator float(Block value) { return value.id; }
        public static implicit operator double(Block value) { return value.id; }

        public static implicit operator Block(ushort value) { return new Block(value); }
        public static implicit operator Block(BlockType value) { return new Block(value); }
    }
}
