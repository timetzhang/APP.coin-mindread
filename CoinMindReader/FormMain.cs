using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoinMindReader
{
    public partial class FormMain : Form
    {
        int[,] num = new int[6, 6];

        public FormMain()
        {
            InitializeComponent();
            GenerateCoin();
        }

        public void GenerateCoin()
        {
            this.flowLayoutPanel.Controls.Clear();

            Random rnd = new Random();

            for (int i = 0; i <= 4; i++)
            {
                int verify = 0;

                for (int j = 0; j <= 4; j++)
                {
                    num[i, j] = rnd.Next(0, 2);
                    if (num[i, j] == 0)
                    {
                        verify++;
                    }
                    num[i, 5] = verify%2;
                }
            }

            for (int i = 0; i <= 5; i++)
            {
                int verify = 0;

                for (int j = 0; j <= 4; j++)
                {
                    if (num[j, i] == 0)
                    {
                        verify++;
                    }
                    num[5, i] = verify % 2;
                }
            }

            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    Label l = new Label();
                    l.Text = num[i, j].ToString();
                    l.ForeColor = Color.White;
                    l.TextAlign = ContentAlignment.MiddleCenter;
                    l.Font = new Font("Verdana", this.flowLayoutPanel.Height/12, FontStyle.Bold);
                    l.Size = new Size(this.flowLayoutPanel.Width/6-6, this.flowLayoutPanel.Height/6-6);
                    l.Click += new System.EventHandler(this.l_Click);
                    this.flowLayoutPanel.Controls.Add(l);
                }
            }
            Button b = new Button();
            b.Text = "产生新随机阵列";
            b.Font = new Font("Verdana", 10, FontStyle.Bold);
            b.BackColor = Color.White;
            b.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(103)))), ((int)(((byte)(211)))));
            b.Height = 35;
            b.Width = this.flowLayoutPanel.Width-6;
            b.Click += new System.EventHandler(this.b_Click);
            this.flowLayoutPanel.Controls.Add(b);
        }

        private void l_Click(object sender, EventArgs e)
        {
            ((Label)sender).Text = ((Label)sender).Text == "0" ? "1" : "0";
        }

        private void b_Click(object sender, EventArgs e) {
            GenerateCoin();
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            GenerateCoin();
        }
    }
}
