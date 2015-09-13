# Builder Pattern

#### Мотивация
**Builder Pattern** е **създаващ (creational) дизайн патърн**, който позволява на клиента обект да изгради сложен обект, като се посочва само типа и съдържанието му,
спестявайки подробностите, свързани с репрезентирането му (отделя изграждането на обекта от неговото представяне). По 
този начин, един и същи процес на изграждане може да бъде представен по различен начин (например превозно средство: 
кола, мотор, камион и т.н.).

#### Цел
* Дефинира инстанция за създаване на обект, но оставя под-класовете да изберат кой клас да инстанцират 
* Реферира към новосъздадения обект през общ интерфейс
 
#### Структура 
 ![Builder UML Diagram](https://raw.githubusercontent.com/svetlai/TelerikAcademy/master/Programming-with-C%23/High-Quality-Code/14-Creational-Design-Patterns/imgs/builder-uml.png "Builder UML Diagram")

#### Участниците в процеса:
-	**Director** – определя последователността на създаване на отделните части
-	**Builder** – абстрактен клас, който дефинира методите, които изграждат отделните части на крайния обект
-	**Concrete Builder** – клас, който имплементира методите на Builder, като ги надгражда/заменя за създаване на конкретно изображение на крайния обект
-	**Product** – крайният обект, който съдържа общи за отделните изображения характеристики

#### Предимства
* Разделяне на логиката от данните
* Енкапсулиране на начина, по който един обект се изгражда

#### Приложение
* Когато алгоритъмът за създаване на сложен обект е независим от частите, които състяват обекта
* Когато системата трябва да предостави различни репрезентации на обектите, които биват конструирани

#### Пример

    // Some helper enums to identify various parts
    public enum ScreenType
    {
    	ScreenType_TOUCH_CAPACITIVE,
    	ScreenType_TOUCH_RESISTIVE,
    	ScreenType_NON_TOUCH
    };
    
    public enum Battery
    {
    	MAH_1000,
    	MAH_1500,
    	MAH_2000
    };
    
    public enum OperatingSystem
    {
    	ANDROID,
    	WINDOWS_MOBILE,
    	WINDOWS_PHONE,
    	SYMBIAN
    };
    
    public enum Stylus
    {
    	YES,
    	NO
    };
    
    // Product
    class MobilePhone
    {
    	// fields to hold the part type
    	string phoneName;       
    	ScreenType phoneScreen;
    	Battery phoneBattery;
    	OperatingSystem phoneOS;
    	Stylus phoneStylus;
    
    	public MobilePhone(string name)
    	{
    		phoneName = name;
    	}
    
    	// Public properties to access phone parts
    
    	public string PhoneName
    	{
    		get { return phoneName; }            
    	}
    
    	public ScreenType PhoneScreen
    	{
    		get { return phoneScreen; }
    		set { phoneScreen = value; }
    	}        
    
    	public Battery PhoneBattery
    	{
    		get { return phoneBattery; }
    		set { phoneBattery = value; }
    	}        
    
    	public OperatingSystem PhoneOS
    	{
    		get { return phoneOS; }
    		set { phoneOS = value; }
    	}       
    
    	public Stylus PhoneStylus
    	{
    		get { return phoneStylus; }
    		set { phoneStylus = value; }
    	}
    
    	// Methiod to display phone details in our own representation
    	public override string ToString()
    	{
    		return string.Format("Name: {0}\nScreen: {1}\nBattery {2}\nOS: {3}\nStylus: {4}",
    			PhoneName, PhoneScreen, PhoneBattery, PhoneOS, PhoneStylus);
    	}
    }
    
    // Builder
    interface IPhoneBuilder
    {
    	void BuildScreen();
    	void BuildBattery();
    	void BuildOS();
    	void BuildStylus();
    	MobilePhone Phone { get;}
    }
    
    // ConcreteBuilder
    class AndroidPhoneBuilder : IPhoneBuilder
    {
    	MobilePhone phone;
    
    	public AndroidPhoneBuilder()
    	{
    		phone = new MobilePhone("Android Phone");
    	}
    
    	public void BuildScreen()
    	{
    		phone.PhoneScreen = ScreenType.ScreenType_TOUCH_RESISTIVE;
    	}
    
    	public void BuildBattery()
    	{
    		phone.PhoneBattery = Battery.MAH_1500;
    	}
    
    	public void BuildOS()
    	{
    		phone.PhoneOS = OperatingSystem.ANDROID;
    	}
    
    	public void BuildStylus()
    	{
    		phone.PhoneStylus = Stylus.YES;
    	}
    	
    	// GetResult Method which will return the actual phone
    	public MobilePhone Phone
    	{
    		get { return phone; }
    	}
    }
    
    // ConcreteBuilder
    class WindowsPhoneBuilder : IPhoneBuilder
    {
    	MobilePhone phone;
    
    	public WindowsPhoneBuilder()
    	{
    		phone = new MobilePhone("Windows Phone");
    	}
    
    	public void BuildScreen()
    	{
    		phone.PhoneScreen = ScreenType.ScreenType_TOUCH_CAPACITIVE;
    	}
    
    	public void BuildBattery()
    	{
    		phone.PhoneBattery = Battery.MAH_2000;
    	}
    
    	public void BuildOS()
    	{
    		phone.PhoneOS = OperatingSystem.WINDOWS_PHONE;
    	}
    
    	public void BuildStylus()
    	{
    		phone.PhoneStylus = Stylus.NO;
    	}
    
    	// GetResult Method which will return the actual phone
    	public MobilePhone Phone
    	{
    		get { return phone; }
    	}
    }
    
    // Director
    class Manufacturer
    {
    	public void Construct(IPhoneBuilder phoneBuilder)
    	{
    		phoneBuilder.BuildBattery();
    		phoneBuilder.BuildOS();
    		phoneBuilder.BuildScreen();
    		phoneBuilder.BuildStylus();
    	}
    }
	
    class Program
    {
        static void Main(string[] args)
        {
            // Lets create the Director first
            Manufacturer newManufacturer = new Manufacturer();
            // Lets have the Builder class ready
            IPhoneBuilder phoneBuilder = null;
    
            // Now let us create an android phone
            phoneBuilder = new AndroidPhoneBuilder();
            newManufacturer.Construct(phoneBuilder);
            Console.WriteLine("A new Phone built:\n\n{0}", phoneBuilder.Phone.ToString());
    
            // Now let us create a Windows Phone
            phoneBuilder = new WindowsPhoneBuilder();
            newManufacturer.Construct(phoneBuilder);
            Console.WriteLine("A new Phone built:\n\n{0}", phoneBuilder.Phone.ToString());
        }
    }
	
#### Source:
* [codeproject](http://www.codeproject.com/Articles/470476/Understanding-and-Implementing-Builder-Pattern-in)
* [oodesign](http://www.oodesign.com/builder-pattern.html)
* [wikipedia](https://en.wikipedia.org/wiki/Builder_pattern)