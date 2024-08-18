using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace rpg_tabel.Logic.SessionNotes
{
    public class SessionNoteManager
    {
        private readonly string _filePath;

        public SessionNoteManager(string filePath)
        {
            _filePath = filePath;
        }

        public List<Session> LoadSessions()
        {
            // Ensure the directory exists
            var directory = Path.GetDirectoryName(_filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(_filePath))
            {
                // File does not exist, so we need to create it
                CreateEmptyFile();
                return new List<Session>();
            }

            var sessions = new List<Session>();
            var doc = XDocument.Load(_filePath);

            foreach (var sessionElement in doc.Root.Elements("Session"))
            {
                var session = new Session
                {
                    Number = int.Parse(sessionElement.Attribute("number").Value),
                    Date = DateTime.Parse(sessionElement.Element("Date").Value),
                    Notes = sessionElement.Elements("Note")
                                          .Select(note => new SessionNote
                                          {
                                              Content = note.Element("Content").Value,
                                              Character = note.Element("Character").Value
                                          }).ToList()
                };

                sessions.Add(session);
            }

            return sessions;
        }

        private void CreateEmptyFile()
        {
            var doc = new XDocument(new XElement("Sessions"));
            doc.Save(_filePath);
        }

        public void SaveSessions(List<Session> sessions)
        {
            var doc = new XDocument(new XElement("Sessions",
                sessions.Select(s => new XElement("Session",
                    new XAttribute("number", s.Number),
                    new XElement("Date", s.Date.ToString("yyyy-MM-dd")),
                    s.Notes.Select(n => new XElement("Note",
                        new XElement("Content", n.Content),
                        new XElement("Character", n.Character)
                    ))
                ))
            ));
            doc.Save(_filePath);
        }

        public IEnumerable<Session> SearchNotes(string searchTerm)
        {
            var sessions = LoadSessions();
            return sessions.Where(s => s.Notes.Any(n => n.Content.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)));
        }

        public void EnsureSessions()
        {
            var sessions = LoadSessions();
            if (sessions.Count == 0)
            {
                var result = MessageBox.Show("No sessions found. Would you like to create a new session?", "No Sessions", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var newSession = new Session
                    {
                        Number = 1,
                        Date = DateTime.Now,
                        Notes = new List<SessionNote>()
                    };

                    SaveSessions(new List<Session> { newSession });
                }
                // If No, do nothing and return
            }
        }
    }
}
