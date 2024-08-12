﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace rpg_tabel.Logic.namegenerator.names
{
    public class HalfElfNameProvider : INameProvider
    {
        private readonly string _filePath;

        public HalfElfNameProvider()
        {
            // Set the file path to Documents/RPG_Table/Tabels/Names/HalfElf/HalfElfNames.xml
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RPG_Table", "Tabels", "Names");
            _filePath = Path.Combine(directoryPath, "HalfElfNames.xml");

            // Ensure the directory and file exist, if not, create them
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(_filePath))
            {
                CreateDefaultHalfElfNamesFile();
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

        private void CreateDefaultHalfElfNamesFile()
        {
            try
            {
                var doc = new XDocument(
                    new XElement("Names",
                        new XElement("FirstNames",
                            new XElement("Name", "Aelar"),
                            new XElement("Name", "Elira"),
                            new XElement("Name", "Thalion"),
                            new XElement("Name", "Lirael"),
                            new XElement("Name", "Caelum")
                        // Add more default first names here
                        ),
                        new XElement("LastNames",
                            new XElement("Name", "Moonshadow"),
                            new XElement("Name", "Starfire"),
                            new XElement("Name", "Windrider"),
                            new XElement("Name", "Silverleaf"),
                            new XElement("Name", "Frostwind")
                        // Add more default last names here
                        )
                    )
                );

                // Save the default names XML to the specified file path
                doc.Save(_filePath);

                Console.WriteLine($"Default HalfElfNames.xml file created at {_filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating default HalfElfNames.xml file: {ex.Message}");
            }
        }
    }
}
