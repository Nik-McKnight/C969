namespace C969
{
    partial class UpdateDeleteCustomer
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
            this.DeleteButton = new System.Windows.Forms.Button();
            this.CityBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PCBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PhoneBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Ad2Box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Ad1Box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.CustIDBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.LookupButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DeleteButton
            // 
            this.DeleteButton.Enabled = false;
            this.DeleteButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DeleteButton.Location = new System.Drawing.Point(139, 354);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(157, 23);
            this.DeleteButton.TabIndex = 27;
            this.DeleteButton.Text = "Delete Customer";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // CityBox
            // 
            this.CityBox.Enabled = false;
            this.CityBox.Location = new System.Drawing.Point(314, 356);
            this.CityBox.Name = "CityBox";
            this.CityBox.Size = new System.Drawing.Size(157, 20);
            this.CityBox.TabIndex = 26;
            this.CityBox.TextChanged += new System.EventHandler(this.CityBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(356, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Enter City ID (1-1000)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PCBox
            // 
            this.PCBox.Enabled = false;
            this.PCBox.Location = new System.Drawing.Point(314, 305);
            this.PCBox.Name = "PCBox";
            this.PCBox.Size = new System.Drawing.Size(157, 20);
            this.PCBox.TabIndex = 24;
            this.PCBox.TextChanged += new System.EventHandler(this.PCBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(356, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Enter Postal Code";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PhoneBox
            // 
            this.PhoneBox.Enabled = false;
            this.PhoneBox.Location = new System.Drawing.Point(314, 254);
            this.PhoneBox.Name = "PhoneBox";
            this.PhoneBox.Size = new System.Drawing.Size(157, 20);
            this.PhoneBox.TabIndex = 22;
            this.PhoneBox.TextChanged += new System.EventHandler(this.PhoneBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(356, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Enter Phone";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Ad2Box
            // 
            this.Ad2Box.Enabled = false;
            this.Ad2Box.Location = new System.Drawing.Point(314, 204);
            this.Ad2Box.Name = "Ad2Box";
            this.Ad2Box.Size = new System.Drawing.Size(157, 20);
            this.Ad2Box.TabIndex = 20;
            this.Ad2Box.TextChanged += new System.EventHandler(this.Ad2Box_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(356, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Enter Address Line 2";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Ad1Box
            // 
            this.Ad1Box.Enabled = false;
            this.Ad1Box.Location = new System.Drawing.Point(314, 153);
            this.Ad1Box.Name = "Ad1Box";
            this.Ad1Box.Size = new System.Drawing.Size(157, 20);
            this.Ad1Box.TabIndex = 18;
            this.Ad1Box.TextChanged += new System.EventHandler(this.Ad1Box_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(356, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Enter Address";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameBox
            // 
            this.NameBox.Enabled = false;
            this.NameBox.Location = new System.Drawing.Point(314, 102);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(157, 20);
            this.NameBox.TabIndex = 16;
            this.NameBox.TextChanged += new System.EventHandler(this.NameBox_TextChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label1.Location = new System.Drawing.Point(356, 86);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(63, 13);
            this.Label1.TabIndex = 15;
            this.Label1.Text = "Enter Name";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CustIDBox
            // 
            this.CustIDBox.Location = new System.Drawing.Point(314, 52);
            this.CustIDBox.Name = "CustIDBox";
            this.CustIDBox.Size = new System.Drawing.Size(157, 20);
            this.CustIDBox.TabIndex = 29;
            this.CustIDBox.TextChanged += new System.EventHandler(this.CustIDBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(355, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Enter Customer ID";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Enabled = false;
            this.UpdateButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UpdateButton.Location = new System.Drawing.Point(493, 353);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(157, 23);
            this.UpdateButton.TabIndex = 30;
            this.UpdateButton.Text = "Update Customer";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // LookupButton
            // 
            this.LookupButton.Enabled = false;
            this.LookupButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LookupButton.Location = new System.Drawing.Point(493, 49);
            this.LookupButton.Name = "LookupButton";
            this.LookupButton.Size = new System.Drawing.Size(157, 23);
            this.LookupButton.TabIndex = 58;
            this.LookupButton.Text = "Look-Up User";
            this.LookupButton.UseVisualStyleBackColor = true;
            this.LookupButton.Click += new System.EventHandler(this.LookupButton_Click);
            // 
            // UpdateDeleteCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LookupButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.CustIDBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CityBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PCBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PhoneBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Ad2Box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Ad1Box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.Label1);
            this.Name = "UpdateDeleteCustomer";
            this.Text = "UpdateDeleteCustomer";
            this.TextChanged += new System.EventHandler(this.NameBox_TextChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.TextBox CityBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PCBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PhoneBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Ad2Box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Ad1Box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox CustIDBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button LookupButton;
    }
}