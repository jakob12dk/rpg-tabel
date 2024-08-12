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
            this.dataGridViewNpc = new DataGridView();
            this.btnGenerate = new Button();
            this.btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNpc)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewNpc
            // 
            this.dataGridViewNpc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNpc.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewNpc.Name = "dataGridViewNpc";
            this.dataGridViewNpc.Size = new System.Drawing.Size(776, 366);
            this.dataGridViewNpc.TabIndex = 0;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(12, 384);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(713, 384);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // NpcEditorForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.dataGridViewNpc);
            this.Name = "NpcEditorForm";
            this.Text = "NPC Editor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNpc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}