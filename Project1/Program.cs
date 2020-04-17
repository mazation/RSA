using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RSA шифрование. Для того, чтобы зашифровать введите:");
            Console.WriteLine("cipher путь_к_исходному_файлу");
            Console.WriteLine("Для того, чтобы зашифровать введите:");
            Console.WriteLine("decipher путь_к_зашифрованному_файлу путь_к_private_key");

            while (true) {
                string message = Console.ReadLine();
                body(message);
            }
         
        }

        public static void body(string message) {
            string[] messageSplit = message.Split(' ');
            if (messageSplit[0] == "cipher" && messageSplit[1] != null)
            {
                string messageToCipher;
                try
                {
                    using (StreamReader sr = new StreamReader(messageSplit[1]))
                    {
                        string line = sr.ReadToEnd();
                        Cipher cipher = new Cipher();
                        messageToCipher = cipher.cipher(line);

                        StreamWriter wr1 = new StreamWriter("ciphered.txt", false, Encoding.GetEncoding(0));
                        wr1.Write(messageToCipher);
                        wr1.Close();
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("При чтении файла возникла ошибка:");
                    Console.WriteLine(e);
                }
            }
            else if (messageSplit[0] == "decipher" && messageSplit[1] != null && messageSplit[2] != null)
            {
                StreamReader f1 = new StreamReader(messageSplit[1]);
                string messageToDecipher = f1.ReadToEnd();
                f1.Close();
                double[] privateKey = new double[2];
                StreamReader f2 = new StreamReader(messageSplit[2]);
                string st1 = f2.ReadLine();
                string st2 = f2.ReadLine();
                f2.Close();
                privateKey[0] = Convert.ToDouble(st1);
                privateKey[1] = Convert.ToDouble(st2);
                string decipheredMessage = Cipher.decipher(messageToDecipher, privateKey);
                StreamWriter wr = new StreamWriter("message.txt", false, Encoding.GetEncoding(0));
                wr.Write(decipheredMessage);
                wr.Close();
            }
            else {
                Console.WriteLine("Команда не найдена");
            }
        }
    }
}
