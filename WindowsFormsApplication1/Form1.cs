using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public static SoundPlayer ButtonSound;
        public Form1()
        {
            InitializeComponent();
            ButtonSound = new SoundPlayer("ButtonSound.wav");
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

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonSound.Play();
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DS Project '17", "Hangman About");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            ButtonSound.Play();
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();     
        }

       
    }
}
