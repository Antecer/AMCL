using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace WebFileLoader
{
    public static class WFL
    {
        /// <summary>
        /// 获取网页内容
        /// </summary>
        /// <param name="WebUrl">网页URL</param>
        /// <returns>网页内容&错误信息</returns>
        public static String GetWebPage(String WebUrl)
        {
            try
            {
                WebClient WebGet = new WebClient();
                byte[] Webdat = WebGet.DownloadData(WebUrl);
                String Text = null;
                if (!isErrorEncoded(Encoding.UTF8.GetString(Webdat)))
                {
                    Text = Encoding.UTF8.GetString(Webdat);
                }
                else
                {
                    Text = Encoding.Default.GetString(Webdat);
                }

                return Text;
            }
            catch (Exception e)
            {
                return "[Error]" + e.Message;
            }
        }

        /// <summary>
        /// 判断指定字符串是否乱码
        /// </summary>
        /// <param name="txt">字符串数据</param>
        /// <returns>true&false</returns>
        public static bool isErrorEncoded(string txt)
        {
            var bytes = Encoding.UTF8.GetBytes(txt);
            for (var i = 0; i < bytes.Length; i++)//239 191 189
            {
                if (i < bytes.Length - 3)
                    if (bytes[i] == 239 && bytes[i + 1] == 191 && bytes[i + 2] == 189)
                    {
                        return true;
                    }
            }
            return false;
        }


        /// <summary>
        /// 文件下载器
        /// </summary>
        /// <param name="downLoadUrl">要下载的URL</param>
        /// <param name="savePathName">要保存到本地的地址(含文件名)</param>
        /// <param name="Progress">从下载器返回的成功信息</param>
        public static void DownloadFile(string downLoadUrl, string savePathName, ref bool Progress)
        {
            HttpWebRequest request = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(downLoadUrl);//根据URL获取远程文件流
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream sr = response.GetResponseStream();
                Stream sw = new FileStream(savePathName, FileMode.Create);//创建本地文件写入流

                Decimal WebFileBytes = response.ContentLength;
                Decimal DownloadByte = 0;
                Byte[] buf = new Byte[1024];//创建数据接收缓冲区
                Int32 osize = sr.Read(buf, 0, (int)buf.Length);
                while (osize > 0)
                {
                    DownloadByte += osize;
                    sw.Write(buf, 0, osize);
                    osize = sr.Read(buf, 0, (int)buf.Length);
                }
                sw.Close();
                sr.Close();
                Progress = true;
            }
            catch (Exception e)
            {
                if (request != null) request.Abort();
                Progress = false;
            }
        }

        /// <summary>
        /// 文件下载器
        /// </summary>
        /// <param name="downLoadUrl">要下载的URL</param>
        /// <param name="saveFilePath">要保存到本地的文件夹</param>
        /// <param name="saveFileName">要保存到本地的文件名</param>
        /// <param name="Progress">从下载器返回的成功信息</param>
        public static void DownloadFile(string downLoadUrl, string saveFilePath, string saveFileName, ref bool Progress)
        {
            Directory.CreateDirectory(saveFilePath);
            String savePathName = saveFilePath + (saveFilePath.EndsWith(@"\") ? saveFileName : (@"\" + saveFileName));
            HttpWebRequest request = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(downLoadUrl);//根据URL获取远程文件流
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream sr = response.GetResponseStream();
                Stream sw = new FileStream(savePathName, FileMode.Create);//创建本地文件写入流

                Decimal WebFileBytes = response.ContentLength;
                Decimal DownloadByte = 0;
                Byte[] buf = new Byte[1024];//创建数据接收缓冲区
                Int32 osize = sr.Read(buf, 0, (int)buf.Length);
                while (osize > 0)
                {
                    DownloadByte += osize;
                    sw.Write(buf, 0, osize);
                    osize = sr.Read(buf, 0, (int)buf.Length);
                }
                sw.Close();
                sr.Close();
                Progress = true;
            }
            catch (Exception e)
            {
                if (request != null) request.Abort();
                Progress = false;
            }
        }

        /// <summary>
        /// 文件下载器
        /// </summary>
        /// <param name="downLoadUrl">要下载的URL</param>
        /// <param name="saveFilePath">要保存到本地的文件夹</param>
        /// <param name="saveFileName">要保存到本地的文件名</param>
        /// <param name="Progress">从下载器返回的进度信息</param>
        public static void DownloadFile(string downLoadUrl, string saveFilePath, string saveFileName, Label Progress)
        {
            Directory.CreateDirectory(saveFilePath);
            String savePathName = saveFilePath + (saveFilePath.EndsWith(@"\") ? saveFileName : (@"\" + saveFileName));
            HttpWebRequest request = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(downLoadUrl);//根据URL获取远程文件流
                request.UserAgent = "AMCL";  //设置客户端信息
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream sr = response.GetResponseStream();
                Stream sw = new FileStream(savePathName, FileMode.Create);//创建本地文件写入流

                Decimal WebFileBytes = response.ContentLength;
                Decimal DownloadByte = 0;
                Byte[] buf = new Byte[1024];//创建数据接收缓冲区
                Int32 osize = sr.Read(buf, 0, (int)buf.Length);
                while (osize > 0)
                {
                    DownloadByte += osize;
                    sw.Write(buf, 0, osize);
                    Progress.Text = String.Format("{0}K/{1}K", Math.Round(DownloadByte / 1024, 1), Math.Round(WebFileBytes / 1024, 1));
                    osize = sr.Read(buf, 0, (int)buf.Length);
                }
                sw.Close();
                sr.Close();
            }
            catch (Exception e)
            {
                if (request != null) request.Abort();
                Progress.Text = "[Error]" + e.Message;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="downLoadUrl"></param>
        /// <param name="saveFilePath"></param>
        /// <param name="saveFileName"></param>
        /// <param name="Progress"></param>
        public static void DownloadFile(string downLoadUrl, string saveFilePath, string saveFileName, DataGridViewCell Progress)
        {
            Directory.CreateDirectory(saveFilePath);
            String savePathName = saveFilePath + (saveFilePath.EndsWith(@"\") ? saveFileName : (@"\" + saveFileName));
            HttpWebRequest request = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(downLoadUrl);//根据URL获取远程文件流
                request.UserAgent = "AMCL";  //设置客户端信息
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream sr = response.GetResponseStream();
                Stream sw = new FileStream(savePathName, FileMode.Create);//创建本地文件写入流

                Decimal WebFileBytes = response.ContentLength;
                Decimal DownloadByte = 0;
                Byte[] buf = new Byte[1024];//创建数据接收缓冲区
                Int32 osize = sr.Read(buf, 0, (int)buf.Length);
                while (osize > 0)
                {
                    DownloadByte += osize;
                    sw.Write(buf, 0, osize);
                    Progress.Value = String.Format("{0}K/{1}K", Math.Round(DownloadByte / 1024, 1), Math.Round(WebFileBytes / 1024, 1));
                    osize = sr.Read(buf, 0, (int)buf.Length);
                }
                sw.Close();
                sr.Close();
            }
            catch (Exception e)
            {
                if (request != null) request.Abort();
                Progress.Value = "[Error]" + e.Message;
            }
        }
    }
}
