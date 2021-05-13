using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MainGame
{
    class Clock
    {
        // Функција за ротирање на самата секундарка и враќање на ротирана слика
        public static Bitmap rotateImage(Bitmap rotateMe/*Сликата која сакаме да ја ротираме*/, float angle)
        {
            Bitmap rotatedImage = new Bitmap(rotateMe.Width, rotateMe.Height); // Создавање на референца која ја ротираме од сликата која сакаме да ја ротираме како Bitmap

            // Ротирање на функцијата за одреден агол и користење на матрици на транслација
            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                g.TranslateTransform(rotateMe.Width / 2, rotateMe.Height / 2);
                g.RotateTransform(angle);
                g.TranslateTransform(-rotateMe.Width / 2, -rotateMe.Height / 2);
                g.DrawImage(rotateMe, new Point(0, 0));
            }
            // Враќање на ротирана слика
            return rotatedImage;
        }
    }
}
