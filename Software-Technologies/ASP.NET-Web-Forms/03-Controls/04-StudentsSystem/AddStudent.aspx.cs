using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _3._4.StudentsSystem
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAddStudent_Click(object sender, EventArgs e)
        {
            string firstName = Server.HtmlEncode(this.TextBoxFirstName.Text);
            string lastName = Server.HtmlEncode(this.TextBoxLastName.Text);
            string facultyNumber = Server.HtmlEncode(this.TextBoxFacultyNumber.Text);
            string university = this.DropDownListUniversity.SelectedValue;
            var courses = this.ListBoxCourses.Items;

            var h3 = new HtmlGenericControl("h3");
            h3.InnerHtml = "New Student Added";

            var pName = new HtmlGenericControl("p");
            pName.InnerHtml = "Name: " + firstName + " " + lastName;

            var pNumber = new HtmlGenericControl("p");
            pNumber.InnerHtml = "Faculty number: " + facultyNumber;

            var pUniversity = new HtmlGenericControl("p");
            pUniversity.InnerHtml = "University: " + university;

            var pCourses = new HtmlGenericControl("p");
            pCourses.InnerHtml = "Courses: ";
            var ul = new HtmlGenericControl("ul");
            foreach (ListItem item in this.ListBoxCourses.Items)
            {
                if (item.Selected)
                {
                    var li = new HtmlGenericControl("li");
                    li.InnerText = item.Text;
                    ul.Controls.Add(li);
                }
            }

            PanelAddedStudent.Controls.Add(h3);
            PanelAddedStudent.Controls.Add(pName);
            PanelAddedStudent.Controls.Add(pNumber);
            PanelAddedStudent.Controls.Add(pUniversity);
            PanelAddedStudent.Controls.Add(pCourses);
            PanelAddedStudent.Controls.Add(ul);
        }
    }
}