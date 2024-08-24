using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using rpg_tabel.Logic;

namespace rpg_tabel.GUI
{
    partial class SettingsTableForm : Form
    {
        private List<Tuple<string, string>> _settings;
        private SettingsEditor _settingsEditor;
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridViewSettings;

        public SettingsTableForm(List<Tuple<string, string>> settings, SettingsEditor settingsEditor)
        {
            _settings = settings;
            _settingsEditor = new SettingsEditor();
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            dataGridViewSettings.Rows.Clear();

            foreach (var setting in _settings)
            {
                dataGridViewSettings.Rows.Add(setting.Item1, setting.Item2);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void SettingsTableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SettingsEditor _settingsEditor = new SettingsEditor();
            var updatedSettings = new Dictionary<string, string>();

            // Ensure the current edit is committed
            if (dataGridViewSettings.IsCurrentCellDirty)
            {
                dataGridViewSettings.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

            // Loop through each row and capture the updated settings
            foreach (DataGridViewRow row in dataGridViewSettings.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    string settingName = row.Cells[0].Value.ToString();
                    string settingValue = row.Cells[1].Value.ToString();
                    updatedSettings[settingName] = settingValue;
                }
            }

            // Save the updated settings to the XML file
            _settingsEditor.SaveSettings(updatedSettings);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsTableForm));
            dataGridViewSettings = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSettings).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewSettings
            // 
            dataGridViewSettings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSettings.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
            dataGridViewSettings.Location = new Point(25, 27);
            dataGridViewSettings.Name = "dataGridViewSettings";
            dataGridViewSettings.Size = new Size(568, 318);
            dataGridViewSettings.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // SettingsTableForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewSettings);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingsTableForm";
            Text = "Settings Table";
            FormClosing += SettingsTableForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridViewSettings).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}
