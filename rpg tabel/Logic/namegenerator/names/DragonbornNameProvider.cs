using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace rpg_tabel.Logic.namegenerator.names
{
    public class DragonbornNameProvider : INameProvider
    {
        private readonly string _filePath;

        public DragonbornNameProvider()
        {
            // Set the file path to Documents/RPG_Table/Tabels/Names/Dragonborn/DragonbornNames.xml
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RPG_Table", "Tabels", "Names");
            _filePath = Path.Combine(directoryPath, "DragonbornNames.xml");

            // Ensure the directory and file exist, if not, create them
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(_filePath))
            {
                CreateDefaultDragonbornNamesFile();
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

        private void CreateDefaultDragonbornNamesFile()
        {
            try
            {
                // Define a list of 100 first names
                var firstNames = new[]
                {
            "Arjhan", "Balasar", "Drogon", "Kava", "Mehen", "Rathos", "Zarvok", "Karn", "Yarvok", "Tharion",
            "Orin", "Volar", "Kethar", "Merrik", "Talos", "Drakar", "Korath", "Gorin", "Falan", "Jorik",
            "Varek", "Harth", "Kron", "Rengar", "Talon", "Vorik", "Grimor", "Marek", "Koran", "Varric",
            "Larik", "Zorin", "Tarek", "Ragan", "Morth", "Khalis", "Zaric", "Haar", "Karth", "Rokar",
            "Gorath", "Varek", "Draken", "Shor", "Rovan", "Toran", "Valin", "Zorath", "Kral", "Thorin",
            "Narek", "Galar", "Kaldor", "Rorik", "Vorn", "Kavak", "Malthor", "Theron", "Varis", "Doran",
            "Brax", "Druan", "Jorath", "Eldrin", "Raxos", "Garr", "Thorik", "Haldor", "Narek", "Rorik",
            "Vorath", "Varn", "Aldrin", "Zarion", "Rurik", "Varak", "Galan", "Harkin", "Neric", "Korin"
        };

                // Define a list of 100 last names
                var lastNames = new[]
                {
            "Tharashk", "Krin", "Khar", "Varyx", "Rhasha", "Drakon", "Grimblade", "Ironfist", "Stormheart", "Frostclaw",
            "Steelwind", "Thunderstrike", "Bloodfang", "Darkflame", "Firestorm", "Shadowbane", "Stormbringer", "Ravencrest", "Stonefist", "Gloomrider", "Moonshadow",
            "Dragonfire", "Goldscale", "Nightstalker", "Ironclaw", "Sunblade", "Wolfbane", "Brightforge", "Stormrider", "Duskfall", "Winterbloom",
            "Silverwind", "Bloodstone", "Darkthorn", "Emberforge", "Ironbark", "Starfire", "Wraithblade", "Frostfang", "Fireclaw", "Thunderclap", "Shadowstrike",
            "Stormbreaker", "Dragoncrest", "Moonfury", "Steelheart", "Winterborn", "Stonecrusher", "Sunshard", "Nightfire", "Bloodmoon", "Ironfang",
            "Emberstorm", "Stormclaw", "Darkfire", "Frostbane", "Silverfang", "Bloodstorm", "Shadowflame", "Goldheart", "Nightblade", "Sunflare", "Moonstone",
            "Ironshadow", "Fireclaw", "Stoneforge", "Stormfang", "Frostfire", "Shadowflame", "Moonblade", "Darkstorm", "Emberclaw", "Thunderheart", "Dragonshadow",
            "Winterfire", "Steelshadow", "Bloodflare", "Nightstorm", "Frostheart", "Stormmoon", "Shadowfang", "Ironstorm", "Emberblade", "Moonflare", "Fireheart",
            "Darkfang", "Sunstone", "Silverstorm", "Nightshade", "Frostshadow", "Thunderblade", "Stormshadow", "Bloodflare", "Shadowmoon", "Ironstorm"
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

                Console.WriteLine($"Default DragonbornNames.xml file created at {_filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating default DragonbornNames.xml file: {ex.Message}");
            }
        }
    }
}
