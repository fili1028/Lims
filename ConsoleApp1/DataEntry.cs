using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DataEntry
    {
        DatabaseWriter dw = new DatabaseWriter();
        DatabaseAttribute da = new DatabaseAttribute();
        public void EnterCommonData(string SampleType, string genomeType, string cellType, string treatment,
            string condition, string comments, double concentration, double volume, string initials, string PIValue,
            string sVar1, string sVar2, string sVar3, double dVar1, double dVar2)
        {
            da.SampleType = SampleType;
            da.GenomeType = genomeType;
            da.CellType = cellType;
            da.Treatment = treatment;
            da.Condition = condition;
            da.Comments = comments;
            da.Concentration = concentration;
            da.Volume = volume;
            da.Initials = initials;
            da.PIValue = PIValue;
            da.DateOfAddition = System.DateTime.Now.ToString();

            switch(SampleType)
            {
                
                case "ATAC-Seq":
                    EnterDataForATAC(da, dVar1, dVar2);
                    break;
                case "ChIP-Seq":
                    EnterDataForCHIP(da, sVar1, sVar2, sVar3);
                    break;
                case "Hi-C":
                    EnterDataForHI(da, dVar1, dVar2);
                    break;
                case "RNA-Seq":
                    EnterDataForRNA(da, sVar1, sVar2);
                    break;
            }
        }

        public void EnterDataForATAC(DatabaseAttribute da, double pcrCycles, double transposaseUnits) 
        {
            da.ATACPCRCycles = pcrCycles;
            da.ATACTransposaseUnit = transposaseUnits;
            dw.InsertSample(da);   
        }

        public void EnterDataForCHIP(DatabaseAttribute da, string antibody, string antibodyLot, string antibodyCatNr) 
        {
            da.ChIPAntibody = antibody;
            da.ChIPAtibodyLot = antibodyLot;
            da.ChIPAntibodyCatalogueNumber = antibodyCatNr;
            dw.InsertSample(da);
        }

        public void EnterDataForHI(DatabaseAttribute da, double restrictionEnzyme, double pcrCycles)
        {
            da.HIRestrictionEnzyme = restrictionEnzyme;
            da.HIPCRCycles = pcrCycles;
            dw.InsertSample(da);
        }

        public void EnterDataForRNA(DatabaseAttribute da, string prepType, string rin) 
        {
            da.RNAPrepType = prepType;
            da.RNARIN = rin;
            dw.InsertSample(da);
        }                                                 
    }
}
