namespace FactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Developer dev = new PanelDeveloper("ООО КирпичСтрой");
            House house2 = dev.Create();

            dev = new WoodDeveloper("Частный застройщик");
            House house = dev.Create();

        }
    }
    // абстрактный класс строительной компании
    abstract class Developer
    {
        public string Name { get; set; }

        public Developer(string n)
        {
            Name = n;
        }
        // фабричный метод
        abstract public House Create();
    }
    // строит панельные дома
    class PanelDeveloper : Developer
    {
        public PanelDeveloper(string n) : base(n)
        { }

        public override House Create()
        {
            return new PanelHouse();
        }
    }
    // строит деревянные дома
    class WoodDeveloper : Developer
    {
        public WoodDeveloper(string n) : base(n)
        { }

        public override House Create()
        {
            return new WoodHouse();
        }
    }

    abstract class House
    { }

    class PanelHouse : House
    {
        public PanelHouse()
        {
            Console.WriteLine("Панельный дом построен");
        }
    }
    class WoodHouse : House
    {
        public WoodHouse()
        {
            Console.WriteLine("Деревянный дом построен");
        }
    }
    #region Concept
    //Абстрактный класс Product определяет интерфейс класса, объекты которого надо создавать.
    abstract class Product
    { }
    //Конкретные классы ConcreteProductA и ConcreteProductB представляют реализацию класса Product. Таких классов может быть множество.
    class ConcreteProductA : Product
    { }

    class ConcreteProductB : Product
    { }
    //Абстрактный класс Creator определяет абстрактный фабричный метод FactoryMethod(), который возвращает объект Product.
    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }
    //Конкретные классы ConcreteCreatorA и ConcreteCreatorB - наследники класса Creator, определяющие свою реализацию метода FactoryMethod().
    //Причем метод FactoryMethod() каждого отдельного класса-создателя возвращает определенный конкретный тип продукта.
    //Для каждого конкретного класса продукта определяется свой конкретный класс создателя.
    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod() { return new ConcreteProductA(); }
    }

    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod() { return new ConcreteProductB(); }
    }
    #endregion
}