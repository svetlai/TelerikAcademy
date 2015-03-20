Homework: Common Type System
============================

### Problem 1. Student class
*	Define a class `Student`, which contains data about a student – first, middle and last name, SSN, permanent address, mobile phone e-mail, course, specialty, university, faculty. Use an enumeration for the specialties, universities and faculties.
*	Override the standard methods, inherited by `System.Object`: `Equals()`, `ToString()`, `GetHashCode()` and operators `==` and `!=`.

### Problem 2. IClonable
*	Add implementations of the `ICloneable` interface. The `Clone()` method should deeply copy all object's fields into a new object of type `Student`.

### Problem 3. IComparable
*	Implement the `IComparable<Student>` interface to compare students by names (as first criteria, in lexicographic order) and by social security number (as second criteria, in increasing order).