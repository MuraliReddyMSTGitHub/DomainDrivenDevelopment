using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers.Parsing.Extensions
{
    public static class JsonSerializationExtensions
    {
        public static T DeserializeFromJson<T>(this string input)
        {
            return JsonConvert.DeserializeObject<T>(input, new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Ignore });
        }

        public static string SerializeToJson<T>(this T input, bool indented = false)
        {
            return JsonConvert.SerializeObject(input, new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Ignore, Formatting = indented ? Formatting.Indented : Formatting.None });
        }
    }
}
