using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Singleton
{
    public interface IInventory
    {
        public int GetRemainingCount(string name);
    }

    public class ShopInventory: IInventory
    {
        private Dictionary<string, int> _items = new Dictionary<string, int>();

        private ShopInventory()
        {
            PopulateInventory();
        }

        private void PopulateInventory()
        {
            var itemsToAdd = new Dictionary<string, int>
            {
                { "coffee", 14 },
                { "tea", 12 },
                { "milk", 8 }
            };

            foreach (var item in itemsToAdd)
            {
                if (!_items.ContainsKey(item.Key))
                    _items.Add(item.Key, item.Value);
            }
        }

        public int GetRemainingCount(string itemName)
        {
            int count = 0;
            _items.TryGetValue(itemName.ToLower(), out count);
            return count; 
        }

        private static Lazy<ShopInventory> _instance = new Lazy<ShopInventory>(() => new ShopInventory());
        public static ShopInventory Instance => _instance.Value;
    }
    public class Singleton
    {
        public static void Main()
        {
            Console.WriteLine("Singleton Instance is about to create");
            var si = ShopInventory.Instance;
            var cc = si.GetRemainingCount("coffee");
            var tc = si.GetRemainingCount("Tea");
            var wc = si.GetRemainingCount("Water");

            Console.WriteLine($"Remaining Count of Coffee is {cc}");
            Console.WriteLine($"Remaining Count of Tea is {tc}");
            Console.WriteLine($"Remaining Count of Water is {wc}");
        }
    }
}
