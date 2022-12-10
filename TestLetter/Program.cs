using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Data;
using Newtonsoft.Json;

namespace TestLetterr
{
    internal class Inf
    {
        public string Nik;
        public int SimvSek;
        public int SimvMin;
    }
    internal class Program
    {
        public static int sek = 60;
        public static int pos = 1;
        public static int b = 0;
        static void Main()
        {
            Base();
        }
        static void Timer1()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Thread.Sleep(60000);
            stopWatch.Stop();
        }
        public static void Base()
        {
            sek = 60;
            pos = 0;
            b = 0;

            Console.Clear();
            Thread Timer = new Thread(new ThreadStart(Timer1));
            Console.WriteLine("Введите ваш Никнейм");
            Inf polz = new Inf();
            polz.Nik = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("При готовности, нажмите \"Enter\"");
            ConsoleKeyInfo clavisha = Console.ReadKey();
            Thread Timer2 = new Thread(_ =>
            {
                while (sek != 0)
                {
                    string del = new string(' ', 4);
                    Console.SetCursorPosition(1, 10);
                    Console.Write(sek);
                    Console.WriteLine(del);
                    Console.SetCursorPosition(pos, b);
                    Thread.Sleep(1000);
                    sek--;
                }
            });
            if (clavisha.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Console.SetCursorPosition(pos, 0);
                string text = ("Что вершит судьбу человека в этом мире? Некое незримое существо или закон? Подобно длани господней парящей над миром.\n По крайней мере, истина - то, что человек не властен даже над своей волей. Я знал, что отличаюсь от остальных. Среди\n всех, с кем мне доводилось встречаться, никто не оставался ко мне равнодушным.");
                Console.Write(text);
                Timer2.Start();
                Timer.Start();
                int a = 0;
                while (Timer.IsAlive)
                {
                    if (pos == 116)
                    {
                        b++;
                        pos = 0;
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    clavisha = Console.ReadKey();

                    if (clavisha.Key == ConsoleKey.Backspace)
                    {
                        if (pos == 0)
                        {
                            b--;
                            pos = 116;
                        }
                        a--;
                        polz.SimvMin--;
                        Console.ResetColor();
                        Console.SetCursorPosition(pos--, b);
                        Console.WriteLine(text[pos+1]);
                    }
                    else
                    {
                        a++;
                        pos++;
                        polz.SimvMin++;
                        Console.SetCursorPosition(pos, b);
                    }

                    if (clavisha.Key == ConsoleKey.Enter)
                    {
                        Timer2.Abort();
                        Timer.Abort();
                    }
                }
                polz.SimvSek = polz.SimvMin / 60;
                Console.SetCursorPosition(0, 15);
                Console.ResetColor();
                Console.WriteLine($"Введено символов {polz.SimvMin}, введено символов в секунду {polz.SimvSek}");
                Tabl.tablicalid(polz);
            }
            Main();
        }
    }
    internal class Tabl
    {
        public static List<string> Lider = new List<string>();
        public static List<Inf> hum = new List<Inf>();
        public static void tablicalid(Inf user)
        {
            Console.Clear();
            string Min = Convert.ToString(user.SimvMin);
            string Sek = Convert.ToString(user.SimvSek);
            Console.SetCursorPosition(50,0);
            Console.WriteLine("Таблица Рекордов");
            Lider.Add(user.Nik);
            Lider.Add(Min);
            Lider.Add(Sek); 
            hum.Add(user);
            foreach (string i in Lider)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Для выхода нажмите Escape");
            Console.WriteLine("Для повтора нажмите Enter");
            ConsoleKeyInfo clavisha = Console.ReadKey();
            if (clavisha.Key == ConsoleKey.Escape)
                Environment.Exit(0);
            if (clavisha.Key == ConsoleKey.Enter)
                Program.Base();

            string json = JsonConvert.SerializeObject(hum);
            File.WriteAllText("C:\\Users\\mrpor\\Desktop\\liderscore.json", json);
        }
    }
}