namespace Engine.GUI
{
    partial class NewWorld
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
            this.numericSeed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSize)).BeginInit();
            this.SuspendLayout();
            // 
            // numericSeed
            // 
            this.numericSeed.Location = new System.Drawing.Point(61, 36);
            this.numericSeed.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericSeed.Name = "numericSeed";
            this.numericSeed.Size = new System.Drawing.Size(120, 20);
            this.numericSeed.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seed";
            // 
            // numericSize
            // 
            this.numericSize.Location = new System.Drawing.Point(61, 73);
            this.numericSize.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericSize.Name = "numericSize";
            this.numericSize.Size = new System.Drawing.Size(120, 20);
            this.numericSize.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Size";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(61, 129);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Generate";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(0, 207);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(243, 23);
            this.progress.TabIndex = 6;
            // 
            // NewWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 235);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericSeed);
            this.Name = "NewWorld";
            this.Text = "NewWorld";
            ((System.ComponentModel.ISupportInitialize)(this.numericSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericSeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar progress;
    }
}