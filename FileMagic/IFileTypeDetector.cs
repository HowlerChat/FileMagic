// <copyright file="IFileTypeDetector.cs" company="Howler Team">
// Copyright (c) Howler Team. All rights reserved.
// Licensed under the MIT License
// See LICENSE file in the project root for full license information.
// </copyright>
// <author>Cassandra A. Heart</author>

namespace FileMagic
{
    using System.IO;
    using FileMagic.Types;

    /// <summary>
    /// Detects a file type based on magic bytes or internal data.
    /// </summary>
    public interface IFileTypeDetector
    {
        /// <summary>
        /// Detects the filetype.
        /// </summary>
        /// <param name="stream">The file stream to detect.</param>
        /// <returns>
        /// Returns the filetype if detectable, null otherwise.
        /// </returns>
        FileType? Detect(Stream stream);
    }
}