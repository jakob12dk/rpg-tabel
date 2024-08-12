using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace rpg_tabel.Logic
{
    public class SettingsEditor
    {
        private readonly string _filePath;
        private readonly string _fileName = "settings.xml";

        // Constructor
        public SettingsEditor()
        {
            // Set the directory to Documents/RPG_Table
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RPG_Table");

            // Ensure the directory exists, if not, create it
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Set the full file path
            _filePath = Path.Combine(directoryPath, _fileName);

            // Ensure the file exists, if not, create it with default settings
            if (!File.Exists(_filePath))
            {
                CreateDefaultSettingsFile();
            }
        }

        // Method to create a default settings file if it doesn't exist
        private void CreateDefaultSettingsFile()
        {
            var defaultSettings = new Dictionary<string, string>
            {
                { "Username", "admin" },
                { "Password", "admin" },
                { "DeviceID", "1234" },
                { "ProductID", "5678" },
                { "OtherSetting1", "Value1" },
                { "OtherSetting2", "Value2" }
            };

            SaveSettings(defaultSettings);
        }

        // Method to load settings from XML file
        public Dictionary<string, string> LoadSettings()
        {
            var settings = new Dictionary<string, string>();

            if (!File.Exists(_filePath))
            {
                Console.WriteLine($"File not found: {_filePath}");
                return settings; // Return empty dictionary if file does not exist
            }

            try
            {
                // Load XML document
                XDocument doc = XDocument.Load(_filePath);

                // Parse XML elements and add to dictionary
                foreach (var element in doc.Root.Elements())
                {
                    settings[element.Name.LocalName] = element.Value;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading settings: {ex.Message}");
            }

            return settings;
        }

        // Method to save settings to XML file
        public void SaveSettings(Dictionary<string, string> settings)
        {
            try
            {
                var doc = new XDocument(
                    new XElement("Settings",
                        from kvp in settings
                        select new XElement(kvp.Key, kvp.Value)
                    )
                );

                // Save XML document to file
                doc.Save(_filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving settings: {ex.Message}");
            }
        }

        // Method to get the value of a specific setting
        public string GetSettingValue(string settingName)
        {
            if (!File.Exists(_filePath))
            {
                Console.WriteLine($"File not found: {_filePath}");
                return null; // File does not exist
            }

            try
            {
                // Load XML document
                XDocument doc = XDocument.Load(_filePath);

                // Find the setting element by name
                var element = doc.Root.Element(settingName);

                // Return the value if found, otherwise return null
                return element?.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving setting value: {ex.Message}");
                return null;
            }
        }

        // Method to get the username
        public string GetUsername()
        {
            return GetSettingValue("Username");
        }

        // Method to get the password
        public string GetPassword()
        {
            return GetSettingValue("Password");
        }

        // Method to get all settings for DataGridView
        public List<Tuple<string, string>> GetAllSettings()
        {
            var settings = new List<Tuple<string, string>>();

            if (!File.Exists(_filePath))
            {
                Console.WriteLine($"File not found: {_filePath}");
                return settings; // Return empty list if file does not exist
            }

            try
            {
                // Load XML document
                XDocument doc = XDocument.Load(_filePath);

                // Parse XML elements and add to list
                settings = doc.Root.Elements()
                    .Select(element => new Tuple<string, string>(element.Name.LocalName, element.Value))
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving all settings: {ex.Message}");
            }

            return settings;
        }
    }
}
