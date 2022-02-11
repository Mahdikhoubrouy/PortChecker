using System;
using System.Net.Sockets;

namespace PortChecker
{
    class Program
    {
      


    static void Main(string[] args)
        {


            Console.Title = "Port Checker || Coded By : Telegram : @Sir_Miti";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"  ____               _      ____  _                  _               
 |  _ \  ___   _ __ | |_   / ___|| |__    ___   ___ | | __ ___  _ __ 
 | |_) |/ _ \ | '__|| __| | |    | '_ \  / _ \ / __|| |/ // _ \| '__|
 |  __/| (_) || |   | |_  | |___ | | | ||  __/| (__ |   <|  __/| |   
 |_|    \___/ |_|    \__|  \____||_| |_| \___| \___||_|\_\\___||_|   
                                                                     ");
            Console.WriteLine();
            Console.CancelKeyPress += Console_CancelKeyPress;
            Console.WriteLine(" - Please Insert IP Next PressKey Enter ....! ");
            Console.WriteLine(" - Exit : Ctrl + C");
            Console.WriteLine();
            Console.ResetColor();
            string ip = Console.ReadLine();


            int[] port = { 22, 123, 53, 80, 443, 21, 23, 25, 43, 70, 79, 110, 119, 143, 194, 389, 443, 465, 990, 993, 1433, 2082, 2083, 2086, 2087, 2095, 2096, 2222, 3306, 4663, 5432, 8080, 8087, 8443, 9999, 10000, 19638, 9898 };



            for (int i = 0; i < 38;)
            {
               
                TcpClient client = new TcpClient();
                try
                {

                   
                    var result = client.BeginConnect(ip, port[i], null, null);
                    var success = result.AsyncWaitHandle.WaitOne(100);
                    client.EndConnect(result);
                    client.Close();
                    if(success == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                     
                        Console.WriteLine($"- [+] Port {port[i]} is open ..!");

                        Console.ResetColor();
                    }
                    else
                   
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine($"- [-] Port {port[i]} Not open ..!");

                        Console.ResetColor();
                    }
                   
                }
                catch(Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("- [*] Message : "+e.Message.ToString());

                    Console.ResetColor();

                }
                i++;
            }

            Console.ReadLine();
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            if (e.SpecialKey == ConsoleSpecialKey.ControlC)
            {
                Environment.Exit(0);
            }
        }
    }
}
