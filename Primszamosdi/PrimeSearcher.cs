using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primszamosdi
{
    class PrimeSearcher
    {
        public static void PrimeSearching(int number)
        {
            bool primszame = false;
            for (int i = 2; i < number; i++)
            {
                if(number % i == 0)
                {
                    primszame = false;
                }
            }
            primszame = true;
        }
    }
}
