using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Calculation
    {
        public static double getPrime() {
            double num = generateNum();
            do {
                num += 1;
            } while (!isPrime(num));
            return num;
        }

        public static double generateNum() {
            double num;
            Random rnd = new Random();
            num = rnd.Next((int)Math.Pow(2, 6));
            return num;
        }

        protected static bool isPrime(double num) {
            for (int i = 2; i < Math.Sqrt(num); i++) {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static double getOpenExp(double phi) {
            int i = 19;
            double m = 19;
            while (phi % i == 0) {
                m = i;
                i++;
            }
            return m;
        }

        public static double getCloseExp(double phi, double exp) {
            double d;
            int x = 1;
            d = (1 + x * phi) / exp;
            while (d % Math.Floor(d) != 0) 
            {
                d = (1 + x * phi) / exp;
                x++;
            }
            return d;
        }
    }
}
