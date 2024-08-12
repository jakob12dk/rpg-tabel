namespace rpg_tabel.GUI
{
    partial class DevicesListForm
    {
        private System.ComponentModel.IContainer components = null;
        private ListBox listBoxDevices;

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
            this.listBoxDevices = new ListBox();
            this.SuspendLayout();
            // 
            // listBoxDevices
            // 
            this.listBoxDevices.Dock = DockStyle.Fill;
            this.listBoxDevices.FormattingEnabled = true;
            this.listBoxDevices.ItemHeight = 15;
            this.listBoxDevices.Location = new Point(0, 0);
            this.listBoxDevices.Name = "listBoxDevices";
            this.listBoxDevices.Size = new Size(400, 300);
            this.listBoxDevices.TabIndex = 0;
            // 
            // DevicesListForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(400, 300);
            this.Controls.Add(this.listBoxDevices);
            this.Name = "DevicesListForm";
            this.Text = "Found Devices";
            this.ResumeLayout(false);
        }
    }
}
