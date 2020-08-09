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
    public partial class EmpList : System.Web.UI.Page
    {
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

        protected async void reptEmployees_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.Item != null)
                {
                    Literal txtEmpID = (Literal)e.Item.FindControl("lbEmpID");
                    if (e.CommandName == "rowEdit")
                    {
                        // You can use query string in front-end or use session
                        // Also you can encrypt a query string 
                        Response.Redirect("EmpUpdate.aspx?id=" + txtEmpID.Text, false);
                    }
                    else if (e.CommandName == "rowDelete")
                    {
                        if (await EmployeeBLL.Delete(Convert.ToInt32(txtEmpID.Text)))
                        {
                            lbMsg.Text = "The record was deleted successfully";
                            e.Item.Visible = false;
                        }   
                        else
                        {
                            lbMsg.Text = "An error occurred during this operation";
                        }
                    }
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