using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
            p = Calculation.getPrime();
            q = Calculation.getPrime();
            n = p * q;
            phi = (p - 1) * (q - 1);
            publicKey = getPublicKey();
            privateKey = getPrivateKey(publicKey[1]);
            savePublicKey();
            savePrivateKey();
        }
        public double[] getPublicKey()
        {
            Console.WriteLine("Создание публичного ключа");
            double[] publicKey = new double[2];

            double openExp = Calculation.getOpenExp(phi);
            publicKey[0] = n;
            publicKey[1] = openExp;
            Console.WriteLine("Создание публичного ключа завершено");
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
            byte[] textBytes = Encoding.ASCII.GetBytes(message);
            string encodedText = "";
            foreach (byte i in textBytes) {
                Console.WriteLine(i);
                
                double c = (Math.Pow(i, openExp)) % n;
                Console.WriteLine(Math.Pow(2, 100) % 3);
                //Console.WriteLine(c);
                //Console.WriteLine(n);
                string m = c.ToString() + '-';
                encodedText += m;
            }
            return encodedText;
        }

        public static string decipher(string message, double[] privateKey) {
            string[] messageArray = message.Split('-');
            List<double> messageArrayDecihered = new List<double>();
            string decipheredMessage = "";
            foreach (string msg in messageArray) {
                if (msg != "") {
                    double deciperedNum = Convert.ToDouble(msg);
                    //Console.WriteLine(deciperedNum);
                    //Console.WriteLine(privateKey[1]);
                    //Console.WriteLine(privateKey[0]);
                    Console.WriteLine(Math.Pow(deciperedNum, privateKey[1]) % privateKey[0]);
                    messageArrayDecihered.Add(Math.Pow(deciperedNum, privateKey[1]) % privateKey[0]);
                    //decimal power = 1;
                    //for (int i = 0; i < privateKey[1]; i++) {
                      //  power *= deciperedNum;
                    //}
                    //messageArrayDecihered.Add(power % Convert.ToDecimal(privateKey[0]));
                }
            }
            foreach (double num in messageArrayDecihered) {
                decipheredMessage += Convert.ToChar(Convert.ToInt32(num));
                //Console.WriteLine(Convert.ToChar(num));
            }
            return decipheredMessage;
        }

        public void savePrivateKey() {
            using (StreamWriter w = new StreamWriter("privateKey.txt", false, Encoding.GetEncoding(0)))
            {
                w.WriteLine(privateKey[0]);
                w.WriteLine(privateKey[1]);
            }
        }

        public void savePublicKey() {
            using (StreamWriter w = new StreamWriter("publicKey.txt", false, Encoding.GetEncoding(0)))
            {
                w.WriteLine(publicKey[0]);
                w.WriteLine(publicKey[1]);
                w.WriteLine(phi);
            }
        }
    }
}
