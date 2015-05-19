using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace JsonArchive
{
    public class J2D
    {
        /// <summary>
        /// 将Json数据反序列化为Dictionary字典
        /// </summary>
        /// <param name="jsonData">json数据</param>
        /// <returns>Dictionary字典</returns>
        public static Dictionary<string, object> JsonToDictionary(string jsonData)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                //将指定的 JSON 字符串转换为 Dictionary<string, object> 类型的对象
                return jss.Deserialize<Dictionary<string, object>>(jsonData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    public class D2J
    {
        /// <summary>
        /// 将Dictionary字典序列化为Json数据
        /// </summary>
        /// <param name="dictionary">Dictionary字典</param>
        /// <returns>Json数据</returns>
        public static string DictionaryToJson(Dictionary<string, object> dictionary)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                String Tjson = jss.Serialize(dictionary);
                Tjson = Tjson.Replace("[{", "[\r{").Replace("}]", "}\r]").Replace("{\"", "{\r\"").Replace("}", "\r}");
                Tjson = Tjson.Replace("\",", "\",\r").Replace("},", "},\r").Replace("],", "],\r");
                String linesign = "";
                for (int n = 0; n < Tjson.Length; n++)
                {
                    if (Tjson[n] == '\r' && Tjson[n - 1] == '{') linesign = linesign + "    ";
                    else if (Tjson[n] == '\r' && Tjson[n - 1] == '[') linesign = linesign + "    ";
                    else if (Tjson[n] == '\r' && Tjson[n + 1] == ']') linesign = linesign.Remove(0, 4);
                    else if (Tjson[n] == '\r' && Tjson[n + 1] == '}') linesign = linesign.Remove(0, 4);
                    if (Tjson[n] == '\r')
                    {
                        Tjson = Tjson.Insert(n + 1, "\n" + linesign);
                        n = n + linesign.Length + 1;
                    }
                }
                return Tjson;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}