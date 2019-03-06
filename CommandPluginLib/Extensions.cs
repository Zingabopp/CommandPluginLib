using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandPluginLib;
using Newtonsoft.Json;

namespace CommandPluginLib
{
    public static class Extensions
    {
        public static string ToJSON(this MessageData s)
        {
            try
            {
                return JsonConvert.SerializeObject(s);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error trying to serialize MessageData:\n{s.ToString(3)}\n{ex.Message}\n{ex.StackTrace}");
                return "";
            }
        }

        public static MessageData ToMessageData(this string d)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageData>(d);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error trying to serialize MessageData:\n{d}");
                throw ex;
            }
            
        }
    }
}
