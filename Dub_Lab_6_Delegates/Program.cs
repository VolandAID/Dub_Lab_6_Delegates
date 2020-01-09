using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_Delegates
{
    class Program
    {
        // Задание на лабораторную работу №6
        //Часть 1. Разработать программу, использующую делегаты. (В качестве примера можно использовать проект «Delegates»).
        // 1.     Программа должна быть разработана в виде консольного приложения на языке C#.
        // 2.     Определите делегат, принимающий несколько параметров различных типов и возвращающий значение произвольного типа.
        // 3.     Напишите метод, соответствующий данному делегату.
        // 4.     Напишите метод, принимающий разработанный Вами делегат, в качестве одного из входным параметров. Осуществите вызов метода, передавая в качестве параметра-делегата:
        //·        метод, разработанный в пункте 3;
        //·        лямбда-выражение.
        // 5.     Повторите пункт 4, используя вместо разработанного Вами делегата, обобщенный делегат Func< > или Action< >, соответствующий сигнатуре разработанного Вами делегата.

        delegate String Operation(String name, double number);
        private static void RegisterDelegate(Operation op, String name, double number)
        {
            Console.WriteLine(op(name, number));
        }
        private static void RegisterFunc(Func<String, double, String> func, String name, double number)
        {
            Console.WriteLine(func(name, number));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №6 Delegates");
            Console.Title = "Дубянский А. И., ИУ5Ц-51Б";

            Operation op = SqrtExp;
            Console.WriteLine(op("sqrt", 80.4));
            RegisterDelegate(op, "exp", -17); // делегат как параметр
            RegisterDelegate((name, number) => name.Equals("sqrt") ?
                "Корень из " + number + " = " + Math.Sqrt(number) :
                (name.Equals("exp") ? "e в степени " + number + " = " + Math.Exp(number) : ""), "sqrt", 6.66); //лямбда-выражение как параметр
            Func<String, double, String> func = SqrtExp;
            RegisterFunc(func, "pow", 3.333); // использование Funct<>

            Console.ReadKey();
        }
        private static String SqrtExp(String name, double number)
        {
            if (name.Equals("sqrt"))
            {
                return "Корень из " + number + " = " + Math.Sqrt(number);
            }
            else if (name.Equals("exp"))
            {
                return "e в степени " + number + " = " + Math.Exp(number);
            }
            else
            {
                return "Нет такой операции.";
            }
        }
    }
}