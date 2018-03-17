using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WordTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int wordNumber = 0;
            int askQuestion = 0;
            var wordsNumber = 0;
            var turnsNumber = 100;
            try
            {
                var file = new StreamReader("words.txt").ReadToEnd();
                var lines = file.Split(new char[] { '\n' }); 
                wordsNumber = (lines.Count() / 4);
                Console.WriteLine("Wykryto {0} słówek",wordsNumber);
            }
            catch (Exception)
            {
                Console.WriteLine("BŁĄD - Plik posiada niepoprawny format albo brak do niego dostępu: ");
                throw;
            }
            string[] question = new string[wordsNumber];
            string[] form1 = new string[wordsNumber];
            string[] form2 = new string[wordsNumber];
            string[] form3 = new string[wordsNumber];
            try
            {
                using (StreamReader sr = new StreamReader("words.txt"))
                {
                    for (int j = 0; j < wordsNumber; j++)
                    {
                        form1[j] = sr.ReadLine();
                        form2[j] = sr.ReadLine();
                        form3[j] = sr.ReadLine();
                        question[j] = sr.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Random rnd = new Random();
            string temp = "";
            int goodanswers = 0;
            for (int j = 0; j < turnsNumber; j++)
            {
                wordNumber = rnd.Next(0, wordsNumber);
                askQuestion = rnd.Next(0, 3);
                Console.Write("{0} forma słówka ", askQuestion+1);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(question[wordNumber]);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(" to:");
                if (askQuestion==0)
                    temp = form1[wordNumber];
                else
                    if (askQuestion == 1)
                    temp = form2[wordNumber];
                else
                    temp = form3[wordNumber];
                if(Console.ReadLine().Equals(temp))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Dobrze");
                    goodanswers++;
                }else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Źle");
                }
                Console.WriteLine("Słowo to: {0}", temp);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine("Dobrych odpowiedzi: {0} \nZłych odpowiedzi: {1}\nWszystkich odpowiedzi: {2}", goodanswers, turnsNumber - goodanswers, turnsNumber);
            Console.ReadLine(); 
        }
    }
}


