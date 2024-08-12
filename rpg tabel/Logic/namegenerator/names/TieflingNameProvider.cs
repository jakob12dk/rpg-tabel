using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace rpg_tabel.Logic.namegenerator.names
{
    public class TieflingNameProvider : INameProvider
    {
        private readonly string _filePath;

        public TieflingNameProvider()
        {
            // Set the file path to Documents/RPG_Table/Tabels/Names/Tiefling/TieflingNames.xml
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RPG_Table", "Tabels", "Names");
            _filePath = Path.Combine(directoryPath, "TieflingNames.xml");

            // Ensure the directory and file exist, if not, create them
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(_filePath))
            {
                CreateDefaultTieflingNamesFile();
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
                return names; // Return an empty list if the file does not exist
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
                // Handle exceptions as needed, such as logging the error
                Console.WriteLine($"Error loading names: {ex.Message}");
            }

            return names;
        }

        private void CreateDefaultTieflingNamesFile()
        {
            try
            {
                var doc = new XDocument(
                    new XElement("Names",
                        new XElement("FirstNames",
                            new XElement("Name", "Azazel"),
                            new XElement("Name", "Balthazar"),
                            new XElement("Name", "Lilith"),
                            new XElement("Name", "Mordecai"),
                            new XElement("Name", "Selene")
                        // Add more default first names here
                        ),
                        new XElement("LastNames",
                            new XElement("Name", "Darkflame"),
                            new XElement("Name", "Hellfire"),
                            new XElement("Name", "Nightshade"),
                            new XElement("Name", "Shadowborn"),
                            new XElement("Name", "Stormbringer")
                        // Add more default last names here
                        )
                    )
                );

                // Save the default names XML to the specified file path
                doc.Save(_filePath);

                Console.WriteLine($"Default TieflingNames.xml file created at {_filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating default TieflingNames.xml file: {ex.Message}");
            }
        }
    }
}
