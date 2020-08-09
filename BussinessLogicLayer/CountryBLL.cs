using BussinesObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer
{
   public class CountryBLL
    {
        public static async Task<IEnumerable<Country>> GetAllCountry()
        {
            return await CountryDAL.GetAllCountry();
        }
    }
}
