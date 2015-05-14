namespace NewsSite.Web.Admin
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;

    using Error_Handler_Control;

    using NewsSite.Web.Data;
    using NewsSite.Web.Models;

    public partial class Categories : System.Web.UI.Page
    {
        private NewsSiteDbContext db;

        public Categories()
        {
            this.db = new NewsSiteDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Category> ListViewCategories_GetData()
        {
            return this.db.Categories;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewCategories_UpdateItem(int id)
        {
            Category category = this.db.Categories.FirstOrDefault(c => c.Id == id);
            
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (category == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                ErrorSuccessNotifier.AddErrorMessage("Cannot find article with such id.");
                return;
            }

            TryUpdateModel(category);

            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                this.db.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Category updated successfully.");
                Response.Redirect("~/Admin/Categories");
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("Cannot update category. Make sure all data is valid.");
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewCategories_DeleteItem(int id)
        {
            Category category = this.db.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            this.db.Categories.Remove(category);
            this.db.SaveChanges();

            ErrorSuccessNotifier.AddSuccessMessage("Category deleted successfully.");
            Response.Redirect("~/Admin/Categories");
        }

        public void ListViewCategories_InsertItem()
        {
            var category = new Category();

            TryUpdateModel(category);

            var existingCategory = this.db.Categories.FirstOrDefault(c => c.Name == category.Name);

            if (existingCategory == null)
            {
                if (ModelState.IsValid)
                {
                    // Save changes here
                    this.db.Categories.Add(category);
                    this.db.SaveChanges();

                    ErrorSuccessNotifier.AddSuccessMessage("Category added successfully.");
                    Response.Redirect("~/Admin/Categories");
                }
                else
                {
                    ErrorSuccessNotifier.AddErrorMessage("Cannot update category. Make sure all data is valid.");
                }
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("Cannot already exists.");
            }
        }

        protected void LinkButtonInsert_Click(object sender, EventArgs e)
        {
            this.ListViewCategories.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void CustomValidatorEditNameLength_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length <= 20)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}