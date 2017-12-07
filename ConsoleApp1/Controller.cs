using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Controller
    {
        DatabaseReader db = new DatabaseReader();
        DataEntry de = new DataEntry();

        public void OpenMenu(int menuLocation) //1 == ConsoleMenu || 2 == Select more data by ID(make method) ||kg
        {
            Menu m = new Menu();
            switch (menuLocation)
            {
                case 1:
                    m.ConsoleMenu();
                break;
                case 2:
                    m.GetSampleByID();
                break;
            }
            
        }
        public void EnterDataForATAC()
        {
            de.EnterCommonData("ATAC-Seq");
            OpenMenu(1);
        }

        public void EnterDataForCHIP()
        {
            de.EnterCommonData("ChIP-Seq");
            OpenMenu(1);
        }

        public void EnterDataForRNA()
        {
            de.EnterCommonData("RNA-Seq");
            OpenMenu(1);
        }

        public void EnterDataForHI()
        {
            de.EnterCommonData("Hi-C");
            OpenMenu(1);
        }

        public void GetSampleByID(int sampleID)
        {
            Console.Clear();
            db.GetSampleByID(sampleID);
            Console.ReadKey();
            OpenMenu(2);
            
        }
    }
}
