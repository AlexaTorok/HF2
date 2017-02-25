using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primszamosdi
{
    class PrimeSearcher
    {
        public static bool PrimeSearching(int number)
        {
            int i;
            for (i = 2; i * i <= number; i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
