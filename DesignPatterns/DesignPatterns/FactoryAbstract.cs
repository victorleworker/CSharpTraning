using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryAbDesignPatterns
{
    public interface IHotDrink
    {
        void Consume();
    }
    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("this tea is nice but...");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("this Coffee is nice but...");
        }
    }

    public interface IhotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }
    internal class TeaFactory : IhotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Put in a tea bag, build walter, fo {amount} ml,add, injoy");
            return new Tea();
        }
    }
    internal class CoffeeFactory : IhotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Put in a Coffee bag, build walter, fo {amount} ml,add, injoy");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        public enum AvailableDrink
        {
            Coffee, Tea
        }

        private Dictionary<AvailableDrink, IhotDrinkFactory> factories =
            new Dictionary<AvailableDrink, IhotDrinkFactory>();

        public HotDrinkMachine()
        {
            foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
            {
                var factory = (IhotDrinkFactory)Activator.CreateInstance(
                    Type.GetType("FactoryAbDesignPatterns." +
                    Enum.GetName(typeof(AvailableDrink), drink) +
                    "Factory"));
                factories.Add(drink, factory);
            }
        }

        public IHotDrink MakeDrink(AvailableDrink drink, int amount)
        {
            return factories[drink].Prepare(amount);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 100);
            drink.Consume();

        }
    }
}
