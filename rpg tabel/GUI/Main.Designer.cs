using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using rpg_tabel.Connections; // Ensure this namespace is correct
using rpg_tabel.GUI;
using rpg_tabel.Logic;
using rpg_tabel.Logic.namegenerator;
using rpg_tabel.Logic.namegenerator.names; // Ensure this namespace is correct

namespace rpg_tabel
{
    public partial class Main : Form
    {
        private readonly SettingsEditor _settingsEditor;
        private readonly UsbSearch _usbSearch;
        private readonly ArduinoConnection _arduinoConnection;
        private readonly NameGenerator _nameGenerator;
        private string _connectedPortName;

        // Dictionary to hold name providers
        private readonly Dictionary<FantasyRace, INameProvider> _nameProviders;

        public Main()
        {
            InitializeComponent();

            // Initialize dependencies
            _settingsEditor = new SettingsEditor(); // Make sure this path is correct
            _usbSearch = new UsbSearch(_settingsEditor);
            _arduinoConnection = new ArduinoConnection();
            _nameGenerator = new NameGenerator();

            // Initialize name providers
            _nameProviders = new Dictionary<FantasyRace, INameProvider>
            {
                { FantasyRace.Human, new HumanNameProvider() },
                { FantasyRace.Elf, new ElfNameProvider() },
                { FantasyRace.Dwarf, new DwarfNameProvider() },
                { FantasyRace.Orc, new OrcNameProvider() },
                { FantasyRace.Goblin, new GoblinNameProvider() },
                { FantasyRace.Troll, new TrollNameProvider() },
                { FantasyRace.Halfling, new HalflingNameProvider() },
                { FantasyRace.Dragonborn, new DragonbornNameProvider() },
                { FantasyRace.Tiefling, new TieflingNameProvider() },
                { FantasyRace.Gnome, new GnomeNameProvider() },
                { FantasyRace.HalfElf, new HalfElfNameProvider() },
                { FantasyRace.HalfOrc, new HalfOrcNameProvider() },
                { FantasyRace.Towns, new FantasyTownNameProvider() },
            };

            // Subscribe to FormClosing event
            FormClosing += Main_FormClosing;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            lblConnetion.Text = "Searching...";
            btnSearch.Enabled = false;

            var devices = await Task.Run(() => _usbSearch.FindArduinoDevices());

            if (devices.Count > 0)
            {
                lblConnetion.Text = devices.Count == 1 ? "Found" : "Multiple devices found";
                if (devices.Count > 1)
                {
                    var devicesListForm = new DevicesListForm(devices);
                    devicesListForm.ShowDialog();

                    string selectedDevicePort = GetSelectedPortFromUser();
                    if (!string.IsNullOrEmpty(selectedDevicePort))
                    {
                        _connectedPortName = selectedDevicePort;
                        _arduinoConnection.Connect(_connectedPortName);
                    }
                }
                else
                {
                    _connectedPortName = GetPortNameFromDevice(devices.First());
                    if (!string.IsNullOrEmpty(_connectedPortName))
                    {
                        _arduinoConnection.Connect(_connectedPortName);
                    }
                }
            }
            else
            {
                lblConnetion.Text = "No devices found";
            }

            btnSearch.Enabled = true;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsTableForm(_settingsEditor.GetAllSettings());
            settingsForm.ShowDialog();
        }

        private void BtnGenerateName_Click(object sender, EventArgs e)
        {
            if (CBNamegerator.SelectedItem is FantasyRace selectedRace)
            {
                var generatedName = _nameGenerator.GenerateName(selectedRace);
                LblGenerated.Text = generatedName;
            }
            else
            {
                LblGenerated.Text = "Please select a fantasy race.";
            }
        }

        private string GetSelectedPortFromUser()
        {
            return "COM3"; // Example implementation
        }

        private string GetPortNameFromDevice(string device)
        {
            return "COM3"; // Example implementation
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            _arduinoConnection.Disconnect();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnSearch = new Button();
            lblConnetion = new Label();
            btnSettings = new Button();
            LblNamegeratorinfo = new Label();
            CBNamegerator = new ComboBox();
            LblGenerated = new Label();
            BtnGenerateName = new Button();
            listNpc = new ListBox();
            label1 = new Label();
            BtnNewNpc = new Button();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(124, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lblConnetion
            // 
            lblConnetion.AutoSize = true;
            lblConnetion.Location = new Point(15, 16);
            lblConnetion.Name = "lblConnetion";
            lblConnetion.Size = new Size(74, 15);
            lblConnetion.TabIndex = 1;
            lblConnetion.Text = "Searching ....";
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(1367, 12);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(75, 23);
            btnSettings.TabIndex = 2;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // LblNamegeratorinfo
            // 
            LblNamegeratorinfo.AutoSize = true;
            LblNamegeratorinfo.Location = new Point(15, 84);
            LblNamegeratorinfo.Name = "LblNamegeratorinfo";
            LblNamegeratorinfo.Size = new Size(94, 15);
            LblNamegeratorinfo.TabIndex = 3;
            LblNamegeratorinfo.Text = "Name Generator";
            // 
            // CBNamegerator
            // 
            CBNamegerator.DataSource = Enum.GetValues(typeof(FantasyRace)).Cast<FantasyRace>().ToList();
            CBNamegerator.FormattingEnabled = true;
            CBNamegerator.Location = new Point(15, 102);
            CBNamegerator.Name = "CBNamegerator";
            CBNamegerator.Size = new Size(121, 23);
            CBNamegerator.TabIndex = 4;
            // 
            // LblGenerated
            // 
            LblGenerated.AutoSize = true;
            LblGenerated.Location = new Point(18, 136);
            LblGenerated.Name = "LblGenerated";
            LblGenerated.Size = new Size(0, 15);
            LblGenerated.TabIndex = 5;
            // 
            // BtnGenerateName
            // 
            BtnGenerateName.Location = new Point(14, 154);
            BtnGenerateName.Name = "BtnGenerateName";
            BtnGenerateName.Size = new Size(75, 23);
            BtnGenerateName.TabIndex = 6;
            BtnGenerateName.Text = "Generate";
            BtnGenerateName.UseVisualStyleBackColor = true;
            BtnGenerateName.Click += BtnGenerateName_Click;
            // 
            // listNpc
            // 
            listNpc.FormattingEnabled = true;
            listNpc.ItemHeight = 15;
            listNpc.Location = new Point(1344, 178);
            listNpc.Name = "listNpc";
            listNpc.Size = new Size(120, 229);
            listNpc.TabIndex = 7;
            
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1344, 154);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 8;
            label1.Text = "Npcs";
            // 
            // BtnNewNpc
            // 
            BtnNewNpc.Location = new Point(1344, 413);
            BtnNewNpc.Name = "BtnNewNpc";
            BtnNewNpc.Size = new Size(120, 23);
            BtnNewNpc.TabIndex = 9;
            BtnNewNpc.Text = "New NPC";
            BtnNewNpc.UseVisualStyleBackColor = true;
            BtnNewNpc.Click += BtnNewNpc_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1476, 628);
            Controls.Add(BtnNewNpc);
            Controls.Add(label1);
            Controls.Add(listNpc);
            Controls.Add(BtnGenerateName);
            Controls.Add(LblGenerated);
            Controls.Add(CBNamegerator);
            Controls.Add(LblNamegeratorinfo);
            Controls.Add(btnSettings);
            Controls.Add(lblConnetion);
            Controls.Add(btnSearch);
            Name = "Main";
            Text = "RPG Table";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
            LoadNpcNames();
            
        }

        private Button btnSearch;
        private Label lblConnetion;
        private Button btnSettings;
        private Label LblNamegeratorinfo;
        private ComboBox CBNamegerator;
        private Label LblGenerated;
        private Button BtnGenerateName;

        // This field is required for the Dispose method to work correctly
        private System.ComponentModel.IContainer components;
        private ListBox listNpc;
        private Label label1;
        private Button BtnNewNpc;
    }
}
