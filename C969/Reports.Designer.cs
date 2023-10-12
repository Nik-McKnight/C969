namespace C969
{
    partial class Reports
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
            this.TypesButton = new System.Windows.Forms.Button();
            this.ConsultantsButton = new System.Windows.Forms.Button();
            this.CustomerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TypesButton
            // 
            this.TypesButton.Location = new System.Drawing.Point(55, 63);
            this.TypesButton.Name = "TypesButton";
            this.TypesButton.Size = new System.Drawing.Size(294, 23);
            this.TypesButton.TabIndex = 0;
            this.TypesButton.Text = "Generate Appointment Types Report";
            this.TypesButton.UseVisualStyleBackColor = true;
            this.TypesButton.Click += new System.EventHandler(this.TypesButton_Click);
            // 
            // ConsultantsButton
            // 
            this.ConsultantsButton.Location = new System.Drawing.Point(55, 92);
            this.ConsultantsButton.Name = "ConsultantsButton";
            this.ConsultantsButton.Size = new System.Drawing.Size(294, 23);
            this.ConsultantsButton.TabIndex = 1;
            this.ConsultantsButton.Text = "Generate Consultants Schedule Report";
            this.ConsultantsButton.UseVisualStyleBackColor = true;
            this.ConsultantsButton.Click += new System.EventHandler(this.ConsultantsButton_Click);
            // 
            // CustomerButton
            // 
            this.CustomerButton.Location = new System.Drawing.Point(55, 121);
            this.CustomerButton.Name = "CustomerButton";
            this.CustomerButton.Size = new System.Drawing.Size(294, 23);
            this.CustomerButton.TabIndex = 2;
            this.CustomerButton.Text = "Generate Patient Visits Report";
            this.CustomerButton.UseVisualStyleBackColor = true;
            this.CustomerButton.Click += new System.EventHandler(this.CustomerButton_Click);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CustomerButton);
            this.Controls.Add(this.ConsultantsButton);
            this.Controls.Add(this.TypesButton);
            this.Name = "Reports";
            this.Text = "Reports";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TypesButton;
        private System.Windows.Forms.Button ConsultantsButton;
        private System.Windows.Forms.Button CustomerButton;
    }
}