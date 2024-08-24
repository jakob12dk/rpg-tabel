namespace rpg_tabel.GUI
{
    partial class SettingsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
            lblUser = new Label();
            txtUsername = new TextBox();
            LblPass = new Label();
            txtPassword = new MaskedTextBox();
            btnSubmit = new Button();
            SuspendLayout();
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(38, 56);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(60, 15);
            lblUser.TabIndex = 0;
            lblUser.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(104, 56);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(100, 23);
            txtUsername.TabIndex = 1;
            // 
            // LblPass
            // 
            LblPass.AutoSize = true;
            LblPass.Location = new Point(38, 104);
            LblPass.Name = "LblPass";
            LblPass.Size = new Size(57, 15);
            LblPass.TabIndex = 2;
            LblPass.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(104, 104);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 3;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(104, 143);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(100, 23);
            btnSubmit.TabIndex = 4;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click_1;
            // 
            // SettingsDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(266, 206);
            Controls.Add(btnSubmit);
            Controls.Add(txtPassword);
            Controls.Add(LblPass);
            Controls.Add(txtUsername);
            Controls.Add(lblUser);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingsDialog";
            Text = "SettingsDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUser;
        private TextBox txtUsername;
        private Label LblPass;
        private MaskedTextBox txtPassword;
        private Button btnSubmit;
    }
}