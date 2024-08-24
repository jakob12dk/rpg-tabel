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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevicesListForm));
            listBoxDevices = new ListBox();
            SuspendLayout();
            // 
            // listBoxDevices
            // 
            listBoxDevices.Dock = DockStyle.Fill;
            listBoxDevices.FormattingEnabled = true;
            listBoxDevices.ItemHeight = 15;
            listBoxDevices.Location = new Point(0, 0);
            listBoxDevices.Name = "listBoxDevices";
            listBoxDevices.Size = new Size(400, 300);
            listBoxDevices.TabIndex = 0;
            // 
            // DevicesListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 300);
            Controls.Add(listBoxDevices);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DevicesListForm";
            Text = "Found Devices";
            ResumeLayout(false);
        }
    }
}
