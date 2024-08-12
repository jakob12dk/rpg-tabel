using System;
using System.Windows.Forms;
using System.Xml.Linq;
using rpg_tabel.Connections;
using rpg_tabel.GUI;
using rpg_tabel.Logic;
using rpg_tabel.Logic.namegenerator;

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

                if (!Directory.Exists(directoryPath))
                {
                    MessageBox.Show("NPC directory does not exist.");
                    return;
                }

                var xmlFiles = Directory.GetFiles(directoryPath, "*.xml");
                listNpc.Items.Clear();

                foreach (var file in xmlFiles)
                {
                    var doc = XDocument.Load(file);
                    var npcNameElement = doc.Descendants("Name").FirstOrDefault();

                    if (npcNameElement != null)
                    {
                        listNpc.Items.Add(npcNameElement.Value);
                    }
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
    }
}
