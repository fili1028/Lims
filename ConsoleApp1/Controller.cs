using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Controller
    {
        DatabaseReader databaseReader = new DatabaseReader();
        DataEntry dataEntry = new DataEntry();
        
        //should we try to have DatabaseAttribute pass into the entry methods, instead of tons of variables
        
        public void EnterDataForATAC(string genomeType, string cellType, string treatment,
            string condition, string comments, double concentration, double volume, string initials, string PIValue, 
            double pcrCycles, double transposaseUnit)
        {
            dataEntry.EnterCommonData("ATAC-Seq", genomeType, cellType, treatment, condition, comments, concentration, volume, initials, PIValue,
                string.Empty, string.Empty, string.Empty, pcrCycles, transposaseUnit);
        }

        public void EnterDataForCHIP(string genomeType, string cellType, string treatment,
            string condition, string comments, double concentration, double volume, string initials, string PIValue,
            string antibody, string antibodyLot, string antibodyCatNr)
        {
            dataEntry.EnterCommonData("ChIP-Seq", genomeType, cellType, treatment, condition, comments, concentration, volume, initials, PIValue,
                antibody, antibodyLot, antibodyCatNr, 0, 0);
        }

        public void EnterDataForHI(string genomeType, string cellType, string treatment,
            string condition, string comments, double concentration, double volume, string initials, string PIValue,
            double restrictionEnzyme, double pcrCycles)
        {
            dataEntry.EnterCommonData("Hi-C", genomeType, cellType, treatment, condition, comments, concentration, volume, initials, PIValue,
                string.Empty, string.Empty, string.Empty, restrictionEnzyme, pcrCycles);
        }

        public void EnterDataForRNA(string genomeType, string cellType, string treatment,
            string condition, string comments, double concentration, double volume, string initials, string PIValue,
            string prepType, string rin)
        {
            dataEntry.EnterCommonData("RNA-Seq", genomeType, cellType, treatment, condition, comments, concentration, volume, initials, PIValue,
                prepType, rin, string.Empty, 0, 0);
        }

        public List<string> GetSampleByValue(string value, string dbParameter)
        {
            //láta virka með list því ég þekki það, checka svo dictionary uppá að ná að halda 
            //sampleID ef það er selectað í ListBox...ObservableCollection(?)

            return databaseReader.GetSampleByValue(value, dbParameter);
        }

        public string GetSampleByID(int sampleID)
        {
            return databaseReader.GetSampleByID(sampleID);
        }
    }
}
