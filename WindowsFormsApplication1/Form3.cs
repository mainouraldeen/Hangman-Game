using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        //to pass the values to form4
        public static int beginn,endd;
      
        public Form3()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.hang4;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Timer tim = new Timer();
            tim.Interval = 150;
            tim.Tick += new EventHandler(changeimage);
            tim.Start();
        }
        private void changeimage(object sender, EventArgs e)
        {
            
            List<Bitmap> b1 = new List<Bitmap>();
            b1.Add(Properties.Resources.hang4);
            b1.Add(Properties.Resources.hang5);
            b1.Add(Properties.Resources.hang6);
            b1.Add(Properties.Resources.hang7);
            b1.Add(Properties.Resources.hang8);
            b1.Add(Properties.Resources.hang9);
            int index = DateTime.Now.Second % b1.Count;

            pictureBox1.Image = b1[index];

        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DS Project '17", "Hangman About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            Form1.ButtonSound.Play();

            Button b = (Button)sender;
            if (b.Text == "Animals")
            {
                //we have to set the values first then create the form
                Form3.beginn = 30;
                Form3.endd = 39;
                Form4 f4 = new Form4();
                f4.BackgroundImage = Properties.Resources.animals;
                f4.Show();
            }
            else if (b.Text == "Food")
            {
                Form3.beginn = 0;
                Form3.endd = 10;
                Form4 f4 = new Form4();
                f4.BackgroundImage = Properties.Resources.food;
                f4.Show();
            }
            else if (b.Text == "Countries")
            {

                Form3.beginn = 10;
                Form3.endd = 20;
                Form4 f4 = new Form4();
                f4.BackgroundImage = Properties.Resources.countries;
                f4.Show();
            }
            else if (b.Text == "Coding")
            {

                Form3.beginn = 20;
                Form3.endd = 30;
                Form4 f4 = new Form4();
                f4.BackgroundImage = Properties.Resources.coding;
                f4.Show();
            }
            else //Random Case
            {
                Form3.beginn = 0;
                Form3.endd = 40;
                Form4 f4 = new Form4();
                f4.BackgroundImage = Properties.Resources.randomm;
                f4.Show();
            }
            this.Hide();
        }
    }
}
