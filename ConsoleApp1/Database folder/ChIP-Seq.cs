﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ChIP_Seq : DatabaseAttribute
    {
        public string Antibody { get; set; }
        public string AtibodyLot { get; set; }
        public string AntibodyCatalogueNumber { get; set; }
    }
}
