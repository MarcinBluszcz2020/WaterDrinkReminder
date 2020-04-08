using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Microsoft.VisualBasic.CompilerServices;

namespace WaterDrinkReminder
{
    public class FileHelper
    {
        /// <summary>
        /// Saves to an xml file
        /// </summary>
        /// <param name="fileName">File path of the new xml file</param>
        public static void Save<T>(T objectToSave, string fileName)
        {
            using (var writer = new System.IO.StreamWriter(fileName))
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, objectToSave);
                writer.Flush();
            }
        }

        public static bool FileExists(string fileName)
        {
            return File.Exists(fileName);
        }

        /// <summary>
        /// Load an object from an xml file
        /// </summary>
        /// <param name="FileName">Xml file name</param>
        /// <returns>The object created from the xml file</returns>
        public static T Load<T>(string FileName) where T : class
        {
            using (var stream = System.IO.File.OpenRead(FileName))
            {
                var serializer = new XmlSerializer(typeof(T));
                return serializer.Deserialize(stream) as T;
            }
        }

    }
}
