using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     class Menu
    {
        Controller c = new Controller();

        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine(@".____    .___   _____    _________");
            Console.WriteLine(@"|    |   |   | /     \  /   _____/");
            Console.WriteLine(@"|    |   |   |/  \ /  \ \_____  \ ");
            Console.WriteLine(@"|    |___|   /    Y    \/        \");
            Console.WriteLine(@"|_______ \___\____|__  /_______  /");
            Console.WriteLine(@"        \/           \/        \/ ");
            Console.WriteLine("Welcome to the Laboratory Information Management System");
            Console.WriteLine("1. Enter data for a new sample.");
            Console.WriteLine("2. Get sample data.");
            Console.WriteLine("3. Edit data for an existing sample.");
            Console.WriteLine("0. Exit the application.");
            MenuSelection();
        }
        private void MenuSelection()
        {
            bool running = true;
            while(running)
            {
                switch(GetUserInput())
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("You have chosen to enter data for a new sample.\n");
                        Console.WriteLine("1. ATAC-SEC");
                        Console.WriteLine("2. ChIP");
                        Console.WriteLine("3. Hi-C");
                        Console.WriteLine("4. RNA");
                        Console.WriteLine("0. Back to menu");

                        switch (GetUserInput()) 
                        {
                            case 1:
                                Console.Clear();
                                c.EnterDataForATAC();
                                break;
                            case 2:
                                Console.Clear();
                                c.EnterDataForCHIP();
                                break;
                            case 3:
                                Console.Clear();
                                c.EnterDataForHI();
                                break;
                            case 4:
                                Console.Clear();
                                c.EnterDataForRNA();
                                break;
                            case 0:
                                Console.Clear();
                                MainMenu();
                                break;
                        }
                        break;

                    case 2:
                        Console.Clear();//rather here than in the method, if user wants to retrieve more than 1 sample and keep the earlier samples in the window
                        GetSample();
                        break;

                    case 0:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Command not found. Press any key");
                        Console.ReadKey();
                        Console.Clear();
                        MainMenu();
                        break;
                }
            }
        }

        public void GetSample()
        {
            Console.Clear();
            Console.WriteLine("0. Back to menu") ;
            Console.WriteLine("1. Search for sample by ID");//placeholder to access new method in database reader
            Console.WriteLine("2. Search for samples by value");
            int userSelection = GetUserInput();
            if (userSelection == 0)
            {
                MainMenu();
            }
            else if(userSelection == 1)
            {
                Console.Clear();
                Console.WriteLine("Enter SampleID");
                c.GetSampleByID(GetUserInput());
            }
            else if (userSelection == 2)
            {
                Console.Clear();
                Console.WriteLine("1.Antibody");
                Console.WriteLine("2.Cell Type");
                Console.WriteLine("3.Condition");
                Console.WriteLine("4.Initials");
                Console.WriteLine("5.PI");
                Console.WriteLine("6.Treatment");

                switch (GetUserInput())
                {
                    case 1:
                        Console.Write("Antibody: ");
                        c.GetSampleByString(Console.ReadLine(), "@Antibody");
                        break;
                    case 2:
                        Console.Write("Cell Type: ");
                        c.GetSampleByString(Console.ReadLine(), "@Cell_Type");
                        break;
                    case 3:
                        Console.Write("Condition: ");
                        c.GetSampleByString(Console.ReadLine(), "@Condition");
                        break;
                    case 4:
                        Console.Write("Initials: ");
                        c.GetSampleByString(Console.ReadLine(), "@Initials");
                        break;
                    case 5:
                        Console.Write("PI: ");
                        c.GetSampleByString(Console.ReadLine(), "@PI_Value");
                        break;
                    case 6:
                        Console.Write("Treatment: ");
                        c.GetSampleByString(Console.ReadLine(), "@Treatment");
                        break;
                }
            }
        }

        private int GetUserInput()
        {
            bool invalidSelection = true;
            int iInput = 0;
            while (invalidSelection)
            {
                Console.Write("\nSelection: ");
                string sInput = string.Empty;
                sInput = Console.ReadLine();
                bool validSelection = Int32.TryParse(sInput, out iInput);
                if (validSelection)
                {
                    invalidSelection = false;
                    iInput = Int32.Parse(sInput);
                }
                else
                {
                    Console.WriteLine("Selection is not valid.");
                }
            }
            return iInput;
        }
    }
}
