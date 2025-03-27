using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Display_Elements
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getNamesButton_Click(object sender, EventArgs e)
        {
            // 建立一個陣列來存放三個字串。
            // 這個陣列的大小是固定的，為3。
            const int SIZE = 3;
            string[] names = new string[SIZE];

            // 從三個TextBox中獲取使用者輸入的名字。
            // 並將這些名字存放到陣列中。
            names[0] = name1TextBox.Text;
            names[1] = name2TextBox.Text;
            names[2] = name3TextBox.Text;

            // 依次顯示陣列中的名字。
            // 每個名字都會顯示在一個MessageBox中。
            MessageBox.Show(names[0]);
            MessageBox.Show(names[1]);
            MessageBox.Show(names[2]);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            // 這將結束應用程式的運行。
            this.Close();
        }
    }
}
