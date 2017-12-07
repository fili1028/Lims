using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class DatabaseWriter
    {
        private static string connectionString =
           "Server=EALSQL1.eal.local; Database= DB2017_C08; User Id=USER_C08; Password=SesamLukOp_08";

        public void InsertCommon(DataEntry da)
        
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();
                        
                        SqlCommand cmd1 = new SqlCommand("spInsertPet", con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.Add(new SqlParameter("@PetName", pet.PetName));
                        cmd1.Parameters.Add(new SqlParameter("@PetType", pet.PetType));
                        cmd1.Parameters.Add(new SqlParameter("@PetBreed", pet.PetBreed));
                        cmd1.Parameters.Add(new SqlParameter("@PetDOB", pet.PetDOB));
                        cmd1.Parameters.Add(new SqlParameter("@PetWeight", pet.PetWeight));
                        cmd1.Parameters.Add(new SqlParameter("@OwnerID", pet.OwnerID));

                        cmd1.ExecuteNonQuery();

                    }
                    catch (SqlException e)
                    {

                        Console.WriteLine(e);
                    }

                }
            }
        
        public void InsertATAC(DataEntry da)
        {

        }
    }
}
