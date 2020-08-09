using BussinesObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer
{
   public class EmployeeBLL
    {

        public static async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return (await EmployeeDAL.GetAllEmployee());
        }

        public static Task<Employee> GetEmployee(int Id)
        {
            return (EmployeeDAL.GetEmployee(Id));
        }
        public static Task<bool> Add(string FirstName,string LastName,int Age,int CountryID)
        {
            Employee emp = new Employee();
            emp.FirstName = FirstName;
            emp.LastName = LastName;
            emp.Age = Age;
            emp.CountryID = CountryID;
            return (EmployeeDAL.Add(emp));
        }

        public static Task<bool> Update(int EmpID, string FirstName, string LastName, int Age, int CountryID)
        {
            Employee emp = new Employee();
            emp.EmpID = EmpID;
            emp.FirstName = FirstName;
            emp.LastName = LastName;
            emp.Age = Age;
            emp.CountryID = CountryID;
            return (EmployeeDAL.Update(emp));
        }
        public static Task<bool> Delete(int Id)
        {
            return (EmployeeDAL.Delete(Id));
        }
    }
}
