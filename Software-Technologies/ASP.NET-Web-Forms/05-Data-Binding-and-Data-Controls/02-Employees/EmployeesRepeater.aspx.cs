using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _5._2___5._6.Employees
{
    public partial class EmployeesRender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new NorthwindEntities();
            var employees = db.Employees.ToList();

            if (!Page.IsPostBack)
            {
                this.RepeaterEmployees.DataSource = employees;
                this.RepeaterEmployees.DataBind();
            }
        }
    }
}