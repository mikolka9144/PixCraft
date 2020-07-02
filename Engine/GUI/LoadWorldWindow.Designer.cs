namespace Engine.GUI
{
    partial class LoadWorldWindow
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
            this.label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtBase = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(42, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(99, 13);
            this.label.TabIndex = 1;
            this.label.Text = "Enter path for world";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBase
            // 
            this.txtBase.Location = new System.Drawing.Point(15, 44);
            this.txtBase.Name = "txtBase";
            this.txtBase.Size = new System.Drawing.Size(158, 20);
            this.txtBase.TabIndex = 3;
            // 
            // LoadWorldWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 97);
            this.Controls.Add(this.txtBase);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label);
            this.Name = "LoadWorldWindow";
            this.Text = "LoadWorldWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBase;
    }
}