# Prototype Pattern

#### Мотивация
**Prototype Pattern** е **създаващ (creational) дизайн патърн**, който позволява на обект да създава къстъмизирани 
обекти, без да знае техния клас или каквито и да е детайли по създаването им. Идеята на този конкретен дизайн патърн
е вместо създаване да използва клониране.

#### Цел
* Определя типовете обекти, които да бъдат създадени, използвайки прототипно инстанциране
* Създаване на нови обекти чрез копиране на техния прототип

#### Структура 
 ![alt text](https://raw.github.com/svetlai/TelerikAcademy/tree/master/Programming-with-C%23/High-Quality-Code/14-Creational-Design-Patterns/imgs/prototype-uml.svg "Prototype UML Diagram")

#### Участниците в процеса:
- **Client** - създава нов обект, карайки прототипа да се клонира
- **Prototype** - декларира интерфейс за клониране declares an interface for cloning itself
- **Concrete Prototype** - имплементира операциято по клониране

#### Предимства
* Елиминира овърхед-а при създаване на обект
* Скрива сложността на създаване на нови инстанции от клиента 

#### Приложение
* Когато една система трябва да е независима от това как се създават, композират и представят нейните продукти

#### Пример

    public interface Prototype {
    	public abstract Object clone ( );
    }
           
    public class ConcretePrototype implements Prototype {
    	public Object clone() {
    		return super.clone();
    	}
    }
    
    public class Client {
    
    	public static void main( String arg[] ) 
    	{
    		ConcretePrototype obj1= new ConcretePrototype ();
    		ConcretePrototype obj2 = ConcretePrototype)obj1.clone();
    	}   
    }

    //-----------------------------
    	
    using System;
    using System.Collections.Generic;
     
    namespace DoFactory.GangOfFour.Prototype.RealWorld
    {
      /// <summary>
      /// MainApp startup class for Real-World 
      /// Prototype Design Pattern.
      /// </summary>
      class MainApp
      {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
          ColorManager colormanager = new ColorManager();
     
          // Initialize with standard colors
          colormanager["red"] = new Color(255, 0, 0);
          colormanager["green"] = new Color(0, 255, 0);
          colormanager["blue"] = new Color(0, 0, 255);
     
          // User adds personalized colors
          colormanager["angry"] = new Color(255, 54, 0);
          colormanager["peace"] = new Color(128, 211, 128);
          colormanager["flame"] = new Color(211, 34, 20);
     
          // User clones selected colors
          Color color1 = colormanager["red"].Clone() as Color;
          Color color2 = colormanager["peace"].Clone() as Color;
          Color color3 = colormanager["flame"].Clone() as Color;
     
          // Wait for user
          Console.ReadKey();
        }
      }
     
      /// <summary>
      /// The 'Prototype' abstract class
      /// </summary>
      abstract class ColorPrototype
      {
        public abstract ColorPrototype Clone();
      }
     
      /// <summary>
      /// The 'ConcretePrototype' class
      /// </summary>
      class Color : ColorPrototype
      {
        private int _red;
        private int _green;
        private int _blue;
     
        // Constructor
        public Color(int red, int green, int blue)
        {
          this._red = red;
          this._green = green;
          this._blue = blue;
        }
     
        // Create a shallow copy
        public override ColorPrototype Clone()
        {
          Console.WriteLine(
            "Cloning color RGB: {0,3},{1,3},{2,3}",
            _red, _green, _blue);
     
          return this.MemberwiseClone() as ColorPrototype;
        }
      }
     
      /// <summary>
      /// Prototype manager
      /// </summary>
      class ColorManager
      {
        private Dictionary<string, ColorPrototype> _colors =
          new Dictionary<string, ColorPrototype>();
     
        // Indexer
        public ColorPrototype this[string key]
        {
          get { return _colors[key]; }
          set { _colors.Add(key, value); }
        }
      }
    }
	
#### Source:
* [dofactory](http://www.dofactory.com/net/prototype-design-pattern)
* [oodesign](http://www.oodesign.com/prototype-pattern.html)
* [wikipedia](https://en.wikipedia.org/wiki/Prototype_pattern)