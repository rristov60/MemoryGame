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
        private PictureBox pb; // 
        private Bitmap bmp; // 
        private Bitmap back; // Променлива која ни ја чува позадината на часовникот како Bitmap за да можеме да го реднерираме истиот
        private Bitmap dot; // Дел од часовникот како Bitmap
        private Bitmap second; // Секундарката на часовникот како Bitmap
        private int minutes; // Променлива употребена за броење на минути додека е активна играта
        private int seconds; // Променлива употребена за броење на секунди додека е активна играта
        private bool timerFinished; // Bool променлива која ни кажува дали тајмерот истекол пред играчот да ја заврши играта
        private PictureBox openCard1; // Моментално отворена карта (pending) 
        private PictureBox openCard2; // Втора отворена карта која се споредува со првата
        private Random randLoc = new Random(); // Random број кој го користиме во комбинација со координатите на картичките за да можеме да ги мешаме
        private List<Point> coordinates = new List<Point>(); // Координати на картите, за да можеме да ги местиме подоцна во комбинација со Random
        public static int score = 0; // Score на моменталната сесија
        private int matchCounter = 0; // Брои колку картички успешно сме спариле
        private int bestBefore = 0; // BestScore пред да започне играта
        public MainGame()
        {
            InitializeComponent();
            bmp = Screenshot.takeSnapshot(panel1); // Правиме screenshot од panel1 
            pb = new PictureBox(); // Правиме нова PictureBox користена во функцијата за замаглување на позадината
            panel1.Controls.Add(pb); // Го додаваме PictureBox во адекватиниот панел
            pb.Dock = DockStyle.Fill; // PictureBox-от го сетираме да го исполни панелот за да можеме да го достигнеме ефектот на замаглување
            back = new Bitmap(Properties.Resources.back); // Позадината на тајмерот/часовникот ја сетираме на адекватниот ресурс
            second = new Bitmap(Properties.Resources.second); // Средишната точка на тајмерот/часовникот ја сетираме на адекватниот ресурс
            dot = new Bitmap(Properties.Resources.dot); // Секундарката на тајмерот/часовникот ја сетираме на адекватниот ресурс
            backBox.Image = back; // Сликата на часовникот/тајмерот (Picbox) ја сетираме на адекватниот Bitmap
            backBox.Controls.Add(secondBox); // Ја додаваме секундарката
            dotBox.Location = new Point(0, 0); // Ja сетираме локацијата на централната точка
            dotBox.Image = dot; // Ја поставуваме сликата на централата точка на сооедветниот Bitmap
            secondBox.Controls.Add(dotBox); // Ја додаваме истата
            secondBox.Location = new Point(0, 0); // Ја сетираме локацијата
            secondBox.Image = Clock.rotateImage(second, 0); // Поставуавме почетна ротација
            lblWelcome.Text = "Welcome " + User.getName() + " !"; 
            bestBefore = User.getBestScore();
            pnlCards.Enabled = false; // За да не може да се притискаат картите

            // Ако играчот игра како Guest
            if(User.getName() == "Guest")
            {
                lblScore.Text = score.ToString();
            } else
            {
                // Ако е логиран
                lblScore.Text = User.getBestScore().ToString();
            }

        }

        // Кога корисникот сака да излезе
        private void btnExit_Click(object sender, EventArgs e)
        {
            timer.Stop(); // Се стопира тајмерот на играта
            QuitForm quitFrm = new QuitForm(); // Се креира инстанца од Quit Form
            BlurFunctions.blur(panel1, pb, bmp); // Се замагчлува позадината
            quitFrm.ShowDialog();// Се prompt играчот со Quit форма 
            BlurFunctions.removeBlur(pb); // Се одмаглува позадината
            quitFrm.Dispose(); // Се ослободуваме од ресурсите зафатени од оваа Quit форма
            timer.Start(); // Тајмерот си продолжува
        }

        // Минизирање на играта
        private void btnMinimise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Тајмер
        private void timer_Tick(object sender, EventArgs e)
        {
            

            Single AngleS = seconds * -6; // Пресметан агол за ротација на секундарката

            backBox.Image = back; // Се ажурира сликата на позадината

            // Ажурирање на секундарката
            backBox.Controls.Add(secondBox); 
            dotBox.Location = new Point(0, 0);
            secondBox.Image = Clock.rotateImage(second, AngleS);

            // Ажурирање на централната точка
            secondBox.Controls.Add(dotBox);
            secondBox.Location = new Point(0, 0);
            dotBox.Image = dot;

            // Доколку времето е изминато
            if ((seconds == 0) && (minutes == 0))
            {
                timer.Stop(); 
                timerFinished = true;
                // И не е усшено завршена играта
                // Се појавува Batter Luck Next time
                if(matchCounter != 18)
                {
                    BlurFunctions.blur(panel1, pb, bmp);
                    BetterLuck B = new BetterLuck();
                    B.ShowDialog();
                    BlurFunctions.removeBlur(pb);
                    B.Dispose();
                }

                btnStart.Enabled = true;

            }else if (seconds == 0) // Ако секундите се 0, се ставват повторно на 60, а се одзема минута
            {
                seconds = 60;
                minutes--;
            }
            // Се додека не е завршен  тајмерот се намалуваат секундите
            if(timerFinished != true)
                seconds--;
            // Логика за поставуање на текст за попрегледно читање на времето
            if(seconds < 10)
            {
                time.Text = "0" + Convert.ToString(minutes) + " : " + "0" + Convert.ToString(seconds);
            }
            else
            {
                time.Text = "0" + Convert.ToString(minutes) + " : " + Convert.ToString(seconds);
            }

         

        }
        
        // Старт на играта
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Се оневозможува притискање на картите
            pnlCards.Enabled = false;
            // Се земаат координатите на сите карти
            foreach (PictureBox picbox in pnlCards.Controls)
            {
                picbox.Enabled = false;
                coordinates.Add(picbox.Location);

            }
            // Се сетираат почетни параметри
            User.newHighScore = false;
            minutes = 2;
            seconds = 30;
            time.Text = "0" + Convert.ToString(minutes) + " : " + Convert.ToString(seconds);
            timerFinished = false;

            // Се мешаат картите
            foreach (PictureBox picbox in pnlCards.Controls)
            {
                picbox.Enabled = true;
                int next = randLoc.Next(coordinates.Count);
                Point x = coordinates[next];
                picbox.Location = x;
                coordinates.Remove(x);
            }

            // Се покажуваат истите измешани за 5 sec
            btnStart.Enabled = false;
            ShowCards();
            timerShowCards.Start(); // (oвој тајмер е за горенаведеното)
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
        
        // Клик на картици
        #region Cards
        private void card1_Click(object sender, EventArgs e)
        {
            card1.Image = Properties.Resources.Shape1; // Се поставува сликата што ја репрезентира истата
            compareCards(card1, card2); // Се споредуваат доколку има претходно кликнато картица или со наредната кликната
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

        // Функција за споредба на отворени картици
        private void compareCards(PictureBox card, PictureBox card2)
        {
            // Ако немаме отворено прва картица
            if(openCard1 == null)
            {
                openCard1 = card;

            }
            // Ако имаме отворено втора картица
            else if(openCard1 != null && openCard2 == null)
            {
                openCard2 = card;
            }
            // Кога се отоврени две
            if (openCard1 != null && openCard2 != null)
            {
                // Ако двете картици се совпаѓаат
                if(openCard1.Tag == openCard2.Tag)
                {
                    openCard1 = null;
                    openCard2 = null;
                    card.Enabled = false;
                    card2.Enabled = false;
                    score += 10;
                    matchCounter++;
                    
                    // Ако резултатот е поголем од претходмо
                    if(User.getBestScore() <= score)
                    {
                        User.setBestScore(score);
                        lblScore.Text = User.getBestScore().ToString();
                    }
                   
                    // Ако сите картици се отворени
                    if(matchCounter == 18)
                    {
                        timer.Stop(); // Се запира тајмерот
                        score += seconds * 10 + minutes * 100; // Се додаваат дополнитени поени
                        lblScore.Text = User.getBestScore().ToString(); // Се прикажува на екран

                        if (User.getBestScore() < score)
                        {
                            User.setBestScore(score);
                        }

                        // Ако имаме нов Best Score
                        if(bestBefore < User.getBestScore())
                        {
                            
                            User.newHighScore = true;
                            // Доколку играчот не е како guest се ажурира во Azure Cloud SQL DB резултатот
                            if(User.getUser() != "guest")
                            {
                                Connection_and_Queries.updateHighScore();
                            }
                            // Се покажува форма за добро сработено
                            GoodJobForm goodJobForm = new GoodJobForm();
                            BlurFunctions.blur(panel1, pb, bmp); // Се замаглува позадината
                            goodJobForm.ShowDialog(); // Се покажува
                            BlurFunctions.removeBlur(pb); // Се трга замаглувањето
                            goodJobForm.Dispose(); // Се ослободуваме од зафанатите ресурси
                            btnStart.Enabled = true;

                        }
                        // Ако немаме подобар резултат од најдобриот
                        else
                        {
                            // Се покажува друга верзија на добро сработено
                            GoodJobForm goodJobForm = new GoodJobForm();
                            BlurFunctions.blur(panel1, pb, bmp);
                            goodJobForm.ShowDialog();
                            BlurFunctions.removeBlur(pb);
                            goodJobForm.Dispose();
                            btnStart.Enabled = true;

                        }


                    }
                }
                // Ако двете картици не се совпаѓаат
                else
                {
                    pnlCards.Enabled = false;
                    timerWrong.Start(); // Истите се задржуваат отворени мал временски период
                }
            }
        }
        // Тајмер за задржување на грешка отворени картици
        private void timerWrong_Tick(object sender, EventArgs e)
        {
            timerWrong.Stop();
            // Ги ресетираме отворените картици
            openCard1.Image = Properties.Resources.ClosedCard;
            openCard2.Image = Properties.Resources.ClosedCard;
            openCard1 = null;
            openCard2 = null;
            pnlCards.Enabled = true;
        }

        // Доколку играчот сака да ја сопре играта пред да заврши времето без да излезе од самата апликацоја
        private void btnStop_Click(object sender, EventArgs e)
        {
            BlurFunctions.blur(panel1, pb, bmp); 
            timer.Stop();
            StopForm S = new StopForm();
            S.ShowDialog();
            BlurFunctions.removeBlur(pb);
            // Доколку не сака да ја сопре играта
            if (S.stop == false)
            {
                timer.Start();
                pnlCards.Enabled = true;
            }
            // Доколку ја споре играта
            else
            {
                pnlCards.Enabled = false;
                btnStart.Enabled = true;
            }
            
            S.Dispose();    
        }
        // Сетирање на картици по парови на конкретни слики
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
        // Иницијален тајмер којшто ни ги покажува слкките на картиците иницијално, а подоцна ги менува во 
        // затворени
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
