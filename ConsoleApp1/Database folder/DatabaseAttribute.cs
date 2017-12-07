using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DatabaseAttribute
    {
        ATAC_Seq at = new ATAC_Seq();
        public string SampleType { get; set; } 
        public string GenomeType { get; set; }
        public string Treatment { get; set; }
        public string Condition { get; set; }
        public string Comments { get; set; }
        public double Concentration { get; set; }
        public double Volume { get; set; }
        public string Initials { get; set; }
        public string PIValue { get; set; }
        public string DateOfAddition { get; set; }
        // ATAC-Seq Data
        public double ATACTransposaseUnit { get; set; }
        public double ATACPCRCycles { get; set; }
        // ChIP-Seq data
        public string ChIPAntibody { get; set; }
        public string ChIPAtibodyLot { get; set; }
        public string ChIPAntibodyCatalogueNumber { get; set; }
        //Hi-C Data
        public double HIRestrictionEnzyme { get; set; }
        public double HIPCRCycles { get; set; }
        //RNA-Seq
        public string PrepType { get; set; }
        public string RIN { get; set; }



    }
}
