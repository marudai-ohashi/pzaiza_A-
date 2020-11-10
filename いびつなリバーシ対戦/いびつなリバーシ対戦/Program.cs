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
//            int y = int.Parse(str[2]);
//            int x = int.Parse(str[3]);

            Ban ban = new Ban();
            ban.Create_masu(height, width);

            ban.Mrak_Cross();
            ban.Mark_Diagonal();
            ban.Draw_masu();
        }
    }
    class Ban
    {
        public char[,] ban;
        public int height;
        public int width;
        public int px;
        public int py;

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
                    if (ban[i, j] == '!')
                    {
                        px = j;
                        py = i;
                        ban[i, j] = '*';
                    }
                }
            }
        }

        public void Create_No_masu(int y, int x)
        {
            height = y;
            width = x;
            ban = new char[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    ban[i, j] = '.';
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

        public void Mrak_Cross()
        {
            int x = px;
            int y = py;

            for (int i = y + 1; i < height; i++)
            {
                if (ban[i, x] == '*')
                {
                    for (int j = y + 1; j <= i; j++) ban[j, x] = '*';
                    break;
                }
                else if (ban[i, x] == '#') break;
            }
            for (int i = y - 1; i >= 0; i--)
            {
                if (ban[i, x] == '*')
                {
                    for (int j = y - 1; j >= i; j--) ban[j, x] = '*';
                    break;
                }
                else if (ban[i, x] == '#') break;
            }
            for (int i = x + 1; i < width; i++)
            {
                if (ban[y, i] == '*')
                {
                    for (int j = x + 1; j <= i; j++) ban[y, j] = '*';
                    break;
                }
                else if (ban[y, i] == '#') break;
            }
            for (int i = x - 1; i >= 0; i--)
            {
                if (ban[y, i] == '*')
                {
                    for (int j = x - 1; j >= i; j--) ban[y, j] = '*';
                    break;
                }
                else if (ban[y, i] == '#') break;
            }
        }

        public void Mark_Diagonal()
        {
            //            ban[y, x] = '*';
            int x = px;
            int y = py;
            for (int i = 1; i < height - y; i++)
            {
                if (x - i >= 0)
                {
                    if (ban[y + i, x - i] == '*')
                    {
                        for (int j = 1; j <= i; j++) ban[y + j, x - j] = '*';
                        break;
                    }
                    else if (ban[y + i, x - i] == '#') break;
                }
            }
            for (int i = 1; i < height - y; i++)
            {
                if (x + i < width)
                {
                    if (ban[y + i, x + i] == '*')
                    {
                        for (int j = 1; j <= i; j++) ban[y + j, x + j] = '*';
                        break;
                    }
                    else if (ban[y + i, x + i] == '#') break;
                }
            }
            for (int i = 1; i <= y; i++)
            {
                if (x - i >= 0)
                {
                    if (ban[y - i, x - i] == '*')
                    {
                        for (int j = 1; j <= i; j++) ban[y - j, x - j] = '*';
                        break;
                    }
                    else if (ban[y - i, x - i] == '#') break;
                }
            }
            for (int i = 1; i <= y; i++)
            {
                if (x + i < width)
                {
                    if( ban[y - i, x + i] == '*')
                    {
                        for (int j = 1; j <= i; j++) ban[y - j, x + j] = '*';
                        break;
                    }
                    else if (ban[y - i, x + i] == '#') break;
                }
            }
        }
    }
}