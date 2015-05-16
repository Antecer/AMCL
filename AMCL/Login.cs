using JsonArchive;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace MineCraftLogin
{
    public class Login
    {
        private const string AuthServer = "https://authserver.mojang.com/";
        private const string Authenticate = "https://authserver.mojang.com/authenticate";
        //private const string Refresh = "https://authserver.mojang.com/refresh";
        //private const string Validate = "https://authserver.mojang.com/validate";
        //private const string Invalidate = "https://authserver.mojang.com/invalidate";
        //private const string Signout = "https://authserver.mojang.com/signout";

        public static string login(string userName, string passWord, string clientToken)
        {
            var LoginJson = new Dictionary<string, object>();
            var Agent = new Dictionary<string, object>();
            Agent.Add("name", "Minecraft");
            Agent.Add("version", "1");
            LoginJson.Add("agent", Agent);
            LoginJson.Add("username", userName);
            LoginJson.Add("password", passWord);
            LoginJson.Add("clientToken", clientToken);
            String LoginData = D2J.DictionaryToJson(LoginJson);
            Byte[] PostData = Encoding.UTF8.GetBytes(LoginData);

            HttpWebRequest httpWebRequest;
            HttpWebResponse httpWebResponse;
            try
            {
                httpWebRequest = WebRequest.Create(Authenticate) as HttpWebRequest;
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentLength = PostData.LongLength;
                Stream requestStream = httpWebRequest.GetRequestStream();
                requestStream.Write(PostData, 0, PostData.Length);//写入post信息  
                requestStream.Close();

                httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                Stream responseStream = httpWebResponse.GetResponseStream();//读取服务器响应流
                using (StreamReader resSR = new StreamReader(responseStream, Encoding.UTF8))
                {
                    LoginData = resSR.ReadToEnd();
                    resSR.Close();
                    responseStream.Close();
                }
                return LoginData;
            }
            catch (Exception)
            {
                return "false";
            }
        }
    }
}