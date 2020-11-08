using System;
using System.Collections.Generic;

namespace 陣取りゲーム
{
    class Program
    {
        static void Main(string[] args)
        {
            Ban b = new Ban();
            string[] str = Console.ReadLine().Split(' ');
            int height = int.Parse(str[0]);
            int width = int.Parse(str[1]);
            b.Create_masu(height, width);
            string start = Console.ReadLine();
            b.Set_masu();

            int ck = 1;
            while (ck > 0)
            {
                ck = 0;
                if (start == "A")
                {
                    ck = b.Mark_Set("A");
                    ck += b.Mark_Set("B");
                }
                else
                {
                    ck = b.Mark_Set("B");
                    ck += b.Mark_Set("A");

                }
            }
            int anum = b.GetA();
            int bnum = b.GetB();
            Console.WriteLine(anum + " " + bnum);
            if (anum > bnum) Console.WriteLine("A");
            else Console.WriteLine("B");
        }
    }

    class Ban
    {
        public char[,] ban;
        public int height;
        public int width;

        public List<int> a_set_x = new List<int>();
        public List<int> a_set_y = new List<int>();
        public List<int> b_set_x = new List<int>();
        public List<int> b_set_y = new List<int>();

        public int GetA()
        {
            int num = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (ban[i, j] == 'A') num++;
                }
            }
            return num;
        }

        public int GetB()
        {
            int num = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (ban[i, j] == 'B') num++;
                }
            }
            return num;
        }


        public int Mark_Set(string mark)
        {
            List<int> lst_x = new List<int>();
            List<int> lst_y = new List<int>();
            List<int> temp_x = new List<int>();
            List<int> temp_y = new List<int>();
            int ck = 0;

            if (mark == "A")
            {
                foreach (var i in a_set_x) temp_x.Add(i);
                foreach (var i in a_set_y) temp_y.Add(i);
                a_set_x.Clear();
                a_set_y.Clear();
            }
            else
            {
                foreach (var i in b_set_x) temp_x.Add(i);
                foreach (var i in b_set_y) temp_y.Add(i);
                b_set_x.Clear();
                b_set_y.Clear();
            }

            for (int i = 0; i < temp_x.Count; i++)
            {
                int x = temp_x[i];
                int y = temp_y[i];

                if (x < width - 1 && ban[y, x + 1] == '.')
                {
                    ban[y, x + 1] = mark[0];
                    lst_x.Add(x + 1);
                    lst_y.Add(y);
                    ck++;
                }
                if (x > 0 && ban[y, x - 1] == '.')
                {
                    ban[y, x - 1] = mark[0];
                    lst_x.Add(x - 1);
                    lst_y.Add(y);
                    ck++;
                }
                if (y > 0 && ban[y - 1, x] == '.')
                {
                    ban[y - 1, x] = mark[0];
                    lst_x.Add(x);
                    lst_y.Add(y - 1);
                    ck++;
                }
                if (y < height - 1 && ban[y + 1, x] == '.')
                {
                    ban[y + 1, x] = mark[0];
                    lst_x.Add(x);
                    lst_y.Add(y + 1);
                    ck++;
                }
            }

            if (mark == "A")
            {
                foreach (var i in lst_x) a_set_x.Add(i);
                foreach (var i in lst_y) a_set_y.Add(i);
            }
            else
            {
                foreach (var i in lst_x) b_set_x.Add(i);
                foreach (var i in lst_y) b_set_y.Add(i);
            }
            return ck;
        }

        public void Create_masu(int y, int x)
        {
            height = y;
            width = x;
            ban = new char[height, width];
        }

        public void Set_masu()
        {
            for (int i = 0; i < height; i++)
            {
                string str = Console.ReadLine();
                for (int j = 0; j < width; j++)
                {
                    if (str[j] == 'B')
                    {
                        b_set_x.Add(j);
                        b_set_y.Add(i);
                    }
                    else if (str[j] == 'A')
                    {
                        a_set_x.Add(j);
                        a_set_y.Add(i);
                    }
                    ban[i, j] = str[j];
                }
            }
        }
    }
}