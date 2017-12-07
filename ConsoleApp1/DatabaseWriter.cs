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
      
        public void InsertCommon(DatabaseAttribute da)
        
            {
                using (SqlConnection con = new SqlConnection(connectionString)) //will we need to close the connection manully if we exit the connection without execution the query??
                {
                    try
                    {
                        con.Open();
                    SqlCommand cmd1 = new SqlCommand();
                    if (da.SampleType == "ATAC-Seq")
                    {
                        cmd1 = new SqlCommand("spAddSample_ATAC_Seq", con);
                    }
                    else if (da.SampleType == "ChIP-Seq")
                    {
                       cmd1 = new SqlCommand("spAddSample_ChIP_Seq", con);
                    }
                   else if (da.SampleType == "Hi-C")
                    {
                        cmd1 = new SqlCommand("spAddSample_Hi_C", con);
                    }
                    if (da.SampleType == "RNA-Seq")
                    {
                        cmd1 = new SqlCommand("spAddSample_RNA_Seq", con);
                    }

                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add(new SqlParameter("@Sample_Type", da.SampleType));
                    cmd1.Parameters.Add(new SqlParameter("@Genome_Type", da.GenomeType));
                    cmd1.Parameters.Add(new SqlParameter("@Treatment", da.Treatment));
                    cmd1.Parameters.Add(new SqlParameter("@Condition", da.Condition));
                    cmd1.Parameters.Add(new SqlParameter("@Comments", da.Comments));
                    cmd1.Parameters.Add(new SqlParameter("@Concentration", da.Concentration));
                    cmd1.Parameters.Add(new SqlParameter("@Volume", da.Volume));
                    cmd1.Parameters.Add(new SqlParameter("@Initials", da.Initials));
                    cmd1.Parameters.Add(new SqlParameter("@PI_Value", da.PIValue));
                    cmd1.Parameters.Add(new SqlParameter("@Date_Of_Addition", da.DateOfAddition));

                    if (da.SampleType == "ATAC-Seq")
                    {
                        cmd1.Parameters.Add(new SqlParameter("@Transposase_Unit", da.ATACTransposaseUnit));
                        cmd1.Parameters.Add(new SqlParameter("@PCR_Cycles", da.ATACPCRCycles));
                    }
                    else if (da.SampleType == "ChIP-Seq")
                    {
                        cmd1.Parameters.Add(new SqlParameter("@Antibody", da.ChIPAntibody));
                        cmd1.Parameters.Add(new SqlParameter("@Antibody_Lot", da.ChIPAtibodyLot));
                        cmd1.Parameters.Add(new SqlParameter("@Antibody_Catalogue_Number", da.ChIPAntibodyCatalogueNumber));
                    }
                    else if (da.SampleType == "Hi-C")
                    {
                        cmd1.Parameters.Add(new SqlParameter("@Restriction_Enzyme", da.HIRestrictionEnzyme));
                        cmd1.Parameters.Add(new SqlParameter("@PCR_Cycles", da.HIPCRCycles));
                    }
                   else if (da.SampleType == "RNA-Seq")
                    {
                        cmd1.Parameters.Add(new SqlParameter("@Prep_Type", da.RNAPrepType));
                        cmd1.Parameters.Add(new SqlParameter("@RIN", da.RNARIN));
                    }

                    bool inappropriateInput = true;
                    while (inappropriateInput)
                    {
                        Console.Write("Submit? Y/N: ");
                        ConsoleKeyInfo submitCheck = Console.ReadKey();
                        if (submitCheck.KeyChar == 'Y' || submitCheck.KeyChar == 'y')
                        {
                            inappropriateInput = false;
                            cmd1.ExecuteNonQuery();
                        }
                        else if (submitCheck.KeyChar == 'N' || submitCheck.KeyChar == 'n')
                        {
                            inappropriateInput = false;
                            con.Close(); //needed ?
                            Controller c = new Controller();
                            c.OpenMenu(1);
                        }
                    }

                }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e);
                    }

                }
            }
        
        
    }
}
