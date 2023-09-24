using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Triangle : Figure
    {
        private float a { get; set; }
        private float b { get; set; }
        private float c { get; set; }
        public Triangle(float a, float b, float c)
        {
            if (a < 0 || b < 0 || c < 0)
            {
                throw new ArgumentOutOfRangeException("Arguments lower then zero");
            }
            if (!(a + b > c && a + c > b && b + c > a))
            {
                throw new ArgumentException("Triangle is not exist");
            }
            this.a = a;
            this.b = b;
            this.c = c;
            S = Square();
        }
        public bool get_rectangle()
        {
            bool right = (a * a + b * b == c * c || a * a + c * c == b * b || b * b + c * c == a * a);
            return right;
        }
        public override float Square()
        {
            float p = (a + b + c) / 2;
            return Math.Abs(p * (p - a) * (p - b) * (p - c));
        }
    }
}
