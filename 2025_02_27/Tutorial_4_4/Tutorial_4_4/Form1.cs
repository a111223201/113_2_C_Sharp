namespace Tutorial_4_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loglistBox1.Items.Clear();
            loglistBox1.Items.Add("平均油耗紀錄:");
        }

        private void caculatebutton_Click(object sender, EventArgs e)
        {
            double distance, gas, average; //宣告區域變數

            if (double.TryParse(distancetextBox1.Text, out distance))
            {
                if (double.TryParse(gastextBox2.Text, out gas))
                {
                    average = distance / gas;
                    averagelabel4.Text = "平均油耗:" + average.ToString("f2") + "公里/公升";
                    loglistBox1.Items.Add(average.ToString("f2") + "公里/公升");
                }
                else
                {
                    MessageBox.Show("油耗請輸入數字");
                    gastextBox2.Focus();
                    gastextBox2.Text = "";
                }
            }
            else
            {
                MessageBox.Show("請輸入數字");
                distancetextBox1.Focus();//將滑鼠游標移至distanceTextBox
                distancetextBox1.Text = " "; //清空textBox
            }
        }

        private void exitbutton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double sum = 0;
            if(loglistBox1.Items.Count>1)
            {
                for(int i=1;i< loglistBox1.Items.Count;i++)
                {
                    sum += double.Parse(loglistBox1.Items[i].ToString().Replace("公里/公升", ""));
                }
                loglistBox1.Items.Add("平均油耗:" + (sum / (loglistBox1.Items.Count - 1)).ToString("f2") + "公里/公升");
            }
            else
            {
                MessageBox.Show("沒有紀錄");
            }
        }
    }
}
