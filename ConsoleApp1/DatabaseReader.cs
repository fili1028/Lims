using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace ConsoleApp1
{
    //Why does sampleID 4 have sample type HI-C but the rest Hi-C ??
    public class DatabaseReader
    {
        private static string connectionString =
                "Server=EALSQL1.eal.local; Database= DB2017_C08; User Id=USER_C08; Password=SesamLukOp_08";

        private List<string> SampleType = new List<string>();
        
        public List<string> GetSampleByParams(string value, string spParameter)
        {
            List<string> ret = new List<string>();
            string storedProcedure = GetStoredProcedureByParameter(value, spParameter);
            List<int> sampleID = GetSampleTypeAndID(value, spParameter, storedProcedure);
            for (int i = 0; i < sampleID.Count; i++)
            {
                ret.Add(GetSampleWithTypeAndId(SampleType[i], sampleID[i]));
            }
            return ret;
        }
        private string GetStoredProcedureByParameter(string value, string spParameter)
        {
            string storedProcedure = string.Empty;
            switch (spParameter)
            {
                case "@Antibody":
                    storedProcedure = "spGetSampleByAntibody";
                    break;
                case "@Cell_Type":
                    storedProcedure = "spGetSampleByCellType";
                    break;
                case "@Condition":
                    storedProcedure = "spGetSampleByCondition";
                    break;
                case "@Initials":
                    storedProcedure = "spGetSampleByInitials";
                    break;
                case "@PI_Value":
                    storedProcedure = "spGetSampleByPI";
                    break;
                case "@Treatment":
                    storedProcedure = "spGetSampleByTreatment";
                    break;
            }
            return storedProcedure;
        }
        private List<int> GetSampleTypeAndID(string value, string spParameter, string storedProcedure)
        {
            List<int> sampleID = new List<int>();
            SampleType.Clear();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(storedProcedure, con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter(spParameter, value));

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())//runs through this loop for any sample id relevant to the value looked for
                        {
                            if (!sampleID.Contains(int.Parse(reader["Sample_ID"].ToString())))
                            {
                                sampleID.Add(int.Parse(reader["Sample_ID"].ToString()));
                                SampleType.Add(reader["Sample_Type"].ToString());
                            }                            
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message.ToString());
                }
            }
            return sampleID;
        }

        private string GetSampleWithTypeAndId(string sampleType, int sampleID)
        {
            string nl = "\n";
            string ret = string.Empty;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd1 = new SqlCommand("spGetSampleInfoFromIDAndType", con);
                    cmd1.CommandType = CommandType.StoredProcedure;

                    cmd1.Parameters.Add("@Sample_ID", SqlDbType.Int).Value = sampleID;
                    cmd1.Parameters.Add("@Sample_Type", SqlDbType.VarChar).Value = sampleType;

                    con.Open();
                    SqlDataReader reader = cmd1.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //string xampleType = reader["Sample_Type"].ToString();//probably not needed as the sampletype is imported as an arg through the method parameters
                            string GenomeType = reader["Genome_Type"].ToString();
                            string CellType = reader["Cell_Type"].ToString();
                            string Treatment = reader["Treatment"].ToString();
                            string Condition = reader["Condition"].ToString();
                            string Comments = reader["Comments"].ToString();
                            string Concentration = reader["Concentration"].ToString();
                            string Volume = reader["Volume"].ToString();
                            string Initials = reader["Initials"].ToString();
                            string PiValue = reader["Pi_Value"].ToString();
                            string DateOfAddition = reader["Date_Of_Addition"].ToString();

                            ret = "SampleID:           " + sampleID + nl +
                                  "Sample Type:        " + sampleType + nl +
                                  "Cell Type:          " + CellType + nl +
                                  "Treatment:          " + Treatment + nl +
                                  "Condition:          " + Condition + nl +
                                  "Comments:           " + Comments + nl +
                                  "Concentration:      " + Concentration + nl +
                                  "Volume:             " + Volume + nl +
                                  "Initials:           " + Initials + nl +
                                  "PI Value:           " + PiValue + nl +
                                  "Date:               " + DateOfAddition + nl;

                            switch (sampleType)
                            {
                                case "ATAC-Seq":
                                    string TransposaseUnit = reader["Transposase_Unit"].ToString();
                                    string PCRCycles = reader["PCR_Cycles"].ToString();
                                    ret += "Transposase Unit:   " + TransposaseUnit + nl +
                                           "PCR Cycles:         " + PCRCycles;
                                    break;
                                case "Hi-C":
                                    string RestrictionEnzyme = reader["Restriction_Enzyme"].ToString();
                                    PCRCycles = reader["PCR_Cycles"].ToString();
                                    ret += "Restriction Enzyme: " + RestrictionEnzyme + nl +
                                           "PCR Cycles:         " + PCRCycles + nl;
                                    break;
                                case "RNA-Seq":
                                    string PrepType = reader["Prep_Type"].ToString();
                                    string RIN = reader["RIN"].ToString();
                                    ret += "Prep Type:          " + PrepType + nl +
                                           "RIN:                " + RIN + nl;
                                    break;
                                case "ChIP-Seq":
                                    string Antibody = reader["Antibody"].ToString();
                                    string AntibodyLot = reader["Antibody_Lot"].ToString();
                                    string AntibodyCatalogueNumber = reader["Antibody_Catalogue_Number"].ToString();
                                    ret += "Atibody:            " + Antibody + nl +
                                           "Antibody Lot:       " + AntibodyLot + nl +
                                           "Antibody Cat. Nr:   " + AntibodyCatalogueNumber + nl;
                                    break;
                            }

                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return ret;
        }
    }
}


