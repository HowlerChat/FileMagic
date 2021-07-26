// <copyright file="FileType.cs" company="Howler Team">
// Copyright (c) Howler Team. All rights reserved.
// Licensed under the MIT License
// See LICENSE file in the project root for full license information.
// </copyright>
// <author>Cassandra A. Heart</author>

namespace FileMagic.Types
{
    /// <summary>
    /// Describes a file type for matching.
    /// </summary>
    public record FileType(
        byte[] magic,
        string extension,
        string type,
        string subtype);
}
