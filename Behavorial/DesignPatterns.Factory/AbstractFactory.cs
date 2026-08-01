using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public interface IHotDrink
    {
        public void Consume();
    }

    public class Tea: IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine($"Consuming Tea");
        }
    }

    public class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine($"Consuming Coffee");
        }
    }

    public interface IHotDrinkMachine
    {
        public IHotDrink Prepare(int amount);
    }

    public class TeaMachine: IHotDrinkMachine
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Preparing Tea of {amount} ml");
            return new Tea();
        }
    }

    public class CoffeeMachine: IHotDrinkMachine
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Preparing Coffee of {amount} ml");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        public enum AvailableHotDrink
        {
            Tea,
            Coffee
        }

        private Dictionary<AvailableHotDrink, IHotDrinkMachine> machines = new Dictionary<AvailableHotDrink, IHotDrinkMachine>();

        public HotDrinkMachine()
        {
            foreach(AvailableHotDrink drink in Enum.GetValues(typeof(AvailableHotDrink)))
            {
                switch (drink)
                {
                    case AvailableHotDrink.Tea:
                        machines.Add(AvailableHotDrink.Tea, new TeaMachine());
                        break;
                    case AvailableHotDrink.Coffee:
                        machines.Add(AvailableHotDrink.Coffee, new CoffeeMachine());
                        break;
                    default:
                        break;
                }
            }
        }

        public IHotDrink Serve(AvailableHotDrink drink, int amount)
        {
            return machines[drink].Prepare(amount);
        }
    }
    public class AbstractFactory
    {
        public static void Main()
        {
            var hdm = new HotDrinkMachine();
            var coffee = hdm.Serve(HotDrinkMachine.AvailableHotDrink.Coffee, 100);
            var tea = hdm.Serve(HotDrinkMachine.AvailableHotDrink.Tea, 200);
            coffee.Consume();
            tea.Consume();
            
        }
    }
}
