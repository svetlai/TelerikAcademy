using Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chat
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                var db = new ApplicationDbContext();

                if (!Page.IsPostBack)
                {
                    LoadData(db);
                    this.PanelMessages.Visible = true;
                }
            }
            else
            {
                Response.Redirect("~/Account/Login");
            }
        }

        protected void ButtonPostMessage_Click(object sender, EventArgs e)
        {
            var db = new ApplicationDbContext();

            var currentUserName = Context.User.Identity.Name;

            var user = db.Users.FirstOrDefault(a => a.UserName == currentUserName);

            //var user = db.Users.Single(x => x.UserName == Context.User.Identity.Name);

            var newMessage = new Message
            {
                Text = this.TextBoxPostMessage.Text,
                Author = user,
                AuthorName = user.FirstName + ' ' + user.LastName
            };

            db.Messages.Add(newMessage);
            db.SaveChanges();
            Response.Redirect("~/Default");
        }

        private void LoadData(ApplicationDbContext db)
        {
            var messages = db.Messages.ToList();
            this.ListViewChat.DataSource = messages;
            this.ListViewChat.DataBind();
        }

        protected void ListViewChat_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            var db = new ApplicationDbContext();
            this.ListViewChat.EditIndex = e.NewEditIndex;
            LoadData(db);
        }

        protected void ListViewChat_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            var db = new ApplicationDbContext();
            this.ListViewChat.EditIndex = -1;
            LoadData(db);
        }

        protected void ListViewChat_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            var listView = (ListView)sender;
            int messageId = int.Parse(listView.DataKeys[e.ItemIndex].Value.ToString());

            var editedRow = listView.Items[e.ItemIndex];
            var tbMessageText = editedRow.FindControl("TextBoxEditMessageText") as TextBox;

            var db = new ApplicationDbContext();

            var currentMessage = db.Messages.Find(messageId);
            currentMessage.Text = tbMessageText.Text;
            db.SaveChanges();

            listView.EditIndex = -1;
            LoadData(db);
        }

        protected void ListViewChat_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            var listView = (ListView)sender;
            int messageId = int.Parse(listView.DataKeys[e.ItemIndex].Value.ToString());

            var editedRow = listView.Items[e.ItemIndex];
            var tbMessageText = editedRow.FindControl("TextBoxEditMessageText") as TextBox;

            var db = new ApplicationDbContext();

            var currentMessage = db.Messages.Find(messageId);
            db.Messages.Remove(currentMessage);
            db.SaveChanges();

            listView.EditIndex = -1;
            LoadData(db);
        }

        protected void ListViewChat_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var listView = sender as ListView;

            if (Context.User.Identity.IsAuthenticated)
            {
                var db = new ApplicationDbContext();
                var user = db.Users
                    .Single(x => x.UserName == this.Context.User.Identity.Name);

                if (db.Roles.Any(x => x.Name == "Admin") && user.Roles.Any(role => role.RoleId == db.Roles.Single(x => x.Name == "Admin").Id))
                {
                    if (e.Item.ItemType == ListViewItemType.DataItem && listView.EditIndex < 0)
                    {
                        var deleteButton = e.Item.FindControl("DeleteButton") as Button;
                        deleteButton.Visible = true;

                        var editButton = e.Item.FindControl("EditButton") as Button;
                        editButton.Visible = true;
                    }

                    this.LiteralRole.Text = "Admin View";
                }

                if (db.Roles.Any(x => x.Name == "Moderator") && user.Roles.Any(role => role.RoleId == db.Roles.Single(x => x.Name == "Moderator").Id))
                {

                    if (e.Item.ItemType == ListViewItemType.DataItem && listView.EditIndex < 0)
                    {
                        var editButton = e.Item.FindControl("EditButton") as Button;
                        editButton.Visible = true;
                    }

                    this.LiteralRole.Text = "Moderator View";
                }
            }
        }
    }
}