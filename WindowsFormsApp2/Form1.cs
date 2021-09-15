using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        int fN, sN, startR, endR, tr1, tr2, wr1, wr2;
        int range_b, range_e, hdNO, tr3, wr3;
        int s = 0;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tm.Visible = checkBox1.Checked;
            tml.Visible = checkBox1.Checked;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            s++;
            tm.Text = s.ToString();
        }

        bool flag1, flag2, flag3 = false;
        Random rn = new Random();
        public Form1()
        {
            InitializeComponent();
            tr1 = 0;
            tr2 = 0;
            wr1 = 0;
            wr2 = 0;
            comboBox1.SelectedIndex = 0;
            tm.Visible = checkBox1.Checked;
            tml.Visible = checkBox1.Checked;
        }
        private void label16_Click(object sender, EventArgs e)
        {


        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            s = 0;
            g3.Visible = false;
            f3.Visible = false;
            flag3 = false;
            try
            {
                range_b = int.Parse(rb_1.Text);
                range_e = int.Parse(re_1.Text);
            }
            catch
            {
                //MessageBox.Show("Ввел что-то не то!");
                range_b = 0;
                range_e = 255;
            }
            hdNO = rn.Next(range_b, range_e);
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    lab_1.Text = "to Dec = ";
                    noHD.Text = "0x"+hdNO.ToString("X");
                    break;
                case 1:
                    lab_1.Text = "to Hex = ";
                    noHD.Text = hdNO.ToString();
                    break;
            }


        }
        private void button5_Click(object sender, EventArgs e)
        {
            bool res = false;
            g3.Visible = false;
            f3.Visible = false;
            try
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    res = hdNO == int.Parse(rHD.Text) ? true : false;
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    res = hdNO.ToString("X") == rHD.Text.ToUpper() ? true : false;
                }
            }
            catch
            {
                MessageBox.Show("Ты че там надумал");
            }
           
            if (res & !flag3)
            {
                timer1.Enabled = false;
                g3.Visible = true;
                tr3++;
                flag3 = true;
                t3.Text = tr3.ToString();

            }
            if (!res & !flag3)
            {
                f3.Visible = true;
                wr3++;
                w3.Text = wr3.ToString();
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool res;
            int r;
            try
            {
                r = int.Parse(rm.Text);
            }
            catch
            {
                MessageBox.Show("Ввел что-то не то!");
                r = -1;
            }
            res = (r == (fN * sN)) ? true : false;
            g2.Visible = res;
            f2.Visible = !res;
            if (res & !flag2)
            {
                timer1.Enabled = false;
                tr2++;
                t2.Text = tr2.ToString();
                flag2 = true;
            }
            if (!res & !flag2)
            {
                wr2++;
                w2.Text = wr2.ToString();
            }
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool res;
            int r;
            try
            {
                r = int.Parse(rp.Text);
            }
            catch
            {
                MessageBox.Show("Ввел что-то не то!");
                r = -1;
            }
            res = (r == (fN + sN)) ? true : false;
            g1.Visible = res;
            f1.Visible = !res;
            if (res & !flag1)
            {
                tr1++;
                t1.Text = tr1.ToString();
                flag1 = true;
                timer1.Enabled = false;
            }
            if (!res & !flag1)
            {
                wr1++;
                w1.Text = wr1.ToString();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            s = 0;
            flag1 = false;
            flag2 = false;
            rp.Text = "";
            rm.Text = "";
            try
            {
                startR = int.Parse(begin.Text);
                endR = int.Parse(end.Text);
               
            }
            catch
            {
                //MessageBox.Show("Ввел что-то не то!");
                startR = 10;
                endR = 99;
            }
            fN = rn.Next(startR, endR);
            sN = rn.Next(startR, endR);
            a.Text = fN.ToString();
            b.Text = sN.ToString();
            c.Text = fN.ToString();
            d.Text = sN.ToString();
            g1.Visible = false;
            g2.Visible = false;
        }
        

    }
}
