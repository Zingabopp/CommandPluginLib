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
            return JsonConvert.SerializeObject(s);
        }

        public static MessageData ToMessageData(this string d)
        {
            return JsonConvert.DeserializeObject<MessageData>(d);
        }
    }
}
