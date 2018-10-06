using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{


    public class Point
    {
        private double x, y;


        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point Origin => new Point(0, 0);
        public static Point Origin2= new Point(0, 0);
        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }


        public static class Factory
        {
            public static Point NewCartesianPoints(double b, double a) => new Point(a, b);
            public static Point NewPolarPoints(double rho, double theta) => new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));

        }
    }

   /* public class demo
    {

        static void Main(string[] args)
        {

            var point = Point.Factory.NewPolarPoints(1.0, Math.PI / 2);
            Console.WriteLine(point);

        }
    }*/
}
