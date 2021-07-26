// <copyright file="Document.cs" company="Howler Team">
// Copyright (c) Howler Team. All rights reserved.
// Licensed under the MIT License
// See LICENSE file in the project root for full license information.
// </copyright>
// <author>Cassandra A. Heart</author>

namespace FileMagic.Types
{
    /// <summary>
    /// Represents a document type.
    /// </summary>
    public record Document(
        byte[] magic,
        byte[] extraMagic,
        string extension,
        string subtype) : FileType(magic, extension, "application", subtype);

    /// <summary>
    /// Represents a zip type.
    /// </summary>
    public record Zip(string extension = "zip", string subtype = "zip") :
        Document(
            new byte[] { 0x50, 0x4B, 0x03, 0x04 },
            new byte[] { },
            extension,
            subtype);

    /// <summary>
    /// Represents a catch-all OpenOffice document.
    /// </summary>
    public abstract record OpenOffice(
        string searchPath,
        string extension,
        string subtype) : Zip(extension, subtype);

    /// <summary>
    /// Represents a Word document.
    /// </summary>
    public record DOCX() : OpenOffice(
        "word/document.xml",
        "docx",
        "vnd.openxmlformats-officedocument.wordprocessingml.document");

    /// <summary>
    /// Represents an Excel document.
    /// </summary>
    public record XSLX() : OpenOffice(
        "xl/workbook.xml",
        "xlsx",
        "vnd.openxmlformats-officedocument.spreadsheetml.sheet");

    /// <summary>
    /// Represents a Visio document.
    /// </summary>
    public record VSDX() : OpenOffice(
        "visio/document.xml",
        "vsdx",
        "vnd.visio");

    /// <summary>
    /// Represents a Powerpoint document.
    /// </summary>
    public record PPTX() : OpenOffice(
        "ppt/presentation.xml",
        "pptx",
        "vnd.openxmlformats-officedocument.presentationml.presentation");

    /// <summary>
    /// Represents an XPS document.
    /// </summary>
    public record XPS() : OpenOffice(
        "FixedDocSeq.fdseq",
        "xps",
        "vnd.ms-xpsdocument");

    /// <summary>
    /// Represents an Open Office Document file.
    /// </summary>
    public record ODS() : Document(
        new byte[] { },
        new byte[]
        {
            0x6D, 0x69, 0x6D, 0x65, 0x74, 0x79, 0x70, 0x65, 0x61, 0x70, 0x70,
            0x6C, 0x69, 0x63, 0x61, 0x74, 0x69, 0x6F, 0x6E, 0x2F, 0x76, 0x6E,
            0x64, 0x2E, 0x6F, 0x61, 0x73, 0x69, 0x73, 0x2E, 0x6F, 0x70, 0x65,
            0x6E, 0x64, 0x6F, 0x63, 0x75, 0x6D, 0x65, 0x6E, 0x74, 0x2E, 0x73,
            0x70, 0x72, 0x65, 0x61, 0x64, 0x73, 0x68, 0x65, 0x65, 0x74,
        },
        "ods",
        "vnd.oasis.opendocument.spreadsheet");

    /// <summary>
    /// Represents an Open Office Presentation file.
    /// </summary>
    public record ODP() : Document(
        new byte[] { },
        new byte[]
        {
            0x6D, 0x69, 0x6D, 0x65, 0x74, 0x79, 0x70, 0x65, 0x61, 0x70, 0x70,
            0x6C, 0x69, 0x63, 0x61, 0x74, 0x69, 0x6F, 0x6E, 0x2F, 0x76, 0x6E,
            0x64, 0x2E, 0x6F, 0x61, 0x73, 0x69, 0x73, 0x2E, 0x6F, 0x70, 0x65,
            0x6E, 0x64, 0x6F, 0x63, 0x75, 0x6D, 0x65, 0x6E, 0x74, 0x2E, 0x70,
            0x72, 0x65, 0x73, 0x65, 0x6E, 0x74, 0x61, 0x74, 0x69, 0x6F, 0x6E,
        },
        "odp",
        "vnd.oasis.opendocument.presentation");

    /// <summary>
    /// Represents an Open Office Text file.
    /// </summary>
    public record ODT() : Document(
        new byte[] { },
        new byte[]
        {
            0x6D, 0x69, 0x6D, 0x65, 0x74, 0x79, 0x70, 0x65, 0x61, 0x70, 0x70,
            0x6C, 0x69, 0x63, 0x61, 0x74, 0x69, 0x6F, 0x6E, 0x2F, 0x76, 0x6E,
            0x64, 0x2E, 0x6F, 0x61, 0x73, 0x69, 0x73, 0x2E, 0x6F, 0x70, 0x65,
            0x6E, 0x64, 0x6F, 0x63, 0x75, 0x6D, 0x65, 0x6E, 0x74, 0x2E, 0x74,
            0x65, 0x78, 0x74,
        },
        "odt",
        "vnd.oasis.opendocument.text");
}
