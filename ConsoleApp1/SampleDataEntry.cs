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
        public void EnterData(SampleDataAttributes sampleDataAttributes)
        {
            dw.InsertSample(sampleDataAttributes);
        }                                      
    }
}
