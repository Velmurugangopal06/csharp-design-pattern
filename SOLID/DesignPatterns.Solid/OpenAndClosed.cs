using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Solid
{
    public enum Color
    {
        Red, Blue, Yellow
    }

    public enum Size
    {
        Small, Medium, Large
    }

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class ColorSpecification: ISpecification<Fruit>
    {
        private Color _color;
        public ColorSpecification(Color color) => _color = color;
        public bool IsSatisfied(Fruit fruit)
        {
            return fruit.Color == _color;
        }
    }

    public class FruitFilter(): IFilter<Fruit>
    {
        public IEnumerable<Fruit> Filter(IEnumerable<Fruit> items, ISpecification<Fruit> spec)
        {
            foreach(Fruit item in items)
            {
                if(spec.IsSatisfied(item))
                    yield return item;
            }
        }
    }

    public class Fruit
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }

        public Fruit(string name, Color color, Size size)
        {
            Name = name;
            Color = color;
            Size = size;
        }
    }

    public class OpenAndClosed
    {
        public static void Main()
        {
            var blueberry = new Fruit("Blueberry", Color.Blue, Size.Small);
            var lemon = new Fruit("Lemon", Color.Yellow, Size.Medium);
            var apple = new Fruit("Apple", Color.Red, Size.Large);

            var fruits = new Fruit[] { blueberry, lemon, apple };

            Console.WriteLine("Filtering Red Fruits - ");
            var ff = new FruitFilter();
            var redFruits = ff.Filter(fruits, new ColorSpecification(Color.Red));
            foreach(var fruit in redFruits)
            {
                Console.WriteLine(fruit.Name);
            }
        }
    }
}
