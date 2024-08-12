using System;
using System.Windows.Forms;
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

       

        

        private void BtnGenerateName_Click_1(object sender, EventArgs e)
        {
            if (CBNamegerator.SelectedItem != null)
            {
                // Get the selected fantasy race
                FantasyRace selectedRace = (FantasyRace)CBNamegerator.SelectedItem;

                // Create a NameGenerator instance with the selected race
                NameGenerator nameGenerator = new NameGenerator(selectedRace);

                // Generate a name
                string generatedName = nameGenerator.GenerateName();

                // Display the generated name in the label
                LblGenerated.Text = generatedName;
            }
            else
            {
                // Handle the case where no item is selected
                MessageBox.Show("Please select a fantasy race from the dropdown.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
