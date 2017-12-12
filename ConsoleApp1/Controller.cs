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
         //moved the instance here instead of having it inside a method(OpenMenu())
                            //if shit starts to break, check here!!!
        public void OpenMenu()
        {
            Menu m = new Menu();
            m.MainMenu();
        }

        public void OpenGetSampleByIdMenu()
        {
            Menu m = new Menu();
            m.GetSampleByID();
        }
        public void EnterDataForATAC()
        {
            de.EnterCommonData("ATAC-Seq");
            OpenMenu();
        }

        public void EnterDataForCHIP()
        {
            de.EnterCommonData("ChIP-Seq");
            OpenMenu();
        }

        public void EnterDataForRNA()
        {
            de.EnterCommonData("RNA-Seq");
            OpenMenu();
        }

        public void EnterDataForHI()
        {
            de.EnterCommonData("Hi-C");
            OpenMenu();
        }

        public void GetSampleByID(int sampleID)
        {
            Console.Clear();
            //db.GetSampleByID(sampleID);
            db.GetSampleTypeByID(sampleID);
            Console.ReadKey();
            OpenGetSampleByIdMenu();//only place where second menu is called
        }
    }
}
