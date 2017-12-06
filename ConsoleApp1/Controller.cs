using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Controller
    {
        DatabaseRepository db = new DatabaseRepository();

        public void OpenMenu(int menuLocation) //1 == ConsoleMenu || 2 == Select more data by ID(make method) ||kg
        {
            switch (menuLocation)
            {
                case 1:
                    Menu m = new Menu();
                    m.ConsoleMenu();
                break;
                case 2:

                break;
            }
            
        }
        public void EnterDataForATAC()
        {
            
        }

        public void EnterDataForCHIP()
        {

        }

        public void EnterDataForRNA()
        {

        }

        public void EnterDataForHI()
        {

        }

        public void GetSampleByID(int sampleID)
        {
            Console.Clear();
            db.GetSampleByID(sampleID);
            
        }
    }
}
