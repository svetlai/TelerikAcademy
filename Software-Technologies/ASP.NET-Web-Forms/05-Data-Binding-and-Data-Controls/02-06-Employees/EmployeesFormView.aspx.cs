using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _5._2___5._6.Employees
{
    public partial class EmployeesFormView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new NorthwindEntities();
            var employees = db.Employees.ToList();

            if (!Page.IsPostBack)
            {
                this.GridViewEmployees.DataSource = employees;
                this.GridViewEmployees.DataBind();
            }
        }

        protected void GridViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(GridViewEmployees.SelectedDataKey.Value.ToString());
            var db = new NorthwindEntities();
            FormViewEmployees.DataSource = new List<Employee>()
                {
                    db.Employees.FirstOrDefault(x => x.EmployeeID == id)
                };
            FormViewEmployees.DataBind();
        }
    }
}