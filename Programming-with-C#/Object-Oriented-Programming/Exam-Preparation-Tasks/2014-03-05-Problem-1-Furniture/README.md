#Object-Oriented Programming – Practical Exam#

##Problem 1 – Furniture##

A furniture manufacturer keeps track of their companies and furniture: tables and chairs. Each furniture piece has model, material, price in dollars, and height in meters. Each table has length and width in meters. Chairs are three types: normal, adjustable and convertible. Each chair has number of legs. Each adjustable chair can adjust its height. Each convertible chair can convert its state and be easily movable. Each company has name, registration number and catalog of furniture. Companies can add or remove furniture to their catalogs. Companies can find furniture by model. Companies can show catalogs of all furniture they offer. 

###Design the Class Hierarchy###

Your task is to design an object-oriented class hierarchy to model the furniture manufacturer, companies and all types of furniture using the best practices for object-oriented design (OOD) and object-oriented programming (OOP). Avoid duplicated code though abstraction, inheritance, and polymorphism and encapsulate correctly all fields.
You are given few C# interfaces that you should obligatory implement and use as a basis of your code:

    namespace FurnitureManufacturer.Interfaces
    {
        public interface ICompany
        {
            string Name { get; }
    
            string RegistrationNumber { get; }
    
            ICollection<IFurniture> Furnitures { get; }
    
            void Add(IFurniture furniture);
    
            void Remove(IFurniture furniture);
    
            IFurniture Find(string model);
    
            string Catalog();
        }
    
        public interface IFurniture
        {
            string Model { get; }
    
            string Material { get; }
    
            decimal Price { get; set; }
    
            decimal Height { get; }
        }
    
        public interface IChair : IFurniture
        {
            int NumberOfLegs { get; }
        }
    
    
    
        public interface ITable : IFurniture
        {
            decimal Length { get; }
    
            decimal Width { get; }
    
            decimal Area { get; }
        }
    
        public interface IAdjustableChair : IChair
        {
            void SetHeight(decimal height);
        }
    
        public interface IConvertibleChair : IChair
        {
            bool IsConverted { get; }
    
            void Convert();
        }
    }

All your furniture should implement IFurniture. Tables should implement ITable, chairs should implement IChair, adjustable chairs should implement IAdjustableChair and convertible chairs should implement IConvertibleChair. Companies should implement ICompany.

Furniture validity rules:

*	Model cannot be empty, null or with less than 3 symbols.
*	Price cannot be less or equal to $0.00.
*	Height cannot be less or equal to 0.00 m.

Table validity rules:

*	Can calculate area by the following formula: length * width.

Adjustable chair validity rules:

*	Can change the height to a new valid one. 

Convertible chair validity rules:

*	Has too states – converted and normal.
*	States can be changed by converting the chair from one to another.
*	Converted state sets the height to 0.10m.
*	Normal state returns the height to the initial one.
*	Initial state is normal.

Company validity rules:

*	Name cannot be empty, null or with less than 5 symbols.
*	Registration number must be exactly 10 symbols and must contain only digits. 
*	Adding duplicate furniture is allowed.
*	Removing furniture removes the first occurance. If such is not found, nothing happens.
*	Finding furniture by model gets the first occurance. If such is not found, return null. Searching is case insensitive.

Companies should only be created through the ICompanyFactory implemented by a class named CompanyFactory. Furniture should only be created through the IFurnitureFactory implemented by a class named FurnitureFactory. Both classes are in the FurnitureManufacturer.Engine.Factories namespace.

The company catalog method returns the information about the available furniture in the following form:

(company name) – (number of furniture/”no”) (“furniture”/”furnitures”)
(information about furniture)
(information about furniture)
(information about furniture)

The listed furniture added to a certain company (through the Add(…) method) should be ordered by price then by model. If the company has no furniture added, print “no furnitures” (yes, we know “furnitures” is not a valid word, but we do not care, obey the requirements :D ). If the company has 1 piece of furniture, print “1 furniture” and show its information on a separate line. If the company has more than 1 piece of furniture, print its number and list each one’s information on a separate line. All decimal type fields should be printed “as is”, without any formatting or rounding.

You may use the following for reference:

    "{0} - {1} - {2} {3}",
    this.Name,
    this.RegistrationNumber,
    this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
    this.Furnitures.Count != 1 ? "furnitures" : "furniture"

Look into the example below to get better understanding of the printing format. 

The table information should be in the following form:

    "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Length: {5}, Width: {6}, 
	Area: {7}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height,  
	this.Length, this.Width, this.Area

The normal and adjustable chair information should be in the following form:

    "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}", this.GetType().Name, 
	this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs

The convertible chair information should be in the following form:

    "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}, State: {6}", this.GetType().Name, 
	this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs, this.IsConverted ? "Converted" : "Normal"

The Type is either “Table“, or “Chair”, or “AdjustableChair” or “ConvertibleChair”. The convertible chair state is either “Converted” or “Normal”. All decimal type fields should be printed “as is”, without any formatting or rounding.

All properties in the above interfaces are mandatory (cannot be null or empty).

If a null value is passed to some mandatory property, you should use defensive programming to prevent unwanted results.

###Additional Notes###

To simplify your work you are given an engine that executes a sequence of commands read from the console using the classes and interfaces in your project. Please put your classes in namespace FurnitureManufacturer.Models. Implement the CompanyFactory and FurnitureFactory class in the namespace FurnitureManufacturer.Engine.Factories.

You are only allowed to write classes in the FurnitureManufacturer.Models namespace. You are not allowed to modify the existing interfaces and classes except the CompanyFactory and FurnitureFactory classes. You may delete the DeleteMe.cs file. 

Current implemented commands the engine supports are:

*	CreateCompany (name) (registration number) – adds a company with given name and registration number. Duplicate names are not allowed. As a result the command returns “Company (name) created”.
*	AddFurnitureToCompany (company name) (furniture model) – searches for furniture and adds it to an existing company’s catalog. As a result the command returns “Furniture (furniture model) added to company (company name)”.
*	RemoveFurnitureFromCompany (company name) (furniture model) – searches for furniture and removes it from an existing company’s catalog. As a result the command returns “Furniture (furniture model) removed from company (company name)”.
*	FindFurnitureFromCompany (company name) (furniture model) – searches for furniture in an existing company’s catalog. If found the engine prints the furniture’s ToString() method.
*	ShowCompanyCatalog (company name) – searches for a company and invokes it’s Catalog() method.
*	CreateTable (model) (material) (price) (height) (length) (width) – creates a table with given model, material, price, height, length and width. Duplicate models are not allowed. As a result the command returns “Table (model) created”.
*	CreateChair (model) (material) (price) (height) (legs) (type) – creates a chair by given model, material, price, height, legs and type. Type can be “Normal”, “Adjustable” and “Convertible”. Duplicate models are not allowed. As a result the command returns “Chair (model) created”.
*	SetChairHeight (model) (height) – searches for a chair by model and sets its height, if the chair is adjustable. As a result the command returns “Chair (model) adjusted to height (height)”.
*	ConvertChair (model) – searches for a chair by model and converts its state, if the chair is convertible. As a result the command returns “Chair (model) converted”.

In case of invalid operation or error, the engine returns appropriate text messages.