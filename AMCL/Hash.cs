using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace AMCL
{
    class Hash
    {
        /// <summary>
        /// 文件SHA1校验
        /// </summary>
        /// <param name="pathName">文件路径（包括文件名）</param>
        /// <returns>文件SHA1码</returns>
        public static string GetSHA1Hash(string pathName)
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
        public static string GetMd5Hash(string pathName)
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
    }
}
