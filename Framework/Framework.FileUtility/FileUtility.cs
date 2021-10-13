using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Framework.FileUtility
{
    public static class FileUtility
    {
        static readonly string[] SizeSuffixes =
                  { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        public static string SizeSuffix(long value)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }

            int i = 0;
            decimal dValue = (decimal)value;
            while (Math.Round(dValue / 1024) >= 1)
            {
                dValue /= 1024;
                i++;
            }

            return string.Format("{0:n1} {1}", dValue, SizeSuffixes[i]);
        }
        public static bool GetRemoteFileSizeAndMimeType(string url,out long ContentLength,out string MimeType)
        {
            try
            {
                var request = HttpWebRequest.CreateHttp(url);
                var response = (HttpWebResponse)(request.GetResponse());
                ContentLength = response.ContentLength;
                MimeType = response.ContentType;
                if (ContentLength == -1 || string.IsNullOrEmpty(MimeType))
                    return false;
                return true;
            }
            catch (Exception)
            {
                ContentLength = 0;
                MimeType = "";
                return false;
            }
        }
        public static bool GetFileInfoSizeAndMimeType(FileInfo file, out long ContentLength, out string MimeType)
        {
            try
            {
                ContentLength = file.Length;
                MimeType = Registry.GetValue(@$"HKEY_CLASSES_ROOT\{file.Extension}", "Content Type", null) as string;
                if (ContentLength == -1 || string.IsNullOrEmpty(MimeType))
                    return false;
                return true;
            }
            catch (Exception)
            {
                ContentLength = 0;
                MimeType = "";
                return false;
            }
        }
        public static bool GetBase64SizeAndMimeType(string base64, out long ContentLength, out string MimeType)
        {
            try
            {
                MimeType = "";
                ContentLength = System.Text.ASCIIEncoding.ASCII.GetByteCount(base64);

                var splited = base64.Split(';');
                if (splited.Length < 2 || !splited[0].Contains("data:"))
                    return false;

                splited = splited[0].Split(':');
                if (splited.Length < 2)
                    return false;

                MimeType = splited[1];
                if (ContentLength == -1 || string.IsNullOrEmpty(MimeType))
                    return false;
                return true;
            }
            catch (Exception)
            {
                ContentLength = 0;
                MimeType = "";
                return false;
            }
            
        }

        public static string GetFileExtentionBaseOnFile(UploadType uploadType)
        {
            return string.Join(",", MimeTypeManage.AccMimeTypeCollection[uploadType].Select(p => p.Extention));
        }
        public static bool CanAcceptFile(string MimeType, UploadType uploadType)
        {
            return MimeTypeManage.AccMimeTypeCollection[uploadType].Any(p => p.MimeType == MimeType);
        }
        public static string CheckAndCreateAccessAddressDirectory(string AccessAddress, string AbsoluteHost)
        {
            if (!Directory.Exists(AbsoluteHost + AccessAddress))
                Directory.CreateDirectory(AbsoluteHost + AccessAddress);

            return AbsoluteHost + AccessAddress;
        }
        public static string CheckAndCreateDirectory(string AccessAddress, string AbsoluteHost)
        {
            var path = CheckAndCreateAccessAddressDirectory(AccessAddress, AbsoluteHost);

            if (!Directory.Exists(path + "/" + DateTime.Now.Year))
                Directory.CreateDirectory(path + "/" + DateTime.Now.Year);

            path += "/" + DateTime.Now.Year;
            if (!Directory.Exists(path + "/" + DateTime.Now.Month))
                Directory.CreateDirectory(path + "/" + DateTime.Now.Month);

            path += "/" + DateTime.Now.Month;
            return path;
        }
        public static string CheckAndCreateDirectoryStaticFile(string AccessAddress, string AbsoluteHost, string staticFolder)
        {
            var path = CheckAndCreateAccessAddressDirectory(AccessAddress, AbsoluteHost);

            if (!Directory.Exists(path + "/" + staticFolder))
                Directory.CreateDirectory(path + "/" + staticFolder);

            path += "/" + staticFolder;
            return path;
        }
        public static string CheckDuplicateFileName(string fullPath)
        {
            int count = 1;

            string fileNameOnly = Path.GetFileNameWithoutExtension(fullPath);
            string extension = Path.GetExtension(fullPath);
            string path = Path.GetDirectoryName(fullPath);
            string newFullPath = fullPath;

            while (File.Exists(newFullPath))
            {
                string tempFileName = string.Format("{0}({1})", fileNameOnly, count++);
                newFullPath = Path.Combine(path, tempFileName + extension);
            }
            return newFullPath;
        }
        public static string GetExtentionBaseOnMimeType(string mime)
        {
            string result;
            RegistryKey key;
            object value;

            key = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type\" + mime, false);
            value = key != null ? key.GetValue("Extension", null) : null;
            result = value != null ? value.ToString() : string.Empty;

            return result;
        }
        public static bool SaveImage64(byte[] Array, string FilePath)
        {
            Image image;
            using (MemoryStream ms = new MemoryStream(Array))
                image = Image.FromStream(ms);
            image.Save(FilePath);
            return true;
        }
    }
}
