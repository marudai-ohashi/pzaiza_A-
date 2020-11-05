using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Globalization;
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
            int num = int.Parse(str[2]);
            b.Create_masu(height, width);
            b.SetRL(num);

            int flag = 1;
            num = -1;
            while (flag>0)
            {
                flag = 0;
                num++;
                for(int i = 0; i < height; i++)
                {
                    for(int j = 0; j < width; j++)
                    {
                        if (b.GetNum(i, j) == num)
                        {
                            if (b.MarkNum(i, j)) flag++;
                        }
                    }
                }
            }

            b.SetRemark();
            b.Draw();
        }
    }

    class Ban
    {
        public char[,] ban;
        public int[,] banNum;
        public int height;
        public int width;

        public int[] rlist;

        public char GetC(int y,int x)
        {
            return ban[y, x];
        }

        public int GetNum(int y,int x)
        {
            return banNum[y, x];
        }

        public bool MarkNum(int y,int x)
        {
            int num = banNum[y, x];
            num++;
            int flag = 0;

            if (x < width - 1 && banNum[y, x + 1] == -1)
            {
                banNum[y, x + 1] = num;
                flag++;
            }
            if (x > 0 && banNum[y, x - 1] == -1)
            {
                banNum[y, x - 1] = num;
                flag++;
            }
            if (y > 0 && banNum[y - 1, x] == -1)
            {
                banNum[y - 1, x] = num;
                flag++;
            }
            if (y < height - 1 && banNum[y + 1, x] == -1)
            {
                banNum[y + 1, x] = num;
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
            banNum = new int[height, width];
            for (int i = 0; i < height; i++)
            {
                string str = Console.ReadLine();
                for (int j = 0; j < width; j++)
                {
                    ban[i, j] = str[j];
                    if (str[j] == '.') banNum[i, j] = -1;
                    else if (str[j] == '#') banNum[i, j] = -99;
                    else if (str[j] == '*') banNum[i, j] = 0;
                }
            }
        }

        public void SetRL(int num)
        {
            rlist = new int[num];
            for(int i = 0; i < num; i++)
            {
                rlist[i] = int.Parse(Console.ReadLine());
            }
        }

        public void SetRemark()
        {
            int num, flag;
            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    num = banNum[i, j];
                    if (num >= 0)
                    {
                        flag = 0;
                        for (int k = 0; k < rlist.Length; k++)
                        {
                            if (num == rlist[k]) flag++;
                        }
                        if (flag > 0) ban[i, j] = '?';
                        else ban[i, j] = '*';
                    }
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

        public void DrawNum()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(banNum[i, j]+" ");
                }
                Console.WriteLine();
            }

        }
    }
}
