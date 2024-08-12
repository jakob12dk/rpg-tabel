using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace rpg_tabel.GUI
{
    public partial class SettingsTableForm : Form
    {
        public SettingsTableForm(List<Tuple<string, string>> settings)
        {
            _settings = settings;
            InitializeComponent();
            LoadSettings();
        }
    }
}
