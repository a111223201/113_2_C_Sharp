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
            loglistBox1.Items.Add("�����o�Ӭ���:");
        }

        private void caculatebutton_Click(object sender, EventArgs e)
        {
            double distance, gas, average; //�ŧi�ϰ��ܼ�

            if (double.TryParse(distancetextBox1.Text, out distance))
            {
                if (double.TryParse(gastextBox2.Text, out gas))
                {
                    average = distance / gas;
                    averagelabel4.Text = "�����o��:" + average.ToString("f2") + "����/����";
                    loglistBox1.Items.Add(average.ToString("f2") + "����/����");
                }
                else
                {
                    MessageBox.Show("�o�ӽп�J�Ʀr");
                    gastextBox2.Focus();
                    gastextBox2.Text = "";
                }
            }
            else
            {
                MessageBox.Show("�п�J�Ʀr");
                distancetextBox1.Focus();//�N�ƹ���в���distanceTextBox
                distancetextBox1.Text = " "; //�M��textBox
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
                    sum += double.Parse(loglistBox1.Items[i].ToString().Replace("����/����", ""));
                }
                loglistBox1.Items.Add("�����o��:" + (sum / (loglistBox1.Items.Count - 1)).ToString("f2") + "����/����");
            }
            else
            {
                MessageBox.Show("�S������");
            }
        }
    }
}
