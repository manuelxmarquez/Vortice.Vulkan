﻿// Copyright (c) Amer Koleci and contributors.
// Distributed under the MIT license. See the LICENSE file in the project root for more information.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Vortice.Vulkan
{
    /// <summary>
    /// Structure specifying a two-dimensional subregion.
    /// </summary>
    public unsafe partial struct VkRect2D : IEquatable<VkRect2D>
    {
        /// <summary>
        /// An <see cref="VkRect2D"/> with all of its components set to zero.
        /// </summary>
        public static readonly VkRect2D Zero = new VkRect2D(VkOffset2D.Zero, VkExtent2D.Zero);

        /// <summary>
        /// Initializes a new instance of the <see cref="VkRect2D"/> structure.
        /// </summary>
        /// <param name="offset">The offset component of the rectangle.</param>
        /// <param name="extent">The extent component of the rectangle.</param>
        public VkRect2D(VkOffset2D offset, VkExtent2D extent)
        {
            this.offset = offset;
            this.extent = extent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VkRect2D"/> structure.
        /// </summary>
        /// <param name="extent">The extent component of the rectangle.</param>
        public VkRect2D(VkExtent2D extent)
        {
            offset = default;
            this.extent = extent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VkRect2D"/> structure.
        /// </summary>
        /// <param name="x">The X component of the offset.</param>
        /// <param name="y">The Y component of the offset.</param>
        /// <param name="width">The width component of the extent.</param>
        /// <param name="height">The height component of the extent.</param>
        public VkRect2D(int x, int y, uint width, uint height)
        {
            offset = new VkOffset2D(x, y);
            extent = new VkExtent2D(width, height);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VkRect2D"/> structure.
        /// </summary>
        /// <param name="x">The X component of the offset.</param>
        /// <param name="y">The Y component of the offset.</param>
        /// <param name="width">The width component of the extent.</param>
        /// <param name="height">The height component of the extent.</param>
        public VkRect2D(int x, int y, int width, int height)
        {
            offset = new VkOffset2D(x, y);
            extent = new VkExtent2D(width, height);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VkRect2D"/> structure.
        /// </summary>
        /// <param name="width">The width component of the extent.</param>
        /// <param name="height">The height component of the extent.</param>
        public VkRect2D(uint width, uint height)
        {
            offset = default;
            extent = new VkExtent2D(width, height);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VkRect2D"/> structure.
        /// </summary>
        /// <param name="width">The width component of the extent.</param>
        /// <param name="height">The height component of the extent.</param>
        public VkRect2D(int width, int height)
        {
            offset = default;
            extent = new VkExtent2D(width, height);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj is VkRect2D other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(VkRect2D other) => offset.Equals(other.offset) && extent.Equals(other.extent);

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = offset.GetHashCode();
                hashCode = (hashCode * 397) ^ extent.GetHashCode();
                return hashCode;
            }
        }

        /// <inheritdoc/>
        public override readonly string ToString() => $"{{Offset={offset},Extent={extent}}}";

        /// <summary>
        /// Compares two <see cref="VkRect2D"/> objects for equality.
        /// </summary>
        /// <param name="left">The <see cref="VkRect2D"/> on the left hand of the operand.</param>
        /// <param name="right">The <see cref="VkRect2D"/> on the right hand of the operand.</param>
        /// <returns>
        /// True if the current left is equal to the <paramref name="right"/> parameter; otherwise, false.
        /// </returns>
        public static bool operator ==(VkRect2D left, VkRect2D right) => left.Equals(right);

        /// <summary>
        /// Compares two <see cref="VkRect2D"/> objects for inequality.
        /// </summary>
        /// <param name="left">The <see cref="VkRect2D"/> on the left hand of the operand.</param>
        /// <param name="right">The <see cref="VkRect2D"/> on the right hand of the operand.</param>
        /// <returns>
        /// True if the current left is unequal to the <paramref name="right"/> parameter; otherwise, false.
        /// </returns>
        public static bool operator !=(VkRect2D left, VkRect2D right) => !left.Equals(right);
    }
}
