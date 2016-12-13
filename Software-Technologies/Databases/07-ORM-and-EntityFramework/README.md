## 08. Entity Framework
### _Homework_

1.  Using the Visual Studio Entity Framework designer create a `DbContext` for the `Northwind` database
1.  Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers.
    *   Write a testing class.
1.  Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
1.  Implement previous by using native SQL query and executing it through the `DbContext`.
1.  Write a method that finds all the sales by specified region and period (start / end dates).
1.  Create a database called `NorthwindTwin` with the same structure as `Northwind` using the features from `DbContext`.
    *   Find for the API for schema generation in MSDN or in Google.
1.  Try to open two different data contexts and perform concurrent changes on the same records.
    *   What will happen at `SaveChanges()`?
    *   How to deal with it?
1.  By inheriting the `Employee` entity class create a class which allows employees to access their corresponding territories as property of type `EntitySet<T>`.
9. Create a method that places a new order in the
Northwind database. The order should contain
several order items. Use transaction to ensure the
data consistency.
10. Create a stored procedures in the Northwind
database for finding the total incomes for given
supplier name and period (start date, end date).
Implement a C# method that calls the stored
procedure and returns the retuned record set.
11. Create a database holding users and groups. Create
a transactional EF based method that creates an
user and puts it in a group "Admins". In case the
group "Admins" do not exist, create the group in the
same transaction. If some of the operations fail (e.g.
the username already exist), cancel the entire
transaction.
