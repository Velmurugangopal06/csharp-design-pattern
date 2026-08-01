using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Solid
{
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle() { }
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }

    public class Square: Rectangle
    {
        public override int Width { set { base.Width = base.Height = value; } }
        public override int Height { set { base.Height = base.Width = value; } }
    }

    public class LiskovSubstitution
    {
        private static double Area(Rectangle r) => r.Width * r.Height;
        public static void Main()
        {
            Rectangle r = new Rectangle(10, 12);
            var rArea = Area(r);
            Console.WriteLine($"Area of Rectangle - {rArea}");

            Rectangle s = new Square();
            s.Width = 10;
            var sArea = Area(s);
            Console.WriteLine($"Area of Square - {sArea}");
        }
    }
}
