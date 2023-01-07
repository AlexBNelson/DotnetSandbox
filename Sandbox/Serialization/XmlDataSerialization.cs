using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Sandbox.Serialization
{
    internal class XmlDataSerialization
    {
        public object DeserializeMatchXML()
        {
            var doc = new XmlDocument();

            doc.LoadXml("./MatchData.xml");

            XmlSerializer serializer =
      new XmlSerializer(typeof(matchdataType));

            FileStream fs = File.Create("./MatchData.xml");

            return serializer.Deserialize(fs);
        }
    }
}
