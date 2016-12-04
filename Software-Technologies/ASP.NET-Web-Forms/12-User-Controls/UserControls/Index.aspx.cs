using _12.User_Controls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _12.User_Controls
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var options = new List<MenuOption>
            { 
                new MenuOption("link1", "#"), 
                new MenuOption("link2", "#"),
                new MenuOption("link3", "#"),
                new MenuOption("link4",  "#")
            };

            this.LinkMenu.FontFamily = "Consolas";
            this.LinkMenu.FontColor = "#FF6600";
            this.LinkMenu.DataSource = options;
            this.LinkMenu.DataBind();
        }
    }
}