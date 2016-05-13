using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using BettingHouse.Models;
using BettingHouse.Data;
using System.IO;

namespace BettingHouse.Data
{
    public class WriteJsonFile
    {

        public static void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite, Formatting.Indented);
            File.WriteAllText(filePath, contentsToWriteToFile);
        }
    }
}

   

