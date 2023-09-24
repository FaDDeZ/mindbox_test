using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public abstract class Figure
    {
        protected const float PI = 3.1415F;
        protected float S { get; set; }
        public abstract float Square();
        public float get_Square()
        {
            return S;
        }
    }
}
