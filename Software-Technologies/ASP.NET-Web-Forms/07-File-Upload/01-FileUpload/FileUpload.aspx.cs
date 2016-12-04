using _7.File_Upload.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _7.File_Upload
{
    public partial class FileUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            FileUploadDbContext db = new FileUploadDbContext();

            StringBuilder sb = new StringBuilder();
            foreach (var item in db.Files)
            {
                sb.AppendFormat("{0}. <br/>", item.Id);
                sb.AppendFormat("{0} <br/>", item.Content);
            }

            this.FileOutput = sb.ToString();
        }

        protected string FileOutput { get; set; }
    }
}