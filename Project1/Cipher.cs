using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Cipher
    {
        private static List<double> getOpenKey()
        {
            // Используем ограниченный набор для облегчения вычислений
            double[] possibleExp = { 3, 5, 7, 11, 17, 23, 29 };
            double p, q;
            p = Calculation.generateNum();
            q = Calculation.generateNum();
            double n = p * q;
            double phi = (p - 1) * (q - 1);
            double exp = Calculation.getExp(phi, possibleExp);
            double d = Calculation.getD(phi, exp);
        }
    }
}
