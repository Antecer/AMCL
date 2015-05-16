using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Text;

namespace JsonArchive
{
    public class J2D
    {
        /// <summary>
        /// 将Json数据反序列化为Dictionary字典
        /// </summary>
        /// <param name="jsonData">json数据</param>
        /// <returns></returns>
        public static Dictionary<string, object> JsonToDictionary(string jsonData)
        {
            //实例化JavaScriptSerializer类的新实例
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
        public static string DictionaryToJson(Dictionary<string, object> dictionary)
        {
            //实例化JavaScriptSerializer类的新实例
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                return jss.Serialize(dictionary);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
