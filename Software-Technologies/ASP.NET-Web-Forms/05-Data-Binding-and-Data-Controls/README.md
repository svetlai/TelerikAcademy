# ASP.NET Data Binding Homework

1. Create a Web form for searching for cars by producer + model + type of engine + set of extras (see www.`mobile.bg`). Use two `DropDownLists` for the `producer` (e.g. VW, BMW, …) and for the `model` (A6, Corsa,…). Create a class `Producer` hodling `Name` + collection of models. Bind the list of producers to the first `DropDownList`. The second should be bound to the models of this producer. You should have a check box for each “`extra`” (use class `Extra` and bind the list of extras at the server side). Implement the `type of engine `as a horizontal radio button selection (options bound to a fixed array). On submit display all collected information in `<asp:Literal>`.

2. Create a page `Employees.aspx` to display the names of all employees from `Northwind` database in a `GridView `as hyperlinks. All links should redirect to another page (e.g. `EmpDetails.aspx?id=3`) where details about the employee are displayed in a `DetailsView`. Add a back button to return back to the previous page.
    - Implement the same task in a single ASPX page by using a `FormView` instead of `DetailsView`.
    - Display the information about all employees a table in an ASPX page using a `Repeater`.
    - Re-implement using `ListView`.