// <copyright file="FileTypeDetector.cs" company="Howler Team">
// Copyright (c) Howler Team. All rights reserved.
// Licensed under the MIT License
// See LICENSE file in the project root for full license information.
// </copyright>
// <author>Cassandra A. Heart</author>

namespace FileMagic
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using FileMagic.Types;

    /// <summary>
    /// A file type detection class.
    /// </summary>
    public class FileTypeDetector : IFileTypeDetector
    {
        private static List<FileType> magicTypes = new List<FileType>
        {
            new BMP(0, 0),
            new GIF(0, 0),
            new JPEG(0, 0),
            new PNG(0, 0),
            new BigEndianTIFF(0, 0),
            new LittleEndianTIFF(0, 0),
            new Zip(),
            new ODS(),
            new ODP(),
            new ODT(),
        };

        private static List<FileType> jpegSubtypes = new List<FileType>
        {
            new JFIF(0, 0),
            new JPEGWithEXIF(0, 0),
            new SPIFF(0, 0),
        };

        private static List<OpenOffice> officeTypes = new List<OpenOffice>
        {
            new XSLX(),
            new XPS(),
            new DOCX(),
            new VSDX(),
            new PPTX(),
        };

        private static List<Document> openOfficeTypes = new List<Document>
        {
            new ODS(),
            new ODP(),
            new ODT(),
        };

        /// <inheritdoc/>
        public FileType? Detect(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            if (!stream.CanSeek && stream.Position != 0)
            {
                throw new InvalidOperationException(
                    "Cannot detect on unseekable stream not at 0.");
            }

            if (stream.Length == 0)
            {
                return null;
            }

            var bytes = new byte[1024];
            var length = stream.Read(bytes, 0, 1024);

            foreach (var magicType in magicTypes
                .Where(m => m.magic.Length <= length))
            {
                if (magicType.magic.SequenceEqual(
                    bytes.Take(magicType.magic.Length)))
                {
                    if (magicType is PNG)
                    {
                        var apng = new APNG(0, 0);
                        return Enumerable.Range(0, length)
                            .Any(i =>
                                bytes.Skip(i).Take(apng.extraMagic.Length)
                                    .SequenceEqual(apng.extraMagic)) ?
                            magicType :
                            apng;
                    }

                    if (magicType is JPEG)
                    {
                        foreach (var subtype in jpegSubtypes)
                        {
                            if (subtype.magic.SequenceEqual(
                                bytes.Take(subtype.magic.Length)))
                            {
                                return subtype;
                            }
                        }
                    }

                    if (magicType is Zip)
                    {
                        if (stream.CanSeek)
                        {
                            stream.Seek(0, SeekOrigin.Begin);

                            foreach (var oot in openOfficeTypes)
                            {
                                if (Enumerable.Range(0, length)
                                    .Any(i =>
                                        bytes.Skip(i).Take(
                                            oot.extraMagic.Length)
                                            .SequenceEqual(oot.extraMagic)))
                                {
                                    return oot;
                                }
                            }

                            using (var zip = new ZipArchive(stream))
                            {
                                return officeTypes.FirstOrDefault(o =>
                                    zip.GetEntry(o.searchPath) != null) ??
                                    magicType;
                            }
                        }
                    }

                    return magicType;
                }
            }

            return null;
        }
    }
}