namespace rpg_tabel.GUI
{
    partial class SessionNoteForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstSessions;
        private System.Windows.Forms.TextBox txtNoteContent;
        private System.Windows.Forms.TextBox txtCharacterName;
        private System.Windows.Forms.TextBox txtSearchTerm;
        private System.Windows.Forms.ListBox lstSearchResults;
        private System.Windows.Forms.Button btnSaveNote;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddSession;
        private System.Windows.Forms.ListBox lstNotes;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SessionNoteForm));
            lstSessions = new ListBox();
            lstNotes = new ListBox();
            txtNoteContent = new TextBox();
            txtCharacterName = new TextBox();
            btnSaveNote = new Button();
            btnSearch = new Button();
            txtSearchTerm = new TextBox();
            lstSearchResults = new ListBox();
            btnAddSession = new Button();
            SuspendLayout();
            // 
            // lstSessions
            // 
            lstSessions.FormattingEnabled = true;
            lstSessions.ItemHeight = 15;
            lstSessions.Location = new Point(12, 12);
            lstSessions.Name = "lstSessions";
            lstSessions.Size = new Size(200, 259);
            lstSessions.TabIndex = 0;
            lstSessions.SelectedIndexChanged += lstSessions_SelectedIndexChanged;
            // 
            // lstNotes
            // 
            lstNotes.FormattingEnabled = true;
            lstNotes.ItemHeight = 15;
            lstNotes.Location = new Point(220, 12);
            lstNotes.Name = "lstNotes";
            lstNotes.Size = new Size(300, 259);
            lstNotes.TabIndex = 1;
            // 
            // txtNoteContent
            // 
            txtNoteContent.Location = new Point(12, 290);
            txtNoteContent.Multiline = true;
            txtNoteContent.Name = "txtNoteContent";
            txtNoteContent.Size = new Size(200, 60);
            txtNoteContent.TabIndex = 2;
            // 
            // txtCharacterName
            // 
            txtCharacterName.Location = new Point(12, 356);
            txtCharacterName.Name = "txtCharacterName";
            txtCharacterName.Size = new Size(200, 23);
            txtCharacterName.TabIndex = 3;
            // 
            // btnSaveNote
            // 
            btnSaveNote.Location = new Point(12, 385);
            btnSaveNote.Name = "btnSaveNote";
            btnSaveNote.Size = new Size(200, 23);
            btnSaveNote.TabIndex = 4;
            btnSaveNote.Text = "Save Note";
            btnSaveNote.UseVisualStyleBackColor = true;
            btnSaveNote.Click += btnSaveNote_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(220, 290);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 23);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearchTerm
            // 
            txtSearchTerm.Location = new Point(330, 290);
            txtSearchTerm.Name = "txtSearchTerm";
            txtSearchTerm.Size = new Size(190, 23);
            txtSearchTerm.TabIndex = 6;
            // 
            // lstSearchResults
            // 
            lstSearchResults.FormattingEnabled = true;
            lstSearchResults.ItemHeight = 15;
            lstSearchResults.Location = new Point(220, 320);
            lstSearchResults.Name = "lstSearchResults";
            lstSearchResults.Size = new Size(300, 139);
            lstSearchResults.TabIndex = 7;
            // 
            // btnAddSession
            // 
            btnAddSession.Location = new Point(12, 414);
            btnAddSession.Name = "btnAddSession";
            btnAddSession.Size = new Size(200, 23);
            btnAddSession.TabIndex = 8;
            btnAddSession.Text = "Add New Session";
            btnAddSession.UseVisualStyleBackColor = true;
            btnAddSession.Click += btnAddSession_Click;
            // 
            // SessionNoteForm
            // 
            ClientSize = new Size(532, 450);
            Controls.Add(btnAddSession);
            Controls.Add(lstSearchResults);
            Controls.Add(txtSearchTerm);
            Controls.Add(btnSearch);
            Controls.Add(btnSaveNote);
            Controls.Add(txtCharacterName);
            Controls.Add(txtNoteContent);
            Controls.Add(lstNotes);
            Controls.Add(lstSessions);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SessionNoteForm";
            Text = "Session Notes";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
