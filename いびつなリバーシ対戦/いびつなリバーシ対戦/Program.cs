﻿using Microsoft.VisualBasic.CompilerServices;
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
            int y = int.Parse(str[2]);
            int x = int.Parse(str[3]);

            Ban ban = new Ban();
            ban.Create_No_masu(height, width);

            ban.Mark_Diagonal(y, x);
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

        public void Mrak_Cross(int y, int x)
        {
            ban[y, x] = '*';

            for (int i = y + 1; i < height; i++)
            {
                if (ban[i, x] == '*')
                {
                    for (int j = y + 1; j <= i; j++) ban[j, x] = '*';
                    break;
                }
            }
            for (int i = y - 1; i >= 0; i--)
            {
                if (ban[i, x] == '*')
                {
                    for (int j = y - 1; j >= i; j--) ban[j, x] = '*';
                    break;
                }
            }
            for (int i = x + 1; i < width; i++)
            {
                if (ban[y, i] == '*')
                {
                    for (int j = x + 1; j <= i; j++) ban[y, j] = '*';
                    break;
                }
            }
            for (int i = x - 1; i >= 0; i--)
            {
                if (ban[y, i] == '*')
                {
                    for (int j = x - 1; j >= i; j--) ban[y, j] = '*';
                    break;
                }
            }
        }

        public void Mark_Diagonal(int y, int x)
        {
            ban[y, x] = '!';
            for (int i = 1; i < height-y; i++)
            {
                if (x - i >= 0) ban[y + i, x - i] = '*';
                if (x + i < width) ban[y + i, x + i] = '*';
            }
            for (int i = 1; i <= y; i++)
            {
                if (x - i >= 0) ban[y - i, x - i] = '*';
                if (x + i < width) ban[y - i, x + i] = '*';
            }
        }
    }
}