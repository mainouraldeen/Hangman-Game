using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        //passing these Lists to another forms
        public static List<string> EasyWords , ModerateWords, HardWords;
        
       
        public Form2()
        {
            InitializeComponent();
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {
            EasyWords =ModerateWords=HardWords= null;
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
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DS Project '17", "Hangman About");
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            Form1.ButtonSound.Play();
            Button b = (Button)sender;
            if (b.Text == "Easy")
                EasyWords = File.ReadAllLines("Easy.txt").ToList();

            else if (b.Text == "Moderate")
                ModerateWords = File.ReadAllLines("Moderate.txt").ToList();

            else
                HardWords = File.ReadAllLines("Hard.txt").ToList();

            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
           
        }

       
        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
