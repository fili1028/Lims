using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     class Menu
    {
        public void ConsoleMenu()
        {
            Console.WriteLine(@".____    .___   _____    _________");
            Console.WriteLine(@"|    |   |   | /     \  /   _____/");
            Console.WriteLine(@"|    |   |   |/  \ /  \ \_____  \ ");
            Console.WriteLine(@"|    |___|   /    Y    \/        \");
            Console.WriteLine(@"|_______ \___\____|__  /_______  /");
            Console.WriteLine(@"        \/           \/        \/ ");
            Console.WriteLine("Welcome to the Laboratory Information Management System");
            Console.WriteLine("Press 1 to enter data for a new sample.");
            Console.WriteLine("Press 2 to get sample data.");
            Console.WriteLine("Press 3 to edit data for an existing sample.");
            Console.WriteLine("Press 0 to exit the application.");
            Console.Write("Please choose an action: ");
            MenuSelection();
        }
        private void MenuSelection()
        {
            Controller c = new Controller();
            bool running = true;
            while(running)
            {
                switch(GetUserInput())
                {
                    case 1:
                        Console.WriteLine("You have chosen to enter data for a new sample.");
                        Console.WriteLine("Please choose the sample type: ");
                        Console.WriteLine("1. ATAC-SEC");
                        Console.WriteLine("2. ChIP");
                        Console.WriteLine("3. Hi-C");
                        Console.WriteLine("4. RNA");
                        Console.WriteLine("0. Back to menu");

                        switch(GetUserInput()) 
                        {
                            case 1:
                                c.EnterDataForATAC();
                                break;
                            case 2:
                                c.EnterDataForCHIP();
                                break;
                            case 3:
                                c.EnterDataForHI();
                                break;
                            case 4:
                                c.EnterDataForRNA();
                                break;
                            case 0:
                                Console.Clear();
                                ConsoleMenu();
                                break;
                        }
                        break;

                    case 2:
                        Console.WriteLine("You have chosen to search for a sample by ID");
                        Console.Write("Please enter the ID sample ID: ");
                        c.GetSampleByID(GetUserInput());
                        break;

                    case 0:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Could not find command. Press any button to return to menu");
                        Console.ReadKey();
                        Console.Clear();
                        ConsoleMenu();
                        break;

                }

            }
        }

        private int GetUserInput()
        {
            string sInput = string.Empty;
            int iInput = 0;
            bool invalidSelection = true;

            sInput = Console.ReadLine();
            while (invalidSelection)
            {
                if (!Int32.TryParse(sInput, out iInput))
                {
                    Console.WriteLine("Selection is not valid.");
                    GetUserInput();
                }
                else
                {
                    iInput = Int32.Parse(sInput);
                    invalidSelection = false;
                }
            }
            return iInput;   
        }
    }
}
