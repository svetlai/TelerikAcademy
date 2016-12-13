# Factory Method Pattern

#### Мотивация
**Factory Method** е **създаващ (creational) дизайн патърн**, който използва отделни методи за 
създаването на обекти, без да уточнява конкретния клас на обекта, който ще бъде създаден.

#### Цел

* Дефинира интерфейс за създаване на обекти, но оставя под-класовете да изберат кой клас да инстанцират 
* Реферира към новосъздадения обект през общ интерфейс

#### Структура 
 ![Factory Method UML Diagram](https://raw.githubusercontent.com/svetlai/TelerikAcademy/master/Programming-with-C%23/High-Quality-Code/14-Creational-Design-Patterns/imgs/factory-method-uml.png "Factory Method UML Diagram")

#### Участниците в процеса:
- **Product** - дефинира интерфейс за обектите, които **Factory Method** създава
- **Creator** - абстрактен създател - декларира метода, който връща обект; уточнява всички стандарти и генералното поведение на продуктите
- **Concrete Creator** - конкретен създател, който овъррайдва метода за създаване на конкретни обекти 
- **Concrete Product** - имплементира Product интерфейса

#### Предимства
* Разделя логиката от данните
* Улеснява къстъмизирането на обекти
* Намалява възможността от дуплициране на код

#### Приложение
* Когато един клас не може да предвиди типовете обекти, които следва да създаде
* Когато един клас иска неговите под-класове да бъдат отговорни за типа на обекта, който следва да се създаде

#### Пример

    public interface Product { ... }
    
    public abstract class Creator 
    {
    	public void anOperation() 
    	{
    		Product product = factoryMethod();
    	}
    	
    	protected abstract Product factoryMethod();
    }
    
    public class ConcreteProduct implements Product { ... }
    
    public class ConcreteCreator extends Creator 
    {
    	protected Product factoryMethod() 
    	{
    		return new ConcreteProduct();
    	}
    }
    
    public class Client 
    {
    	public static void main( String arg[] ) 
    	{
    		Creator creator = new ConcreteCreator();
    		creator.anOperation();
    	}
    }
    
    //---------------------------
	
    interface IIceCream
    {
        string Functionality();
    }
    
    class ChocolateIceCream : IIceCream
    {
        public string Functionality()
        {
            return "Chocolate Ice cream";
        }
    }
    
    class VanillaIceCream : IIceCream
    {
        public string Functionality()
        {
            return "Vanilla Ice cream";
        }
    }
    
    class StrawberryIceCream : IIceCream
    {
        public string Functionality()
        {
            return "Strawberry Ice cream";
        }
    }
    
    static class Factory
    {
       /// <summary>
       /// This is the Factory method
       /// </summary>
       public static IIceCream Get(int id)
       {
           switch (id)
           {
               case 0:
                    return new ChocolateIceCream();
               case 1:
                    return new VanillaIceCream();
               case 2:
                    return new StrawberryIceCream();
               default:
                    return null;
            }
       }
    } 
	
    /// <summary>
    /// This is the Client
    /// </summary>
    static void Main()
    {
       for (int i = 0; i <= 3; i++)
       {
           var type = Factory.Get(i);
           if (type != null)
           {
               Console.WriteLine("This is Product : " + type.Functionality());
           }
       }
    } 
	
#### Source:
* [codeproject](http://www.codeproject.com/Articles/570183/Factory-Method-Pattern)
* [oodesign](http://www.oodesign.com/factory-method-pattern.html)
* [wikipedia](https://en.wikipedia.org/wiki/Factory_method_pattern)