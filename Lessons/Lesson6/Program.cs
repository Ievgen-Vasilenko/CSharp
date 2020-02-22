using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = File.OpenText("Entries.txt");

            XmlDocument xmlDoc = new XmlDocument();

            XmlDeclaration xmlDec1 = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.AppendChild(xmlDec1);

            XmlElement entriesElement = xmlDoc.CreateElement("entries");

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] fields = line.Split('|');

                XmlElement entryElement = xmlDoc.CreateElement("entry");
                entryElement.SetAttribute("type", fields[0]);

                XmlElement amountElement = xmlDoc.CreateElement("amount");
                amountElement.InnerText = fields[1];

                XmlElement dateElement = xmlDoc.CreateElement("date");
                dateElement.InnerText = fields[2];

                XmlElement descriptionElement = xmlDoc.CreateElement("description");
                XmlCDataSection cDadaDescription = xmlDoc.CreateCDataSection(fields[3]);
                descriptionElement.AppendChild(cDadaDescription);

                XmlElement categoryElement = xmlDoc.CreateElement("category");
                categoryElement.InnerText = fields[4];

                entryElement.AppendChild(amountElement);
                entryElement.AppendChild(dateElement);
                entryElement.AppendChild(descriptionElement);
                entryElement.AppendChild(categoryElement);

                entriesElement.AppendChild(entryElement);
            }

            xmlDoc.AppendChild(entriesElement);
            xmlDoc.Save("Entries.xml");

            sr.Close();
        }
    }
}
