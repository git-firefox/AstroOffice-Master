﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShared.Utilities
{
    public class FileData
    {
        public Stream File { get; set; } = null!;
        public FileType FileType { get; set; }
        public string FileName { get; set; } = null!;

        public FileType GetFileType(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLowerInvariant();

            return extension switch
            {
                ".txt" => FileType.Text,
                ".jpg" or ".png" => FileType.Image,
                ".mp3" or ".wav" => FileType.Audio,
                ".mp4" or ".avi" => FileType.Video,
                ".pdf" => FileType.PDF,
                ".xls" or ".xlsx" => FileType.Spreadsheet,
                ".ppt" or ".pptx" => FileType.Presentation,
                ".zip" or ".tar" => FileType.Archive,
                _ => FileType.Other,
            };
        }
    }
}