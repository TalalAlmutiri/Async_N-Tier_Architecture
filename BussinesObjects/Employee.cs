using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesObjects
{
    public class Employee
    {
        private int empID;
        private string firstName;
        private string lastName;
        private int age;
        private int countryID;
        private Country country;
        private string countryDesc;

        public int EmpID { get => empID; set => empID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Age { get => age; set => age = value; }
        public int CountryID { get => countryID; set => countryID = value; }
        public Country Country { get => country; set => country = value; }
        public string CountryDesc { get => country.CountryDesc; }
    }
}
