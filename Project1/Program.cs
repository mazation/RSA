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
            string message = Console.ReadLine();
            string[] messageSplit = message.Split(' ');
            if (messageSplit[0] == "cipher" && messageSplit[1] != null)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(messageSplit[1]))
                    {
                        String line = sr.ReadToEnd();
                        Cipher cipher = new Cipher();
                    }
                }
                catch (IOException e) {
                    Console.WriteLine("При чтении файла возникла ошибка:");
                    Console.WriteLine(e);
                }
                }
            string path = Directory.GetCurrentDirectory();
            Console.ReadLine();
         
        }
    }
}
