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
            Console.WriteLine("Press 2 to get data for samples.");
            Console.WriteLine("Press 3 to edit data for an existing sample.");
            Console.Write("Please choose an action: ");
            MenuSelection();
        }
        private void MenuSelection()
        {
            Controller c = new Controller();
            bool running = true;
            while(running)
            {
                string SwitchSelection = Console.ReadLine();
                switch(SwitchSelection)
                {
                    case "1":
                        Console.WriteLine("You have chosen to enter data for a new sample.");
                        Console.WriteLine("Please choose the sample type: ");
                        Console.WriteLine("1. ATAC-SEC");
                        Console.WriteLine("2. ChIP");
                        Console.WriteLine("3. Hi-C");
                        Console.WriteLine("4. RNA");
                        string userinput = Console.ReadLine();
                        break;
                        switch(SwitchSelection) //
                        {
                            case "1":
                                c.EnterDataForATAC();
                                break;
                            case "2":
                                c.EnterDataForCHIP();
                                break;
                            case "3":
                                c.EnterDataForHI();
                                break;
                            case "4":
                                c.EnterDataForRNA();
                                break;
                        }

                    case "2":
                        Console.WriteLine("You have chosen to search for a sample by its ID");
                        Console.WriteLine("Please enter the ID of the sample");
                        int ID = Convert.ToInt32(Console.ReadLine());
                        DatabaseRepository db = new DatabaseRepository();
                        db.GetSampleByID(ID);
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



    }
}
