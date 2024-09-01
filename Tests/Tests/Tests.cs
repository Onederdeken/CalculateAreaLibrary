using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AreaOfFigures;
using System.Runtime.InteropServices;
namespace Tests
{
    public class Test
    {
        Area area;

        Vektor Center;
        Vektor AxisY5;
        Vektor AxisY7;
        Vektor AxisY10;

        Circle Circle;
        Triangle triangle;
        Triangle triangle1;
        Triangle triangle2;
        Triangle triangle3;
        Triangle triangle4;
        private void Arrange()
        {
            area = new Area();
            Center = new Vektor(0,0);
            AxisY5 = new Vektor(0,5);
            AxisY7 = new Vektor(0,7);
            AxisY10 = new Vektor(0,10);
            Circle = new Circle(5, Center);
            //треугольник с вершинами в одной точке
            triangle = new Triangle(Center, Center, Center);
            //треугольник с вершинами на одной прямой
            triangle1 = new Triangle(Center,AxisY5,AxisY7);
            //тупоугольный треугольник
            triangle2 = new Triangle(Center,AxisY5, new Vektor(5,10));
            //Прямоугольный треугольник
            triangle3 = new Triangle(Center,AxisY7, new Vektor(10,7));
            //Острый треугольник
            triangle4 = new Triangle(Center,AxisY10, new Vektor(5,3));
            
        }
        [Fact]
        public void TestCalculateOfArea()
        {
            Arrange();
            //act
            var result  = area.CalculateArea(Circle);
            var result1 = area.CalculateArea(triangle);
            var result2 = area.CalculateArea(triangle1);
            var result3 = area.CalculateArea(triangle2);
            var result4 = area.CalculateArea(triangle3);
            var result5 = area.CalculateArea(triangle4);

            //Assert
            Assert.Equal(78.5, result);
            Assert.Equal(0, result1);
            Assert.Equal(0, result2);
            Assert.Equal(12.5, result3);
            Assert.Equal(35,result4);
            Assert.Equal(25.0, result5);

        }
        [Fact]
        public void TestCheckTypeOfTriangle()
        {
            Arrange();
            //act
            var result1 = area.CheckTypeTriangle(triangle2);
            var result2 = area.CheckTypeTriangle(triangle3);
            var result3 = area.CheckTypeTriangle(triangle4);

            //Assert
            Assert.Equal(TypeTriangle.obtuse, result1);
            Assert.Equal(TypeTriangle.rectangular, result2);
            Assert.Equal(TypeTriangle.acute, result3);


        }
        
    }
}
