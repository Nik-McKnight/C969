﻿namespace C969
{
    partial class Calendar
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.button1 = new System.Windows.Forms.Button();
            this.ReportsButton = new System.Windows.Forms.Button();
            this.CreateUserButton = new System.Windows.Forms.Button();
            this.UDCustButton = new System.Windows.Forms.Button();
            this.createAppButton = new System.Windows.Forms.Button();
            this.UDAppButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(14, 14);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(5);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Open Weekly Calendar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReportsButton
            // 
            this.ReportsButton.Location = new System.Drawing.Point(291, 14);
            this.ReportsButton.Name = "ReportsButton";
            this.ReportsButton.Size = new System.Drawing.Size(233, 23);
            this.ReportsButton.TabIndex = 2;
            this.ReportsButton.Text = "Generate Reports";
            this.ReportsButton.UseVisualStyleBackColor = true;
            this.ReportsButton.Click += new System.EventHandler(this.ReportsButton_Click);
            // 
            // CreateUserButton
            // 
            this.CreateUserButton.Location = new System.Drawing.Point(291, 43);
            this.CreateUserButton.Name = "CreateUserButton";
            this.CreateUserButton.Size = new System.Drawing.Size(233, 23);
            this.CreateUserButton.TabIndex = 3;
            this.CreateUserButton.Text = "Create Customer";
            this.CreateUserButton.UseVisualStyleBackColor = true;
            this.CreateUserButton.Click += new System.EventHandler(this.CreateUserButton_Click);
            // 
            // UDCustButton
            // 
            this.UDCustButton.Location = new System.Drawing.Point(291, 72);
            this.UDCustButton.Name = "UDCustButton";
            this.UDCustButton.Size = new System.Drawing.Size(233, 23);
            this.UDCustButton.TabIndex = 4;
            this.UDCustButton.Text = "Update/Delete Customer";
            this.UDCustButton.UseVisualStyleBackColor = true;
            this.UDCustButton.Click += new System.EventHandler(this.UDCustButton_Click);
            // 
            // createAppButton
            // 
            this.createAppButton.Location = new System.Drawing.Point(291, 101);
            this.createAppButton.Name = "createAppButton";
            this.createAppButton.Size = new System.Drawing.Size(233, 23);
            this.createAppButton.TabIndex = 5;
            this.createAppButton.Text = "Create Appointment";
            this.createAppButton.UseVisualStyleBackColor = true;
            this.createAppButton.Click += new System.EventHandler(this.createAppButton_Click);
            // 
            // UDAppButton
            // 
            this.UDAppButton.Location = new System.Drawing.Point(291, 130);
            this.UDAppButton.Name = "UDAppButton";
            this.UDAppButton.Size = new System.Drawing.Size(233, 23);
            this.UDAppButton.TabIndex = 6;
            this.UDAppButton.Text = "Update/Delete Appointment";
            this.UDAppButton.UseVisualStyleBackColor = true;
            this.UDAppButton.Click += new System.EventHandler(this.UDAppButton_Click);
            // 
            // Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 240);
            this.Controls.Add(this.UDAppButton);
            this.Controls.Add(this.createAppButton);
            this.Controls.Add(this.UDCustButton);
            this.Controls.Add(this.CreateUserButton);
            this.Controls.Add(this.ReportsButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.monthCalendar1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Calendar";
            this.Text = "Calendar";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ReportsButton;
        private System.Windows.Forms.Button CreateUserButton;
        private System.Windows.Forms.Button UDCustButton;
        private System.Windows.Forms.Button createAppButton;
        private System.Windows.Forms.Button UDAppButton;
    }
}