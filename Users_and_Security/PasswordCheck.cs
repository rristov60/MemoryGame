using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Users_and_Security
{
    public class PasswordCheck
    {
        // Функција која проверува дали внесениот password при SignUP е внесен коректно
        // т.е. да биде подолг од 8 карактери, да содржи специјален знак, една бројка, една голема и една Мала буква
        public static bool valid(string password)
        {
            string specialCh = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            char [] specialChArray = specialCh.ToCharArray();

            if ((password.Length < 8) || (!password.Any(char.IsUpper)) || (!password.Any(char.IsLower)) || (!password.Any(char.IsDigit)))
            {
                return false;
            }
            else
            {
                foreach(char ch in specialChArray)
                {
                    if (password.Contains(ch))
                    {
                        return true;
                    }
                }

                return false;
               
            }
        }
    }
}
