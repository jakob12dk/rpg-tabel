using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using rpg_tabel.Logic.SessionNotes;

namespace rpg_tabel.GUI
{
    public partial class SessionNoteForm : Form
    {
        private readonly SessionNoteManager _noteManager;
        private List<Session> _sessions;

        public SessionNoteForm()
        {
            InitializeComponent();

            // Construct the path to the sessions.xml file
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string directoryPath = Path.Combine(documentsPath, "RPG_Table", "sessions");
            string filePath = Path.Combine(directoryPath, "sessions.xml");

            _noteManager = new SessionNoteManager(filePath);
            _noteManager.EnsureSessions();
            LoadSessions();
        }

        private void LoadSessions()
        {
            _sessions = _noteManager.LoadSessions();
            UpdateSessionList();
        }

        private void UpdateSessionList()
        {
            lstSessions.Items.Clear();
            lstSessions.Items.AddRange(_sessions.Select(s => $"Session {s.Number} - {s.Date.ToShortDateString()}").ToArray());
        }

        private void lstSessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSessions.SelectedItem != null)
            {
                var selectedSessionText = lstSessions.SelectedItem.ToString();
                var selectedSessionNumber = int.Parse(selectedSessionText.Split(' ')[1]);
                var session = _sessions.FirstOrDefault(s => s.Number == selectedSessionNumber);
                if (session != null)
                {
                    DisplayNotes(session);
                }
            }
        }

        private void DisplayNotes(Session session)
        {
            lstNotes.Items.Clear();
            foreach (var note in session.Notes)
            {
                lstNotes.Items.Add($"Character: {note.Character} - {note.Content}");
            }
        }

        private void btnSaveNote_Click(object sender, EventArgs e)
        {
            var selectedSessionText = lstSessions.SelectedItem?.ToString();
            if (selectedSessionText != null)
            {
                var selectedSessionNumber = int.Parse(selectedSessionText.Split(' ')[1]);
                var session = _sessions.FirstOrDefault(s => s.Number == selectedSessionNumber);
                if (session != null)
                {
                    var note = new SessionNote
                    {
                        Content = txtNoteContent.Text,
                        Character = txtCharacterName.Text
                    };

                    session.Notes.Add(note);
                    _noteManager.SaveSessions(_sessions);
                    DisplayNotes(session); // Refresh the notes display
                    MessageBox.Show("Note saved successfully!");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchTerm = txtSearchTerm.Text;
            var results = _noteManager.SearchNotes(searchTerm);

            lstSearchResults.Items.Clear();
            foreach (var session in results)
            {
                foreach (var note in session.Notes)
                {
                    lstSearchResults.Items.Add($"Session {session.Number}: {note.Content} (Character: {note.Character})");
                }
            }
        }

        private void btnAddSession_Click(object sender, EventArgs e)
        {
            // Add new session
            var newSession = new Session
            {
                Number = _sessions.Max(s => s.Number) + 1,
                Date = DateTime.Now,
                Notes = new List<SessionNote>()
            };

            _sessions.Add(newSession);
            _noteManager.SaveSessions(_sessions);
            LoadSessions(); // Refresh the session list
            MessageBox.Show("New session added successfully!");
        }
    }
}
