using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Users_and_Security;
using SQLLogic;

namespace MainGame
{
    public partial class MainGame : Form
    {
        private PictureBox pb;
        private Bitmap bmp;
        private Bitmap back;
        private Bitmap dot;
        private Bitmap second;
        private int minutes;
        private int seconds;
        private bool timerFinished;
        private PictureBox openCard1; // Currently opened card (pending) 
        private PictureBox openCard2; // Second opened card that is being compared to the first one
        private Random randLoc = new Random(); // Random number that helps in randomizing cards every time
        private List<Point> coordinates = new List<Point>();
        public static int score = 0;
        private int matchCounter = 0; // Counts how many matches there are
        private int bestBefore = 0;
        public MainGame()
        {
            InitializeComponent();
            bmp = Screenshot.takeSnapshot(panel1);
            pb = new PictureBox();
            panel1.Controls.Add(pb);
            pb.Dock = DockStyle.Fill;
            back = new Bitmap(Properties.Resources.back);
            second = new Bitmap(Properties.Resources.second);
            dot = new Bitmap(Properties.Resources.dot);
            backBox.Image = back;
            backBox.Controls.Add(secondBox);
            dotBox.Location = new Point(0, 0);
            dotBox.Image = dot;
            secondBox.Controls.Add(dotBox);
            secondBox.Location = new Point(0, 0);
            secondBox.Image = Clock.rotateImage(second, 0);
            lblWelcome.Text = "Welcome " + User.getName() + " !";
            bestBefore = User.getBestScore();

            //foreach(PictureBox picbox in pnlCards.Controls)
            //{
            //    picbox.Enabled = false;
            //    coordinates.Add(picbox.Location);

            //}

            if(User.getName() == "Guest")
            {
                lblScore.Text = score.ToString();
            } else
            {
                lblScore.Text = User.getBestScore().ToString();
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            timer.Stop();
            QuitForm quitFrm = new QuitForm();
            BlurFunctions.blur(panel1, pb, bmp);
            quitFrm.ShowDialog();
            BlurFunctions.removeBlur(pb);
            quitFrm.Dispose();
            timer.Start();
        }

        private void btnMinimise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            

            Single AngleS = seconds * -6;

            backBox.Image = back;

            backBox.Controls.Add(secondBox);
            dotBox.Location = new Point(0, 0);
            secondBox.Image = Clock.rotateImage(second, AngleS);


            secondBox.Controls.Add(dotBox);
            secondBox.Location = new Point(0, 0);
            dotBox.Image = dot;

            if ((seconds == 0) && (minutes == 0))
            {
                timer.Stop();
                timerFinished = true;
                if(matchCounter != 18)
                {
                    BlurFunctions.blur(panel1, pb, bmp);
                    BetterLuck B = new BetterLuck();
                    B.ShowDialog();
                    BlurFunctions.removeBlur(pb);
                    B.Dispose();
                }
                btnStart.Enabled = true;

            }else if (seconds == 0)
            {
                seconds = 60;
                minutes--;
            }

            if(timerFinished != true)
                seconds--;

            if(seconds < 10)
            {
                time.Text = "0" + Convert.ToString(minutes) + " : " + "0" + Convert.ToString(seconds);
            }
            else
            {
                time.Text = "0" + Convert.ToString(minutes) + " : " + Convert.ToString(seconds);
            }

         

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //List<Point> coordinates = new List<Point>();
            pnlCards.Enabled = false;
            foreach (PictureBox picbox in pnlCards.Controls)
            {
                picbox.Enabled = false;
                coordinates.Add(picbox.Location);

            }

            User.newHighScore = false;
            minutes = 2;
            seconds = 30;
            time.Text = "0" + Convert.ToString(minutes) + " : " + Convert.ToString(seconds);
            timerFinished = false;

            foreach (PictureBox picbox in pnlCards.Controls)
            {
                picbox.Enabled = true;
                int next = randLoc.Next(coordinates.Count);
                Point x = coordinates[next];
                picbox.Location = x;
                coordinates.Remove(x);
            }


            btnStart.Enabled = false;
            ShowCards();
            timerShowCards.Start();
        }

        private void MainGame_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void mainTicker_Paint(object sender, PaintEventArgs e)
        {
           
        }

        //private void btnReset_Click(object sender, EventArgs e)
        //{

        //}
        #region Cards
        private void card1_Click(object sender, EventArgs e)
        {
            card1.Image = Properties.Resources.Shape1;
            compareCards(card1, card2);
        }


        private void card2_Click(object sender, EventArgs e)
        {
            card2.Image = Properties.Resources.Shape1;
            compareCards(card2,card1);
        }

        private void card3_Click(object sender, EventArgs e)
        {
            card3.Image = Properties.Resources.Shape2;
            compareCards(card3,card4);
        }

        private void card4_Click(object sender, EventArgs e)
        {
            card4.Image = Properties.Resources.Shape2;
            compareCards(card4,card3);
        }

        private void card5_Click(object sender, EventArgs e)
        {
            card5.Image = Properties.Resources.Shape3;
            compareCards(card5,card6);
        }

        private void card6_Click(object sender, EventArgs e)
        {
            card6.Image = Properties.Resources.Shape3;
            compareCards(card6,card5);
        }

        private void card7_Click(object sender, EventArgs e)
        {
            card7.Image = Properties.Resources.Shape4;
            compareCards(card7,card8);
        }

        private void card8_Click(object sender, EventArgs e)
        {
            card8.Image = Properties.Resources.Shape4;
            compareCards(card8,card7);
        }

        private void card9_Click(object sender, EventArgs e)
        {
            card9.Image = Properties.Resources.Shape5;
            compareCards(card9,card10);
        }

        private void card10_Click(object sender, EventArgs e)
        {
            card10.Image = Properties.Resources.Shape5;
            compareCards(card10,card9);
        }

        private void card11_Click(object sender, EventArgs e)
        {
            card11.Image = Properties.Resources.Shape6;
            compareCards(card11,card12);
        }

        private void card12_Click(object sender, EventArgs e)
        {
            card12.Image = Properties.Resources.Shape6;
            compareCards(card12,card11);
        }

        private void card13_Click(object sender, EventArgs e)
        {
            card13.Image = Properties.Resources.Shape7;
            compareCards(card13,card14);
        }

        private void card14_Click(object sender, EventArgs e)
        {
            card14.Image = Properties.Resources.Shape7;
            compareCards(card14,card13);
        }

        private void card15_Click(object sender, EventArgs e)
        {
            card15.Image = Properties.Resources.Shape8;
            compareCards(card15,card16);
        }

        private void card16_Click(object sender, EventArgs e)
        {
            card16.Image = Properties.Resources.Shape8;
            compareCards(card16,card15);
        }

        private void card17_Click(object sender, EventArgs e)
        {
            card17.Image = Properties.Resources.Shape9;
            compareCards(card17,card18);
        }

        private void card18_Click(object sender, EventArgs e)
        {
            card18.Image = Properties.Resources.Shape9;
            compareCards(card18,card17);
        }

        private void card19_Click(object sender, EventArgs e)
        {
            card19.Image = Properties.Resources.Shape10;
            compareCards(card19,card20);
        }

        private void card20_Click(object sender, EventArgs e)
        {
            card20.Image = Properties.Resources.Shape10;
            compareCards(card20,card19);
        }

        private void card21_Click(object sender, EventArgs e)
        {
            card21.Image = Properties.Resources.Shape11;
            compareCards(card21,card22);
        }

        private void card22_Click(object sender, EventArgs e)
        {
            card22.Image = Properties.Resources.Shape11;
            compareCards(card22,card21);
        }

        private void card23_Click(object sender, EventArgs e)
        {
            card23.Image = Properties.Resources.Shape12;
            compareCards(card23,card24);
        }

        private void card24_Click(object sender, EventArgs e)
        {
            card24.Image = Properties.Resources.Shape12;
            compareCards(card24,card23);
        }

        private void card25_Click(object sender, EventArgs e)
        {
            card25.Image = Properties.Resources.Shape13;
            compareCards(card25,card26);
        }

        private void card26_Click(object sender, EventArgs e)
        {
            card26.Image = Properties.Resources.Shape13;
            compareCards(card26,card25);
        }

        private void card27_Click(object sender, EventArgs e)
        {
            card27.Image = Properties.Resources.Shape14;
            compareCards(card27,card28);
        }

        private void card28_Click(object sender, EventArgs e)
        {
            card28.Image = Properties.Resources.Shape14;
            compareCards(card28,card27);
        }

        private void card29_Click(object sender, EventArgs e)
        {
            card29.Image = Properties.Resources.Shape15;
            compareCards(card29,card30);
        }

        private void card30_Click(object sender, EventArgs e)
        {
            card30.Image = Properties.Resources.Shape15;
            compareCards(card30,card29);
        }

        private void card31_Click(object sender, EventArgs e)
        {
            card31.Image = Properties.Resources.Shape16;
            compareCards(card31,card32);
        }

        private void card32_Click(object sender, EventArgs e)
        {
            card32.Image = Properties.Resources.Shape16;
            compareCards(card32,card31);
        }

        private void card33_Click(object sender, EventArgs e)
        {
            card33.Image = Properties.Resources.Shape17;
            compareCards(card33,card34);
        }

        private void card34_Click(object sender, EventArgs e)
        {
            card34.Image = Properties.Resources.Shape17;
            compareCards(card34,card33);
        }

        private void card35_Click(object sender, EventArgs e)
        {
            card35.Image = Properties.Resources.Shape18;
            compareCards(card35,card36);
        }

        private void card36_Click(object sender, EventArgs e)
        {
            card36.Image = Properties.Resources.Shape18;
            compareCards(card36,card35);
        }
        #endregion

        private void compareCards(PictureBox card, PictureBox card2)
        {
            if(openCard1 == null)
            {
                openCard1 = card;

            }else if(openCard1 != null && openCard2 == null)
            {
                openCard2 = card;
            }

            if (openCard1 != null && openCard2 != null)
            {
                if(openCard1.Tag == openCard2.Tag)
                {
                    openCard1 = null;
                    openCard2 = null;
                    card.Enabled = false;
                    card2.Enabled = false;
                    score += 10;
                    matchCounter++;
                    if(User.getBestScore() <= score)
                    {
                        User.setBestScore(score);
                        lblScore.Text = User.getBestScore().ToString();
                    }

                    if(matchCounter == 18)
                    {
                        timer.Stop();
                        score += seconds * 10 + minutes * 100;
                        lblScore.Text = User.getBestScore().ToString();

                        if (User.getBestScore() < score)
                        {
                            User.setBestScore(score);
                        }
     
                        if(bestBefore < User.getBestScore())
                        {
                            // Go ahead and show congrats, you have new personal best
                            User.newHighScore = true;
                       
                            if(User.getUser() != "guest")
                            {
                                Connection_and_Queries.updateHighScore();
                            }

                            GoodJobForm goodJobForm = new GoodJobForm();
                            BlurFunctions.blur(panel1, pb, bmp);
                            goodJobForm.ShowDialog();
                            BlurFunctions.removeBlur(pb);
                            goodJobForm.Dispose();
                            btnStart.Enabled = true;

                        }
                        else
                        {
                            // Show good job dialog ( make smth about the score e.g. add the time to the score )
                            // and return to the previous ( don't forget to use the blur function
                            // show in the dialog if there is new best score

                            GoodJobForm goodJobForm = new GoodJobForm();
                            BlurFunctions.blur(panel1, pb, bmp);
                            goodJobForm.ShowDialog();
                            BlurFunctions.removeBlur(pb);
                            goodJobForm.Dispose();
                            btnStart.Enabled = true;

                        }


                    }
                }
                else
                {
                    pnlCards.Enabled = false;
                    timerWrong.Start();
                }
            }
        }

        private void timerWrong_Tick(object sender, EventArgs e)
        {
            timerWrong.Stop();
            openCard1.Image = Properties.Resources.ClosedCard;
            openCard2.Image = Properties.Resources.ClosedCard;
            openCard1 = null;
            openCard2 = null;
            pnlCards.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //score = 0;
            BlurFunctions.blur(panel1, pb, bmp);
            // Show the are you sure you want to stop, the previous progress will be lost
            timer.Stop();
            StopForm S = new StopForm();
            S.ShowDialog();
            BlurFunctions.removeBlur(pb);
            if (S.stop == false)
            {
                timer.Start();
                pnlCards.Enabled = true;
            }
            else
            {
                pnlCards.Enabled = false;
                btnStart.Enabled = true;
            }
            
            S.Dispose();    
        }

        private void ShowCards()
        {
            card1.Image = Properties.Resources.Shape1;
            card2.Image = Properties.Resources.Shape1;
            card3.Image = Properties.Resources.Shape2;
            card4.Image = Properties.Resources.Shape2;
            card5.Image = Properties.Resources.Shape3;
            card6.Image = Properties.Resources.Shape3;
            card7.Image = Properties.Resources.Shape4;
            card8.Image = Properties.Resources.Shape4;
            card9.Image = Properties.Resources.Shape5;
            card10.Image = Properties.Resources.Shape5;
            card11.Image = Properties.Resources.Shape6;
            card12.Image = Properties.Resources.Shape6;
            card13.Image = Properties.Resources.Shape7;
            card14.Image = Properties.Resources.Shape7;
            card15.Image = Properties.Resources.Shape8;
            card16.Image = Properties.Resources.Shape8;

            card17.Image = Properties.Resources.Shape9;
            card18.Image = Properties.Resources.Shape9;
            card19.Image = Properties.Resources.Shape10;
            card20.Image = Properties.Resources.Shape10;
            card21.Image = Properties.Resources.Shape11;
            card22.Image = Properties.Resources.Shape11;
            card23.Image = Properties.Resources.Shape12;
            card24.Image = Properties.Resources.Shape12;
            card25.Image = Properties.Resources.Shape13;
            card26.Image = Properties.Resources.Shape13;
            card27.Image = Properties.Resources.Shape14;
            card28.Image = Properties.Resources.Shape14;
            card29.Image = Properties.Resources.Shape15;
            card30.Image = Properties.Resources.Shape15;
            card31.Image = Properties.Resources.Shape16;
            card32.Image = Properties.Resources.Shape16;

            card33.Image = Properties.Resources.Shape17;
            card34.Image = Properties.Resources.Shape17;
            card35.Image = Properties.Resources.Shape18;
            card36.Image = Properties.Resources.Shape18;

        }

        private void timerShowCards_Tick(object sender, EventArgs e)
        {
            timerShowCards.Stop();
            foreach(PictureBox picBox in pnlCards.Controls)
            {
                picBox.Image = Properties.Resources.ClosedCard;
            }
            pnlCards.Enabled = true;
            timer.Start();
        }
    }
}
