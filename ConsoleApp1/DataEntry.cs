using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DataEntry
    {
        DatabaseAttribute da = new DatabaseAttribute();
        public void EnterCommonData(string SampleType)
        {
            da.SampleType = SampleType;
            Console.WriteLine("Sample type: " + da.SampleType);
            
            Console.WriteLine("Please enter the genome type: ");
            da.GenomeType = Console.ReadLine();
            Console.WriteLine("Please enter the treatment: ");
            da.Treatment = Console.ReadLine();
            Console.WriteLine("Please enter the condition: ");
            da.Condition = Console.ReadLine();
            Console.WriteLine("Please add comments: ");
            da.Comments = Console.ReadLine();
            Console.WriteLine("Please enter the concentration: ");
            da.Concentration = GetUserInputDouble();
            Console.WriteLine("Please enter the volume: ");
            da.Volume = GetUserInputDouble();
            Console.WriteLine("Please enter the initials: ");
            da.Initials = Console.ReadLine();
            Console.WriteLine("Please enter the PI of the sample: ");
            da.PIValue = Console.ReadLine();
            Console.WriteLine("Please enter the date of addition for the sample, in the format DD-MM-YYYY: ");
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

            DatabaseWriter dw = new DatabaseWriter();
            Console.WriteLine("Please enter the count of transposase units: ");
            da.ATACTransposaseUnit = GetUserInputDouble();
            Console.WriteLine("Please enter the count of PCR Cycles: ");
            da.ATACPCRCycles = GetUserInputDouble();
            dw.InsertCommon(da);
            
        }

        public void EnterDataForCHIP(DatabaseAttribute da)
        {

        }

        public void EnterDataForRNA(DatabaseAttribute da)
        {

        }

        public void EnterDataForHI(DatabaseAttribute da)
        {

        }
        public DatabaseAttribute ReturnSample (DatabaseAttribute da)
        {
            return da;
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
