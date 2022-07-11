using Memory;
using System.Diagnostics;
using System.Threading;

namespace EtG_Assist
{
    internal class Program
    {

        static Mem memoryManager = new Mem();

        static void Main(string[] args)
        {
            Console.WriteLine(@"
███████╗████████╗░██████╗░  ░█████╗░░██████╗░██████╗██╗░██████╗████████╗
██╔════╝╚══██╔══╝██╔════╝░  ██╔══██╗██╔════╝██╔════╝██║██╔════╝╚══██╔══╝
█████╗░░░░░██║░░░██║░░██╗░  ███████║╚█████╗░╚█████╗░██║╚█████╗░░░░██║░░░
██╔══╝░░░░░██║░░░██║░░╚██╗  ██╔══██║░╚═══██╗░╚═══██╗██║░╚═══██╗░░░██║░░░
███████╗░░░██║░░░╚██████╔╝  ██║░░██║██████╔╝██████╔╝██║██████╔╝░░░██║░░░
╚══════╝░░░╚═╝░░░░╚═════╝░  ╚═╝░░╚═╝╚═════╝░╚═════╝░╚═╝╚═════╝░░░░╚═╝░░░");

            if (Process.GetProcessesByName("EtG").Length > 0)
            {
                Console.WriteLine("Enter the Gungeon is open! Now injecting..\n");

                memoryManager.OpenProcess("EtG");

                Console.WriteLine("Injected!\n");

                Thread.Sleep(2000);

                Console.Clear();

                menu();
            }
            else
            {
                Console.WriteLine("Enter the Gungeon isn't open!\n");
                Console.WriteLine("Closing in 2 seconds!");

                Thread.Sleep(2000);

                Environment.Exit(1);
            }

            void menu()
            {
                Console.WriteLine("Welcome to EtG Assist! To choose a cheat to use, type the corresponding number and press enter.");
                Console.WriteLine("For example, to choose \"Infinite Health\" you would type \"1\" and press enter!\n");

                Console.WriteLine("[1] Infinite Health");
                Console.WriteLine("[2] Infinite Shells");

                switch (Console.ReadLine())
                {
                    case "1":
                        infHealth();
                        break;
                    case "2":
                        infShells();
                        break;
                    default:
                        Console.Clear();
                        menu();
                        break;
                }
            }

            void infHealth()
            {
                Console.WriteLine("Starting Infinite Health! To exit, press L");

                do
                {
                    while (!Console.KeyAvailable)
                    {
                        memoryManager.WriteMemory("UnityPlayer.dll+0146FCC8,120,80,18,50,118", "float", "3");

                        Thread.Sleep(500);
                    }
                } while (Console.ReadKey(true).Key != ConsoleKey.L);
                Console.Clear();
                menu();
            }

            void infShells()
            {
                Console.WriteLine("Gave Player 100 million shells!");

                memoryManager.WriteMemory("mono.dll+00264A68,C0,E90,A8,198,1C", "int", "100000000");

                Thread.Sleep(2000);

                Console.Clear();
                menu();
            }
        }
    }
}