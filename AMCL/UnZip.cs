using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
namespace UnZipApp
{
    public class ZIP : IDisposable
    {
        private object zipPackage;

        private ZIP(object zPackage)
        {
            zipPackage = zPackage;
        }

        public static ZIP OpenOnFile(string path)
        {
            Type type = typeof(System.IO.Packaging.Package).Assembly.GetType("MS.Internal.IO.Zip.ZipArchive");
            var method = type.GetMethod("OpenOnFile", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            return new ZIP(method.Invoke(null, new object[] { path, FileMode.Open, FileAccess.Read, FileShare.Read, false }));
        }

        public IEnumerable<ZipFile> Files
        {
            get
            {
                var method = zipPackage.GetType().GetMethod("GetFiles", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                var zipFiles = method.Invoke(zipPackage, null) as System.Collections.IEnumerable;
                foreach (var file in zipFiles)
                {
                    yield return new ZipFile(file);
                }
            }
        }

        /// <summary>
        /// 解压并更新文件
        /// </summary>
        /// <param name="zipPath">ZIP压缩包路径</param>
        /// <param name="destFolder">解压到目录</param>
        public static void UnZip(string zipPath, string destFolder)
        {
            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }
            using (var zip = ZIP.OpenOnFile(zipPath))
            {
                string rootFolder = destFolder;
                foreach (var file in zip.Files)
                {
                    if (file.Name.EndsWith("/"))
                    {
                        string[] folders = file.Name.Split('/');
                        rootFolder = destFolder;
                        for (int i = 0; i < folders.Length; i++)
                        {
                            if (!Directory.Exists(Path.Combine(rootFolder, folders[i])))
                            {
                                Directory.CreateDirectory(Path.Combine(rootFolder, folders[i]));
                            }
                            rootFolder = Path.Combine(rootFolder, folders[i]);
                        }
                    }
                }
                foreach (var file in zip.Files)
                {
                    if (!file.Name.EndsWith("/"))
                    {
                        string contentFilePath = Path.Combine(destFolder, file.Name);
                        try
                        {
                            byte[] content = new byte[file.GetStream().Length];
                            file.GetStream().Read(content, 0, content.Length);
                            if (File.Exists(contentFilePath))   //跳过相同的文件，否则覆盖
                            {
                                if (content.Length == new FileInfo(contentFilePath).Length) continue;
                            }
                            else
                            {
                                File.WriteAllBytes(contentFilePath, content);
                            }
                        }
                        catch (DirectoryNotFoundException e)
                        {
                            string[] folders = file.Name.Split('/');
                            rootFolder = destFolder;
                            for (int i = 0; i < folders.Length - 1; i++)
                            {
                                if (!Directory.Exists(Path.Combine(rootFolder, folders[i])))
                                {
                                    Directory.CreateDirectory(Path.Combine(rootFolder, folders[i]));
                                }
                                rootFolder = Path.Combine(rootFolder, folders[i]);
                            }
                            byte[] content = new byte[file.GetStream().Length];
                            file.GetStream().Read(content, 0, content.Length);
                            if (File.Exists(contentFilePath))   //跳过相同的文件
                            {
                                if (content.Length == new FileInfo(contentFilePath).Length) continue;
                            }
                            else
                            {
                                File.WriteAllBytes(contentFilePath, content);
                            }
                        }
                    }
                }
            }
        }

        public void Dispose()
        {
            ((IDisposable)zipPackage).Dispose();
        }
    }

    public class ZipFile
    {
        internal object zipFile;

        public ZipFile(object zfile)
        {
            zipFile = zfile;
        }

        private object GetProperty(string name)
        {
            return zipFile.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(zipFile, null);
        }
        public string Name
        {
            get { return (string)GetProperty("Name"); }
        }
        public Stream GetStream(FileMode mode = FileMode.Open, FileAccess access = FileAccess.Read)
        {
            var meth = zipFile.GetType().GetMethod("GetStream", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            return (Stream)meth.Invoke(zipFile, new object[] { mode, access });
        }
    }
}