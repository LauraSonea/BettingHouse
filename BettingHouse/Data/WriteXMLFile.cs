﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace BettingHouse.Data
{
    class WriteXMLFile
    {
        public static void WriteToXmlFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, objectToWrite);
            }
           finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
    }
}
