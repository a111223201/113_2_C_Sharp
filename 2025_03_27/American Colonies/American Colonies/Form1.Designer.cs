﻿namespace American_Colonies
{
    partial class Form1
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
            this.exitButton = new System.Windows.Forms.Button();
            this.promptLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.selectionListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(143, 156);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 21);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "退出";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // promptLabel
            // 
            this.promptLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.promptLabel.Location = new System.Drawing.Point(22, 6);
            this.promptLabel.Name = "promptLabel";
            this.promptLabel.Size = new System.Drawing.Size(237, 36);
            this.promptLabel.TabIndex = 6;
            this.promptLabel.Text = "以下哪一個是美國最初的13個殖民地之一？";
            this.promptLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(62, 156);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 21);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "確定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // selectionListBox
            // 
            this.selectionListBox.FormattingEnabled = true;
            this.selectionListBox.ItemHeight = 12;
            this.selectionListBox.Items.AddRange(new object[] {
            "Alabama",
            "Florida",
            "Georgia",
            "Indiana",
            "Nebraska",
            "Tennessee",
            "Texas"});
            this.selectionListBox.Location = new System.Drawing.Point(35, 52);
            this.selectionListBox.Name = "selectionListBox";
            this.selectionListBox.Size = new System.Drawing.Size(214, 88);
            this.selectionListBox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 184);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.promptLabel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.selectionListBox);
            this.Name = "Form1";
            this.Text = "美國殖民地";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label promptLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ListBox selectionListBox;
    }
}

