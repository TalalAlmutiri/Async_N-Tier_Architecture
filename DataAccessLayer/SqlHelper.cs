using SharedClassess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    
    public class SqlHelper
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["DbConnecion"].ConnectionString;
        public static async Task<DataTable> ExecuteQuery(string cmdText, CommandType cmdType, SqlParameter[] parameters)
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, con))
                    {
                        await con.OpenAsync();
                        cmd.CommandType = cmdType;

                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.WriteLog(ex.ToString());
            }
            return table;
        }

        public static async Task<bool> ExecuteNonQuery(string cmdText, CommandType cmdType, SqlParameter[] parameters)
        {
            var value = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, con))
                    {
                        await con.OpenAsync();
                        cmd.CommandType = cmdType;
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);
                        value = await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.WriteLog(ex.ToString());
                return false;
            }
            if (value < 0)
                return false;
            else
                return true;
        }
    }
}
