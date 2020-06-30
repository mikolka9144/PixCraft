namespace Engine.GUI
{
    partial class StatusDisplay
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
            this.LifeBar = new System.Windows.Forms.ProgressBar();
            this.Inventory = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // LifeBar
            // 
            this.LifeBar.Location = new System.Drawing.Point(12, 12);
            this.LifeBar.Name = "LifeBar";
            this.LifeBar.Size = new System.Drawing.Size(339, 23);
            this.LifeBar.TabIndex = 0;
            // 
            // Inventory
            // 
            this.Inventory.HideSelection = false;
            this.Inventory.Location = new System.Drawing.Point(12, 73);
            this.Inventory.MultiSelect = false;
            this.Inventory.Name = "Inventory";
            this.Inventory.Size = new System.Drawing.Size(339, 175);
            this.Inventory.TabIndex = 1;
            this.Inventory.UseCompatibleStateImageBehavior = false;
            // 
            // StatusDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 260);
            this.Controls.Add(this.Inventory);
            this.Controls.Add(this.LifeBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatusDisplay";
            this.Text = "StatusDisplay";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar LifeBar;
        private System.Windows.Forms.ListView Inventory;
    }
}