using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SampleDataEntry
    {
        DatabaseWriter dw = new DatabaseWriter();
        SampleDataAttributes sampleDataAttributes = new SampleDataAttributes();
        public void EnterSampleData(string SampleType, string genomeType, string cellType, string treatment,
            string condition, string comments, double concentration, double volume, string initials, string PIValue,
            string sVar1, string sVar2, string sVar3, double dVar1, double dVar2)
        {
            sampleDataAttributes.SampleType = SampleType;
            sampleDataAttributes.GenomeType = genomeType;
            sampleDataAttributes.CellType = cellType;
            sampleDataAttributes.Treatment = treatment;
            sampleDataAttributes.Condition = condition;
            sampleDataAttributes.Comments = comments;
            sampleDataAttributes.Concentration = concentration;
            sampleDataAttributes.Volume = volume;
            sampleDataAttributes.Initials = initials;
            sampleDataAttributes.PIValue = PIValue;
            sampleDataAttributes.DateOfAddition = System.DateTime.Now.ToString();

            switch(SampleType)
            {
                case "ATAC-Seq": //add the special values corresponding with sample type to the common data
                    EnterDataForATAC(sampleDataAttributes, dVar1, dVar2);
                    break;
                case "ChIP-Seq":
                    EnterDataForCHIP(sampleDataAttributes, sVar1, sVar2, sVar3);
                    break;
                case "Hi-C":
                    EnterDataForHI(sampleDataAttributes, dVar1, dVar2);
                    break;
                case "RNA-Seq":
                    EnterDataForRNA(sampleDataAttributes, sVar1, sVar2);
                    break;
            }
        }
        public void EnterData(SampleDataAttributes sampleDataAttributes)
        {
            dw.InsertSample(sampleDataAttributes);
        }

        public void EnterDataForATAC(SampleDataAttributes da, double pcrCycles, double transposaseUnits) 
        {
            da.ATACPCRCycles = pcrCycles;
            da.ATACTransposaseUnit = transposaseUnits;
            dw.InsertSample(da);   
        }

        public void EnterDataForCHIP(SampleDataAttributes da, string antibody, string antibodyLot, string antibodyCatNr) 
        {
            da.ChIPAntibody = antibody;
            da.ChIPAntibodyLot = antibodyLot;
            da.ChIPAntibodyCatalogueNumber = antibodyCatNr;
            dw.InsertSample(da);
        }

        public void EnterDataForHI(SampleDataAttributes da, double restrictionEnzyme, double pcrCycles)
        {
            da.HIRestrictionEnzyme = restrictionEnzyme;
            da.HIPCRCycles = pcrCycles;
            dw.InsertSample(da);
        }

        public void EnterDataForRNA(SampleDataAttributes da, string prepType, string rin) 
        {
            da.RNAPrepType = prepType;
            da.RNARIN = rin;
            dw.InsertSample(da);
        }                                                 
    }
}
