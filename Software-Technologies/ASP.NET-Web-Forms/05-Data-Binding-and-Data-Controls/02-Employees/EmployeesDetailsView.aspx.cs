using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _5._2___5._6.Employees
{
    public partial class EmployeesDetailsView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["EmployeeID"] == null)
            {
                Response.Redirect("Employees.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    var db = new NorthwindEntities();
                    int id = int.Parse(Request.Params["EmployeeID"]);
                    var employee = db.Employees.FirstOrDefault(x => x.EmployeeID == id);

                    this.DetailsViewEmployee.DataSource = new List<Employee>() { employee };
                    this.DetailsViewEmployee.DataBind();
                }
            }

        }
    }
}