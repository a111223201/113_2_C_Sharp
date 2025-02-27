namespace Tutorial_4_4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            distancetextBox1 = new TextBox();
            gastextBox2 = new TextBox();
            averagelabel4 = new Label();
            caculatebutton = new Button();
            exitbutton1 = new Button();
            loglistBox1 = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label1.Location = new Point(94, 81);
            label1.Name = "label1";
            label1.Size = new Size(143, 24);
            label1.TabIndex = 0;
            label1.Text = "輸入行駛里程數";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label2.Location = new Point(94, 154);
            label2.Name = "label2";
            label2.Size = new Size(143, 24);
            label2.TabIndex = 1;
            label2.Text = "消耗油量公升數";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label3.Location = new Point(94, 230);
            label3.Name = "label3";
            label3.Size = new Size(124, 24);
            label3.TabIndex = 2;
            label3.Text = "您的平均油耗";
            // 
            // distancetextBox1
            // 
            distancetextBox1.Location = new Point(292, 82);
            distancetextBox1.Name = "distancetextBox1";
            distancetextBox1.Size = new Size(123, 23);
            distancetextBox1.TabIndex = 3;
            // 
            // gastextBox2
            // 
            gastextBox2.Location = new Point(292, 158);
            gastextBox2.Name = "gastextBox2";
            gastextBox2.Size = new Size(123, 23);
            gastextBox2.TabIndex = 4;
            // 
            // averagelabel4
            // 
            averagelabel4.BorderStyle = BorderStyle.Fixed3D;
            averagelabel4.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            averagelabel4.Location = new Point(292, 230);
            averagelabel4.Name = "averagelabel4";
            averagelabel4.Size = new Size(252, 23);
            averagelabel4.TabIndex = 5;
            // 
            // caculatebutton
            // 
            caculatebutton.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            caculatebutton.Location = new Point(173, 336);
            caculatebutton.Name = "caculatebutton";
            caculatebutton.Size = new Size(129, 51);
            caculatebutton.TabIndex = 6;
            caculatebutton.Text = "計算";
            caculatebutton.UseVisualStyleBackColor = true;
            caculatebutton.Click += caculatebutton_Click;
            // 
            // exitbutton1
            // 
            exitbutton1.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            exitbutton1.Location = new Point(469, 336);
            exitbutton1.Name = "exitbutton1";
            exitbutton1.Size = new Size(129, 51);
            exitbutton1.TabIndex = 7;
            exitbutton1.Text = "離開";
            exitbutton1.UseVisualStyleBackColor = true;
            exitbutton1.Click += exitbutton1_Click;
            // 
            // loglistBox1
            // 
            loglistBox1.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            loglistBox1.FormattingEnabled = true;
            loglistBox1.ItemHeight = 24;
            loglistBox1.Location = new Point(636, 66);
            loglistBox1.Name = "loglistBox1";
            loglistBox1.Size = new Size(229, 316);
            loglistBox1.TabIndex = 8;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            button1.Location = new Point(654, 388);
            button1.Name = "button1";
            button1.Size = new Size(129, 51);
            button1.TabIndex = 9;
            button1.Text = "總平均油耗";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(877, 448);
            Controls.Add(button1);
            Controls.Add(loglistBox1);
            Controls.Add(exitbutton1);
            Controls.Add(caculatebutton);
            Controls.Add(averagelabel4);
            Controls.Add(gastextBox2);
            Controls.Add(distancetextBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox distancetextBox1;
        private TextBox gastextBox2;
        private Label averagelabel4;
        private Button caculatebutton;
        private Button exitbutton1;
        private ListBox loglistBox1;
        private Button button1;
    }
}
