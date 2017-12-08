using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DataEntry
    {
        DatabaseWriter dw = new DatabaseWriter();
        DatabaseAttribute da = new DatabaseAttribute();
        public void EnterCommonData(string SampleType)
        {
            da.SampleType = SampleType;
            Console.WriteLine("Sample type: " + da.SampleType);
            Console.Write("Genome type: ");
            da.GenomeType = Console.ReadLine();
            Console.Write("Treatment: ");
            da.Treatment = Console.ReadLine();
            Console.Write("Condition: ");
            da.Condition = Console.ReadLine();
            Console.Write("Comments: ");
            da.Comments = Console.ReadLine();
            Console.Write("Concentration: ");
            da.Concentration = GetUserInputDouble();
            Console.Write("Volume: ");
            da.Volume = GetUserInputDouble();
            Console.Write("Initials: ");
            da.Initials = Console.ReadLine();
            Console.Write("PI: ");
            da.PIValue = Console.ReadLine();
            Console.Write("Enter the date, the format is DD-MM-YYYY: ");
            da.DateOfAddition = Console.ReadLine();

            switch(SampleType)
            {
                case "ATAC-Seq":
                    EnterDataForATAC(da);
                    break;
                case "ChIP-Seq":
                    EnterDataForCHIP(da);
                    break;
                case "Hi-C":
                    EnterDataForHI(da);
                    break;
                case "RNA-Seq":
                    EnterDataForRNA(da);
                    break;
            }
        }

        public void EnterDataForATAC(DatabaseAttribute da) 
        {
            Console.Write("Transposase units: ");
            da.ATACTransposaseUnit = GetUserInputDouble();
            Console.Write("PCR Cycles: ");
            da.ATACPCRCycles = GetUserInputDouble();
            dw.InsertCommon(da);   
        }

        public void EnterDataForCHIP(DatabaseAttribute da) 
        {
            Console.Write("Antibody: ");
            da.ChIPAntibody = Console.ReadLine();
            Console.Write("Antibody Lot: ");
            da.ChIPAtibodyLot = Console.ReadLine();
            Console.Write("Antibody Catalouge Number: ");
            da.ChIPAntibodyCatalogueNumber = Console.ReadLine();
            dw.InsertCommon(da);
        }

        public void EnterDataForRNA(DatabaseAttribute da) 
        {                                                 
            Console.WriteLine("Prep type: ");
            Console.WriteLine("  1.mRNA\n  2.Total RNA");
            bool invalidInput = true;
            while (invalidInput)
            {
                switch (GetUserInputDouble())
                {
                    case 1:
                        da.RNAPrepType = "mRNA";
                        invalidInput = false;
                        break;
                    case 2:
                        da.RNAPrepType = "Total RNA";
                        invalidInput = false;
                        break;
                    default:
                        invalidInput = true;
                        Console.Write("\nPrep type: ");
                        break;
                }
            }
            Console.Write("RIN: ");
            da.RNARIN = Console.ReadLine();
            dw.InsertCommon(da);
        }                                                 

        public void EnterDataForHI(DatabaseAttribute da)  
        {
            Console.Write("Restriction Enzyme: ");
            da.HIRestrictionEnzyme = GetUserInputDouble();
            Console.Write("PCR Cycles: ");
            da.HIPCRCycles = GetUserInputDouble();
            dw.InsertCommon(da);
        }
       
        private double GetUserInputDouble()
        {
            bool invalidSelection = true;
            double dInput = 0.0;
            while (invalidSelection)
            {
                string sInput = string.Empty;
                sInput = Console.ReadLine();
                bool validSelection = Double.TryParse(sInput, out dInput);
                if (validSelection)
                {
                    invalidSelection = false;
                    dInput = double.Parse(sInput);
                }
                else
                {
                    Console.WriteLine("Selection is not valid.");
                }
            }
            return dInput;
        }
    }
}
