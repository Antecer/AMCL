using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace GetHash
{
    class Hash
    {
        /// <summary>
        /// 文件SHA1校验
        /// </summary>
        /// <param name="pathName">文件路径（包括文件名）</param>
        /// <returns>文件SHA1码</returns>
        public static string GetFileSHA1(string pathName)
        {
            string strResult = "";
            string strHashData = "";
            byte[] arrbytHashValue;
            FileStream oFileStream = null;
            SHA1CryptoServiceProvider oSHA1Hasher = new SHA1CryptoServiceProvider();
            try
            {
                oFileStream = new FileStream(pathName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                arrbytHashValue = oSHA1Hasher.ComputeHash(oFileStream); //计算指定Stream 对象的哈希值
                oFileStream.Close();
                //由以连字符分隔的十六进制对构成的String，其中每一对表示value 中对应的元素；例如“F-2C-4A”
                strHashData = BitConverter.ToString(arrbytHashValue);
                strHashData = strHashData.Replace("-", "");     //替换-
                strResult = strHashData.ToLower();              //将哈希值转换成小写
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return strResult;
        }

        /// <summary>
        /// 文件MD5校验
        /// </summary>
        /// <param name="pathName">文件路径（包括文件名）</param>
        /// <returns>MD5校验码</returns>
        public static string GetFileMd5(string pathName)
        {
            string strResult = "";
            string strHashData = "";
            byte[] arrbytHashValue;
            FileStream oFileStream = null;
            MD5CryptoServiceProvider oMD5Hasher = new MD5CryptoServiceProvider();
            try
            {
                oFileStream = new FileStream(pathName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                arrbytHashValue = oMD5Hasher.ComputeHash(oFileStream); //计算指定Stream 对象的哈希值
                oFileStream.Close();
                //由以连字符分隔的十六进制对构成的String，其中每一对表示value 中对应的元素；例如“F-2C-4A”
                strHashData = BitConverter.ToString(arrbytHashValue);
                strHashData = strHashData.Replace("-", "");     //删除-
                strResult = strHashData.ToLower();              //将哈希值转换成小写
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return strResult;
        }

        /// <summary>
        /// 字符串转MD5
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <returns>返回MD5值</returns>
        public static string StringToMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(str);
            byte[] OutBytes = md5.ComputeHash(data);
            string OutString = "";
            for (int i = 0; i < OutBytes.Length; i++)
            {
                OutString += OutBytes[i].ToString("x2");
            }
            // return OutString.ToUpper();
            return OutString.ToLower();
        }

        /// <summary>
        /// 字符串转SHA1
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StringToSHA1(string str)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] data = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(str);
            byte[] OutBytes = sha1.ComputeHash(data);
            string OutString = "";
            for (int i = 0; i < OutBytes.Length; i++)
            {
                OutString += OutBytes[i].ToString("x2");
            }
            // return OutString.ToUpper();
            return OutString.ToLower();
        }

        /// <summary>
        /// 计算文件SHA1值(忽略\r和\n)
        /// </summary>
        /// <param name="str">文件路径（包括文件名）</param>
        /// <returns>SHA1效验码</returns>
        public static string FileStrToSHA1(string str)
        {
            String FileStr = File.ReadAllText(str);
            FileStr = FileStr.Replace("\r", "").Replace("\n", "");
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] data = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(FileStr);
            byte[] OutBytes = sha1.ComputeHash(data);
            string OutString = "";
            for (int i = 0; i < OutBytes.Length; i++)
            {
                OutString += OutBytes[i].ToString("x2");
            }
            // return OutString.ToUpper();
            return OutString.ToLower();
        }
    }
}