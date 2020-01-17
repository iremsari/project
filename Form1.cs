using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrackNumeratorV2
{
    public partial class Form1 : Form
    {
        int n,count;
        int rowNum, columnNum;

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'A' && e.KeyChar <= 'F') || (e.KeyChar >= 'a' && e.KeyChar <= 'f')))
            {
                MessageBox.Show("Lütfen Hexadecimal bir sayı giriniz");
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'A' && e.KeyChar <= 'F') || (e.KeyChar >= 'a' && e.KeyChar <= 'f'))) 
            {
                MessageBox.Show("Lütfen Hexadecimal bir sayı giriniz");
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if( !char.IsDigit(e.KeyChar) )
            {
                MessageBox.Show("Lütfen pozitif bir sayı giriniz");
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowCount = 2;
        }

        public Form1()
        {
            InitializeComponent();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int hexNum = Int32.Parse(textBox2.Text, System.Globalization.NumberStyles.HexNumber);
            string hexValue = hexNum.ToString("X");

            int hexMaxDec= Int32.Parse(textBox3.Text, System.Globalization.NumberStyles.HexNumber);
            string hexMaxValue = hexMaxDec.ToString("X");

            n = Convert.ToInt32(textBox1.Text);
            count = n;

            if (n<=8)
            {
                int[,] flagArray = new int[2, 4];
                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 4; j++)
                        flagArray[i, j] = 0;

                Random r = new Random();
                while (count != 0)
                {
                    columnNum = r.Next() % 4;
                    rowNum = r.Next() % 2;
                    if ((flagArray[rowNum, columnNum] == 0))
                    {
                        flagArray[rowNum, columnNum] = 1;
                        count--;
                    }
                }

                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 4; j++)
                    {
                        if ((flagArray[i, j] == 1) && (hexNum <= hexMaxDec))
                        {
                            CircleButton greenCircle = new CircleButton();
                            greenCircle.BackColor = Color.Green;
                            greenCircle.FlatStyle = FlatStyle.Flat;
                            greenCircle.FlatAppearance.BorderSize = 0;
                            greenCircle.Dock = System.Windows.Forms.DockStyle.Fill;

                            greenCircle.Text = hexValue;
                            tableLayoutPanel1.Controls.Add(greenCircle, j, i);
                            hexNum++;
                            hexValue = hexNum.ToString("X");
                        }
                        else
                        {
                            CircleButton redCircle = new CircleButton();
                            redCircle.BackColor = Color.Red;
                            redCircle.FlatStyle = FlatStyle.Flat;
                            redCircle.FlatAppearance.BorderSize = 0;
                            redCircle.Dock = System.Windows.Forms.DockStyle.Fill;
                            tableLayoutPanel1.Controls.Add(redCircle, j, i);
                        }
                    }
            }
            else
            {
                int a = n / 4;
                if (n % 4 != 0)
                    a++;

                int[,] flagArray = new int[a, 4];
                for (int i = 0; i < a; i++)
                    for (int j = 0; j < 4; j++)
                        flagArray[i, j] = 0;

                Random r = new Random();
                while (count != 0)
                {
                    columnNum = r.Next() % 4;
                    rowNum = r.Next() % a;
                    if ((flagArray[rowNum, columnNum] == 0))
                    {
                        flagArray[rowNum, columnNum] = 1;
                        count--;
                    }
                }

                tableLayoutPanel1.RowCount = a;
                for(int b=2;b<a;b++)
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50));

                for (int i = 0; i < a; i++)
                    for (int j = 0; j < 4; j++)
                    {
                        if ((flagArray[i, j] == 1) && (hexNum <= hexMaxDec))
                        {
                            CircleButton greenCircle = new CircleButton();
                            greenCircle.BackColor = Color.Green;
                            greenCircle.FlatStyle = FlatStyle.Flat;
                            greenCircle.FlatAppearance.BorderSize = 0;
                            greenCircle.Dock = System.Windows.Forms.DockStyle.Fill;

                            greenCircle.Text = hexValue;
                            tableLayoutPanel1.Controls.Add(greenCircle, j, i);
                            hexNum++;
                            hexValue = hexNum.ToString("X");
                        }
                        else
                        {
                            CircleButton redCircle = new CircleButton();
                            redCircle.BackColor = Color.Red;
                            redCircle.FlatStyle = FlatStyle.Flat;
                            redCircle.FlatAppearance.BorderSize = 0;
                            redCircle.Dock = System.Windows.Forms.DockStyle.Fill;
                            tableLayoutPanel1.Controls.Add(redCircle, j, i);
                        }
                    }
            }
        }
    }
}
