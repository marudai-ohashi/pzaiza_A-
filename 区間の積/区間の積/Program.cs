using System;

namespace 区間の積
{
    class Program
    {
        static void Main(string[] args)
        {
            int num=int.Parse(Console.ReadLine());
            string[] str = Console.ReadLine().Split(' ');
            int sum = 0;

            for(int i = 0; i < num; i++)
            {
                Console.WriteLine(sum += int.Parse(str[i]));
            }
        }
    }
}
