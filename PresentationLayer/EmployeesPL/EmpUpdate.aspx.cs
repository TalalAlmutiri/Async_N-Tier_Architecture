using BussinesObjects;
using BussinessLogicLayer;
using SharedClassess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer.EmployeesPL
{
    public partial class EmpUpdate : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["id"] == null)
                        Response.Redirect("EmpList.aspx", false);
                    else
                    {
                        // loading countries 
                        ddlCountries.DataSource = await CountryBLL.GetAllCountry();
                        ddlCountries.DataBind();

                        Employee emp = await EmployeeBLL.GetEmployee(Convert.ToInt32(Request.QueryString["id"]));
                        txtEmpID.Value = emp.EmpID.ToString();
                        txtFirstName.Value = emp.FirstName;
                        txtLastName.Value = emp.LastName;
                        txtAge.Value = emp.Age.ToString();
                        ddlCountries.SelectedValue = emp.CountryID.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                lbMsg.Text = "error";
                AppLogger.WriteLog(ex.ToString());
            }
        }

        protected async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // You can add validation rules here or in the EmployeeBLL class
                if (await EmployeeBLL.Update(Convert.ToInt32(txtEmpID.Value), txtFirstName.Value, txtLastName.Value, Convert.ToInt32(txtAge.Value), Convert.ToInt32(ddlCountries.SelectedValue)))
                {
                    lbMsg.Text = "The record successfully updated";
                }
            }
            catch (Exception ex)
            {
                lbMsg.Text = "error";
                AppLogger.WriteLog(ex.ToString());
            }
        }
    }
}