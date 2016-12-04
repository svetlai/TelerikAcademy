using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _11._3.Photo_Album
{
    public partial class PhotoAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static AjaxControlToolkit.Slide[] GetSlides()
        {
            AjaxControlToolkit.Slide[] imgSlide = new AjaxControlToolkit.Slide[4];

            imgSlide[1] = new AjaxControlToolkit.Slide("images/1.jpg", "1", "Blue Hills");
            imgSlide[2] = new AjaxControlToolkit.Slide("images/2.jpg", "kenny", "Sunset");
            imgSlide[0] = new AjaxControlToolkit.Slide("images/3.jpg", "stan", "Rocks");

            return (imgSlide);
        }

    }
}