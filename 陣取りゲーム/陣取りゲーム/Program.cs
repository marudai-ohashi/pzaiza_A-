using System;
using System.Globalization;

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

            int flag = 1;
            int num = -1;
            b.SetZero();
            while (flag>0)
            {
                flag = 0;
                num++;
                for(int i = 0; i < height; i++)
                {
                    for(int j = 0; j < width; j++)
                    {
                        if (b.GetC(i, j) == num.ToString()[0])
                        {
                            if (b.MarkNum(i, j)) flag++;
                        }
                    }
                }
            }
            b.Draw();
        }
    }

    class Ban
    {
        public char[,] ban;
        public int height;
        public int width;

        public char GetC(int y,int x)
        {
            return ban[y, x];
        }

        public void SetZero()
        {
            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    if (ban[i, j] == '*') ban[i, j] = '0';
                }
            }
        }


        public bool MarkNum(int y,int x)
        {
            int num = int.Parse(ban[y, x].ToString());
            num++;
            int flag = 0;

            if (x < width - 1 && ban[y, x + 1] == '.')
            {
                ban[y, x + 1] = num.ToString()[0];
                flag++;
            }
            if (x > 0 && ban[y, x - 1] == '.')
            {
                ban[y, x - 1] = num.ToString()[0];
                flag++;
            }
            if (y > 0 && ban[y - 1, x] == '.')
            {
                ban[y - 1, x] = num.ToString()[0];
                flag++;
            }
            if (y < height - 1 && ban[y + 1, x] == '.')
            {
                ban[y + 1, x] = num.ToString()[0];
                flag++;
            }
            if (flag > 0) return true;
            else return false;
        }

        public bool Mark(int y,int x)
        {
            int flag = 0;

            if (x < width - 1 && ban[y, x + 1] == '.')
            {
                ban[y, x + 1] = '*';
                flag ++;
            }
            if (x > 0 && ban[y, x - 1] == '.')
            {
                ban[y, x - 1] = '*';
                flag++;
            }
            if (y > 0 && ban[y - 1, x] == '.')
            {
                ban[y - 1, x] = '*';
                flag++;
            }
            if (y < height - 1 && ban[y + 1, x] == '.')
            {
                ban[y + 1, x] = '*';
                flag++;
            }
            if (flag > 0) return true;
            else return false;
        }

        public void Create_masu(int y, int x)
        {
            height = y;
            width = x;
            ban = new char[height, width];
            for (int i = 0; i < height; i++)
            {
                string str = Console.ReadLine();
                for (int j = 0; j < width; j++)
                {
                    ban[i, j] = str[j];
                }
            }
        }

        public void Draw()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(ban[i, j]);
                }
                Console.WriteLine();
            }

        }
    }
}
