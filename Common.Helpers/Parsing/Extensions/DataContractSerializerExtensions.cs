using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Common.Helpers.Parsing.Extensions
{
    public static class DataContractSerializerExtensions
    {

        public static object ReadObjectFromString(this DataContractSerializer serializer, string s)
        {
            Argument.RequiresNonEmptyString("s", s);
            using (var reader = new StringReader(s))
            using (var xmlReader = XmlTextReader.Create(reader))
            {
                return serializer.ReadObject(xmlReader);
            }
        }
        /// <summary>
        /// Allows serialization of any object to xmlstring using datacontract serialzer instantiated at runtime
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeToXmlString<TIn>(this TIn obj)
        {
            Argument.RequiresNonNullValue("obj", obj);
            var serializer = new DataContractSerializer(typeof(TIn));
            using (var output = new StringWriter())
            using (var writer = new XmlTextWriter(output) { Formatting = Formatting.Indented })
            {
                serializer.WriteObject(writer, obj);
                return output.GetStringBuilder().ToString();
            }
        }


        public static TOut DeserializeFromXml<TOut>(this string xmlString)
        {
            Argument.RequiresNonNullValue("xmlString", xmlString);
            var serializer = new DataContractSerializer(typeof(TOut));
            return (TOut)serializer.ReadObjectFromString(xmlString);
        }
    }
}
