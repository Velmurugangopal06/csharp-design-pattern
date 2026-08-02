using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public class Point2
    {
        private double _x;
        private double _y;
        public Point2(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public override string ToString()
        {
            return $"{nameof(_x)} is {_x} and {nameof(_y)} is {_y}";
        }
    }

    public static class Point2Factory
    {
        public static Point2 CreateCartesianPoint(double x, double y)
        {
            return new Point2(x, y);
        }

        public static Point2 CreatePolarPoint(double rho, double theta)
        {
            var x = rho * Math.Cos(theta);
            var y = rho * Math.Sin(theta);
            return new Point2(x, y);
        }
    }
    public class Factory
    {
        public static void Main()
        {
            var cp = Point2Factory.CreateCartesianPoint(1, 2);
            Console.WriteLine($"{cp}");

            var pp = Point2Factory.CreatePolarPoint(1, Math.PI/2);
            Console.WriteLine($"{pp}");
        }
    }
}
