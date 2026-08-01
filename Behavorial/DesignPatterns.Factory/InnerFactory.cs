using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public class Point3
    {
        private double _x;
        private double _y;
        private Point3(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public override string ToString()
        {
            return $"{nameof(_x)} is {_x} and {nameof(_y)} is {_y}";
        }

        public static class Factory
        {
            public static Point3 CreateCartesianPoint(double x, double y)
            {
                return new Point3(x, y);
            }

            public static Point3 CreatePolarPoint(double rho, double theta)
            {
                var x = rho * Math.Cos(theta);
                var y = rho * Math.Sin(theta);
                return new Point3(x, y);
            }
        }
    }


    public class InnerFactory
    {
        public static void Main()
        {
            var cp = Point3.Factory.CreateCartesianPoint(1, 2);
            Console.WriteLine($"{cp}");

            var pp = Point3.Factory.CreatePolarPoint(1, Math.PI / 2);
            Console.WriteLine($"{pp}");
        }
    }
}
