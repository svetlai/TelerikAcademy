using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _11._1.Employees
{
    public partial class Employees1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var db = new NorthwindEntities();
                var allEmployees = db.Employees.ToList();
                this.GridViewEmployees.DataSource = allEmployees;
                this.GridViewEmployees.DataBind();
            }
        }

        protected void GridViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            var db = new NorthwindEntities();
            int employeeIndex = int.Parse(this.GridViewEmployees.SelectedValue.ToString());

            var currentOrders = db.Orders.Where(o => o.EmployeeID == employeeIndex).ToList();

            this.GridViewOrders.DataSource = currentOrders;
            this.GridViewOrders.DataBind();
        }
    }
}