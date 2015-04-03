#Object-Oriented Programming – Practical Exam

##Problem 2 – Ecosystem Simulation API

You are given an ecosystem simulation API that gives the base for creating organisms, moving organisms and handling encounters between organisms. The API includes an engine, which controls the simulation world and executes commands on the objects within it. You are also given a C# file, which has a Main method and uses the API for processing commands from the input.

There are some simple rules the simulation API supports:

*	Objects can be created anywhere
*	There are 3 major types of objects – carnivores (meat-eaters), herbivores (plant-eaters) and plants
	o	carnivores can eat herbivores and other carnivores
	o	herbivores can eat plants
*	Objects can go anywhere if they support the "go" command
	o	Only one object can move at a time
	o	When one object moves, all objects (including the moving one) get "updated" with the time required for the moving object to travel (the time is determined by the Manhattan distance between the start and end positions).
	o	When the moved object gets to a position where other objects are located, it "encounters" all of them – it tries to eat them, according to the rules above
*	Objects can sleep
*	Some objects change their size when eating or sleeping

The following lines will help you better understand the API.

###Important Classes and Interfaces

These are the API’s interfaces:

*	IOrganism – provides base properties and methods, supported by all organisms – IsAlive, Location, Size
*	IHerbivore – represents a plant-eater and provides a method EatPlant(Plant), which is called when the object encounters other objects. Eating a plant could reduce its size or kill it. Note: The proper way to implement the EatPlant method is to call the passed plant's GetEatenQuantity(int). EatPlant must also return the eaten quantity.
*	ICarnivore – represents a meat-eater and provides a method TryEatAnimal(Animal), which is called when the object encounters other objects. The carnivore could fail in eating the animal, but if it succeeds, the animal dies. Note: The proper way to implement the TryEatAnimal method is to call the passed animal's GetMeatFromKillQuantity(). The TryEatAnimal method must return the quantity of meat eaten.

These are the API’s classes and structures:

*	Point – struct, represents a two-dimensional point with integer coordinates and provides a Parse(string) and overloaded ToString() method, along with a GetManhattanDistance(Point, Point) static method
*	Organism – abstract implementation of the IOrganism interface. Has an overloaded ToString() method
*	Animal – abstract base for all animals (organisms which can move), which can execute "go" and "sleep" commands. Provides the respective GoTo(Point) and Sleep(int) commands. Also provides an implementation of the GetMeatFromKillQuantity() method, which kills the animal and returns its meat value. Also has a State property, indicating whether the animal is sleeping or awake. Has a Name and an overloaded ToString() method
*	Plant – abstract base for organisms that never change their position. Has a GetEatenQuantity(int) method, which takes a "bite size" and reduces the size of the plant by that bite size (if the plant is bigger), or kills the plant and sets its size to 0, if the bite is larger than the plant's size. The method returns the change in size of the plant (i.e. the "eaten" quantity). Has an overloaded ToString() method
*	Tree and Bush – plants with a predefined size 
*	Deer – animal class, implementation of the IHerbivore interface. Does not change in any way when eating.
*	Engine – handles commands and executes them on the simulation world, keeps several lists of the objects in it, provides methods for adding objects and removes dead objects after each "go" command

###Commands


There are two types of commands the Engine supports:

*	Organism birth command – creates an object in the world
	o	Format: birth <object-type-name> <object-parameters…>
	o	Example: birth tree (0,0) – creates a tree at the position (0, 0)
	o	Example: birth deer Rudolf (0,0) – creates a deer with the name Rudolf at position (0,0)
*	Object instance command – orders an object to execute a command. If the object executes the command, a string is printed.
	o	Format: <command-name> <object-name> <command-parameters>
	o	Commands:
			sleep <object-name> <time>
			go <object-name> <position> 
	o	Example: sleep Rudolf 10 – puts the animal with the name Rudolf to sleep for 10 time units
	o	Example: go Rudolf (5,5) – sends the animal with the name Rudolf to position (5,5), updates all objects with the elapsed time and checks for possible encounters with other organisms

Here is a list of all commands the Engine supports currently:
	
*	birth tree <position> - creates a tree at the specified coordinates
*	birth bush <position> - creates a bush at the specified coordinates
*	birth deer <name> <coordinates> - creates a deer with the specified name at the specified coordinates
*	sleep <name> <time> - puts the animal with the specified name to sleep for the specified time
*	go <name> coordinates – moves the animal with the specified name to the specified coordinates, updates all objects with the elapsed time (calculated by Manhattan distance from the object position to the object destination) and checks for encounters

The Engine handles all listed commands and you shouldn’t write your own parsing code for these commands.

Study the aforementioned classes to get a better understanding of how they work and how the Engine class handles the listed commands.

###Tasks

You are tasked with extending the API by implementing several commands and object types. You are not allowed to edit any existing class from the original code of the API. You are not allowed to edit the Main method. You are allowed to edit the GetEngineInstance() method.

*	Implement a command to create a Wolf. The Wolf should be an animal and should have a Size of 4. The Wolf should be able to eat any animal smaller than or as big as him, or any animal which is sleeping.
	o	Format: birth wolf <name> <position> - creates a Wolf at the specified position with the specified name
	o	Example: birth wolf Joro (1,1) – creates a Wolf with the name Joro, at coordinates (1, 1)
*	Implement a command to create a Lion. The Lion should be an animal and should have a Size of 6. The Lion should be able to eat any animal, which is at most twice larger than him (inclusive). Also, the Lion should grow by 1 with each animal it eats.
	o	Format: birth lion <name> <position> - creates a Lion at the specified position with the specified name
*	Implement a command to create Grass. The Grass should be a plant and should have a Size of 2. The Grass should grow by 1 at each time unit (i.e. by as much as the timeElapsed parameter is in the Update method), if it IsAlive.
	o	Format: birth grass <position> - creates grass at the specified position
	o	Example: birth grass (1,2) – creates grass at coordinates (1,2)
*	Implement a command to create a Boar. The Boar should be an animal and should have a Size of 4. The Boar should be able to eat any animal, which is smaller than him or as big as him. The Boar should be able to eat from any plant. The Boar always has a bite size of 2. When eating from a plant, the Boar increases its size by 1.
	o	Format: birth boar <name> <position> - creates a boar at the specified position, with the specified name
	o	Example: birth boar Gruhcho (7,-3) – creates a boar at the coordinates (7,-3), with the name Gruhcho
*	Implement a command to create a Zombie. The Zombie should be an animal and should not be able to eat. When a carnivore (of the so-far existing) tries to eat a Zombie, it should always succeed and receive 10 meat from the Zombie. However, the Zombie should never die. 
	o	Format: birth zombie <name> <position> - creates a zombie with the specified name at the specified position
	o	Example: birth zombie Joro (0,0) – creates a zombie named Joro at the coordinates (0,0)

###Input and Output Data

You should not concern yourself with handling input and output data – the engine does it for you. You should only consider how to implement the required creation commands. See the existing Engine code for hints. Also:

*	The names in the commands will always consist of upper and lowercase English letters only. The numbers in the commands will always be 32-bit signed integers (System.Int32).
*	There will never be two plants at the same position, nor two organisms with the same names.

