using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个整数：");
            //int iNum = Convert.ToInt32(Console.ReadLine());
            //if (iNum%2==0)
            //{
            //    Console.WriteLine("{0}是一个偶数！",iNum);
            //}
            //else
            //{
            //    Console.WriteLine("{0}是一个奇数！",iNum);
            //}
            //string str = iNum % 2 == 0 ? "是一个偶数！" : "不是一个偶数！";
            int[,] a = {{1,2,3},{4,5,6}};
            int[,] b;
            int[] c = {1,2,3,4,5};
            b = a;
            Console.WriteLine(a.Rank);//获取二维数组的行数
            for (int i = 0; i<a.GetLength(0); i++)
            {
                for(int j=0; j<a.GetLength(1); j++)
                {
                    Console.Write(a[i,j]+" ");
                }
                Console.WriteLine();
            }
            int[,] Arr = new int[,] { { 1, 2, 3, 5, 6 }, { 1, 2, 3, 4, 5 } };
            int row = Arr.GetLength(0);  //第一维的长度（即行数）
            int col = Arr.GetLength(1); //第二维的长度（即列数）
            Console.WriteLine("行数，列数分别为："+row+","+col);
            ArrayList List = new ArrayList(c);
            List.Add(70);
            List.Insert(2, 33);
            foreach (int i in List)
                Console.Write(i+" ");
            Console.WriteLine();
            List.RemoveRange(3,2);
            foreach (int i in List)
                Console.Write(i + " ");

            Console.ReadKey();
        }
    }
}
