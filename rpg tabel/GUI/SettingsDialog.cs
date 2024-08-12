using rpg_tabel.Logic;
using System;
using System.Windows.Forms;

namespace rpg_tabel.GUI
{
    public partial class SettingsDialog : Form
    {
        private SettingsEditor _settingsEditor = new SettingsEditor();

        public SettingsDialog()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            string storedUsername = _settingsEditor.GetUsername();
            string storedPassword = _settingsEditor.GetPassword();

            if (txtUsername.Text == storedUsername && txtPassword.Text == storedPassword)
            {
                using (var settingsTableForm = new SettingsTableForm(_settingsEditor.GetAllSettings()))
                {
                    settingsTableForm.ShowDialog();
                }
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
