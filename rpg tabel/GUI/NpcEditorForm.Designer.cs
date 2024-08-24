namespace rpg_tabel.GUI
{
    partial class NpcEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NpcEditorForm));
            dataGridViewNpc = new DataGridView();
            btnGenerate = new Button();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNpc).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewNpc
            // 
            dataGridViewNpc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewNpc.Location = new Point(12, 12);
            dataGridViewNpc.Name = "dataGridViewNpc";
            dataGridViewNpc.Size = new Size(776, 366);
            dataGridViewNpc.TabIndex = 0;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(12, 384);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(75, 23);
            btnGenerate.TabIndex = 1;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += BtnGenerate_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(713, 384);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += BtnSave_Click;
            // 
            // NpcEditorForm
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(btnGenerate);
            Controls.Add(dataGridViewNpc);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "NpcEditorForm";
            Text = "NPC Editor";
            ((System.ComponentModel.ISupportInitialize)dataGridViewNpc).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}