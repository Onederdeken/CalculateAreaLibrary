using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfFigures
{
    public class Triangle : Figure
    {
        #region "parametrs"
        private TypeTriangle typeTriangle;
        //координаты вершин треугольника
        private Vektor verticeA;
        private Vektor verticeB;
        private Vektor verticeC;
        //длины сторон треугольника
        private double SideAB;
        private double SideAC;
        private double SideBC;
        //углы треугольника
        private double AngleA;
        private double AngleB;
        private double AngleC;
        //Существует ли треугольник
        private bool IsExist;
        //Полупериметр
        private double PoluPerimeter;
        #endregion
        #region "gets"
        public TypeTriangle GetTypeTriangle()
        {
            return typeTriangle;
        }
        #endregion
        #region "constructor"
        public Triangle(Vektor A, Vektor B, Vektor C)
        {
            this.verticeA = A; this.verticeB = B; this.verticeC = C;
            CalculateSides();
            CalculateAngles();
            Check();
            
           
        }
        #endregion
        #region "проверка"
        private void Check()
        {
            /*так как треугольник задается по трем координатам он всегда будет выполнять условие a+b>c и единственное,
            что следует проверить не лежат ли три вершины на одной линии*/
            if ((int)(AngleA + AngleB + AngleC) == 180 && AngleB < 180 && AngleC<180 && AngleA < 180)
            {
                IsExist = true;
                if(AngleA == 90 || AngleB == 90 || AngleC==90) typeTriangle = TypeTriangle.rectangular;
                else if(AngleC < 90 && AngleB<90 && AngleA<90) typeTriangle = TypeTriangle.acute;
                else if(AngleC > 90 || AngleB>90 || AngleA>90) typeTriangle = TypeTriangle.obtuse;
                
            }
            else
            {
                typeTriangle = TypeTriangle.none;
                IsExist = false;
            }
        }
        #endregion
        #region "Calculate"
        private void CalculateSides()
        {
            
            SideAB =  Math.Sqrt(Math.Pow(verticeB.x - verticeA.x,2) + Math.Pow(verticeB.y-verticeA.y,2));
            SideAC = Math.Sqrt(Math.Pow(verticeC.x - verticeA.x, 2) + Math.Pow(verticeC.y - verticeA.y, 2));
            SideBC = Math.Sqrt(Math.Pow(verticeB.x - verticeC.x, 2) + Math.Pow(verticeB.y - verticeC.y, 2));
        }
        private void CalculateAngles()
        {
            AngleA = Math.Round(Math.Acos(((Math.Pow(SideAB,2)+Math.Pow(SideAC,2)-Math.Pow(SideBC,2))/(2*SideAC*SideAB)))*(180.0/Math.PI));
            AngleB = Math.Round(Math.Acos(((Math.Pow(SideAB, 2) + Math.Pow(SideBC, 2) - Math.Pow(SideAC, 2)) / (2 * SideBC * SideAB))) * (180.0 / Math.PI));
            AngleC = Math.Round(Math.Acos(((Math.Pow(SideAC, 2) + Math.Pow(SideBC, 2) - Math.Pow(SideAB, 2)) / (2 * SideAC * SideBC))) * (180.0 / Math.PI));
        }
        public override double CalculatePerimeter()
        {
            perimeter = SideAB + SideAC + SideBC;
            PoluPerimeter = perimeter / 2;
            return perimeter; 
        }
        public override double CalculateArea()
        {
            if (IsExist)
            {
                CalculatePerimeter();
                Area = Math.Round(Math.Sqrt(PoluPerimeter * (PoluPerimeter - SideAB) * (PoluPerimeter - SideAC) * (PoluPerimeter - SideBC)),1);
                PrintArea();
                return Area;
            }
            else
            {
                Console.WriteLine("такого треугольника не существует");
                return 0;
            }
        }
        #endregion
        #region "Print"
        public override void PrintArea()
        {
            Console.WriteLine($"Площадь треугольника составляет: {Area}");
        }
        public override async void PrintPerimeter()
        {
            Console.WriteLine($"Периметр треугольника составляет: {perimeter}");

        }
        public void PrintType()
        {
            switch (typeTriangle)
            {
                case TypeTriangle.rectangular: Console.WriteLine("прямоугольный треугольник"); break;
                case TypeTriangle.acute: Console.WriteLine("остроугольный треугольник"); break;
                case TypeTriangle.obtuse: Console.WriteLine("тупоугольный треугольник"); break;

            }
        }
        public void PrintAngels()
        {
            Console.WriteLine($"Угол A = {AngleA}, Угол B = {AngleB}, Угол C = {AngleC}");
        }
        public void PrintSides()
        {
            Console.WriteLine($"AB = {SideAB}, AC = {SideAC}, BC = {SideBC}");
        }
        #endregion




    }
}
