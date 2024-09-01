using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfFigures
{
    public abstract class Figure : ICalculateAreaOrPerimeter, IPrintAreaOrPerimeter
    {
        protected double Area;
        protected double perimeter;
        abstract public double CalculateArea();
        abstract public double CalculatePerimeter();
        abstract public void PrintArea();
        abstract public void PrintPerimeter();
    }
}
