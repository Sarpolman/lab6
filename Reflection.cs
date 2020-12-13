using System;
using System.Reflection;

namespace lab6
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple=false, Inherited= false)]
    public class NewAttribute :Attribute
    {
        public NewAttribute() {}
        public NewAttribute(string param)
        {
            Description=param;
        }

        public string Description {get; set;}
    }

[   AttributeUsage(AttributeTargets.Property,AllowMultiple=false, Inherited= false)]
    public class PropertyAttribute:Attribute
    {
        public PropertyAttribute() {}
        public PropertyAttribute(string param)
        {
            Description=param;
        }

        public string Description {get; set;}
    }
    class Person
    {
        delegate void MoneyOperations(double number);
        private int age;

        [PropertyAttribute("Возраст сотрудника")]
        public int Age {
            get{
                return age;
            }
            set{
                age=value;
            }
        }

        private string name;
        public string Name {
            get{
                return name;
            }
            set{
                name=value;
            }
        }

        private double salary;

        [PropertyAttribute("Зарплата сотрудникам")]
        public double Salary {
            get{
                return salary;
            }
            set{
                salary=value;
            }
        }
        

         public Person(string name, int age){
            Age=age;
            Name=name;
            Salary =50000;
        }

         public Person(string name, int age, double salary){
            Age=age;
            Name=name;
            Salary=salary;
        }

        [NewAttribute("Увеличить зарплату в процентах сотруднику")]
        public void MoreMoneyPR(double percent){
            Salary = Salary/100*(100+percent);
        }

        public void LessMoneyPR(double percent){
            Salary = Salary/100*(100-percent);
        }
        [NewAttribute("Увеличить зарплату сотруднику на определённую сумму")]
        public void MoreMoney(double number){
            Salary = Salary+number;
        }

        public void LessMoney(double number){
            Salary = Salary+number;
        }

        public double ToDollars(){
            return Math.Round(Salary/77.18,2);
        }


    }
}