// <copyright file="Image.cs" company="Howler Team">
// Copyright (c) Howler Team. All rights reserved.
// Licensed under the MIT License
// See LICENSE file in the project root for full license information.
// </copyright>
// <author>Cassandra A. Heart</author>

namespace FileMagic.Types
{
    /// <summary>
    /// Represents an image type.
    /// </summary>
    public record Image(
        byte[] magic,
        byte[] extraMagic,
        string extension,
        string subtype) : FileType(magic, extension, "image", subtype);

    /// <summary>
    /// Represents an image/apng type.
    /// </summary>
    public record APNG(int width, int height) : Image(
        new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A },
        new byte[] { 0x00, 0x00, 0x00, 0x08, 0x61, 0x63, 0x54, 0x4C },
        "apng",
        "apng");

    /// <summary>
    /// Represents an image/png type.
    /// </summary>
    public record PNG(int width, int height) : Image(
        new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A },
        new byte[] { },
        "png",
        "png");

    /// <summary>
    /// Represents an image/bmp type.
    /// </summary>
    public record BMP(int width, int height) : Image(
        new byte[] { 0x42, 0x4D },
        new byte[] { },
        "bmp",
        "bmp");

    /// <summary>
    /// Represents an image/gif type.
    /// </summary>
    public record GIF(int width, int height) : Image(
        new byte[] { 0x47, 0x49, 0x46, 0x38 },
        new byte[] { },
        "gif",
        "gif");

    /// <summary>
    /// Represents an image/jpeg type.
    /// </summary>
    public record JPEG(int width, int height) : Image(
        new byte[] { 0xFF, 0xD8 },
        new byte[] { },
        "jpg",
        "jpeg");

    /// <summary>
    /// Represents an image/jfif type.
    /// </summary>
    public record JFIF(int width, int height) : Image(
        new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
        new byte[] { },
        "jfif",
        "jfif");

    /// <summary>
    /// Represents an image/jpeg type.
    /// </summary>
    public record JPEGWithEXIF(int width, int height) : Image(
        new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
        new byte[] { },
        "jpg",
        "jpeg");

    /// <summary>
    /// Represents an image/spiff type.
    /// </summary>
    public record SPIFF(int width, int height) : Image(
        new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 },
        new byte[] { },
        "spf",
        "spiff");

    /// <summary>
    /// Represents an image/tiff type.
    /// </summary>
    public record BigEndianTIFF(int width, int height) : Image(
        new byte[] { (byte)'M', (byte)'M', 0x00, 0x2A },
        new byte[] { },
        "tif",
        "tiff");

    /// <summary>
    /// Represents an image/tiff type.
    /// </summary>
    public record LittleEndianTIFF(int width, int height) : Image(
        new byte[] { (byte)'I', (byte)'I', 0x2A, 0x00 },
        new byte[] { },
        "tif",
        "tiff");
}