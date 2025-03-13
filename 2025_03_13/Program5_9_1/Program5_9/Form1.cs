using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program5_9
{
    public partial class Form1 : Form
    {
        Random rand = new Random(); // 創建一個隨機對象，有效範圍在整個類別中
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int n1 = rand.Next(1, 7); // 產生1~6之間的隨機數，有效範圍在button1_Click方法中
            int n2 = rand.Next(1, 7); // 產生1~6之間的隨機數，有效範圍在button1_Click方法中


            showPicture(n1,pictureBox1);//呼叫方法showPicture，顯示第一個骰子的圖片

            showPicture(n2,pictureBox2);//呼叫方法showPicture，顯示第二個骰子的圖片


        }

        private void showPicture(int n,PictureBox pic)
        {
            switch (n)
            {
                case 1:
                    pic.Image = Properties.Resources._1Die;
                    break;
                case 2:
                    pic.Image = Properties.Resources._2Die;
                    break;
                case 3:
                    pic.Image = Properties.Resources._3Die;
                    break;
                case 4:
                    pic.Image = Properties.Resources._4Die;
                    break;
                case 5:
                    pic.Image = Properties.Resources._5Die;
                    break;
                case 6:
                    pic.Image = Properties.Resources._6Die;
                    break;
            }
        }
    }
}
