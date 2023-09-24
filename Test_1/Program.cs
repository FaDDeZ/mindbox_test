using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApp3
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input name of figure (triangle or circle): ");
            string name = Console.ReadLine();
            float a, b, c;
            switch (name.ToLower())
            {
                case "triangle":
                    try
                    {
                        line();
                        a = Convert.ToSingle(Console.ReadLine());
                        line();
                        b = Convert.ToSingle(Console.ReadLine());
                        line();
                        c = Convert.ToSingle(Console.ReadLine());
                        Triangle tr = new Triangle(a, b, c);
                        Console.WriteLine(tr.get_Square());
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine(Ex.Message);
                    }
                    break;
                case "circle":
                    try
                    {
                        line();
                        a = Convert.ToSingle(Console.ReadLine());
                        Circle cr = new Circle(a);
                        Console.WriteLine(cr.get_Square()); 
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine(Ex.Message);
                    }
                    break;
                default: 
                    Console.WriteLine("Inccorect figure");
                    break;
            }
            void line()
            {
                Console.Write("Input parameter: ");
            }
        }
    }
}
