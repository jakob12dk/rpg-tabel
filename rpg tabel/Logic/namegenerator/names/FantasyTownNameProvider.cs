using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace rpg_tabel.Logic.namegenerator.names
{
    public class FantasyTownNameProvider : INameProvider
    {
        private readonly string _filePath;

        public FantasyTownNameProvider()
        {
            // Set the file path to Documents/RPG_Table/Tabels/Names/FantasyTown/FantasyTownNames.xml
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RPG_Table", "Tabels", "Names", "FantasyTown");
            _filePath = Path.Combine(directoryPath, "FantasyTownNames.xml");

            // Ensure the directory and file exist, if not, create them
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(_filePath))
            {
                CreateDefaultFantasyTownNamesFile();
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

        private void CreateDefaultFantasyTownNamesFile()
        {
            try
            {
                var townNames = GenerateFantasyTownNames(100); // Generate 100 fantasy town names

                var doc = new XDocument(
                    new XElement("Names",
                        new XElement("FirstNames",
                            townNames.Select(name => new XElement("Name", name))
                        ),
                        new XElement("LastNames",
                            townNames.Select(name => new XElement("Name", name))
                        )
                    )
                );

                // Save the default names XML to the specified file path
                doc.Save(_filePath);

                Console.WriteLine($"Default FantasyTownNames.xml file created at {_filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating default FantasyTownNames.xml file: {ex.Message}");
            }
        }

        private List<string> GenerateFantasyTownNames(int count)
        {
            var baseNames = new List<string>
            {
                "Alder", "Briar", "Cedar", "Dew", "Elm", "Frost", "Glen", "Hollow", "Ivy", "Jade",
                "Kirk", "Lynx", "Moss", "Nettle", "Orchard", "Pine", "Quill", "Rose", "Stone", "Thorn",
                "Umber", "Vale", "Willow", "Yew", "Zephyr"
                // Add more base names here
            };

            var random = new Random();
            var names = new HashSet<string>();

            while (names.Count < count)
            {
                string name = GenerateRandomTownName(baseNames, random);
                names.Add(name);
            }

            return names.ToList();
        }

        private string GenerateRandomTownName(List<string> baseNames, Random random)
        {
            var prefix = baseNames[random.Next(baseNames.Count)];
            var suffix = baseNames[random.Next(baseNames.Count)];

            return $"{prefix}{suffix}"; // Combine prefix and suffix to form a town name
        }
    }
}
