using System;
using System.Collections.Generic;

namespace いびつなリバーシ対戦
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');
            int height = int.Parse(str[0]);
            int width = int.Parse(str[1]);
            int num = int.Parse(str[2]);
            int x, y;

            Ban ban = new Ban();
            ban.Create_masu(height, width);
            for (int i = 0; i < num; i++)
            {
                str = Console.ReadLine().Split(' ');
                y = int.Parse(str[0]);
                x = int.Parse(str[1]);
                ban.Mrak_Cross(y, x, 'A');
                ban.Mark_Diagonal(y, x, 'A');
                str = Console.ReadLine().Split(' ');
                y = int.Parse(str[0]);
                x = int.Parse(str[1]);
                ban.Mrak_Cross(y, x, 'B');
                ban.Mark_Diagonal(y, x, 'B');
            }
            ban.Draw_masu();
        }
    }
    class Ban
    {
        public char[,] ban;
        public int height;
        public int width;

        public void Create_masu(int y, int x)
        {
            string str;
            
            height = y;
            width = x;
            ban = new char[height, width];
            for (int i = 0; i < height; i++)
            {
                str = Console.ReadLine();
                for (int j = 0; j < width; j++)
                {
                    ban[i, j] = str[j];
                }
            }
        }

        public void Draw_masu()
        {
            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    Console.Write(ban[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void Mrak_Cross(int y, int x, char ch)
        {
            ban[y, x] = ch;

            for (int i = y + 1; i < height; i++)
            {
                if (ban[i, x] == ch)
                {
                    for (int j = y + 1; j <= i; j++) ban[j, x] = ch;
                    break;
                }
                else if (ban[i, x] == '#') break;
            }
            for (int i = y - 1; i >= 0; i--)
            {
                if (ban[i, x] == ch)
                {
                    for (int j = y - 1; j >= i; j--) ban[j, x] = ch;
                    break;
                }
                else if (ban[i, x] == '#') break;
            }
            for (int i = x + 1; i < width; i++)
            {
                if (ban[y, i] == ch)
                {
                    for (int j = x + 1; j <= i; j++) ban[y, j] = ch;
                    break;
                }
                else if (ban[y, i] == '#') break;
            }
            for (int i = x - 1; i >= 0; i--)
            {
                if (ban[y, i] == ch)
                {
                    for (int j = x - 1; j >= i; j--) ban[y, j] = ch;
                    break;
                }
                else if (ban[y, i] == '#') break;
            }
        }

        public void Mark_Diagonal(int y,int x,char ch)
        {
            for (int i = 1; i < height - y; i++)
            {
                if (x - i >= 0)
                {
                    if (ban[y + i, x - i] == ch)
                    {
                        for (int j = 1; j <= i; j++) ban[y + j, x - j] = ch;
                        break;
                    }
                    else if (ban[y + i, x - i] == '#') break;
                }
            }
            for (int i = 1; i < height - y; i++)
            {
                if (x + i < width)
                {
                    if (ban[y + i, x + i] == ch)
                    {
                        for (int j = 1; j <= i; j++) ban[y + j, x + j] = ch;
                        break;
                    }
                    else if (ban[y + i, x + i] == '#') break;
                }
            }
            for (int i = 1; i <= y; i++)
            {
                if (x - i >= 0)
                {
                    if (ban[y - i, x - i] == ch)
                    {
                        for (int j = 1; j <= i; j++) ban[y - j, x - j] = ch;
                        break;
                    }
                    else if (ban[y - i, x - i] == '#') break;
                }
            }
            for (int i = 1; i <= y; i++)
            {
                if (x + i < width)
                {
                    if( ban[y - i, x + i] == ch)
                    {
                        for (int j = 1; j <= i; j++) ban[y - j, x + j] = ch;
                        break;
                    }
                    else if (ban[y - i, x + i] == '#') break;
                }
            }
        }
    }
}