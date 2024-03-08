using System;
using System.Xml;
using System.IO;

namespace NewbInjector
{
    class Config
    {
        public static string cfgPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Newb\\Injector\\config.xml");

        // Read XML File
        public static string readXML(string attribute)
        {
            XmlDocument reader = new XmlDocument();
            reader.Load(cfgPath);

            XmlNode node = reader.DocumentElement.SelectSingleNode("/Injector/" + attribute);
            string value = node.InnerText;

            return value;
        }


        // Write XML File
        public static void writeXML(string value, string attribute)
        {
            XmlDocument writer = new XmlDocument();
            writer.Load(cfgPath);

            XmlNode node = writer.DocumentElement.SelectSingleNode("/Injector/" + attribute);
            node.FirstChild.Value = value;

            writer.Save(cfgPath);
        }
    }
}
