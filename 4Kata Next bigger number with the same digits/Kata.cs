using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Kata_Next_bigger_number_with_the_same_digits
{
    internal class Kata
    {
        public static long NextBiggerNumber(long n)
        {
            char[] charLong = n.ToString().ToCharArray();
            char[] charForOrder = new char[charLong.Length];
            int count = 0;
            for (int i = charLong.Length - 1; i > 0; i--)
            {
                charForOrder[charLong.Length - 1 - i] = charLong[i];
                if (charLong[i] > charLong[i - 1])
                {
                    char a = charLong[i - 1];
                    for (int j = 0; j < charLong.Length; j++)
                    {
                        if (a < charForOrder[j])
                        {
                            charLong[i - 1] = charForOrder[j];
                            charForOrder[j] = a;
                            break;
                        }
                    }
                    break;
                }
                else count++;
            }
            if (count == charLong.Length - 1)
            {
                return -1;
            }
            charForOrder = charForOrder.Where(x => x != '\0').OrderBy(x => x).ToArray();
            for (int i = 0; i < charForOrder.Length; i++)
            {
                charLong[charLong.Length - charForOrder.Length + i] = charForOrder[i];
            }
            return long.Parse(String.Concat(charLong.Select(x => x - '0').ToArray()));
                    }

    }
}
