# Async_N-Tier_Architecture
N tier architecture using ASP.net framework with Ado.net. All methods work in an asynchronous 

Multitier architecture (often referred to as n-tier architecture) or multilayered architecture is a client-server architecture in which presentation, application processing, and data management functions are physically separated. The most widespread use of multitier architecture is the three-tier architecture. N-tier application architecture provides a model by which developers can create flexible and reusable applications. By segregating an application into tiers, developers acquire the option of modifying or adding a specific layer, instead of reworking the entire application. A three-tier architecture is typically composed of a presentation tier, a domain logic tier, and a data storage tier.(wikipedia)

![N-tier0](https://user-images.githubusercontent.com/62042702/88465311-8f3bd480-ceca-11ea-9032-e8c1b02e23db.png)

ref: http://www.itte.no/en/2018/09/24/3-tier-architecture-whats-wrong-with-it/

The web application architecture using class libraries for each layer

![N-tier1](https://user-images.githubusercontent.com/62042702/88465340-e2ae2280-ceca-11ea-9bd9-a5dd34b9d11c.png)


Bussines Objects (Employee.cs)

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
    
Data Access Layer for Employee, GetAllEmployees method in EmployeeDAL.cs

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

Bussiness Logic Layer (EmployeeBLL.cs)

    public static async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return (await EmployeeDAL.GetAllEmployee());
        }
        
Presentation Layer Employees List

![N-tier2](https://user-images.githubusercontent.com/62042702/88465785-5d2c7180-cece-11ea-829a-2477db5af065.png)



     protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    reptEmployees.DataSource = await EmployeeBLL.GetAllEmployee();
                    reptEmployees.DataBind();
                }
            }
            catch (Exception ex)
            {
                lbMsg.Text = "error";
                AppLogger.WriteLog(ex.ToString());
            }
        }


