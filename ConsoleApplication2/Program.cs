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
            Random rnd = new Random();
            int disablePoint = 0;
            string rememberWord = "";
            int goodanswers = 0;
            try
            {  
                using (StreamReader sr = new StreamReader("words.txt"))
                {
                    for (int j = 0; j < 20; j++ )
                    {
                        disablePoint = rnd.Next(0, 3);
                        for (int i = 0; i < 4; i++)
                        {
                           if(i == disablePoint)
                           {
                             rememberWord = sr.ReadLine();
                             Console.WriteLine("--------");
                           }else
                           {
                             Console.WriteLine(sr.ReadLine());
                           }
                           
                        }

                        if (Console.ReadLine().Equals(rememberWord))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Dobrze");
                            goodanswers++;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Źle. {0}",rememberWord);
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Dobrych odpowiedzi było: {0}",goodanswers);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Złych odpowiedzi było: {0}", 20 - goodanswers);
            Console.ReadLine();
        }
    }
}
