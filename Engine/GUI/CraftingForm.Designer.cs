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
            this.neededItemsList = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Inventory = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listOfItemsToCraft
            // 
            this.listOfItemsToCraft.FormattingEnabled = true;
            this.listOfItemsToCraft.Location = new System.Drawing.Point(12, 12);
            this.listOfItemsToCraft.Name = "listOfItemsToCraft";
            this.listOfItemsToCraft.Size = new System.Drawing.Size(120, 251);
            this.listOfItemsToCraft.TabIndex = 0;
            this.listOfItemsToCraft.SelectedIndexChanged += new System.EventHandler(this.listOfItemsToCraft_SelectedIndexChanged);
            // 
            // btnCraft
            // 
            this.btnCraft.Location = new System.Drawing.Point(275, 12);
            this.btnCraft.Name = "btnCraft";
            this.btnCraft.Size = new System.Drawing.Size(75, 23);
            this.btnCraft.TabIndex = 1;
            this.btnCraft.Text = "Craft";
            this.btnCraft.UseVisualStyleBackColor = true;
            this.btnCraft.Click += new System.EventHandler(this.btnCraft_Click);
            // 
            // neededItemsList
            // 
            this.neededItemsList.HideSelection = false;
            this.neededItemsList.Location = new System.Drawing.Point(139, 42);
            this.neededItemsList.Name = "neededItemsList";
            this.neededItemsList.Size = new System.Drawing.Size(211, 97);
            this.neededItemsList.TabIndex = 2;
            this.neededItemsList.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // Inventory
            // 
            this.Inventory.HideSelection = false;
            this.Inventory.Location = new System.Drawing.Point(145, 173);
            this.Inventory.Name = "Inventory";
            this.Inventory.Size = new System.Drawing.Size(205, 90);
            this.Inventory.TabIndex = 5;
            this.Inventory.UseCompatibleStateImageBehavior = false;
            // 
            // CraftingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 270);
            this.Controls.Add(this.Inventory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.neededItemsList);
            this.Controls.Add(this.btnCraft);
            this.Controls.Add(this.listOfItemsToCraft);
            this.Name = "CraftingForm";
            this.Text = "CraftingForm";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listOfItemsToCraft;
        private System.Windows.Forms.Button btnCraft;
        private System.Windows.Forms.ListView neededItemsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView Inventory;
    }
}