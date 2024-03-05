using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int testsCounter = 1;
            TestClass3 a = new TestClass3("A");
            TestClass3 b = new TestClass3("B");
            TestClass c = new TestClass("C");
            TestClass2 d = new TestClass2("E");
            TestClass4 f = new TestClass4();
            bool e = false;

            List<object> correctTestList = new List<object> {a, b, d, e};
            List<object> testList1 = new List<object> { a }; //разная длина
            List<object> testList2 = new List<object> { a, b, c, d}; //нечитаемое поле
            List<object> testList3 = new List<object> { a, new TestClass3("R"), d, e }; // разные значения 
            List<object> testList4 = new List<object> { a, 2, e, e }; //разные типы
            List<object> testList5 = new List<object> { a, b, d, f }; //нечитаемый тип
            List<object> testList6 = new List<object> { a, b, d, e }; //совпадают

            CheckClass checkClass = new CheckClass(correctTestList);

            foreach (List<object> test in new List<List<object>>{testList1, testList2, testList3, testList4, testList5, testList6 })
            {
                Console.WriteLine($"Тест {testsCounter++}");
                Console.WriteLine($"{checkClass.Compare(test)}\n");
            }

            foreach (PropertyInfo p in typeof(string).GetProperties())
            {
                Console.WriteLine(p.Name);
            }
        }
    }
}
