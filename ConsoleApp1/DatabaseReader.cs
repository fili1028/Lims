using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;


namespace ConsoleApp1
{
    class DatabaseReader
    {
        private static string connectionString =
                "Server=EALSQL1.eal.local; Database= DB2017_C08; User Id=USER_C08; Password=SesamLukOp_08";


        public void GetSampleTypeByID(int sampleID)
        {
            string sampleType = string.Empty;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand GetSampleType = new SqlCommand("spGetSampleTypeByID", con);
                    GetSampleType.CommandType = CommandType.StoredProcedure;
                    GetSampleType.Parameters.Add(new SqlParameter("@Sample_ID", sampleID));

                    SqlDataReader reader = GetSampleType.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            sampleType = reader["Sample_Type"].ToString();
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                    //What do we want it to do here ??
                }
            }
            GetSampleWithStoredProcedure(sampleID, sampleType);
        }


        //Was called GetSampleByID(int SampleID)
        public void GetSampleWithStoredProcedure(int SampleID, string SampleType)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("spGetSampleInfoFromIDAndType", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@Sample_ID", SampleID);
                    cmd1.Parameters.AddWithValue("@Sample_Type", SampleType);
                    SqlDataReader reader = cmd1.ExecuteReader();

                    bool red = reader.HasRows;

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string xampleType = reader["Sample_Type"].ToString();
                            string GenomeType = reader["Genome_Type"].ToString();
                            string Treatment = reader["Treatment"].ToString();
                            string Condition = reader["Condition"].ToString();
                            string Comments = reader["Comments"].ToString();
                            string Concentration = reader["Concentration"].ToString();
                            string Volume = reader["Volume"].ToString();
                            string Initials = reader["Initials"].ToString();
                            string PiValue = reader["Pi_Value"].ToString();
                            string DateOfAddition = reader["Date_Of_Addition"].ToString();
                            Console.WriteLine("SAMPLE ID:          " + SampleID);
                            Console.WriteLine("Sample Type:        " + SampleType);
                            Console.WriteLine("Genome Type:        " + GenomeType);
                            Console.WriteLine("Treatment:          " + Treatment);
                            Console.WriteLine("Condition:          " + Condition);
                            Console.WriteLine("Comments:           " + Comments);
                            Console.WriteLine("Concentration:      " + Concentration);
                            Console.WriteLine("Volume:             " + Volume);
                            Console.WriteLine("Initials:           " + Initials);
                            Console.WriteLine("PI:                 " + PiValue);
                            Console.WriteLine("Date:               " + DateOfAddition);

                            //change this to switch!
                            if (SampleType == "ATAC_Seq")//if prob, changed from - to _
                            {
                                string TransposaseUnit = reader["Transposase_Unit"].ToString();
                                string PCRCycles = reader["PCR_Cycles"].ToString();
                                Console.WriteLine("Transposase Unit:   " + TransposaseUnit);
                                Console.WriteLine("PCR Cycles:         " + PCRCycles);
                            }
                            else if (SampleType == "HI-C")
                            {
                                string RestrictionEnzyme = reader["Restriction_Enzyme"].ToString();
                                string PCRCycles = reader["PCR_Cycles"].ToString();
                                Console.WriteLine("Restriction Enzyme: " + RestrictionEnzyme);
                                Console.WriteLine("PCR Cycle:          " + PCRCycles);
                            }
                            else if (SampleType == "RNA-Seq")
                            {
                                string PrepType = reader["Prep_Type"].ToString();
                                string RIN = reader["RIN"].ToString();
                                Console.WriteLine("Prep Type:          " + PrepType);
                                Console.WriteLine("RIN:                " + RIN);
                            }

                            else if (SampleType == "ChIP-Seq")
                            {
                                string Antibody = reader["Antibody"].ToString();
                                string AntibodyLot = reader["Antibody_Lot"].ToString();
                                string AntibodyCatalogueNumber = reader["Antibody_Catalogue_Number"].ToString();
                                Console.WriteLine("Atibody:            " + Antibody);
                                Console.WriteLine("Antibody Lot:       " + AntibodyLot);
                                Console.WriteLine("Antibody Cat. Nr:   " + AntibodyCatalogueNumber);
                            }
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


