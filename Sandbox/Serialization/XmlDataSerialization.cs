using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sandbox.Serialization
{
    internal class XmlDataSerialization
    {
        public object DeserializeMatchXML()
        {
            XmlSerializer serializer =
      new XmlSerializer(typeof(matchdataType));

            FileStream fs = File.Create("./MatchData.xml");

            return serializer.Deserialize(fs);
        }
    }
}
