namespace Engine.GUI
{
    partial class SaveWorldWindow
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnCloud = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type path to file for saving";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(16, 58);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(179, 20);
            this.txtName.TabIndex = 1;
            // 
            // btnCloud
            // 
            this.btnCloud.Location = new System.Drawing.Point(61, 84);
            this.btnCloud.Name = "btnCloud";
            this.btnCloud.Size = new System.Drawing.Size(75, 23);
            this.btnCloud.TabIndex = 3;
            this.btnCloud.Text = "Save";
            this.btnCloud.UseVisualStyleBackColor = true;
            this.btnCloud.Click += new System.EventHandler(this.btnCloud_Click);
            // 
            // SaveWorldWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 149);
            this.Controls.Add(this.btnCloud);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "SaveWorldWindow";
            this.Text = "SaveWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnCloud;
    }
}