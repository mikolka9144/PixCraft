namespace Engine.GUI
{
    partial class Settings_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.numericGrid = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "GameGrid";
            // 
            // numericGrid
            // 
            this.numericGrid.Location = new System.Drawing.Point(86, 13);
            this.numericGrid.Name = "numericGrid";
            this.numericGrid.Size = new System.Drawing.Size(120, 20);
            this.numericGrid.TabIndex = 2;
            this.numericGrid.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(68, 73);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // Settings_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 113);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numericGrid);
            this.Controls.Add(this.label1);
            this.Name = "Settings_Form";
            this.Text = "Settings_Form";
            ((System.ComponentModel.ISupportInitialize)(this.numericGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericGrid;
        private System.Windows.Forms.Button btnSave;
    }
}