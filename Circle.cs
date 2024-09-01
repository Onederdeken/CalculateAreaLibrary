using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfFigures
{
    public class Circle : Figure
    {
        #region"parametrs"
        private double diametr;
        private double radius;
        private Vektor center;
        private double Pi = Math.PI;
        #endregion
        #region "constructs"
        public Circle(double radius, Vektor center)
        {
            this.diametr = radius*2;
            this.radius = radius;
            this.center = center;
        }
        #endregion
        #region "Calculates"
        public override double CalculateArea()
        {
            Area = Math.Round(Pi * radius * radius,1);
            PrintArea();
            return Area;
        }
        
        //у окружности за периметр будем считать длину окружности
        public override double CalculatePerimeter()
        {
            perimeter = Pi * diametr;
            return perimeter;

        }
        #endregion
        #region "Prints"

        public override void PrintArea()
        {
            Console.WriteLine($"Площадь окружности составляет: {Area}");
        }
        public override void PrintPerimeter()
        {
            Console.WriteLine($"Длина окружности составляет: {perimeter}");
        }


        #endregion
    }
}
