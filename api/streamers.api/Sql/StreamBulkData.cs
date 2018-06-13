using streamers.api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace streamers.api.Sql
{
    public class StreamBulkData
    {
        static readonly string connString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=StreamersDB;Integrated Security=True;Trusted_Connection=true;Persist Security Info=False;Enlist=false;Timeout=30;";
        static readonly string sqlQueryString = "SELECT * FROM tblStreamerBulkData;";


        public static IEnumerable<InsurerData> DataReaderReturnData()
        {
            SqlConnection conn = new SqlConnection(connString);

            using (conn)
            {
                SqlCommand command = new SqlCommand(sqlQueryString, conn);
                SqlDataReader reader = null;
                try
                {
                    conn.Open();

                    reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            yield return BuildReaderInsurerData(reader);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }

                } finally
                {
                    reader.Close();
                }
            }
        }

        public static IEnumerable<InsurerData> DataAdapterReturnData()
        {
            SqlConnection conn = new SqlConnection(connString);

            using (conn)
            {
                SqlCommand command = new SqlCommand(sqlQueryString, conn);
                SqlDataAdapter adapter = null;
                try
                {
                    conn.Open();

                    adapter = new SqlDataAdapter(command);

                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    for(int i = 0; i < table.Rows.Count; i++)
                    {
                        yield return BuildAdapterInsurerData(table, i);
                    }

                } finally
                {
                    conn.Close();
                }
            }
        }

        private static InsurerData BuildReaderInsurerData(SqlDataReader reader)
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

        private static InsurerData BuildAdapterInsurerData(DataTable table, int i)
        {
            InsurerData insurerData = new InsurerData
            {
                Id = (long)table.Rows[i]["StreamerDataID"],
                PolicyId = table.Rows[i]["policyID"] as string,
                StateCode = table.Rows[i]["statecode"] as string,
                County = table.Rows[i]["county"] as string,

                EqSiteLimit = table.Rows[i]["eq_site_limit"] as string,
                HuSiteLimit = table.Rows[i]["hu_site_limit"] as string,
                FlSiteLimit = table.Rows[i]["fl_site_limit"] as string,
                FrSiteLimit = table.Rows[i]["fr_site_limit"] as string,

                TivOne = table.Rows[i]["tiv_2011"] as string,
                TivTwo = table.Rows[i]["tiv_2012"] as string,

                EqSiteDeductible = table.Rows[i]["eq_site_deductible"] as string,
                HuSiteDeductible = table.Rows[i]["hu_site_deductible"] as string,
                FlSiteDeductible = table.Rows[i]["fl_site_deductible"] as string,
                FrSiteDeductible = table.Rows[i]["fr_site_deductible"] as string,

                PointLatitude = table.Rows[i]["point_latitude"] as string,
                PointLongitude = table.Rows[i]["point_longitude"] as string,

                Line = table.Rows[i]["line"] as string,
                Construction = table.Rows[i]["construction"] as string,
                PointGranularity = table.Rows[i]["point_granularity"] as string
            };
            return insurerData;
        }
    }
}
