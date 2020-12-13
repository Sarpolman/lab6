using System;
using System.Collections.Generic;

namespace lab6
{
    class Delegates
    {
        public delegate string square_count(double first, double second, string name);

        static public string tri_square(double length, double height, string name)
        {
            double result = 0.5*length*height;
            return ($"Треугольник {name} со параметрами {length} и {height}. Площадь равна:{result}");
        }

        static public string paral_square(double length,double height, string name)
        {
            double result =length*height;
            return ($"Параллелограмм {name} со параметрами {length} и {height}. Площадь равна:{result}");
        }
        static public string circle_square(double radius,double pi,string name)
        {
            pi=Math.PI;
            double result=pi*radius*radius;
            return ($"Круг {name} с радиусом {radius}. Площадь равна:{result}");
        }

        static public string square (double length, double height, string name, square_count result)
        {
            return result(length,height,name);
        }

        static public string squareFunc (double length, double height, string name, Func <double,double,string,string> result)
        {
            return result(length,height, name);
        }
    }
}