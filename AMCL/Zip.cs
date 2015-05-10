using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;

namespace AMCL
{
    public class Zip
    {

        /// <summary>
        /// 解压缩一个 zip 文件。
        /// </summary>
        /// <param name="zipFileName">要解压的 zip 文件</param>
        /// <param name="dirPath">zip 文件的解压目录</param>
        /// <param name="password">zip 文件的密码。</param>
        /// <param name="overWrite">是否覆盖已存在的文件。</param>
        public static bool UnZipDir(string zipFileName, string dirPath, string password, bool overWrite)
        {
            if (!File.Exists(zipFileName)) return false;
            if (!Directory.Exists(dirPath)) return false;
            if (!dirPath.EndsWith(@"/")) dirPath = dirPath + @"\";
            ZipInputStream s = new ZipInputStream(File.OpenRead(zipFileName));
            s.Password = password;
            ZipEntry theEntry;

            while ((theEntry = s.GetNextEntry()) != null)//判断下一个zip 接口是否未空
            {
                string dirName = "";
                string pathToZip = "";
                pathToZip = theEntry.Name;

                if (pathToZip != "")
                    dirName = Path.GetDirectoryName(pathToZip) + @"/";
                string fileName = Path.GetFileName(pathToZip);
                Directory.CreateDirectory(dirPath + dirName);
                if (fileName != "")
                {
                    try
                    {
                        if ((File.Exists(dirPath + dirName + fileName) && overWrite) || (!File.Exists(dirPath + dirName + fileName)))
                        {
                            FileStream streamWriter = File.Create(dirPath + dirName + fileName);
                            int size = 2048;
                            byte[] data = new byte[2048];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                    streamWriter.Write(data, 0, size);
                                else
                                    break;
                            }
                            streamWriter.Close();
                        }
                    }
                    catch (ZipException ex)
                    {
                        FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "log.txt", FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fs);
                        sw.WriteLine(ex.Message);
                    }
                }
            }
            s.Close();
            return true;
        }
    }
}
