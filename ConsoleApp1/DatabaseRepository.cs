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
        private static string connectionString = "Server=ealdb1.eal.local; Database= DB2017_C08; User Id= USER_C08; Password=SesamLukOp_08;";

        private void GetSampleByID(int SampleID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("spGetSampleByID", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add(new SqlParameter("@Sample_ID", SampleID));
                    cmd1.ExecuteNonQuery();

                    SqlDataReader reader = cmd1.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string SampleType = reader["SampleType"].ToString(); ;
                            string GenomeType = reader["GenomeType"].ToString();
                            Console.WriteLine("Sample Type is = " + SampleType + "Genome type is = " + GenomeType);

                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("UPS" + e.Message);
                }

            }

        }
    }
}
    
    
