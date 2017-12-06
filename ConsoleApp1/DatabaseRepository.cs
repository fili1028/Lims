using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace ConsoleApp1
{
    class DatabaseRepository
    {
        private static string connectionString =
                "Server=EALSQL1.eal.local; Database= DB2017_C08; User Id=USER_C08; Password=SesamLukOp_08";


        public void GetSampleByID(int SampleID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("spGetSampleByID", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add(new SqlParameter("@Sample_ID", SampleID));
                

                    SqlDataReader reader = cmd1.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                           
                            string SampleType = reader["Sample_Type"].ToString(); 
                            string GenomeType = reader["Genome_Type"].ToString();
                            string Treatment = reader["Treatment"].ToString();
                            string Condition = reader["Condition"].ToString();
                            string Comments = reader["Comments"].ToString();
                            string Concentration = reader["Concentration"].ToString();
                            string Volume = reader["Volume"].ToString();
                            string Initials = reader["Initials"].ToString();
                            string PiValue = reader["Pi_Value"].ToString();
                            string DateOfAddition = reader["Date_Of_Addition"].ToString();
                            Console.WriteLine("SAMPLE ID: " + SampleID);
                            Console.WriteLine("Sample Type of " + SampleID + " is " + SampleType);
                            Console.WriteLine("Genome type is" + GenomeType);
                            Console.WriteLine("Treatment of sample " + SampleID + " is:" + Treatment);
                            Console.WriteLine("Condition of the sample " + SampleID + " is: " + Condition);
                            Console.WriteLine("Comments for sample " + SampleID + " is: " + Comments);
                            Console.WriteLine("Concentration of sample " + SampleID + " is: " + Concentration);
                            Console.WriteLine("Volume of sample " + SampleID + " is: " + Volume);
                            Console.WriteLine("Initials of sample " + SampleID + " is: " + Initials);
                            Console.WriteLine("PI of sample " + SampleID + " is: " + PiValue );
                            Console.WriteLine("Date of addition for sample " + SampleID + " is: " + DateOfAddition);
                            
                            if (SampleType == "ATAC-Seq")
                            {
                                string TransposaseUnit = reader["Transposase_Unit"].ToString();
                                string PCRCycles = reader["PCR_Cycles"].ToString();
                                Console.WriteLine("Transposase unit count of sample " + SampleID + " is: " + TransposaseUnit);
                                Console.WriteLine("PCR cycles count of sample " + SampleID + " is : " + PCRCycles);
                                
                            }
                            if (SampleType == "Hi-C")
                            {
                                string RestrictionEnzyme = reader["Restriction_Enzyme"].ToString();
                                string PCRCycles = reader["PCR_Cycles"].ToString();
                                Console.WriteLine("Restriction enzyme count of sample " + SampleID + " is: " + RestrictionEnzyme);
                                Console.WriteLine("PCR Cycle count of sample " + SampleID + " is: " + PCRCycles);
                            }
                            if (SampleType == "RNA-Seq")
                            {
                                string PrepType = reader["Prep_Type"].ToString();
                                string RIN = reader["RIN"].ToString();
                                Console.WriteLine("The prep type of sample " + SampleID + " is: " + PrepType);
                                Console.WriteLine("The RIN of the sample " + SampleID + " is: " + RIN);
                            }

                          //  if (SampleType == "ChIP-Seq")
                         
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }

            }

        }
    }
}
    
    
