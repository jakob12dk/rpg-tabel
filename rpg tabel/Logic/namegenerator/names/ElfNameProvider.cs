using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace rpg_tabel.Logic.namegenerator.names
{
    public class ElfNameProvider : INameProvider
    {
        private readonly string _filePath;

        public ElfNameProvider()
        {
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RPG_Table", "Tabels", "Names");
            _filePath = Path.Combine(directoryPath, "ElfNames.xml");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(_filePath))
            {
                CreateDefaultElfNamesFile();
            }
        }

        public List<string> GetFirstNames()
        {
            return LoadNames("FirstNames");
        }

        public List<string> GetLastNames()
        {
            return LoadNames("LastNames");
        }

        private List<string> LoadNames(string elementName)
        {
            var names = new List<string>();

            if (!File.Exists(_filePath))
            {
                return names;
            }

            try
            {
                XDocument doc = XDocument.Load(_filePath);
                names = doc.Root.Element(elementName)
                            ?.Elements("Name")
                            .Select(e => e.Value)
                            .ToList() ?? new List<string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading names: {ex.Message}");
            }

            return names;
        }

        private void CreateDefaultElfNamesFile()
        {
            try
            {
                var doc = new XDocument(
                    new XElement("Names",
                        new XElement("FirstNames",
                            new XElement("Name", "Legolas"),
                            new XElement("Name", "Arwen"),
                            new XElement("Name", "Elrond"),
                            new XElement("Name", "Galadriel"),
                            new XElement("Name", "Thranduil")
                        // Add more default elf first names here
                        ),
                        new XElement("LastNames",
                            new XElement("Name", "Greenleaf"),
                            new XElement("Name", "Evenstar"),
                            new XElement("Name", "Halfelven"),
                            new XElement("Name", "Stormcrow"),
                            new XElement("Name", "Moonshadow")
                        // Add more default elf last names here
                        )
                    )
                );

                doc.Save(_filePath);
                Console.WriteLine($"Default ElfNames.xml file created at {_filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating default ElfNames.xml file: {ex.Message}");
            }
        }
    }
}
