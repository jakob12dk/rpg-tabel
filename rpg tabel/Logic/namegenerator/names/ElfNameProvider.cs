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
                // Define a list of 100 first names
                var firstNames = new[]
                {
                    "Legolas", "Arwen", "Elrond", "Galadriel", "Thranduil", "Erestor", "Celeborn", "Gandalf", "Lúthien", "Idril",
                    "Finrod", "Fingolfin", "Turgon", "Gwindor", "Gildor", "Haldir", "Eöl", "Círdan", "Aredhel", "Maeglin",
                    "Glorfindel", "Nimrodel", "Oropher", "Eöl", "Lindir", "Amras", "Amrod", "Curufin", "Celegorm", "Rúmil",
                    "Fëanor", "Húrin", "Melian", "Finduilas", "Lúthien", "Lórien", "Míriel", "Nerdanel", "Varda", "Yavanna",
                    "Eönwë", "Taniquetil", "Galadrielle", "Eruanna", "Galandriel", "Eowyn", "Finarfin", "Eldar", "Ailin", "Aranel",
                    "Arathorn", "Galdor", "Gondor", "Faramir", "Eldarion", "Arweniel", "Eldor", "Elanor", "Elendir", "Elostirion",
                    "Lorien", "Elme", "Maeron", "Lúthion", "Gondoriel", "Fíriel", "Eru", "Eldarion", "Elwen", "Galadorn",
                    "Arathor", "Isildur", "Eldarion", "Haldor", "Gweneth", "Melwas", "Finrodiel", "Aulë", "Yavannamírë", "Lúthien"
                };

                // Define a list of 100 last names
                var lastNames = new[]
                {
                    "Greenleaf", "Evenstar", "Halfelven", "Stormcrow", "Moonshadow", "Silvermoon", "Starfire", "Brightblade", "Shadowfax", "Swiftfoot",
                    "Highborn", "Winterlight", "Starwind", "Frostleaf", "Dewfall", "Dawnblade", "Sunshadow", "Dreamweaver", "Skywalker", "Windrider",
                    "Gildedleaf", "Sunfire", "Shadowmoon", "Starflame", "Moonlight", "Brightstar", "Eagleclaw", "Nightfall", "Dewwind", "Winterstone",
                    "Crystalheart", "Silverleaf", "Frostwind", "Shadowdancer", "Sunrise", "Starshine", "Moonbeam", "Brightmoon", "Silverstar", "Eagleeye",
                    "Dawnstar", "Snowfall", "Starflame", "Silvershadow", "Wintermoon", "Gildedmoon", "Sunflare", "Shadowlight", "Windstorm", "Skyfire",
                    "Nightwind", "Dewstone", "Brightwind", "Crystalmoon", "Frostflame", "Eagleblade", "Sunbeam", "Dewmoon", "Winterflare", "Starwind",
                    "Moonshadow", "Snowstorm", "Crystalflare", "Brightlight", "Gildedstar", "Shadowfire", "Winterdawn", "Eaglewind", "Sunlight", "Starshadow",
                    "Frostblade", "Dewshine", "Brightstone", "Silversun", "Eagleflare", "Shadowstar", "Winterwind", "Moonflare", "Crystalstar", "Sunstorm",
                    "Gildedshadow", "Nightstar", "Brightshadow", "Dewlight", "Silverwind", "Frostheart", "Gildedwind", "Moonfire", "Eaglemoon", "Snowflake"
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
