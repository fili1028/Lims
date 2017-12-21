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
        SampleDataEntry dataEntry = new SampleDataEntry();
        
        //should we try to have DatabaseAttribute pass into the entry methods, instead of tons of variables
        
        public void EnterData(SampleDataAttributes sampleDataAttributes)
        {
            dataEntry.EnterData(sampleDataAttributes);
        }

        public void EnterDataForATAC(string genomeType, string cellType, string treatment,
            string condition, string comments, double concentration, double volume, string initials, string PIValue, 
            double pcrCycles, double transposaseUnit)
        {
            dataEntry.EnterSampleData("ATAC-Seq", genomeType, cellType, treatment, condition, comments, concentration, volume, initials, PIValue,
                string.Empty, string.Empty, string.Empty, pcrCycles, transposaseUnit);
        }

        public void EnterDataForCHIP(string genomeType, string cellType, string treatment,
            string condition, string comments, double concentration, double volume, string initials, string PIValue,
            string antibody, string antibodyLot, string antibodyCatNr)
        {
            dataEntry.EnterSampleData("ChIP-Seq", genomeType, cellType, treatment, condition, comments, concentration, 
                                        volume, initials, PIValue, antibody, antibodyLot, antibodyCatNr, 0, 0);
        }

        public void EnterDataForHI(string genomeType, string cellType, string treatment,
            string condition, string comments, double concentration, double volume, string initials, string PIValue,
            double restrictionEnzyme, double pcrCycles)
        {
            dataEntry.EnterSampleData("Hi-C", genomeType, cellType, treatment, condition, comments, concentration, 
                volume, initials, PIValue, string.Empty, string.Empty, string.Empty, restrictionEnzyme, pcrCycles);
        }

        public void EnterDataForRNA(string genomeType, string cellType, string treatment,
            string condition, string comments, double concentration, double volume, string initials, string PIValue,
            string prepType, string rin)
        {
            dataEntry.EnterSampleData("RNA-Seq", genomeType, cellType, treatment, condition, comments, concentration, 
                                        volume, initials, PIValue, prepType, rin, string.Empty, 0, 0);
        }

        public List<string> GetSampleByValue(string searchValue, string spParameter)
        {
            return databaseReader.GetSampleByValue(searchValue, spParameter);
        }

        public string GetSampleByID(int sampleID)
        {
            return databaseReader.GetSampleByID(sampleID);
        }
    }
}
