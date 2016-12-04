using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _11._2.Messages
{
    public partial class Chat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new ChatDbEntities();

            if (!db.Messages.Any())
            {
                SeedInitialData();
            }

            var messages = db.Messages.ToList();

            this.GridViewChat.DataSource = messages;
            this.GridViewChat.DataBind();
        }

        private void SeedInitialData()
        {
            var db = new ChatDbEntities();
            var newMessage = new Message
            {
                MessageContent = "Hello"
            };

            var secondMessage = new Message
            {
                MessageContent = "Hello There"
            };

            db.Messages.Add(newMessage);
            db.Messages.Add(secondMessage);
            db.SaveChanges();
        }
    }
}