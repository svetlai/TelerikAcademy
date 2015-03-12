Homework: Extension-Methods-Delegates-Lambda-LINQ
=================================================

### Problem 9. Student groups
*	Create a class `Student` with properties `FirstName`, `LastName`, `FN`, `Tel`, `Email`, `Marks` (a List<int>), `GroupNumber`.
*	Create a `List<Student>` with sample students. Select only the students that are from group number 2.
*	Use LINQ query. Order the students by FirstName.

### Problem 10. Student groups extensions
*	Implement the previous using the same query expressed with extension methods.

### Problem 11. Extract students by email
*	Extract all students that have email in `abv.bg`.
*	Use `string` methods and LINQ.

### Problem 12. Extract students by phone
*	Extract all students with phones in Sofia.
*	Use LINQ.

### Problem 13. Extract students by marks
*	Select all students that have at least one mark `Excellent` (`6`) into a new anonymous class that has properties – `FullName` and `Marks`.
*	Use LINQ.

### Problem 14. Extract students with two marks
*	Write down a similar program that extracts the students with exactly two marks "`2`".
*	Use extension methods.

### Problem 15. Extract marks 
*	Extract all `Marks` of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).

### Problem 16.* Groups
*	Create a class `Group` with properties `GroupNumber` and `DepartmentName`.
*	Introduce a property `Group` in the `Student` class.
*	Extract all students from "Mathematics" department.
*	Use the `Join` operator.

### Problem 18. Grouped by GroupName
*	Create a program that extracts all students grouped by `GroupName` and then prints them to the console.
*	Use LINQ.

### Problem 19. Grouped by GroupName extensions
*	Rewrite the previous using extension methods.