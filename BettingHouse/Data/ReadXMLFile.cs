using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace BettingHouse.Data
{
    class ReadXMLFile
    {
        public static T ReadFromXmlFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                reader = new StreamReader(filePath);
                return (T)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
