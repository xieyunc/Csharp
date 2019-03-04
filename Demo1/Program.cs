using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary;

namespace Demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "";
            long startTime = DateTime.Now.Millisecond;
            for (int i = 0; i < 10000;i++ )
            {
                str += i;
            }
            long endTime = DateTime.Now.Millisecond;
            long time = endTime - startTime;
            Console.WriteLine("stirng消耗的时间：{0}ms",time);

            StringBuilder str2 = new StringBuilder("");
            startTime = DateTime.Now.Millisecond;
            for (int i = 0; i < 10000; i++)
            {
                str2.Append(i);
            }
            endTime = DateTime.Now.Millisecond;
            time = endTime - startTime;
            Console.WriteLine("StringBuilder消耗的时间：{0}ms",time);

            TestClass myClass = new TestClass();

            Console.WriteLine("MyClassLibary.TestClass myClass.a="+myClass.a);

            Console.ReadKey();
        }
    }
}
