using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace rpg_tabel.Logic.namegenerator.names
{
    public class DwarfNameProvider : INameProvider
    {
        private readonly string _filePath;

        public DwarfNameProvider()
        {
            // Set the file path to Documents/RPG_Table/Tabels/Names/Dwarf/DwarfNames.xml
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RPG_Table", "Tabels", "Names");
            _filePath = Path.Combine(directoryPath, "DwarfNames.xml");

            // Ensure the directory and file exist, if not, create them
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(_filePath))
            {
                CreateDefaultDwarfNamesFile();
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

        private void CreateDefaultDwarfNamesFile()
        {
            try
            {
                // Define a list of 100 first names
                var firstNames = new[]
                {
            "Borin", "Dori", "Thrain", "Kili", "Gimli", "Balin", "Oin", "Gloin", "Farin", "Dwalin",
            "Bofur", "Bombur", "Dain", "Thorin", "Grimli", "Krag", "Nori", "Ori", "Rurik", "Drog",
            "Keldor", "Brogar", "Harn", "Grogan", "Thark", "Kragan", "Rurik", "Varg", "Thrain", "Nar",
            "Grim", "Borin", "Einar", "Farin", "Marn", "Rorik", "Grun", "Jorik", "Korin", "Haldor",
            "Bjar", "Harkin", "Goran", "Lodin", "Korin", "Harik", "Bodvar", "Torin", "Thar", "Rokar",
            "Myr", "Sten", "Dorrin", "Hjor", "Brok", "Torr", "Gorrim", "Kragor", "Derrik", "Sorin",
            "Kaldur", "Rond", "Grimbold", "Haldar", "Thorin", "Krond", "Baldor", "Gorim", "Mord", "Berg",
            "Ragnor", "Halgar", "Throk", "Vorn", "Lund", "Baldric", "Rorin", "Gorm", "Haldon", "Tarl",
            "Bram", "Thorik", "Thorr", "Drek", "Yar", "Naldor", "Bren", "Thorim", "Hrogar", "Keldor"
        };

                // Define a list of 100 last names
                var lastNames = new[]
                {
            "Ironfist", "Stonefoot", "Hammerbeard", "Bronzebeard", "Forgehammer", "Grimforge", "Oakenshield", "Dwarfson", "Stoneheart", "Thunderfist",
            "Blackstone", "Anvilhammer", "Steelclad", "Brassforge", "Deepdelver", "Stonehelm", "Goldgrip", "Rockshear", "Ironbane", "Frostbeard",
            "Rockfist", "Grimstone", "Stormbreaker", "Ironshield", "Fireforge", "Gritstone", "Earthshaker", "Dwarfhammer", "Trollbane", "Stonegrip",
            "Emberforge", "Stormhelm", "Steelbeard", "Thunderridge", "Goldforge", "Deepstone", "Frostforge", "Ragefist", "Ironfist", "Dwarfson", "Rook",
            "Bronzeshield", "Rockforge", "Grimhelm", "Thundermane", "Ironheart", "Blackforge", "Ravenstone", "Flameforge", "Stonebane", "Deepforge",
            "Ironthorn", "Stonebrand", "Frosthelm", "Gritforge", "Thunderstone", "Firestone", "Grimhammer", "Forgeheart", "Stonehelm", "Stormstone",
            "Brassbeard", "Firefist", "Emberstone", "Goldbeard", "Rockhelm", "Rageforge", "Ironstone", "Dwarfhelm", "Steelstone", "Froststone",
            "Grimbeard", "Deepforge", "Flameheart", "Stormforge", "Bronzeheart", "Grimshield", "Ironhelm", "Thunderforge", "Stonehammer", "Goldstone"
        };

                var doc = new XDocument(
                    new XElement("Names",
                        new XElement("FirstNames",
                            firstNames.Select(name => new XElement("Name", name))
                        ),
                        new XElement("LastNames",
                            lastNames.Select(name => new XElement("Name", name))
                        )
                    )
                );

                // Save the default names XML to the specified file path
                doc.Save(_filePath);

                Console.WriteLine($"Default DwarfNames.xml file created at {_filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating default DwarfNames.xml file: {ex.Message}");
            }
        }
    }
