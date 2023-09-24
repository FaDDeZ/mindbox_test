using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Circle : Figure
    {
        private float R;
        public Circle(float R)
        {
            if (R < 0)
            {
                throw new ArgumentOutOfRangeException("Arguments lower then zero");
            }
            this.R = R;
            S = Square();
        }
        public override float Square()
        {
            return R * R * PI;
        }
    }
}
