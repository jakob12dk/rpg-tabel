using System;
using System.Windows.Forms;
using System.Xml.Linq;
using rpg_tabel.Connections;
using rpg_tabel.GUI;
using rpg_tabel.Logic;
using rpg_tabel.Logic.namegenerator;
using rpg_tabel.Logic.NpcGenerator.npcs;
using rpg_tabel.Logic.NpcGenerator;

namespace rpg_tabel
{
    public partial class Main : Form
    {




        private void button1_Click(object sender, EventArgs e)
        {
            using (var settingsDialog = new SettingsDialog())
            {
                if (settingsDialog.ShowDialog() == DialogResult.OK)
                {
                    // Handle successful settings update if needed
                }
            }
        }



        private void LoadNpcNames()
        {
            try
            {
                string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RPG_Table", "Npcs");

                // Check if the directory exists
                if (!Directory.Exists(directoryPath))
                {
                    MessageBox.Show("NPC directory does not exist.");
                    return;
                }

                // Get all XML files in the directory
                var xmlFiles = Directory.GetFiles(directoryPath, "*.xml");
                listNpc.Items.Clear();

                foreach (var file in xmlFiles)
                {
                    // Load the XML document
                    var doc = XDocument.Load(file);

                    // Find the NPC name element
                    var npcNameElement = doc.Descendants("Name").FirstOrDefault();

                    if (npcNameElement != null)
                    {
                        // Add the NPC name to the list
                        listNpc.Items.Add(npcNameElement.Value);
                    }
                    else
                    {
                        MessageBox.Show($"No <Name> element found in file: {file}");
                    }
                }

                if (listNpc.Items.Count == 0)
                {
                    MessageBox.Show("No NPCs found in the directory.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading NPC names: {ex.Message}");
            }
        }

        private void BtnGenerateName_Click_1(object sender, EventArgs e)
        {
            if (CBNamegerator.SelectedItem != null)
            {
                // Get the selected fantasy race
                FantasyRace selectedRace = (FantasyRace)CBNamegerator.SelectedItem;

                // Create a NameGenerator instance with the selected race
                NameGenerator nameGenerator = new NameGenerator();

                // Generate a name
                string generatedName = nameGenerator.GenerateName(selectedRace);

                // Display the generated name in the label
                LblGenerated.Text = generatedName;
            }
            else
            {
                // Handle the case where no item is selected
                MessageBox.Show("Please select a fantasy race from the dropdown.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnNewNpc_Click(object sender, EventArgs e)
        {
            var npcEditorForm = new NpcEditorForm();
            npcEditorForm.ShowDialog();
        }

        private void listNpc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listNpc.SelectedItem != null)
            {
                string selectedNpcName = listNpc.SelectedItem.ToString();
                OpenNpcEditor(selectedNpcName);
            }
        }
        private void OpenNpcEditor(string npcName)
        {
            try
            {
                // Define the path to the NPC directory and file
                string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RPG_Table", "Npcs");
                string filePath = Path.Combine(directoryPath, $"{npcName}.xml");

                // Check if the NPC file exists
                if (!File.Exists(filePath))
                {
                    MessageBox.Show($"NPC file not found: {npcName}");
                    return;
                }

                // Load the NPC data from the XML file
                var doc = XDocument.Load(filePath);
                var npc = new NPC
                {
                    Name = doc.Root.Element("Name")?.Value,
                    Race = Enum.TryParse(doc.Root.Element("Race")?.Value, out FantasyRace race) ? race : default,
                    Class = Enum.TryParse(doc.Root.Element("Class")?.Value, out NPCClass npcClass) ? npcClass : default,
                    Background = Enum.TryParse(doc.Root.Element("Background")?.Value, out Background background) ? background : default,
                    Alignment = Enum.TryParse(doc.Root.Element("Alignment")?.Value, out Alignment alignment) ? alignment : default,
                    AbilityScores = doc.Root.Element("AbilityScores")
                                 .Elements()
                                 .ToDictionary(e => Enum.TryParse(e.Name.LocalName, out Ability ability) ? ability : default, e => int.Parse(e.Value)),
                    Skills = doc.Root.Element("Skills")
                              .Elements()
                              .ToDictionary(e => Enum.TryParse(e.Name.LocalName, out Skill skill) ? skill : default, e => int.Parse(e.Value)),
                    ArmorClass = int.Parse(doc.Root.Element("ArmorClass")?.Value ?? "0"),
                    HitPoints = int.Parse(doc.Root.Element("HitPoints")?.Value ?? "0"),
                    Speed = int.Parse(doc.Root.Element("Speed")?.Value ?? "0"),
                    Personality = doc.Root.Element("Personality")?.Value,
                    Backstory = doc.Root.Element("Backstory")?.Value,
                    Appearance = doc.Root.Element("Appearance")?.Value
                };

                // Open the NPC editor form with the selected NPC
                var npcEditorForm = new NpcEditorForm(npc);
                npcEditorForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening NPC editor: {ex.Message}");
            }
        }
        private async void btnLoadMethods_Click(object sender, EventArgs e)
        {
            if (_arduinoConnection == null || !_arduinoConnection.IsConnected)
            {
                MessageBox.Show("Not connected to Arduino.");
                return;
            }

            try
            {
                var methods = await Task.Run(() => _arduinoConnection.GetAvailableMethods());

                listArduinoMethods.Items.Clear();
                foreach (var method in methods)
                {
                    listArduinoMethods.Items.Add(method);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving methods: {ex.Message}");
            }
        }

        private void ListArduinoMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listArduinoMethods.SelectedItem != null)
            {
                string selectedMethod = listArduinoMethods.SelectedItem.ToString();
                try
                {
                    _arduinoConnection.CallMethod(selectedMethod);
                    MessageBox.Show($"Called method: {selectedMethod}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error calling method: {ex.Message}");
                }
            }
        }

    }
}
