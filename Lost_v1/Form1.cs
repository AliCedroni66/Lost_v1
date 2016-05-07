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
using System.Media;

namespace Lost_v1
{
    public partial class LostForm : Form
    {
        int X = 0;
        int Y = 0;
        int moveCount = 0;
        int deathCount = 0;
        string progress = "";
        string playing = "";
        Random random = new Random();
        int RandomNumber = 0;
        SoundPlayer player;
        bool Cheat = false;

        private string progressFile = "progress.txt";
       

        public LostForm()
        {
            InitializeComponent();

            LabelX.Hide();
            LabelY.Hide();
            textLabel.Hide();

            DeathLabel.Hide();
            MoveLabel.Hide();
            MenuButton.Hide();
            MainText.Hide();
            Level2Button.Hide();
            //Level3Button.Hide();
            TutorialEndButton.Hide();
            LabelX.Text = Convert.ToString(X);
            LabelY.Text = Convert.ToString(Y);


            //Progression for additional levels
            if (File.Exists("Progress.txt"))
            {
                if (progress == "2")
                {
                    Level2Button.Show();
                }
                /*if (progress == "3")
                {
                    Level2Button.Show();
                    Level3Button.Show();
                }  */
            }
        }

        

        private void LostForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (playing == "0")
            {

            }
            else
            {
                if (e.KeyCode == Keys.Up)
                {
                    if (Y <= 29)
                    {
                        Y++;
                        PlaySound();
                        moveCount++;
                        LabelY.Text = Convert.ToString(Y);
                        MoveLabel.Text = Convert.ToString("Moves: " + moveCount);
                        DeathLabel.Text = Convert.ToString("Deaths: " + deathCount);
                    }
                    else
                    {
                        Thud();
                    }
                }
                if (e.KeyCode == Keys.Down)
                {
                    if (Y >= 2)
                    {
                        Y--;
                        PlaySound();
                        moveCount++;
                        LabelY.Text = Convert.ToString(Y);
                        MoveLabel.Text = Convert.ToString("Moves: " + moveCount);
                        DeathLabel.Text = Convert.ToString("Deaths: " + deathCount);
                    }
                    else
                    {
                        Thud();
                    }
                }
                if (e.KeyCode == Keys.Left)
                {
                    if (X >= 2)
                    {
                        X--;
                        PlaySound();
                        moveCount++;
                        LabelX.Text = Convert.ToString(X);
                        MoveLabel.Text = Convert.ToString("Moves: " + moveCount);
                        DeathLabel.Text = Convert.ToString("Deaths: " + deathCount);
                    }
                    else
                    {
                        Thud();
                    }
                }
                if (e.KeyCode == Keys.Right)
                {
                    if (X <= 29)
                    {
                        X++;
                        PlaySound();
                        moveCount++;
                        LabelX.Text = Convert.ToString(X);
                        MoveLabel.Text = Convert.ToString("Moves: " + moveCount);
                    }
                    else
                    {
                        Thud();
                    }
                }
            }
            
            if (e.KeyCode == Keys.Escape)
            {
                 menu();
            }
            if (e.KeyCode == Keys.Oemtilde)
            {
                if (Cheat == false)
                {
                    LabelX.Show();
                    LabelY.Show();
                    textLabel.Show();
                    Cheat = true;
                }
                else
                {
                    LabelX.Hide();
                    LabelY.Hide();
                    textLabel.Hide();
                    Cheat = false;
                }
            }
        }

        private void level1()
        {
            Level1Button.Hide();
            Level2Button.Hide();
            //Level3Button.Hide();
            TutorialEndButton.Hide();
            TutorialButton.Hide();
            CreditsButton.Hide();
            MoveLabel.Show();
            DeathLabel.Show();
            MenuButton.Hide();
            MainText.Show();
            this.Focus();
            this.Activate();
            MainText.Text = "";

            X = 16;
            Y = 1;
            LabelX.Text = Convert.ToString(X);
            LabelY.Text = Convert.ToString(Y);
            moveCount = 0;
            deathCount = 0;
            MoveLabel.Text = Convert.ToString("Moves: " + moveCount);
            DeathLabel.Text = Convert.ToString("Deaths: " + deathCount);
            playing = "1";

            
        }

        private void level2()
        {
            Level1Button.Hide();
            Level2Button.Hide();
            //Level3Button.Hide();
            TutorialEndButton.Hide();
            TutorialButton.Hide();
            CreditsButton.Hide();
            MoveLabel.Show();
            DeathLabel.Show();
            MenuButton.Hide();
            MainText.Show();
            MainText.Text = "";

            progress = "2";
            File.WriteAllText("progress.txt", progress);

            if (!File.Exists("progress.txt"))
            {
                File.WriteAllText(progressFile, "2");
            }

            X = 8;
            Y = 1;
            LabelX.Text = Convert.ToString(X);
            LabelY.Text = Convert.ToString(Y);
            moveCount = 0;
            deathCount = 0;
            MoveLabel.Text = Convert.ToString("Moves: " + moveCount);
            DeathLabel.Text = Convert.ToString("Deaths: " + deathCount);
            playing = "2";
        }

        /*private void level3()
        {
            Level1Button.Hide();
            Level2Button.Hide();
            Level3Button.Hide();
            TutorialEndButton.Hide();
            TutorialButton.Hide();
            CreditsButton.Hide();
            MoveLabel.Show();
            DeathLabel.Show();
            MenuButton.Show();
            MainText.Show();

            progress = "3";
            File.WriteAllText("progress.txt", progress);

            if (!File.Exists("progress.txt"))
            {
                File.WriteAllText(progressFile, "3");
            }

             X = 1;
            Y = 1;
            LabelX.Text = Convert.ToString(X);
            LabelY.Text = Convert.ToString(Y);
            moveCount = 0;
            deathCount = 0;
            MoveLabel.Text = Convert.ToString("Moves: " + moveCount);
            DeathLabel.Text = Convert.ToString("Deaths: " + deathCount);
            playing = "3";
        }*/

        private void tutorial()
        {
            Level1Button.Hide();
            Level2Button.Hide();
            //Level3Button.Hide();
            TutorialEndButton.Show();
            TutorialButton.Hide();
            CreditsButton.Hide();
            MoveLabel.Hide();
            DeathLabel.Hide();
            MenuButton.Show();
            MainText.Show();

            MainText.Text = File.ReadAllText("tutorial.txt");
        }

        private void credits()
        {
            Level1Button.Hide();
            Level2Button.Hide();
            //Level3Button.Hide();
            TutorialEndButton.Hide();
            TutorialButton.Hide();
            CreditsButton.Hide();
            MoveLabel.Hide();
            DeathLabel.Hide();
            MenuButton.Show();
            MainText.Show();

            MainText.Text = File.ReadAllText("credits.txt");
        }

        private void menu()
        {
            DeathLabel.Hide();
            MoveLabel.Hide();
            MenuButton.Hide();
            MainText.Hide();
            Level1Button.Show();
            Level2Button.Hide();
            //Level3Button.Hide();
            CreditsButton.Show();
            TutorialButton.Show();
            TutorialEndButton.Hide();
            MainText.Text = "";


            if (File.Exists("Progress.txt"))
            {
                progress = File.ReadAllText(progressFile);
                if (progress == "2")
                {
                    Level2Button.Show();
                }
                /*if (progress == "3")
                {
                    Level2Button.Show();
                    Level3Button.Show();
                }*/
            }
        }


        //SoundTriggers
        private void PlaySound()
        {
            //level 1 sounds
            if (moveCount == 80)
            {
                MainText.Text = "Listen carefully, the path may sound slightly different.";
            }
            if (moveCount == 150)
            {
                MainText.Text = "Maybe try a more straightforward path?";
            }
            if (moveCount == 500)
            {
                MainText.Text = "Okay no seriously, just walk forward. There's a dirt path, you go over a bridge, hit a sidewalk and your house is literally in front of you. \n\n This is just sad.";
            }
            if (playing == "1")
            {
                if (Y == 1 && X == 16)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 1 && X == 20)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 1 && X == 21)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 1 && X == 22)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 1 && X == 23)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 1 && X == 24)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 2 && X == 16)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 2 && X == 20)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 2 && X == 21)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 2 && X == 22)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 2 && X == 23)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 2 && X == 24)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 3 && X == 16)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 3 && X == 20)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 3 && X == 21)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 3 && X == 22)
                {
                    textLabel.Text = "Eaten";
                    Eaten();
                }
                else if (Y == 3 && X == 23)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 3 && X == 24)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 4 && X == 2)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 4 && X == 3)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 4 && X == 4)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 4 && X == 5)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 4 && X == 6)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 4 && X == 16)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 4 && X == 20)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 4 && X == 21)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 4 && X == 22)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 4 && X == 23)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 4 && X == 24)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 5 && X == 2)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 5 && X == 3)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 5 && X == 4)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 5 && X == 5)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 5 && X == 6)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 5 && X == 16)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 5 && X == 20)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 5 && X == 21)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 5 && X == 23)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 5 && X == 24)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 6 && X == 2)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 6 && X == 3)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 6 && X == 4)
                {
                    textLabel.Text = "Eaten";
                    Eaten();
                }
                else if (Y == 6 && X == 5)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 6 && X == 6)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 6 && X == 16)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 7 && X == 2)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 7 && X == 3)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 7 && X == 4)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 7 && X == 5)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 7 && X == 6)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 7 && X == 16)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 8 && X == 2)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 8 && X == 3)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 8 && X == 4)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 8 && X == 5)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 8 && X == 6)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 8 && X == 16)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 9 && X == 16)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 9 && X == 25)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 9 && X == 26)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 9 && X == 27)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 9 && X == 28)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 9 && X == 29)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 10 && X == 1)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 10 && X == 2)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 10 && X == 3)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 10 && X == 4)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 10 && X == 5)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 10 && X == 16)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 10 && X == 25)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 10 && X == 26)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 10 && X == 27)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 10 && X == 28)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 10 && X == 29)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 11 && X == 1)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 11 && X == 2)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 11 && X == 3)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 11 && X == 4)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 11 && X == 5)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 11 && X == 6)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 11 && X == 7)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 11 && X == 16)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 11 && X == 25)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 11 && X == 26)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 11 && X == 27)
                {
                    textLabel.Text = "Eaten";
                    Eaten();
                }
                else if (Y == 11 && X == 28)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 11 && X == 29)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 12 && X == 1)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 12 && X == 2)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 12 && X == 3)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 12 && X == 4)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 12 && X == 5)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 12 && X == 6)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 12 && X == 7)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 12 && X == 8)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 12 && X == 9)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 12 && X == 16)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 12 && X == 25)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                 }
                else if (Y == 12 && X == 26)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 12 && X == 27)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 12 && X == 28)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 12 && X == 29)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 13 && X == 5)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 13 && X == 6)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 13 && X == 7)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 13 && X == 8)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 13 && X == 9)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 13 && X == 10)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 13 && X == 11)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 13 && X == 12)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 13 && X == 16)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 13 && X == 25)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 13 && X == 26)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 13 && X == 27)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 13 && X == 28)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 13 && X == 29)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 14 && X == 7)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 14 && X == 8)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 14 && X == 9)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 14 && X == 10)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 14 && X == 11)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 14 && X == 12)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 14 && X == 13)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 14 && X == 16)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 14 && X == 19)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 14 && X == 20)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 14 && X == 21)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 14 && X == 22)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 14 && X == 23)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 15 && X == 9)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 15 && X == 10)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 15 && X == 11)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 15 && X == 12)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 15 && X == 13)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 15 && X == 14)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 15 && X == 15)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 15 && X == 16)
                {
                    textLabel.Text = "Wood";
                    FootWood();
                }
                else if (Y == 15 && X == 17)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 15 && X == 18)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 15 && X == 19)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 15 && X == 20)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 15 && X == 21)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 15 && X == 22)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 15 && X == 23)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 15 && X == 24)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 15 && X == 25)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 15 && X == 26)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 16 && X == 1)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 16 && X == 2)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 16 && X == 3)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 16 && X == 12)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 16 && X == 13)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 16 && X == 14)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 16 && X == 15)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 16 && X == 16)
                {
                    textLabel.Text = "Wood";
                    FootWood();
                }
                else if (Y == 16 && X == 17)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 16 && X == 18)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 16 && X == 19)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 16 && X == 20)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 16 && X == 21)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 16 && X == 22)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 16 && X == 23)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 16 && X == 24)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 16 && X == 25)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 16 && X == 26)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 16 && X == 27)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 16 && X == 28)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 17 && X == 1)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 17 && X == 2)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 17 && X == 3)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 17 && X == 4)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 17 && X == 5)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 17 && X == 9)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 17 && X == 10)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 17 && X == 11)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 17 && X == 12)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 17 && X == 13)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 17 && X == 14)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 17 && X == 15)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 17 && X == 16)
                {
                    textLabel.Text = "Wood";
                    FootWood();
                }
                else if (Y == 17 && X == 17)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 17 && X == 18)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 17 && X == 19)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 17 && X == 20)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 17 && X == 21)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 17 && X == 22)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 17 && X == 23)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 17 && X == 24)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 17 && X == 25)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 17 && X == 26)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 17 && X == 27)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 17 && X == 28)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 17 && X == 29)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 17 && X == 30)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 18 && X == 1)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 18 && X == 2)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 18 && X == 3)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 18 && X == 4)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 18 && X == 5)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 18 && X == 6)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 18 && X == 7)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 18 && X == 8)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 18 && X == 9)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 18 && X == 10)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 18 && X == 11)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 18 && X == 12)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 18 && X == 13)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 18 && X == 14)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 18 && X == 15)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 18 && X == 16)
                {
                    textLabel.Text = "Wood";
                    FootWood();
                }
                else if (Y == 18 && X == 17)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 18 && X == 18)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 18 && X == 19)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 18 && X == 20)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 18 && X == 21)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 18 && X == 22)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 18 && X == 23)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 18 && X == 24)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 18 && X == 26)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 18 && X == 27)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 18 && X == 28)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 18 && X == 29)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 18 && X == 30)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 19 && X == 4)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 19 && X == 5)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 19 && X == 6)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 19 && X == 7)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 19 && X == 8)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 19 && X == 9)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 19 && X == 10)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 19 && X == 11)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 19 && X == 12)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 19 && X == 16)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 19 && X == 21)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 19 && X == 22)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 19 && X == 23)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 19 && X == 24)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 19 && X == 25)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 19 && X == 26)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 19 && X == 27)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 19 && X == 28)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 19 && X == 29)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 19 && X == 30)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 20 && X == 6)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 20 && X == 7)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 20 && X == 8)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 20 && X == 16)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 20 && X == 23)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 20 && X == 24)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 20 && X == 25)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 20 && X == 26)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 20 && X == 27)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 20 && X == 28)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 20 && X == 29)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 20 && X == 30)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 21 && X == 16)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 21 && X == 25)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 21 && X == 26)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 21 && X == 27)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 21 && X == 28)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 21 && X == 29)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 21 && X == 30)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 22 && X == 16)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 22 && X == 28)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 22 && X == 29)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 22 && X == 30)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 23 && X == 16)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 24)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 25 && X == 1)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 2)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 3)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 4)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 5)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 6)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 7)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 8)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 9)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 10)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 11)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 12)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 13)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 14)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 15)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 16)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 25 && X == 17)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 18)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 19)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 20)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 21)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 22)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 23)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 24)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 25)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 26)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 27)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 28)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 29)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 30)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 26 && X == 1)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 2)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 3)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 4)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 5)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 6)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 7)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 8)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 9)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 10)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 11)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 12)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 13)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 14)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 15)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 26 && X == 16)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 26 && X == 17)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 26 && X == 18)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 19)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 20)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 21)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 22)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 23)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 24)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 25)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 26)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 27)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 28)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 29)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 30)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 27 && X == 1)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 2)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 3)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 4)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 5)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 6)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 7)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 8)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 9)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 10)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 11)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 12)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 13)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 14)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 27 && X == 15)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 27 && X == 16)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 27 && X == 17)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 27 && X == 18)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 27 && X == 19)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 20)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 21)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 22)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 23)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 24)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 25)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 26)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 27)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 28)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 29)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 27 && X == 30)
                {
                    textLabel.Text = "CarCrash";
                    CarCrash();
                }
                else if (Y == 28 && X == 1)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 2)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 3)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 4)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 5)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 6)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 7)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 8)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 9)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 10)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 11)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 12)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 13)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 14)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 15)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 28 && X == 16)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 28 && X == 17)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 28 && X == 18)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 19)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 20)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 21)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 22)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 23)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 24)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 25)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 26)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 27)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 28)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 29)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 30)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 29 && X == 1)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 2)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 3)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 4)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 5)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 6)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 7)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 8)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 9)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 10)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 11)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 12)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 13)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 14)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 15)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 16)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 17)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 18)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 19)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 20)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 21)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 22)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 23)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 24)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 25)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 26)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 27)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 28)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 29)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 30)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 30 && X == 1)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 2)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 3)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 4)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 5)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 6)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 7)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 8)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 9)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 10)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 11)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 12)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 13)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 14)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 15)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 16)
                {
                    textLabel.Text = "Door";
                    Door();

                    progress = "2";
                    File.WriteAllText("progress.txt", progress);
                }
                else if (Y == 30 && X == 17)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 18)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 19)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 20)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 21)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 22)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 23)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 24)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 25)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 26)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 27)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 28)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 29)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 30)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                    //last sound
                else
                {
                    textLabel.Text = "Grass";
                    FootGrass();
                }
            }

            //level 2 sounds
            else if (playing == "2")
            {
                if (moveCount == 80)
                {
                    MainText.Text = "Remember to listen to your steps, the path will sound different.";
                }
                if (moveCount == 150)
                {
                    MainText.Text = "You are south of your house, maybe that would help?";
                }
                if (moveCount == 600)
                {
                    MainText.Text = "Okay okay, I guess this is just too hard for you. Just walk forward. Again. You'll lose the path but your house is liteally right in front of you AGAIN.";
                }
                if (Y == 1)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 2 && X == 5)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 2 && X == 6)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 2 && X == 7)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 2 && X == 8)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 2 && X == 9)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 2 && X == 27)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 3 && X == 5)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 3 && X == 6)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 3 && X == 7)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 3 && X == 8)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 3 && X == 9)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 3 && X == 27)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 4 && X == 5)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 4 && X == 6)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 4 && X == 7)
                {
                    textLabel.Text = "Eaten";
                    Eaten();
                }
                else if (Y == 4 && X == 8)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 4 && X == 9)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 4 && X == 27)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 5 && X == 5)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 5 && X == 6)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 5 && X == 7)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 5 && X == 8)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 5 && X == 9)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 5 && X == 27)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 6 && X == 5)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 6 && X == 6)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 6 && X == 7)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 6 && X == 8)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 6 && X == 9)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 6 && X == 27)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 7 && X == 27)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 8 && X == 27)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 9 && X == 12)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 9 && X == 13)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 9 && X == 14)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 9 && X == 27)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 10 && X == 1)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 10 && X == 2)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 10 && X == 3)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 10 && X == 4)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 10 && X == 5)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 10 && X == 6)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 10 && X == 7)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 10 && X == 8)
                {
                    textLabel.Text = "Wood";
                    FootWood();
                }
                else if (Y == 10 && X == 9)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 10 && X == 10)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 10 && X == 11)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 10 && X == 12)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 10 && X == 13)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 10 && X == 14)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 10 && X == 15)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 10 && X == 27)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 11 && X == 1)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 11 && X == 2)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 11 && X == 3)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 11 && X == 4)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 11 && X == 5)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 11 && X == 6)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 11 && X == 7)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 11 && X == 8)
                {
                    textLabel.Text = "Wood";
                    FootWood();
                }
                else if (Y == 11 && X == 9)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 11 && X == 10)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 11 && X == 11)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 11 && X == 12)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 11 && X == 13)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 11 && X == 14)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 11 && X == 15)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 11 && X == 16)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 11 && X == 27)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 12 && X == 1)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 12 && X == 2)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 12 && X == 3)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 12 && X == 4)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 12 && X == 5)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 12 && X == 6)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 12 && X == 7)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 12 && X == 8)
                {
                    textLabel.Text = "Wood";
                    FootWood();
                }
                else if (Y == 12 && X == 9)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 12 && X == 10)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 12 && X == 11)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 12 && X == 15)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 12 && X == 16)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 12 && X == 17)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 12 && X == 18)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 12 && X == 19)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 12 && X == 20)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 12 && X == 21)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 12 && X == 22)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 12 && X == 23)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 12 && X == 24)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 12 && X == 25)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 12 && X == 26)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 12 && X == 27)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 13 && X == 7)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 13 && X == 8)
                {
                    textLabel.Text = "Wood";
                    FootWood();
                }
                else if (Y == 13 && X == 9)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 13 && X == 15)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 13 && X == 16)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 13 && X == 17)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 13 && X == 18)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 14 && X == 4)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 14 && X == 5)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 14 && X == 6)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 14 && X == 7)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 14 && X == 8)
                {
                    textLabel.Text = "Wood";
                    FootWood();
                }
                else if (Y == 14 && X == 9)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 14 && X == 10)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 14 && X == 11)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 14 && X == 12)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 14 && X == 13)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 14 && X == 14)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 14 && X == 15)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 14 && X == 16)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 14 && X == 17)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 14 && X == 18)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 15 && X == 1)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 15 && X == 2)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 15 && X == 3)
                {
                    textLabel.Text = "Drown";
                    Drown();
                }
                else if (Y == 15 && X == 4)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 15 && X == 5)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 15 && X == 6)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 15 && X == 7)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 15 && X == 8)
                {
                    textLabel.Text = "Wood";
                    FootWood();
                }
                else if (Y == 15 && X == 9)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 15 && X == 10)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 15 && X == 11)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 15 && X == 12)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 15 && X == 13)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 15 && X == 14)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 15 && X == 15)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 15 && X == 16)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 15 && X == 18)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 16 && X == 1)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 16 && X == 2)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 16 && X == 3)
                {
                    textLabel.Text = "Water";
                    FootWater();
                }
                else if (Y == 16 && X == 4)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 16 && X == 5)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 16 && X == 6)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 16 && X == 7)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 16 && X == 8)
                {
                    textLabel.Text = "Wood";
                    FootWood();
                }
                else if (Y == 16 && X == 8)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 16 && X == 10)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 16 && X == 11)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 16 && X == 12)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 16 && X == 13)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 16 && X == 14)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 16 && X == 15)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 16 && X == 18)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 17 && X == 1)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 17 && X == 2)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 17 && X == 3)
                {
                    textLabel.Text = "Sand";
                    FootSand();
                }
                else if (Y == 17 && X == 18)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 18 && X == 13)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 18 && X == 14)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 18 && X == 15)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 18 && X == 16)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 18 && X == 17)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 18 && X == 18)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 19 && X == 13)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 19 && X == 14)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 19 && X == 15)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 19 && X == 16)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 19 && X == 17)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 19 && X == 18)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 19 && X == 23)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 19 && X == 24)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 19 && X == 25)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 19 && X == 26)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 19 && X == 27)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 19 && X == 28)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 19 && X == 29)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 19 && X == 30)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 20 && X == 13)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 20 && X == 14)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 20 && X == 15)
                {
                    textLabel.Text = "Eaten";
                    Eaten();
                }
                else if (Y == 20 && X == 16)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 20 && X == 17)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 20 && X == 18)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 20 && X == 23)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 20 && X == 24)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 20 && X == 25)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 20 && X == 26)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 20 && X == 27)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 20 && X == 28)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 20 && X == 29)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 20 && X == 30)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 21 && X == 13)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 21 && X == 14)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 21 && X == 15)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 21 && X == 16)
                {
                    textLabel.Text = "Growl";
                    Growl();
                }
                else if (Y == 21 && X == 17)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 21 && X == 18)
                {
                    textLabel.Text = "Dirt";
                    FootDirt();
                }
                else if (Y == 21 && X == 23)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 21 && X == 24)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 21 && X == 25)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 21 && X == 26)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 21 && X == 27)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 21 && X == 28)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 21 && X == 29)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 21 && X == 30)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 22 && X == 13)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 22 && X == 14)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 22 && X == 15)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 22 && X == 16)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 22 && X == 17)
                {
                    textLabel.Text = "Shuffle";
                    Shuffle();
                }
                else if (Y == 22 && X == 18)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 22 && X == 23)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 22 && X == 24)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 22 && X == 25)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 22 && X == 26)
                {
                    textLabel.Text = "Crash";
                    CarCrash();
                }
                else if (Y == 22 && X == 27)
                {
                    textLabel.Text = "Crash";
                    CarCrash();
                }
                else if (Y == 22 && X == 28)
                {
                    textLabel.Text = "Crash";
                    CarCrash();
                }
                else if (Y == 22 && X == 29)
                {
                    textLabel.Text = "Crash";
                    CarCrash();
                }
                else if (Y == 22 && X == 30)
                {
                    textLabel.Text = "Crash";
                    CarCrash();
                }
                else if (Y == 23 && X == 9)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 23 && X == 10)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 23 && X == 11)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 23 && X == 12)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 23 && X == 13)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 23 && X == 14)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 23 && X == 15)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 23 && X == 16)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 23 && X == 17)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 23 && X == 18)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 23 && X == 19)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 23 && X == 20)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 23 && X == 21)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 23 && X == 22)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 23 && X == 23)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 23 && X == 24)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 23 && X == 25)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 23 && X == 26)
                {
                    textLabel.Text = "Crash";
                    CarCrash();
                }
                else if (Y == 24 && X == 9)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 24 && X == 10)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 24 && X == 11)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 24 && X == 12)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 24 && X == 13)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 24 && X == 14)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 24 && X == 15)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 24 && X == 16)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 24 && X == 17)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 24 && X == 18)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 24 && X == 19)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 24 && X == 20)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 24 && X == 21)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 24 && X == 22)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 24 && X == 23)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 24 && X == 24)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 24 && X == 25)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 24 && X == 26)
                {
                    textLabel.Text = "Crash";
                    CarCrash();
                }
                else if (Y == 25 && X == 9)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 25 && X == 10)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 11)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 25 && X == 12)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 25 && X == 13)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 25 && X == 14)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 25 && X == 15)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 25 && X == 16)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 25 && X == 17)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 25 && X == 18)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 25 && X == 19)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 25 && X == 20)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 25 && X == 21)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 25 && X == 22)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 23)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 25 && X == 24)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 25 && X == 25)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 25 && X == 26)
                {
                    textLabel.Text = "Crash";
                    CarCrash();
                }
                else if (Y == 26 && X == 9)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 26 && X == 10)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 26 && X == 11)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 12)
                {
                    textLabel.Text = "Crash";
                    CarCrash();
                }
                else if (Y == 26 && X == 13)
                {
                    textLabel.Text = "Crash";
                    CarCrash();
                }
                else if (Y == 26 && X == 14)
                {
                    textLabel.Text = "Crash";
                    CarCrash();
                }
                else if (Y == 26 && X == 15)
                {
                    textLabel.Text = "Crash";
                    CarCrash();
                }
                else if (Y == 26 && X == 16)
                {
                    textLabel.Text = "Crash";
                    CarCrash();
                }
                else if (Y == 26 && X == 17)
                {
                    textLabel.Text = "Crash";
                    CarCrash();
                }
                else if (Y == 26 && X == 18)
                {
                    textLabel.Text = "Crash";
                    CarCrash();
                }
                else if (Y == 26 && X == 19)
                {
                    textLabel.Text = "Crash";
                    CarCrash();
                }
                else if (Y == 26 && X == 20)
                {
                    textLabel.Text = "Crash";
                    CarCrash();
                }
                else if (Y == 26 && X == 21)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 22)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 26 && X == 23)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 26 && X == 24)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 26 && X == 25)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 26 && X == 26)
                {
                    textLabel.Text = "Crash";
                    CarCrash();
                }
                else if (Y == 27 && X == 9)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 27 && X == 10)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 27 && X == 11)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 27 && X == 12)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 27 && X == 13)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 27 && X == 14)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 27 && X == 15)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 27 && X == 16)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 27 && X == 17)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 27 && X == 18)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 27 && X == 19)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 27 && X == 20)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 27 && X == 21)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 27 && X == 22)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 27 && X == 23)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 27 && X == 24)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 27 && X == 25)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 27 && X == 26)
                {
                    textLabel.Text = "Crash";
                    CarCrash();
                }
                else if (Y == 28 && X == 9)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 28 && X == 10)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 28 && X == 11)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 28 && X == 12)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 28 && X == 13)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 28 && X == 14)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 28 && X == 15)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 28 && X == 16)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 28 && X == 17)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 28 && X == 18)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 28 && X == 19)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 28 && X == 20)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 28 && X == 21)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 28 && X == 22)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 28 && X == 23)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 28 && X == 24)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 28 && X == 25)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 28 && X == 26)
                {
                    textLabel.Text = "Crash";
                    CarCrash();
                }
                else if (Y == 29 && X == 1)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 2)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 3)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 4)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 5)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 6)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 7)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 8)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 9)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 10)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 11)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 12)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 13)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 14)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 15)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 16)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 17)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 18)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 19)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 20)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 21)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 22)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 23)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 29 && X == 24)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 29 && X == 25)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 29 && X == 26)
                {
                    textLabel.Text = "Crash";
                    CarCrash();
                }
                else if (Y == 30 && X == 1)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 2)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 3)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 4)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 5)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 6)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 7)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 8)
                {
                    textLabel.Text = "Door";
                    Door();
                }
                else if (Y == 30 && X == 9)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 10)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 11)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 12)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 13)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 14)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 15)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 16)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 17)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 18)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 19)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 20)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 21)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 22)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 23)
                {
                    textLabel.Text = "Concrete";
                    FootConcrete();
                }
                else if (Y == 30 && X == 24)
                {
                    textLabel.Text = "CarPass";
                    CarPass();
                }
                else if (Y == 30 && X == 25)
                {
                    textLabel.Text = "Horn";
                    Horn();
                }
                else if (Y == 30 && X == 26)
                {
                    textLabel.Text = "Crash";
                    CarCrash();
                }
                else 
                {
                    textLabel.Text = "Grass";
                    FootGrass();
                }
            }
        }

        //SoundBanks
        private void FootGrass()
        {
            RandomNumber = random.Next(4);

            if (RandomNumber == 0)
            {
                player = new SoundPlayer(Properties.Resources.FootGrass);
                player.Play();
            }
            if (RandomNumber == 1)
            {
                player = new SoundPlayer(Properties.Resources.FootGrass2);
                player.Play();
            }
            if (RandomNumber == 2)
            {
                player = new SoundPlayer(Properties.Resources.FootGrass3);
                player.Play();
            }
            if (RandomNumber == 3)
            {
                player = new SoundPlayer(Properties.Resources.FootGrass4);
                player.Play();
            }
        }
        private void FootDirt()
        {
            RandomNumber = random.Next(4);

            if (RandomNumber == 0)
            {
                player = new SoundPlayer(Properties.Resources.FootDirt);
                player.Play();
            }
            if (RandomNumber == 1)
            {
                player = new SoundPlayer(Properties.Resources.FootDirt2);
                player.Play();
            }
            if (RandomNumber == 2)
            {
                player = new SoundPlayer(Properties.Resources.FootDirt3);
                player.Play();
            }
            if (RandomNumber == 3)
            {
                player = new SoundPlayer(Properties.Resources.FootDirt4);
                player.Play();
            }
        }
        private void FootWood()
        {
            RandomNumber = random.Next(4);
            if (RandomNumber == 0)
            {
                player = new SoundPlayer(Properties.Resources.FootWood);
                player.Play();
            }
            if (RandomNumber == 1)
            {
                player = new SoundPlayer(Properties.Resources.FootWood2);
                player.Play();
            }
            if (RandomNumber == 2)
            {
                player = new SoundPlayer(Properties.Resources.FootWood3);
                player.Play();
            }
            if (RandomNumber == 3)
            {
                player = new SoundPlayer(Properties.Resources.FootWood4);
                player.Play();
            }
        }
        private void FootConcrete()
        {
            RandomNumber = random.Next(4);
            if (RandomNumber == 0)
            {
                player = new SoundPlayer(Properties.Resources.FootConcrete);
                player.Play();
            }
            if (RandomNumber == 1)
            {
                player = new SoundPlayer(Properties.Resources.FootConcrete2);
                player.Play();
            }
            if (RandomNumber == 2)
            {
                player = new SoundPlayer(Properties.Resources.FootConcrete3);
                player.Play();
            }
            if (RandomNumber == 3)
            {
                player = new SoundPlayer(Properties.Resources.FootConcrete4);
                player.Play();
            }
        }
        private void FootSand()
        {
            RandomNumber = random.Next(4);
            if (RandomNumber == 0)
            {
                player = new SoundPlayer(Properties.Resources.FootSand);
                player.Play();
            }
            if (RandomNumber == 1)
            {
                player = new SoundPlayer(Properties.Resources.FootSand2);
                player.Play();
            }
            if (RandomNumber == 2)
            {
                player = new SoundPlayer(Properties.Resources.FootSand3);
                player.Play();
            }
            if (RandomNumber == 3)
            {
                player = new SoundPlayer(Properties.Resources.FootSand4);
                player.Play();
            }
        }
        private void FootWater()
        {
            RandomNumber = random.Next(4);
            if (RandomNumber == 0)
            {
                player = new SoundPlayer(Properties.Resources.FootWater);
                player.Play();
            }
            if (RandomNumber == 1)
            {
                player = new SoundPlayer(Properties.Resources.FootWater2);
                player.Play();
            }
            if (RandomNumber == 2)
            {
                player = new SoundPlayer(Properties.Resources.FootWater3);
                player.Play();
            }
            if (RandomNumber == 3)
            {
                player = new SoundPlayer(Properties.Resources.FootWater4);
                player.Play();
            }
        }
        private void Shuffle()
        {
            RandomNumber = random.Next(2);
            if (RandomNumber == 0)
            {
                player = new SoundPlayer(Properties.Resources.Shuffle);
                player.Play();
            }
            if (RandomNumber == 1)
            {
                player = new SoundPlayer(Properties.Resources.Shuffle2);
                player.Play();
            }
        }
        private void Growl()
        {
            RandomNumber = random.Next(2);
            if (RandomNumber == 0)
            {
                player = new SoundPlayer(Properties.Resources.Growl);
                player.Play();
            }
            if (RandomNumber == 1)
            {
                player = new SoundPlayer(Properties.Resources.Growl2);
                player.Play();
            }
        }
        private void Eaten()
        {
            player = new SoundPlayer(Properties.Resources.Eaten);
            player.Play();
            deathCount++;
            Y = 1;
            X = 16;
            LabelX.Text = Convert.ToString(X);
            LabelY.Text = Convert.ToString(Y);
            MainText.Text = "Some animals don't like to be pet.";
        }
        private void Drown()
        {
            player = new SoundPlayer(Properties.Resources.Drown);
            player.Play();
            deathCount++;
            Y = 1;
            X = 16;
            LabelX.Text = Convert.ToString(X);
            LabelY.Text = Convert.ToString(Y);
            MainText.Text = "You're not the best swimmer...";
        }
        private void CarPass()
        {
            RandomNumber = random.Next(2);
            if (RandomNumber == 0)
            {
                player = new SoundPlayer(Properties.Resources.CarPass);
                player.Play();
            }
            if (RandomNumber == 1)
            {
                player = new SoundPlayer(Properties.Resources.CarPass2);
                player.Play();
            }
        }
        private void Horn()
        {
            RandomNumber = random.Next(2);
            if (RandomNumber == 0)
            {
                player = new SoundPlayer(Properties.Resources.Horn);
                player.Play();
            }
            if (RandomNumber == 1)
            {
                player = new SoundPlayer(Properties.Resources.Horn2);
                player.Play();
            }
        }
        private void CarCrash()
        {
            player = new SoundPlayer(Properties.Resources.CarCrash);
            player.Play();
            deathCount++;
            Y = 1;
            X = 16;
            LabelX.Text = Convert.ToString(X);
            LabelY.Text = Convert.ToString(Y);
            MainText.Text = "You shouldn't play in the street.";
        }
        private void Thud()
        {
            
                RandomNumber = random.Next(2);
                if (RandomNumber == 0)
                {
                    player = new SoundPlayer(Properties.Resources.Thud);
                    player.Play();
                }
                if (RandomNumber == 1)
                {
                    player = new SoundPlayer(Properties.Resources.Thud2);
                    player.Play();
                }
                MainText.Text = "Can't go that way.";
            
        }
        private void Door()
        {
            player = new SoundPlayer(Properties.Resources.Door);
            player.Play();
            MainText.Text = "Welcome Home!\n\n\n\nYou reached the exit in " + moveCount + " moves.\n\nYou died " + deathCount + " times.";
            MenuButton.Show();

            if (!File.Exists("progress.txt"))
            {
                File.WriteAllText(progressFile, "2");
            }
            playing = "0";
            
        }




       
      
     
      
      
        private void MenuLabel_Click(object sender, EventArgs e)
        {
            menu();
        }

        private void TutorialButton_Click(object sender, EventArgs e)
        {
            tutorial();
        }

        private void Level1Button_Click(object sender, EventArgs e)
        {
            level1();
        }

        private void Level2Button_Click(object sender, EventArgs e)
        {
            level2();
        }

        private void CreditsButton_Click(object sender, EventArgs e)
        {
            credits();
        }

        private void TutorialEndButton_Click(object sender, EventArgs e)
        {
            level1();
        }
    }
}
