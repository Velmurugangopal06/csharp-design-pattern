using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public class Point
    {
        private double _x;
        private double _y;

        private Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public static Point CreateCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point CreatePolarPoint(double rho, double theta)
        {
            var x = rho * Math.Cos(theta);
            var y = rho * Math.Sin(theta);
            return new Point(x, y);
        }

        public override string ToString()
        {
            return $"{nameof(_x)} is {_x} and {nameof(_y)} is {_y}";
        }
    }
    public class FactoryMethod
    {
        public static void Main()
        {
            var cp = Point.CreateCartesianPoint(1, 2);
            Console.WriteLine($"{cp}");

            var pp = Point.CreatePolarPoint(1, Math.PI / 2);
            Console.WriteLine($"{pp}");
        }
    }
}
