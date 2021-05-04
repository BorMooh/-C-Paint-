using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace PaintTool
{

    public partial class Form1 : Form
    {
        Graphics g;
        bool startPaint = false;
        int? initX = null;
        int? initY = null;

        //Za izbris canvasa
        bool canBool = false;

        //Booli za preverjanje kater lik je uporabnikh izbral
        bool elipse = false;
        bool rectangle = false;

        //Pen p je namenjem črtam, Pen pliki pa likom
        //Vsak pen je posebej ker imamo hkrati lahko drugači width za like in črte
        Pen p = new Pen(Color.Black, 5);
        Pen pliki = new Pen(Color.Black, 5);

        int brushSize = 5;
        Bitmap bmp;

        //Test
        public static string lik = "";

        //Ali je bila slika imported?
        bool imported = false;
        string pathTemp = "";

        public Form1()
        {
            InitializeComponent();

            //Novi bitmap - podloga za risanje(papir)
            bmp = new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Height);

            //Spreminjanje začetka in konca črte - da sta zaobljena
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            pliki.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pliki.EndCap = System.Drawing.Drawing2D.LineCap.Round;


        }

        #region Panel1
        //Ustvarjanje likov
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            startPaint = true;

            //Za pridobivanje centra lika.
            int diff =  Form2.F2Elwidth / 2;
            //Brush size iz Form2
            pliki.Width = Form2.brushSize;

            //Za risanje likov
            using (g = Graphics.FromImage(bmp))
            {
                //Če je katerkoli od njiju true se izvede spodji del kode
                if (elipse || rectangle)
                {
                    if (elipse) //Ali je uporabnik izbral elipso?
                    {
                        g.DrawEllipse(pliki, e.X - diff, e.Y - diff, Form2.F2Elwidth, Form2.F2Elheigth);
                    }
                    else if (rectangle) //Ali pravotoknik?
                        g.DrawRectangle(pliki, e.X - diff, e.Y - diff, Form2.F2Rewidth, Form2.F2Reheigth);


                    //Na koncu oba booleana nastavimo na false
                    elipse = false;
                    rectangle = false;
                }
            }
            panel1.Refresh();
            g.Dispose();

        }

        //Ustvarjanje črt z miško
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startPaint)
            {
                using (g = Graphics.FromImage(bmp))
                {
                    //Ob kliku na "Clear canvas"
                    if (canBool)
                    {
                        g.Clear(panel1.BackColor);
                        canBool = false;
                    }

                    //Da so črte lepše
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    //Risanje dejanske črte
                    g.DrawLine(p, new Point(initX ?? e.X, initY ?? e.Y), new Point(e.X, e.Y));
                    initX = e.X;
                    initY = e.Y;
                }
                panel1.Refresh();
                g.Dispose();
            }
        }

        //Prenehanje z risanjem
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
                startPaint = false;
                initX = null;
                initY = null;

        }

        #endregion Panel1

        //Color picker dialog
        private void colorPickerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if(cd.ShowDialog() == DialogResult.OK)
            {
                //Definiranje barve za PEN
                p.Color = cd.Color;
                pliki.Color = cd.Color;

                //Definiranje foregrond in background barve za TEKST v meniju
                toolStripColor.BackColor = cd.Color;
            }

        }

        //Save 
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            //Ali je bila slika imported?
            if(imported && pathTemp.Length != 0)
            {
                if(File.Exists(pathTemp))
                {
                    //Vsa koda je namenjena da uporabnik vidi da se shranjuje
                    Cursor.Current = Cursors.WaitCursor;
                    Application.DoEvents();
                    Thread.Sleep(700);

                    //Datoteko izbrišemo in shranimo z istim imenom
                    File.Delete(pathTemp);
                    bmp.Save(pathTemp);

                    //Naredimo Thread za prikaz teksta in cursor nastavimo na privzetega
                    Thread tekst = new Thread(StatusBarSaveTekst);
                    tekst.Start();
                    Cursor.Current = Cursors.Default;
                }

                else
                {
                    MessageBox.Show("datoteka ne obstaja!");
                }
            }
            //Če datoteke nismo importali nas vodi direktno do metode Save-As
            else
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }


        //Save-As file dialog
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Image | *.jpeg";

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                if(System.IO.File.Exists(sfd.FileName))
                {
                    System.IO.File.Delete(sfd.FileName);
                }

                bmp.Save(sfd.FileName);
                
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, Point.Empty);

        }

        //Če se form resize-a, se na novo naredi Bitmap
        private void Form1_Resize(object sender, EventArgs e)
        {
            bmp = new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Height);
        }

        //Tipke za spreminjanje debeline svincnika
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add)
            {
                brushSize += 1;
                p.Width = brushSize;
            }
            else if(e.KeyCode == Keys.Subtract)
            {
                if (brushSize > 0)
                {
                    brushSize -= 1;
                    p.Width = brushSize;
                }
            }


            toolStripPenWidth.Text = "Pen width: " + brushSize;
        }

        //Ob kliku na clear canvas
        private void clearCanvasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canBool = true;

            //Za SAVE
            imported = false;
            pathTemp = "";
        }

        //Meni za odpiranje slike in nastavljanje višine in širine
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter = "Images | *.jpg;*.jpeg;*.png;*.ico |" +
                         "All files | *.*";

            if(opd.ShowDialog() == DialogResult.OK)
            {
                //Image se import-a v Visual Studio preko FileStreama kar je potrebno da se sliko lahko shrani v isti
                //ime kot je bila prej = "Shrani namesto Shrani-kot"
                Image curImg;
                using (FileStream fs = new FileStream(opd.FileName, FileMode.Open))
                {
                    curImg = Image.FromStream(fs);
                    fs.Close();
                }

                //Izračunavanje širino glede na višino slike
                //ČE je slika višja kot širša je formula drugačna 
                int calc;
                if (curImg.Height > curImg.Width)
                    calc = (curImg.Height / curImg.Width) * panel1.Height;

                //Če je slika širša kot visoka
                else
                    calc = (curImg.Width / curImg.Height) * panel1.Width;

                bmp = new Bitmap(curImg, calc, panel1.Height);


                imported = true;
                pathTemp = opd.FileName;
            }

        }

        //Program nas vpraša če res zelimo zapreti program
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult clos = MessageBox.Show("Do you want to close Paint?", "Paint", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(clos != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        //Zamenjava barve ozadja - ob zamenjavi ozadja se vse stvari na canvasu izbrišejo!
        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            
            if(cd.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = cd.Color;

                //Ko se zamenja barva panela se bool "canBool" nastavi na true - kar potem v
                //panel1_mousemove metodi sproži Clear in počisti zaslon in spremeni barvo
                canBool = true;
            }
        }

        //Info menu item
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Odpre nov form/mbox in napiše informacije o projektu.
            string stavek = "Avtor: Bor Mohorič\n" +
                            "29.4.2021\n" +
                            "To je testni projekt.";
            MessageBox.Show(stavek, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Preverjanje kateri gradnik iz DRAW menija je bil izbran
        private void elipseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (sender.ToString() == "Elipse")
                elipse = true;

            else if (sender.ToString() == "Rectangle")
                rectangle = true;

        }

        //"Properties" okno za vsak lik
        private void setShapeProperties(object sender, EventArgs e)
        {
            //Pridobivanje imena od parenta iz MenuStripToolItem
            lik = Convert.ToString(((ToolStripMenuItem)sender).OwnerItem);


            Form2 setting = new Form2();
            setting.Show();


        }

        //--------------------------------------------------------------------------------------------------------------//
        //----------------------------------------------------METODE----------------------------------------------------//
        //--------------------------------------------------------------------------------------------------------------//
        #region Metode
        //Metoda ki nam določa barvo foregrounda glede na barvo backgrounda
        Color Kontrast(Color color)
        {
            int d = 0;
            double luminance = (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;
            if (luminance > 0.5)
                d = 0; 
            else
                d = 255; 
            return Color.FromArgb(d, d, d);
        }

        //Metoda ki nam spodaj v oknu napiše da je bila datoteka shranjena. 
        private void StatusBarSaveTekst()
        {

            toolStripStatusSaved.Text = "File has been saved!";
            toolStripStatusSaved.BackColor = Color.Yellow;
            Thread.Sleep(5000);
            toolStripStatusSaved.Text = "";

            Thread.CurrentThread.Abort();
        }

        #endregion Metode

    }
}
