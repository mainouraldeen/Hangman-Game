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
    public partial class Form4 : Form
    {
        private SoundPlayer GameOver = new SoundPlayer("GameOverSound.wav");
        private SoundPlayer Yay = new SoundPlayer("YAYSound.wav");
        //taking a variable from form3 and use it in this form4
        int begin = Form3.beginn;
        int end = Form3.endd;

        int NumOfMistakes = 0; //index of image is the no. of mistakes
        Timer tim;
        int timer = 0;
        string CurrentWord = "";
        string CopyCurrentWord = "";

        public Form4()
        {
            InitializeComponent();
            InitializeGame();

        }


        private void DisplayCatLable(int ind) //Display the category lable upon guess index
        {
            if (0 <= ind && ind <= 9)
            {
                LableCatName.Text = "Food";
            }
            else if (10 <= ind && ind <= 19)
            {
                LableCatName.Text = "Countries";
            }
            else if (20 <= ind && ind <= 29)
            {
                LableCatName.Text = "Coding";
            }
            else if (30 <= ind && ind <= 39)
            {
                LableCatName.Text = "Animals";
            }

        }


        private void TimerTick(object sender, EventArgs e)
        {
            timer++;
            LabelTime.Text = timer.ToString();
        }

        private void disable_buttons()
        {
            tim.Stop();//as we call it if the user wins or lose
            try//as there is other objects in the form which are not buttons "labels"
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    if (b.Text != "Reset" && b.Text != "Menu")
                        b.Enabled = false;
                }
            }
            catch { }
        }


        private void changeimage()
        {
            if (NumOfMistakes == 1)
                pictureBox1.BackgroundImage = Properties.Resources.hang1;
            else if (NumOfMistakes == 2)
                pictureBox1.BackgroundImage = Properties.Resources.hang2;
            else if (NumOfMistakes == 3)
                pictureBox1.BackgroundImage = Properties.Resources.hang3;
            else if (NumOfMistakes == 4)
                pictureBox1.BackgroundImage = Properties.Resources.hang4;
            else if (NumOfMistakes == 5)
                pictureBox1.BackgroundImage = Properties.Resources.hang5;
            else if (NumOfMistakes == 6)
                pictureBox1.BackgroundImage = Properties.Resources.hang6;
            else if (NumOfMistakes == 7)
                pictureBox1.BackgroundImage = Properties.Resources.hang7;
            else if (NumOfMistakes == 8)
                pictureBox1.BackgroundImage = Properties.Resources.hang8;
            else if (NumOfMistakes == 9)
            {
                pictureBox1.BackgroundImage = Properties.Resources.hang9;
                GameOver.Play();
                tim.Stop();
                //LabelTime.Text = "0";
                MessageBox.Show(String.Format("\tYou Lost :( \n \n The Correct Word is "+ CurrentWord+"."), "Game Over!");
                disable_buttons();
            }
        }


        private void CheckIfUserWins()
        {
            if (CopyCurrentWord == CurrentWord.ToUpper())
            {
                Yay.Play();
                tim.Stop();
                MessageBox.Show("You Won ^_^", "Congratulations!");
                disable_buttons();
            }
        }

    
        private void InitializeGame()
        {
            tim = new Timer();
            timer = 0;
            LabelTime.Text = "0";
            tim.Interval = 1900;//1 sec
            tim.Start();
            tim.Tick += new EventHandler(TimerTick);
            NumOfMistakes = 0;
            pictureBox1.BackgroundImage = Properties.Resources.Background;
            LabelOfWord.Text = "";
            try //as we try to cast the menu strip which is not a button to a button
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                }
            }
            catch { }//do nothing if found an exception
  
            //get a random index
            int GuessIndex = (new Random()).Next(begin, end);

            DisplayCatLable(GuessIndex);

            //get a random word depends on which list is full
            if (Form2.EasyWords != null) //check if the list is full or not = lenght !=0
                CurrentWord =Form2.EasyWords[GuessIndex];
            else if (Form2.ModerateWords != null)
                CurrentWord = Form2.ModerateWords[GuessIndex];
            else
                CurrentWord = Form2.HardWords[GuessIndex];
            
            CopyCurrentWord = "";//update the style of word
            for (int i = 0; i < CurrentWord.Length; i++)
            {
                CopyCurrentWord += "_";
            }
            UpdateWordStyle();
        }


        private void UpdateWordStyle()//by displaying the copy of the word
        {
            LabelOfWord.Text = "";

            for (int i = 0; i < CurrentWord.Length; i++)
            {
                LabelOfWord.Text += CopyCurrentWord[i];//.Substring(i,1);//to concatenate 1 char at atime to the lable
                LabelOfWord.Text += " ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.ButtonSound.Play();
            Button B = (Button)sender;
            B.Enabled = false; //in both cases the button should be disabled
            //if the clicked button is correct
            if (CurrentWord.Contains(B.Text.ToLower()))//as i've written the letters of keyboard as capital letters
            {
                char[] CopyCurrent = CopyCurrentWord.ToCharArray();
                char[] Current = CurrentWord.ToCharArray();
                char letter = B.Text[0];//as it consider it as a string[]
                for (int i = 0; i < Current.Length; i++)
                {
                    if (Current[i] == letter + 32)//+32 to cahnge it to small letter
                    {
                        //CopyCurrentWord[i] = B.Text[0]; it can't access this string directly so we changed it into char arr//saying an error it's read only   
                        CopyCurrent[i] = B.Text[0];
                    }
                }
                //save the updated string
                CopyCurrentWord = new string(CopyCurrent);
                UpdateWordStyle();
            }

            //if the clicked button isn't in the string 
            else
            {
                NumOfMistakes++;
                changeimage();
            }
            CheckIfUserWins();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Form1.ButtonSound.Play();
            InitializeGame();
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.ButtonSound.Play();
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
        private void ButtonHint_Click(object sender, EventArgs e)
        {
            Form1.ButtonSound.Play();
            for (int i = 0; i < CurrentWord.Length; i++)
            {
                if (CopyCurrentWord[i] == '_')
                {
                    char[] copycurrent = CopyCurrentWord.ToCharArray();

                    copycurrent[i] = CurrentWord[i];
                    CopyCurrentWord = new string(copycurrent).ToUpper();

                    UpdateWordStyle();
                    ButtonHint.Enabled = false;//one hint in game
                    return;
                }
            }
        }
    }
}
