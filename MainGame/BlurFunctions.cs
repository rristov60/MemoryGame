using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace MainGame
{
    class BlurFunctions
    {
        public static void blur(Panel panel, PictureBox picBox, Bitmap btm)
        {
            btm = Screenshot.takeSnapshot(panel);
            BitmapFilter.gaussianBlur(btm, 4);
            BitmapFilter.gaussianBlur(btm, 4);
            BitmapFilter.gaussianBlur(btm, 4);
            BitmapFilter.gaussianBlur(btm, 4);
            BitmapFilter.gaussianBlur(btm, 4);
            BitmapFilter.gaussianBlur(btm, 4);
            BitmapFilter.gaussianBlur(btm, 4);

            picBox.Image = btm;
            picBox.BringToFront();

        }

        public static void removeBlur(PictureBox picBox)
        {
            picBox.Image = null;
            picBox.SendToBack();
        }
    }
}
