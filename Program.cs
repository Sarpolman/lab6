using System;
using System.Reflection;

namespace lab6
{
    
    class Program
    {
        public static bool GetPropertyAttribute(PropertyInfo checkType, Type attributeType, out object attribute)
        {
            bool Result = false;
            attribute = null;
            var isAttribute =
            checkType.GetCustomAttributes(attributeType, false);
            if (isAttribute.Length > 0)
            {
                Result = true;
                attribute = isAttribute[0];
            }
            return Result;
        }
        static void Main(string[] args)
        {
            double a=10;
            double b=5;
            string name ="ARTYOM";

            System.Console.WriteLine(Delegates.square(a,b,"OR",Delegates.circle_square));

            Delegates.square_count lbd_square_count = (x,y,z) =>
            {
                double result = (x*y)*2/5;
                return $"Фигура {z} со параметрами {x} и {y}. Площадь равна:{result}. Лямбда-выражение";
            };
            System.Console.WriteLine(lbd_square_count(20,15.3,"FRETY"));
            
            System.Console.WriteLine(Delegates.square(a,b,name,(x,y,z) => 
            {
                double result = (x*y)*2/5;
                return $"Фигура {z} со параметрами {x} и {y}. Площадь равна:{result}. Лямбда-выражение в качестве аргумента";
            }));

            System.Console.WriteLine(Delegates.squareFunc(a,b,"ABC",Delegates.tri_square));

            //-----------------------------------------------------------------------------------------
            Person obj =new Person("Artyom",18);
            Type t =obj.GetType();

            Console.WriteLine("\nКонструкторы:");
            foreach (var x in t.GetConstructors())
                {
                Console.WriteLine(x);
                }

            Console.WriteLine("\nМетоды:");
            foreach (var x in t.GetMethods())
                {
                Console.WriteLine(x);
                }
                
            Console.WriteLine("\nСвойства:");
            foreach (var x in t.GetProperties())
                {
                Console.WriteLine(x);
                }
            Console.WriteLine("\nСвойства, помеченные атрибутом:");
            foreach (var x in t.GetProperties())
            {
                object attrObj;
                if (GetPropertyAttribute(x, typeof(PropertyAttribute), out attrObj))
                {
                    PropertyAttribute attr = attrObj as PropertyAttribute;
                    Console.WriteLine(x.Name + " - " + attr.Description);
                }
            }
            Console.WriteLine("\nВызов метода:");
            Person fi = new Person("Artyom",19);
            object[] parametrs = new object[] {};
            object Result = t.InvokeMember("ToDollars", BindingFlags.InvokeMethod, null, fi, parametrs);
            System.Console.WriteLine("ToDollars={0}$", Result);
        }
    }
}
