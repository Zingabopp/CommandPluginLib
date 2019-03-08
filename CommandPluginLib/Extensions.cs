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
        /// <summary>
        /// Serializes a MessageData into a JSON string.
        /// </summary>
        /// <param name="s">MessageData to serialize.</param>
        /// <returns>JSON string from a serialized MessageData.</returns>
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

        /// <summary>
        /// Deserializes a JSON string to a MessageData struct.
        /// </summary>
        /// <param name="d">MessageData serialized as a JSON string</param>
        /// <returns>A MessageData with the values from the JSON string.</returns>
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

        /// <summary>
        /// Attempts to add a Key/Value pair to a Dictionary. If the Key already exists and update is true, the value is changed to the provided value.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="source"></param>
        /// <param name="key"></param>
        /// <param name="value">Value to add/update</param>
        /// <param name="update">If true, updates the existing key's value.</param>
        public static void AddSafe<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue value, bool update = true)
        {
            if (!source.ContainsKey(key))
                source.Add(key, value);
            else
            {
                if (update)
                    source[key] = value;
            }
        }
    }
}
