using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrayEquality
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 1, 2, 3, 4, 6 };

            // 檢查陣列是否相等
            bool arraysEqual = IsArrayEqual(array1, array2);
            MessageBox.Show(arraysEqual ? "陣列相等" : "陣列不相等");
        }

        private bool IsArrayEqual(int[] array1, int[] array2)
        {
            // 檢查長度是否相等
            if (array1.Length != array2.Length)
            {
                return false;
            }
            // 檢查每個元素是否相等
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
