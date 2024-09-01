using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfFigures
{
    public class Area
    {

        public double CalculateArea(Figure figure)
        {
            return figure.CalculateArea();
        }
        public TypeTriangle CheckTypeTriangle(Triangle triangle)
        {
            return triangle.GetTypeTriangle();
        }
    }
}
