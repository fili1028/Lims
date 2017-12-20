using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Controller
    {
        DatabaseReader db = new DatabaseReader();
        DataEntry de = new DataEntry();
         //moved the instance here instead of having it inside a method(OpenMenu())
                            //if shit starts to break, check here!!!
        public void OpenMenu()
        {
            //Menu m = new Menu();
            //m.MainMenu();
        }

        public void OpenGetSampleMenu()
        {
            //Menu m = new Menu();
            //m.GetSample();
        }

        public void EnterData(string sampleType, string genomeType, string treatment,
            string condition, string comment, double concentration, double volume, 
            string initials, string PIValue, string sVar1, string sVar2, string sVar3,
            double dVar1, double dvar2)//for UI
        {
            switch (sampleType)
            {
                case "ATAC - Seq":

                    break;
                case "ChIP-Seq":

                    break;
                case "RNA-Seq":

                    break;
                case "Hi-C":

                    break;
            }
        }
        
        public void EnterDataForATAC(string genomeType, string cellType, string treatment,
            string condition, string comments, double concentration, double volume, string initials, string PIValue, 
            double pcrCycles, double transposaseUnit)
        {
            de.EnterCommonData("ATAC-Seq", genomeType, cellType, treatment, condition, comments, concentration, volume, initials, PIValue,
                string.Empty, string.Empty, string.Empty, pcrCycles, transposaseUnit);
        }

        public void EnterDataForCHIP(string genomeType, string cellType, string treatment,
            string condition, string comments, double concentration, double volume, string initials, string PIValue,
            string antibody, string antibodyLot, string antibodyCatNr)
        {
            de.EnterCommonData("ChIP-Seq", genomeType, cellType, treatment, condition, comments, concentration, volume, initials, PIValue,
                antibody, antibodyLot, antibodyCatNr, 0, 0);
        }

        public void EnterDataForHI(string genomeType, string cellType, string treatment,
            string condition, string comments, double concentration, double volume, string initials, string PIValue,
            double restrictionEnzyme, double pcrCycles)
        {
            de.EnterCommonData("Hi-C", genomeType, cellType, treatment, condition, comments, concentration, volume, initials, PIValue,
                string.Empty, string.Empty, string.Empty, restrictionEnzyme, pcrCycles);
        }

        public void EnterDataForRNA(string genomeType, string cellType, string treatment,
            string condition, string comments, double concentration, double volume, string initials, string PIValue,
            string prepType, string rin)
        {
            de.EnterCommonData("RNA-Seq", genomeType, cellType, treatment, condition, comments, concentration, volume, initials, PIValue,
                prepType, rin, string.Empty, 0, 0);
            OpenMenu();
        }

        

        public void GetSampleByID(int sampleID)
        {
            Console.Clear();
            db.GetSampleTypeByID(sampleID);
            Console.ReadKey();
            OpenGetSampleMenu();
        }

        public void GetSampleByString(string value, string dbParameter)
        {
            Console.Clear();
            db.GetDBAccessValuesByString(value, dbParameter);
            Console.ReadKey();
            OpenGetSampleMenu();
        }
    }
}
