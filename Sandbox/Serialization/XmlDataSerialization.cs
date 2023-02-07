using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Sandbox.Serialization
{
    internal partial class XmlDataSerialization
    {
        public static partial void GetXMLResource(Stream resource);


        public string DeserializeMatchXML()
        {
            FileStream fs = new FileStream("C:\\Users\\alexb\\source\\repos\\Sandbox\\Sandbox\\Serialization\\MatchData.xml", FileMode.Open);


            XmlSerializer serializer =
     new XmlSerializer(typeof(matchdataType));

            var deserialized = serializer.Deserialize(fs) as matchdataType;

            fs.Dispose();


            string result;

            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames()
  .Single(str => str.EndsWith("MatchData.xml"));

            

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader streamReader = new StreamReader(stream))
            {
                GetXMLResource(stream);
                result = streamReader.ReadToEnd();
            }

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader streamReader = new StreamReader(stream))
            {
                var deserializedViaPlainStream = serializer.Deserialize(stream) as matchdataType;
                result = streamReader.ReadToEnd();
            }


            return "";
        }
    }

    partial class XmlDataSerialization
    {
        // Comment out this method and the program
        // will still compile.
        public static partial void GetXMLResource(Stream resource)
        {
            XmlReader reader = XmlReader.Create(resource);


            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        Console.Write("<{0}>", reader.Name);
                        break;
                    case XmlNodeType.Text:
                        Console.Write(reader.Value);
                        break;
                    case XmlNodeType.CDATA:
                        Console.Write("<![CDATA[{0}]]>", reader.Value);
                        break;
                    case XmlNodeType.ProcessingInstruction:
                        Console.Write("<?{0} {1}?>", reader.Name, reader.Value);
                        break;
                    case XmlNodeType.Comment:
                        Console.Write("<!--{0}-->", reader.Value);
                        break;
                    case XmlNodeType.XmlDeclaration:
                        Console.Write("<?xml version='1.0'?>");
                        break;
                    case XmlNodeType.Document:
                        break;
                    case XmlNodeType.DocumentType:
                        Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
                        break;
                    case XmlNodeType.EntityReference:
                        Console.Write(reader.Name);
                        break;
                    case XmlNodeType.EndElement:
                        Console.Write("</{0}>", reader.Name);
                        break;
                }
            }
        }
    }
}

