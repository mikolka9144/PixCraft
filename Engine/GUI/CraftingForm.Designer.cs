namespace Engine.GUI
{
    partial class CraftingForm
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
            this.listOfItemsToCraft = new System.Windows.Forms.ListBox();
            this.btnCraft = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listOfItemsToCraft
            // 
            this.listOfItemsToCraft.FormattingEnabled = true;
            this.listOfItemsToCraft.Location = new System.Drawing.Point(12, 12);
            this.listOfItemsToCraft.Name = "listOfItemsToCraft";
            this.listOfItemsToCraft.Size = new System.Drawing.Size(120, 251);
            this.listOfItemsToCraft.TabIndex = 0;
            // 
            // btnCraft
            // 
            this.btnCraft.Location = new System.Drawing.Point(139, 235);
            this.btnCraft.Name = "btnCraft";
            this.btnCraft.Size = new System.Drawing.Size(75, 23);
            this.btnCraft.TabIndex = 1;
            this.btnCraft.Text = "Craft";
            this.btnCraft.UseVisualStyleBackColor = true;
            this.btnCraft.Click += new System.EventHandler(this.btnCraft_Click);
            // 
            // CraftingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 270);
            this.Controls.Add(this.btnCraft);
            this.Controls.Add(this.listOfItemsToCraft);
            this.Name = "CraftingForm";
            this.Text = "CraftingForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listOfItemsToCraft;
        private System.Windows.Forms.Button btnCraft;
    }
}