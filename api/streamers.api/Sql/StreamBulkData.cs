using streamers.api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace streamers.api.Sql
{
    public class StreamBulkData
    {
        public static IEnumerable<InsurerData> ReturnBulkData()
        {
            List<InsurerData> insurerList = null;

            string connString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=StreamersDB;Integrated Security=True;Trusted_Connection=true;Persist Security Info=False;Enlist=false;Timeout=30;";
            SqlConnection conn = new SqlConnection(connString);

            using (conn)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM tblStreamerBulkData;",
                  conn);
                SqlDataReader reader = null;
                try
                {
                    conn.Open();

                    reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        insurerList = new List<InsurerData>();
                        while (reader.Read())
                        {
                            InsurerData insurerData = BuildInsurerData(reader);
                            insurerList.Add(insurerData);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }

                } catch(SqlException se)
                {
                    throw se;
                } finally
                {
                    reader.Close();
                }
            }
            return insurerList;
        }

        private static InsurerData BuildInsurerData(SqlDataReader reader)
        {
            InsurerData insurerData = new InsurerData
            {
                Id = reader.GetInt64(reader.GetOrdinal("StreamerDataID")),
                PolicyId = reader["policyID"] as string,
                StateCode = reader["statecode"] as string,
                County = reader["county"] as string,

                EqSiteLimit = reader["eq_site_limit"] as string,
                HuSiteLimit = reader["hu_site_limit"] as string,
                FlSiteLimit = reader["fl_site_limit"] as string,
                FrSiteLimit = reader["fr_site_limit"] as string,

                TivOne = reader["tiv_2011"] as string,
                TivTwo = reader["tiv_2012"] as string,

                EqSiteDeductible = reader["eq_site_deductible"] as string,
                HuSiteDeductible = reader["hu_site_deductible"] as string,
                FlSiteDeductible = reader["fl_site_deductible"] as string,
                FrSiteDeductible = reader["fr_site_deductible"] as string,

                PointLatitude = reader["point_latitude"] as string,
                PointLongitude = reader["point_longitude"] as string,

                Line = reader["line"] as string,
                Construction = reader["construction"] as string,
                PointGranularity = reader["point_granularity"] as string
            };

            return insurerData;
        }
    }
}
