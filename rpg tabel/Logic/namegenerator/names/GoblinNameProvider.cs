using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace rpg_tabel.Logic.namegenerator.names
{
    public class GoblinNameProvider : INameProvider
    {
        private readonly string _filePath;

        public GoblinNameProvider()
        {
            // Set the file path to Documents/RPG_Table/Tabels/Names/Goblin/GoblinNames.xml
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RPG_Table", "Tabels", "Names", "Goblin");
            _filePath = Path.Combine(directoryPath, "GoblinNames.xml");

            // Ensure the directory and file exist, if not, create them
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(_filePath))
            {
                CreateDefaultGoblinNamesFile();
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

        private void CreateDefaultGoblinNamesFile()
        {
            try
            {
                var doc = new XDocument(
                    new XElement("Names",
                        new XElement("FirstNames",
                            GenerateNameElements(new[]
                            {
                                "Grizzle", "Snaggle", "Bark", "Mog", "Zog",
                                "Ruk", "Blagg", "Skrunt", "Glim", "Nok",
                                "Drek", "Skarn", "Krag", "Murl", "Trog",
                                "Zar", "Bort", "Nok", "Grub", "Mork",
                                "Dug", "Frog", "Rug", "Gnar", "Zerk",
                                "Krosh", "Drog", "Fling", "Rask", "Brug",
                                "Zrek", "Jurk", "Krog", "Skrag", "Zug",
                                "Murk", "Fang", "Ruk", "Blix", "Grum",
                                "Trog", "Brak", "Warr", "Lug", "Zig",
                                "Dorg", "Kruk", "Mog", "Skulk", "Brak",
                                "Gorp", "Zok", "Zarg", "Drek", "Blak",
                                "Razz", "Trek", "Skrunk", "Wok", "Nork",
                                "Ruk", "Skazz", "Grok", "Trog", "Gragg",
                                "Krak", "Snag", "Mog", "Ruk", "Zogg"
                            }),
                            GenerateNameElements(new[]
                            {
                                "Snot", "Gnar", "Stinkfoot", "Skulk", "Razor",
                                "Blight", "Gnash", "Muck", "Scrap", "Tusk",
                                "Crank", "Grub", "Moss", "Dreg", "Gloom",
                                "Stink", "Muck", "Fester", "Rime", "Ruck",
                                "Skulk", "Vile", "Zik", "Rubble", "Murk",
                                "Grim", "Hag", "Scum", "Spite", "Drek",
                                "Stomp", "Scrag", "Gnarl", "Rubbish", "Bane",
                                "Sputter", "Moss", "Gristle", "Krunk", "Crust",
                                "Vile", "Grub", "Skrunch", "Murk", "Scum",
                                "Grizzle", "Bork", "Ruck", "Squeak", "Dreg",
                                "Gnar", "Scrap", "Thorn", "Gloam", "Grind",
                                "Krag", "Gnash", "Ruk", "Fester", "Gloom",
                                "Moss", "Rime", "Zog", "Rubble", "Skit"
                            })
                        ),
                        new XElement("LastNames",
                            GenerateNameElements(new[]
                            {
                                "Snot", "Gnar", "Stinkfoot", "Skulk", "Razor",
                                "Blight", "Gnash", "Muck", "Scrap", "Tusk",
                                "Crank", "Grub", "Moss", "Dreg", "Gloom",
                                "Stink", "Muck", "Fester", "Rime", "Ruck",
                                "Skulk", "Vile", "Zik", "Rubble", "Murk",
                                "Grim", "Hag", "Scum", "Spite", "Drek",
                                "Stomp", "Scrag", "Gnarl", "Rubbish", "Bane",
                                "Sputter", "Moss", "Gristle", "Krunk", "Crust",
                                "Vile", "Grub", "Skrunch", "Murk", "Scum",
                                "Grizzle", "Bork", "Ruck", "Squeak", "Dreg",
                                "Gnar", "Scrap", "Thorn", "Gloam", "Grind",
                                "Krag", "Gnash", "Ruk", "Fester", "Gloom",
                                "Moss", "Rime", "Zog", "Rubble", "Skit",
                                "Scrap", "Gloom", "Thorn", "Rime", "Zik"
                            })
                        )
                    )
                );

                // Save the default names XML to the specified file path
                doc.Save(_filePath);

                Console.WriteLine($"Default GoblinNames.xml file created at {_filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating default GoblinNames.xml file: {ex.Message}");
            }
        }

        private IEnumerable<XElement> GenerateNameElements(IEnumerable<string> names)
        {
            return names.Select(name => new XElement("Name", name));
        }
    }
}
