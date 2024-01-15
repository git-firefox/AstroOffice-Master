using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.Utilities;

namespace AstroOfficeWeb.Shared.Helper
{
    public static class StringExtensions
    {
        public static string ToUrlEncode(this string str)
        {
            string encodedString = WebUtility.UrlEncode(str);
            return encodedString;
        }

        public static string ToUrlFriendlyString(this string @string)
        {
            return @string.Replace(" ", "-").ToLower();
        }
        public static FileType ToFileType(this string @string)
        {
            
            return Path.GetExtension(@string).ToLowerInvariant()[1..].ToLowerInvariant() switch
            {
                "jpg" or "png" => FileType.Image,
                "mp4" or "webm" or "ogg" => FileType.Video,
                "mp3" or "wav" => FileType.Audio,
                "txt" => FileType.Text,
                "pdf" => FileType.PDF,
                "xls" or "xlsx" => FileType.Spreadsheet,
                "ppt" or "pptx" => FileType.Presentation,
                "zip" or "tar" => FileType.Archive,
                _ => FileType.Other,
            };
        }
    }
}
