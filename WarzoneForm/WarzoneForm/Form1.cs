using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WarzoneForm
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int vKey);

        private bool isRightButtonHeld = false;
        private bool isLeftButtonHeld = false;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 800;
            timer1.Tick += timer1_Tick;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = checkBox1.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            isRightButtonHeld = GetAsyncKeyState(0x02) < 0;

            isLeftButtonHeld = GetAsyncKeyState(0x01) < 0;


            if (isRightButtonHeld && isLeftButtonHeld)
            {
                SendKeys.Send("0");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
