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
        DatabaseWriter databaseWriter = new DatabaseWriter();
        
        public void EnterData(SampleDataAttributes sampleDataAttributes)
        {
            databaseWriter.InsertSample(sampleDataAttributes);
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
