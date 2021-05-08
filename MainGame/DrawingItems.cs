using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MainGame
{
    class DrawingItems
    {
        private static double rotationAngle;
        private static int locationMainTickerX;
        private static int locationMainTickerY;
        public static void drawClock(PictureBox mainClock, PictureBox wrldInClock, PictureBox mainTicker, PictureBox dotTicker/*, PaintEventArgs e*/)
        {
            mainTicker.Size = new Size(500, 500);

            mainClock.Controls.Add(wrldInClock);
            mainClock.Controls.Add(mainTicker);
            mainClock.Controls.Add(dotTicker);
            wrldInClock.SizeMode = PictureBoxSizeMode.Normal;
            mainTicker.SizeMode = PictureBoxSizeMode.Normal;
            //Bitmap bmpWrldInClock = new Bitmap(wrldInClock.Image.Width, wrldInClock.Image.Height);
            //Graphics gfxWrldInClock = Graphics.FromImage(bmpWrldInClock);

            //gfxWrldInClock.DrawImage(wrldInClock.Image, 0, 0);
            //e.Graphics.DrawImage(bmpWrldInClock, 0, 0);

            //Bitmap bmpMainTicker = new Bitmap(mainTicker.Image.Width, mainTicker.Image.Height);
            //Graphics gfxMainTicker = Graphics.FromImage(bmpMainTicker);

            //gfxMainTicker.DrawImage(mainTicker.Image, 0, 0);
            //e.Graphics.DrawImage(bmpMainTicker, 0, 0);

            //Bitmap bmpWrldInClock = new Bitmap(wrldInClock.Image.Width, wrldInClock.Image.Height);
            //Graphics gfxWrldInClock = Graphics.FromImage(bmpWrldInClock);

            //gfxWrldInClock.DrawImage(wrldInClock.Image, 100, 110);
            //e.Graphics.DrawImage(bmpWrldInClock, 0, 0);
            wrldInClock.Location = new Point(100, 110);
            wrldInClock.BackColor = Color.Transparent;
            mainTicker.Location = new Point(94, 25);
            mainTicker.BackColor = Color.Transparent;
            dotTicker.Location = new Point(94, -13);
            dotTicker.BackColor = Color.Transparent;
        }

        public static void rotateMainTicker(PictureBox mainTicker)
        {
            Image img = mainTicker.Image;
            img.RotateFlip(RotateFlipType.Rotate180FlipNone);
            mainTicker.Image = img;
        }

        public static void milisecondTicker(PictureBox dotTicker)
        {
            dotTicker.Location = new Point(dotTicker.Location.X + 5, dotTicker.Location.Y + 2);
        }

    }
}
