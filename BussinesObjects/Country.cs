using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesObjects
{
    public class Country
    {
        private int countryID;
        private string countryDesc;

        public int CountryID { get => countryID; set => countryID = value; }
        public string CountryDesc { get => countryDesc; set => countryDesc = value; }
    }
}
