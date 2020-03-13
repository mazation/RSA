using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Cipher
    {
        // Используем ограниченный набор для облегчения вычислений
        public double[] possibleExp = { 3, 5, 7, 11, 17, 23, 29 };
        private double p, q, n, phi;
        private double[] publicKey = new double[2];
        private double[] privateKey = new double[2];

        public Cipher()
        {
            p = Calculation.generateNum();
            q = Calculation.generateNum();
            n = p * q;
            phi = (p - 1) * (q - 1);
            publicKey = this.getPublicKey();
            privateKey = this.getPrivateKey(publicKey[1]);
        }
        public double[] getPublicKey()
        {
            double[] publicKey = new double[2];

            double openExp = Calculation.getOpenExp(phi, possibleExp);
            publicKey[0] = n;
            publicKey[1] = openExp;
            return publicKey;
        }

        public double[] getPrivateKey(double openExp)
        {
            double closeExp = Calculation.getCloseExp(phi, openExp);
            privateKey[0] = n;
            privateKey[1] = closeExp;
            return privateKey;
        }

        public string cipher(string message)
        {
            double openExp = publicKey[1];
            //double[] privateKey = this.getPrivateKey(openExp);
            byte[] textBytes = Encoding.ASCII.GetBytes(message);
            string encodedText = "";
            foreach (byte i in textBytes) {
                double c = Math.Pow(i, openExp) % n;
                string m = c.ToString() + '-';
                encodedText += m;
            }
            return encodedText;
        }

        public static string decipher(string message, double[] privateKey) {
            string v = "Kek";
            return v;
        }
    }
}
