using rpg_tabel.Logic.namegenerator;
using rpg_tabel.Logic.NpcGenerator.npcs;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace rpg_tabel.GUI
{
    public partial class NpcEditorForm : Form
    {
        private DataTable _npcDataTable;
        private NPC _npc;

        public NpcEditorForm()
        {
            InitializeComponent();
            InitializeNpcDataTable();
        }

        private void InitializeNpcDataTable()
        {
            _npcDataTable = new DataTable();
            _npcDataTable.Columns.Add("Attribute", typeof(string));
            _npcDataTable.Columns.Add("Value", typeof(string));

            dataGridViewNpc.DataSource = _npcDataTable;
        }

        private void PopulateNpcData(NPC npc)
        {
            _npcDataTable.Rows.Clear();

            _npcDataTable.Rows.Add("Name", npc.Name);
            _npcDataTable.Rows.Add("Race", npc.Race.ToString());
            _npcDataTable.Rows.Add("Class", npc.Class.ToString());
            _npcDataTable.Rows.Add("Background", npc.Background.ToString());
            _npcDataTable.Rows.Add("Alignment", npc.Alignment.ToString());

            foreach (var ability in npc.AbilityScores)
            {
                _npcDataTable.Rows.Add(ability.Key.ToString(), ability.Value.ToString());
            }

            foreach (var skill in npc.Skills)
            {
                _npcDataTable.Rows.Add(skill.Key.ToString(), skill.Value.ToString());
            }

            _npcDataTable.Rows.Add("Armor Class", npc.ArmorClass.ToString());
            _npcDataTable.Rows.Add("Hit Points", npc.HitPoints.ToString());
            _npcDataTable.Rows.Add("Speed", npc.Speed.ToString());

            _npcDataTable.Rows.Add("Personality", npc.Personality);
            _npcDataTable.Rows.Add("Backstory", npc.Backstory);
            _npcDataTable.Rows.Add("Appearance", npc.Appearance);
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            var npcGenerator = new NpcGenerator(new NameGenerator());
            _npc = npcGenerator.GenerateNpc("Generated Name");

            // Example of setting additional properties
            _npc.Personality = "Brave and honorable.";
            _npc.Backstory = "A former soldier who now seeks justice.";
            _npc.Appearance = "Tall, muscular, with red scales.";

            PopulateNpcData(_npc);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (_npc == null)
            {
                MessageBox.Show("Please generate an NPC first.");
                return;
            }

            try
            {
                string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RPG_Table", "Npcs");

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string filePath = Path.Combine(directoryPath, $"{_npc.Name}.xml");

                var doc = new XDocument(
                    new XElement("NPC",
                        new XElement("Name", _npc.Name),
                        new XElement("Race", _npc.Race.ToString()),
                        new XElement("Class", _npc.Class.ToString()),
                        new XElement("Background", _npc.Background.ToString()),
                        new XElement("Alignment", _npc.Alignment.ToString()),
                        new XElement("AbilityScores",
                            from ability in _npc.AbilityScores
                            select new XElement(ability.Key.ToString(), ability.Value)
                        ),
                        new XElement("Skills",
                            from skill in _npc.Skills
                            select new XElement(skill.Key.ToString(), skill.Value)
                        ),
                        new XElement("ArmorClass", _npc.ArmorClass),
                        new XElement("HitPoints", _npc.HitPoints),
                        new XElement("Speed", _npc.Speed),
                        new XElement("Personality", _npc.Personality),
                        new XElement("Backstory", _npc.Backstory),
                        new XElement("Appearance", _npc.Appearance)
                    )
                );

                doc.Save(filePath);
                MessageBox.Show($"NPC saved successfully to {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving NPC: {ex.Message}");
            }
        }

        private DataGridView dataGridViewNpc;
        private Button btnGenerate;
        private Button btnSave;
    }
}
