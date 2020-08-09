using BussinesObjects;
using SharedClassess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class CountryDAL
    {
        public static async Task<IEnumerable<Country>> GetAllCountry()
        {
            try
            {
                List<Country> countriesList = new List<Country>();

                string query = @"SELECT * FROM Country";
                DataTable table = await SqlHelper.ExecuteQuery(query, CommandType.Text, null);

                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        Country country = new Country();
                        country.CountryID = (table.Rows[i]["CountryID"] != DBNull.Value) ? Convert.ToInt32(table.Rows[i]["CountryID"]) : 0;
                        country.CountryDesc = table.Rows[i]["CountryDesc"].ToString();

                        countriesList.Add(country);
                    }
                }
                return countriesList;
            }
            catch (Exception ex)
            {
                AppLogger.WriteLog(ex.ToString());
                return null;
            }
        }

        public static async Task<Country> GetCountry(int Id)
        {
            try
            {
                Country country = new Country();
                SqlParameter[] parametersList = new SqlParameter[]{
                new SqlParameter ("@ID",Id),

           };
                string query = @"SELECT * FROM Country WHERE CountryID=@ID ";
                DataTable table = await SqlHelper.ExecuteQuery(query, CommandType.Text, parametersList);

                if (table.Rows.Count > 0)
                {
                    country.CountryID = (table.Rows[0]["CountryID"] != DBNull.Value) ? Convert.ToInt32(table.Rows[0]["CountryID"]) : 0;
                    country.CountryDesc = table.Rows[0]["CountryDesc"].ToString();

                    return country;
                }
                else
                    return null;

            }
            catch (Exception ex)
            {
                AppLogger.WriteLog(ex.ToString());
                return null;
            }
        }
    }
}
