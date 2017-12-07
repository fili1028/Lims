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
        DataEntry dw = new DataEntry();

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
            dw.EnterCommonData("ATAC-Seq");  
        }

        public void EnterDataForCHIP()
        {
            dw.EnterCommonData("ChIP-Seq");
        }

        public void EnterDataForRNA()
        {
            dw.EnterCommonData("RNA-Seq");
        }

        public void EnterDataForHI()
        {
            dw.EnterCommonData("Hi-C");
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
