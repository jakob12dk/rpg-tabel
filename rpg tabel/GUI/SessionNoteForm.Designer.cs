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
            this.lstSessions = new System.Windows.Forms.ListBox();
            this.lstNotes = new System.Windows.Forms.ListBox();
            this.txtNoteContent = new System.Windows.Forms.TextBox();
            this.txtCharacterName = new System.Windows.Forms.TextBox();
            this.btnSaveNote = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchTerm = new System.Windows.Forms.TextBox();
            this.lstSearchResults = new System.Windows.Forms.ListBox();
            this.btnAddSession = new System.Windows.Forms.Button();
            // 
            // lstSessions
            // 
            this.lstSessions.FormattingEnabled = true;
            this.lstSessions.ItemHeight = 15;
            this.lstSessions.Location = new System.Drawing.Point(12, 12);
            this.lstSessions.Name = "lstSessions";
            this.lstSessions.Size = new System.Drawing.Size(200, 259);
            this.lstSessions.TabIndex = 0;
            this.lstSessions.SelectedIndexChanged += new System.EventHandler(this.lstSessions_SelectedIndexChanged);
            // 
            // lstNotes
            // 
            this.lstNotes.FormattingEnabled = true;
            this.lstNotes.ItemHeight = 15;
            this.lstNotes.Location = new System.Drawing.Point(220, 12);
            this.lstNotes.Name = "lstNotes";
            this.lstNotes.Size = new System.Drawing.Size(300, 259);
            this.lstNotes.TabIndex = 1;
            // 
            // txtNoteContent
            // 
            this.txtNoteContent.Location = new System.Drawing.Point(12, 290);
            this.txtNoteContent.Multiline = true;
            this.txtNoteContent.Name = "txtNoteContent";
            this.txtNoteContent.Size = new System.Drawing.Size(200, 60);
            this.txtNoteContent.TabIndex = 2;
            // 
            // txtCharacterName
            // 
            this.txtCharacterName.Location = new System.Drawing.Point(12, 356);
            this.txtCharacterName.Name = "txtCharacterName";
            this.txtCharacterName.Size = new System.Drawing.Size(200, 23);
            this.txtCharacterName.TabIndex = 3;
            // 
            // btnSaveNote
            // 
            this.btnSaveNote.Location = new System.Drawing.Point(12, 385);
            this.btnSaveNote.Name = "btnSaveNote";
            this.btnSaveNote.Size = new System.Drawing.Size(200, 23);
            this.btnSaveNote.TabIndex = 4;
            this.btnSaveNote.Text = "Save Note";
            this.btnSaveNote.UseVisualStyleBackColor = true;
            this.btnSaveNote.Click += new System.EventHandler(this.btnSaveNote_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(220, 290);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.Location = new System.Drawing.Point(330, 290);
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(190, 23);
            this.txtSearchTerm.TabIndex = 6;
            // 
            // lstSearchResults
            // 
            this.lstSearchResults.FormattingEnabled = true;
            this.lstSearchResults.ItemHeight = 15;
            this.lstSearchResults.Location = new System.Drawing.Point(220, 320);
            this.lstSearchResults.Name = "lstSearchResults";
            this.lstSearchResults.Size = new System.Drawing.Size(300, 139);
            this.lstSearchResults.TabIndex = 7;
            // 
            // btnAddSession
            // 
            this.btnAddSession.Location = new System.Drawing.Point(12, 414);
            this.btnAddSession.Name = "btnAddSession";
            this.btnAddSession.Size = new System.Drawing.Size(200, 23);
            this.btnAddSession.TabIndex = 8;
            this.btnAddSession.Text = "Add New Session";
            this.btnAddSession.UseVisualStyleBackColor = true;
            this.btnAddSession.Click += new System.EventHandler(this.btnAddSession_Click);
            // 
            // SessionNoteForm
            // 
            this.ClientSize = new System.Drawing.Size(532, 450);
            this.Controls.Add(this.btnAddSession);
            this.Controls.Add(this.lstSearchResults);
            this.Controls.Add(this.txtSearchTerm);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSaveNote);
            this.Controls.Add(this.txtCharacterName);
            this.Controls.Add(this.txtNoteContent);
            this.Controls.Add(this.lstNotes);
            this.Controls.Add(this.lstSessions);
            this.Name = "SessionNoteForm";
            this.Text = "Session Notes";
        }
    }
}
