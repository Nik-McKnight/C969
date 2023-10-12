namespace C969
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.UserLabelSec = new System.Windows.Forms.Label();
            this.UserBox = new System.Windows.Forms.TextBox();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.PassBox = new System.Windows.Forms.TextBox();
            this.PassLabelSec = new System.Windows.Forms.Label();
            this.PassLabelPri = new System.Windows.Forms.Label();
            this.UserLabelPri = new System.Windows.Forms.Label();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserLabelSec
            // 
            resources.ApplyResources(this.UserLabelSec, "UserLabelSec");
            this.UserLabelSec.Name = "UserLabelSec";
            // 
            // UserBox
            // 
            resources.ApplyResources(this.UserBox, "UserBox");
            this.UserBox.Name = "UserBox";
            this.UserBox.TextChanged += new System.EventHandler(this.UserBox_TextChanged);
            // 
            // SubmitButton
            // 
            resources.ApplyResources(this.SubmitButton, "SubmitButton");
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // PassBox
            // 
            resources.ApplyResources(this.PassBox, "PassBox");
            this.PassBox.Name = "PassBox";
            this.PassBox.UseSystemPasswordChar = true;
            this.PassBox.TextChanged += new System.EventHandler(this.PassBox_TextChanged);
            // 
            // PassLabelSec
            // 
            resources.ApplyResources(this.PassLabelSec, "PassLabelSec");
            this.PassLabelSec.Name = "PassLabelSec";
            // 
            // PassLabelPri
            // 
            resources.ApplyResources(this.PassLabelPri, "PassLabelPri");
            this.PassLabelPri.Name = "PassLabelPri";
            // 
            // UserLabelPri
            // 
            resources.ApplyResources(this.UserLabelPri, "UserLabelPri");
            this.UserLabelPri.Name = "UserLabelPri";
            // 
            // RegisterButton
            // 
            resources.ApplyResources(this.RegisterButton, "RegisterButton");
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // Login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.PassLabelPri);
            this.Controls.Add(this.UserLabelPri);
            this.Controls.Add(this.PassBox);
            this.Controls.Add(this.PassLabelSec);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.UserBox);
            this.Controls.Add(this.UserLabelSec);
            this.Name = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserLabelSec;
        private System.Windows.Forms.TextBox UserBox;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.TextBox PassBox;
        private System.Windows.Forms.Label PassLabelSec;
        private System.Windows.Forms.Label PassLabelPri;
        private System.Windows.Forms.Label UserLabelPri;
        private System.Windows.Forms.Button RegisterButton;
    }
}

