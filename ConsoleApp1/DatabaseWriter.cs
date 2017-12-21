using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace ConsoleApp1
{
    public class DatabaseWriter
    {
        private static string connectionString =
        "Server=EALSQL1.eal.local; Database= DB2017_C08; User Id=USER_C08; Password=SesamLukOp_08";
      
        public void InsertSample(SampleDataAttributes da)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    switch (da.SampleType)
                    {
                        case "ATAC-Seq":
                            cmd = new SqlCommand("spAddSample_ATAC_Seq", con);
                            cmd.Parameters.Add(new SqlParameter("@Transposase_Unit", da.ATACTransposaseUnit));
                            cmd.Parameters.Add(new SqlParameter("@PCR_Cycles", da.ATACPCRCycles));
                            break;
                        case "ChIP-Seq":
                            cmd = new SqlCommand("spAddSample_ChIP_Seq", con);
                            cmd.Parameters.Add(new SqlParameter("@Antibody", da.ChIPAntibody));
                            cmd.Parameters.Add(new SqlParameter("@Antibody_Lot", da.ChIPAntibodyLot));
                            cmd.Parameters.Add(new SqlParameter("@Antibody_Catalogue_Number", da.ChIPAntibodyCatalogueNumber));
                            break;
                        case "Hi-C":
                            cmd = new SqlCommand("spAddSample_Hi_C", con);
                            cmd.Parameters.Add(new SqlParameter("@Restriction_Enzyme", da.HIRestrictionEnzyme));
                            cmd.Parameters.Add(new SqlParameter("@PCR_Cycles", da.HIPCRCycles));
                            break;
                        case "RNA-Seq":
                            cmd = new SqlCommand("spAddSample_RNA_Seq", con);
                            cmd.Parameters.Add(new SqlParameter("@Prep_Type", da.RNAPrepType));
                            cmd.Parameters.Add(new SqlParameter("@RIN", da.RNARIN));
                            break;
                    }

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Sample_Type", da.SampleType));
                    cmd.Parameters.Add(new SqlParameter("@Genome_Type", da.GenomeType));
                    cmd.Parameters.Add(new SqlParameter("@Cell_Type", da.CellType));
                    cmd.Parameters.Add(new SqlParameter("@Treatment", da.Treatment));
                    cmd.Parameters.Add(new SqlParameter("@Condition", da.Condition));
                    cmd.Parameters.Add(new SqlParameter("@Comments", da.Comments));
                    cmd.Parameters.Add(new SqlParameter("@Concentration", da.Concentration));
                    cmd.Parameters.Add(new SqlParameter("@Volume", da.Volume));
                    cmd.Parameters.Add(new SqlParameter("@Initials", da.Initials));
                    cmd.Parameters.Add(new SqlParameter("@PI_Value", da.PIValue));
                    cmd.Parameters.Add(new SqlParameter("@Date_Of_Addition", da.DateOfAddition));
                    
                    cmd.ExecuteNonQuery();
                    con.Close();//needed? 
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message.ToString());
                }
            }
        }
    }
}
