using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGame
{
    /* Матрица на конверзија користена за замаглување на екранот
     поточно 3x3 матрица
     Оваа матрица ја користиме за замаглувањње на екранот
     таа на почетокот ја има овва конструкција
        0   0   0
        0   1   0
        0   0   0
    Вака е преставен еден пиксел, а подоцна го користиме ова својтво и својството дека секој пиксел има своја тежина
    да ја распределиме истата на околните пиксели, создавајќи ефект на замагленост*/
    class ConversionMatrix
    {
        public int TopLeft = 0, TopMid = 0, TopRight = 0;
        public int MidLeft = 0, Pixel = 1, MidRight = 0;
        public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;
        public int Factor = 1;
        public int Offset = 0;
        public void SetAll(int nVal)
        {
            TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight = BottomLeft = BottomMid = BottomRight = nVal;
        }
    }
}
