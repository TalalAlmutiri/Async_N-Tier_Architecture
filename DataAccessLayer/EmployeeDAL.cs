using BussinesObjects;
using SharedClassess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmployeeDAL
    {
        public static async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            try
            {
                List<Employee> employeesList = new List<Employee>();

                string query = @"SELECT * FROM Employees";
                DataTable table = await SqlHelper.ExecuteQuery(query, CommandType.Text, null);
               
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        Employee emp = new Employee();
                        emp.EmpID = (table.Rows[i]["EmpID"] != DBNull.Value) ? Convert.ToInt32(table.Rows[i]["EmpID"]) : 0;
                        emp.FirstName = table.Rows[i]["FirstName"].ToString();
                        emp.LastName = table.Rows[i]["LastName"].ToString();
                        emp.Age = (table.Rows[i]["Age"] != DBNull.Value) ? Convert.ToInt32(table.Rows[i]["Age"]) : 0;
                        emp.CountryID = (table.Rows[i]["CountryID"] != DBNull.Value) ? Convert.ToInt32(table.Rows[i]["CountryID"]) : 0;
                        emp.Country = await CountryDAL.GetCountry(emp.CountryID);

                        employeesList.Add(emp);
                    }
                }
                return employeesList;
            }
            catch (Exception ex)
            {
                AppLogger.WriteLog(ex.ToString());
                return null;
            }
        }

        public static async Task<Employee> GetEmployee(int Id)
        {
            try
            {
                Employee emp = new Employee();
                SqlParameter[] parametersList = new SqlParameter[]{
                new SqlParameter ("@EmpID",Id),

           };
                string query = @"SELECT * FROM Employees WHERE EmpID=@EmpID ";
                DataTable table = await SqlHelper.ExecuteQuery(query, CommandType.Text, parametersList);

                if (table.Rows.Count > 0)
                {
                    emp.EmpID = (table.Rows[0]["EmpID"] != DBNull.Value) ? Convert.ToInt32(table.Rows[0]["EmpID"]) : 0;
                    emp.FirstName = table.Rows[0]["FirstName"].ToString();
                    emp.LastName = table.Rows[0]["LastName"].ToString();
                    emp.Age = (table.Rows[0]["Age"] != DBNull.Value) ? Convert.ToInt32(table.Rows[0]["Age"]) : 0;
                    emp.CountryID = (table.Rows[0]["CountryID"] != DBNull.Value) ? Convert.ToInt32(table.Rows[0]["CountryID"]) : 0;
                    emp.Country = await CountryDAL.GetCountry(emp.CountryID);
                    return emp;
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

        public static async Task<bool> Add(Employee emp)
        {
            try
            {
                string sql = @"INSERT INTO Employees(FirstName,LastName,Age,CountryID)
                               VALUES(@FirstName,@LastName,@Age,@CountryID)";

                SqlParameter[] parametersList = new SqlParameter[]{
                    new SqlParameter ("@FirstName",emp.FirstName),
                    new SqlParameter ("@LastName",emp.LastName),
                    new SqlParameter ("@Age",emp.Age),
                    new SqlParameter ("@CountryID",emp.CountryID),
                };

                return (await SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parametersList));
            }
            catch (Exception ex)
            {
                AppLogger.WriteLog(ex.ToString());
                return false;
            }
        }

        public static async Task<bool> Update(Employee emp)
        {
            try
            {
                string sql = @"UPDATE Employees SET FirstName=@FirstName,LastName=@LastName,Age=@Age,CountryID=@CountryID WHERE EmpID =@ID";

                SqlParameter[] parametersList = new SqlParameter[]{
                    new SqlParameter ("@ID",emp.EmpID),
                    new SqlParameter ("@FirstName",emp.FirstName),
                    new SqlParameter ("@LastName",emp.LastName),
                    new SqlParameter ("@Age",emp.Age),
                    new SqlParameter ("@CountryID",emp.CountryID),
                };

                return (await SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parametersList));
            }
            catch (Exception ex)
            {
                AppLogger.WriteLog(ex.ToString());
                return false;
            }
        }

        public static async Task<bool> Delete(int Id)
        {
            try
            {
                string sql = @"DELETE FROM Employees WHERE EmpID =@ID";

                SqlParameter[] parametersList = new SqlParameter[]{
                    new SqlParameter ("@ID",Id),
                };

                return (await SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parametersList));
            }
            catch (Exception ex)
            {
                AppLogger.WriteLog(ex.ToString());
                return false;
            }
        }
    }
}
