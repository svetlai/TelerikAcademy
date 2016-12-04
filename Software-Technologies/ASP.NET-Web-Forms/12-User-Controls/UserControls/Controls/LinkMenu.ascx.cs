using _12.User_Controls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _12.User_Controls.Controls
{
    public partial class LinkMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.DataListMenu.Style.Add("font-family", this.FontFamily);
        }

        public LinkMenu()
        {
            this.FontFamily = "Calibri";
            this.FontColor = "green";
        }

        public string FontFamily { get; set; }

        public string FontColor { get; set; }

        public IEnumerable<MenuOption> DataSource
        {
            get 
            { 
                return DataListMenu.DataSource as IEnumerable<MenuOption>; 
            }
            set
            {
                foreach (var item in value)
                {
                    if (string.IsNullOrWhiteSpace(item.FontColor))
                    {
                        item.FontColor = this.FontColor;
                    }
                }

                this.DataListMenu.DataSource = value;
                this.DataListMenu.DataBind();
            }
        }
    }
}