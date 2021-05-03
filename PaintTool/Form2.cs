using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintTool
{
    public partial class Form2 : Form
    {
        //Elipse H in W
        public static int F2Elwidth;
        public static int F2Elheigth;

        //Rectangle H in W
        public static int F2Rewidth;
        public static int F2Reheigth;

        public static int brushSize;

        bool buttonLock = false;


        public Form2()
        {
            InitializeComponent();
            label1.Text = Form1.lik;

            //Če imamo izbrano elipso nam v textboxe uvozi podatke ki smo jih nazadnje vnesli za elipso
            if(label1.Text == "Elipse")
            {
                tbWid.Text = Properties.Settings.Default.width.ToString();
                tbHei.Text = Properties.Settings.Default.height.ToString();

                trackBarW.Value = Properties.Settings.Default.width;
                trackBarH.Value = Properties.Settings.Default.height;
            }
            //Za pravokotnik nam naredi enako
            else if(label1.Text == "Rectangle")
            {
                tbWid.Text = Properties.Settings.Default.Rewidth.ToString();
                tbHei.Text = Properties.Settings.Default.Reheigth.ToString();

                trackBarW.Value = Properties.Settings.Default.Rewidth;
                trackBarH.Value = Properties.Settings.Default.Reheigth;
            }

            //Nastavljanje default vrednosti za Elipso
            F2Elwidth = Properties.Settings.Default.width;
            F2Elheigth = Properties.Settings.Default.height;

            //Nastavljanje default vrednosti za Rectangle
            F2Rewidth = Properties.Settings.Default.Rewidth;
            F2Reheigth = Properties.Settings.Default.Reheigth;

            //PaintTool.Properties.Settings.Default.width
        }


        //Gumb "Generiraj"
        private void button1_Click(object sender, EventArgs e)
        {
            //Deklaracije za grafiko
            Graphics g = panel1.CreateGraphics();
            g.Clear(panel1.BackColor);

            brushSize = Convert.ToInt32(tbBru.Text);

            Pen p = new Pen(Color.Black, brushSize);


            if (label1.Text == "Elipse")
            {
                try
                {
                    //Če imamo elipso nam podatke iz textboxov shrani v spremenljivke
                    F2Elwidth = int.Parse(tbWid.Text);
                    F2Elheigth = int.Parse(tbHei.Text);

                    //Obe vrednosti (Width, Height) nam tudi shrani v projekt 
                    Properties.Settings.Default.width = Convert.ToInt32(tbWid.Text);
                    Properties.Settings.Default.height = Convert.ToInt32(tbHei.Text);

                    //Izris elipse
                    g.DrawEllipse(p, (panel1.Height / 2) - (F2Elheigth / 2), (panel1.Width / 2) - (F2Elwidth / 2), F2Elwidth, F2Elheigth);

                }
                catch
                {
                    MessageBox.Show("Enter a valid number", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
            else if(label1.Text == "Rectangle")
            {
                try
                {
                    //Če imamo elipso nam podatke iz textboxov shrani v spremenljivke
                    F2Rewidth = int.Parse(tbWid.Text);
                    F2Reheigth = int.Parse(tbHei.Text);

                    //Obe vrednosti (Width, Height) nam tudi shrani v projekt 
                    Properties.Settings.Default.Rewidth = Convert.ToInt32(tbWid.Text);
                    Properties.Settings.Default.Reheigth = Convert.ToInt32(tbHei.Text);

                    //Izris pravokotnika
                    //g.DrawRectangle(p, panel1.Height / 2, panel1.Width / 2, F2Rewidth, F2Reheigth);
                    g.DrawRectangle(p, (panel1.Height / 2) - (F2Reheigth / 2), (panel1.Width / 2) - (F2Rewidth / 2), F2Rewidth, F2Reheigth); 
                }
                catch
                {
                    MessageBox.Show("Enter a valid number", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            //Na koncu shranimo spremenljivke v projektu
            Properties.Settings.Default.Save();
        }
        //Metoda ki se izvede vsakič ko trackbar uporabimo
        private void scroll(object sender, EventArgs e)
        {
            tbWid.Text = Convert.ToString(trackBarW.Value);
            tbHei.Text = Convert.ToString(trackBarH.Value);

            if(buttonLock)//Width
            {
                trackBarH.Value = trackBarW.Value;
                tbHei.Text = tbWid.Text;
                trackBarH.Enabled = false;

            }
        }
        private void tbWid_Leave(object sender, EventArgs e)
        {
            if(buttonLock)
            {
                tbHei.Text = tbWid.Text;
            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (buttonLock)
            {
                buttonLock = false;
                trackBarH.Enabled = true;
                btnLock.BackColor = Color.White;
            }
            else
            {
                buttonLock = true;
                btnLock.BackColor = Color.Black;
            }
        }


    }
}
