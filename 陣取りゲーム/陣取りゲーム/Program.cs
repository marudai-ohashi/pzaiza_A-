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

            int num;
            string start = Console.ReadLine();
            if (start == "A") num = 0;
            else num = 1;

            b.Create_masu(height, width, start);

            bool flag;
            do
            {
                flag = b.SetNum(num++);
                if (flag || b.SetNum(num++)) flag = true;
                else flag = false;
                //b.DrawNum();
            } while (flag);

            int anum = b.GetA();
            int bnum = b.GetB();
            Console.WriteLine(anum + " " + bnum);
            if (anum > bnum) Console.WriteLine("A");
            else Console.WriteLine("B");
        }
    }

    class Ban
    {
        public int[,] banNum;
        public int height;
        public int width;

        public List<(int, int)> a_list = new List<(int, int)>();
        public List<(int, int)> b_list = new List<(int, int)>();

        public int GetNum(int y,int x)
        {
            return banNum[y, x];
        }

        public int GetA()
        {
            int num = 0;
            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    if (banNum[i, j] % 2 == 0) num++;
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
                    if (banNum[i, j] % 2 == 1) num++;
                }
            }
            return num;
        }


        public bool MarkNum(int y,int x)
        {
            int num = banNum[y, x];
            num += 2;
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

        public bool SetNum(int num)
        {
            int flag = 0;
            if (num % 2 == 0)
            {
                for(int i=0;i<a_list.Count;i++)
                {
                    (int y,int x) = a_list[i];
                    
                    if (banNum[y, x] == num)
                    {
                        if (x < width - 1 && banNum[y, x + 1] == -1)
                        {
                            banNum[y, x + 1] = num + 2;
                            flag++;
                            a_list.Add((y, x + 1));
                        }
                        if (x > 0 && banNum[y, x - 1] == -1)
                        {
                            banNum[y, x - 1] = num + 2;
                            flag++;
                            a_list.Add((y, x - 1));
                        }
                        if (y > 0 && banNum[y - 1, x] == -1)
                        {
                            banNum[y - 1, x] = num + 2;
                            flag++;
                            a_list.Add((y - 1, x));
                        }
                        if (y < height - 1 && banNum[y + 1, x] == -1)
                        {
                            banNum[y + 1, x] = num + 2;
                            flag++;
                            a_list.Add((y + 1, x));
                        }
                    }
                }
            }
            else
            {
                for(int i=0;i<b_list.Count;i++)
                {
                    (int y, int x) = b_list[i];
                    if (banNum[y, x] == num)
                    {
                        if (x < width - 1 && banNum[y, x + 1] == -1)
                        {
                            banNum[y, x + 1] = num + 2;
                            flag++;
                            b_list.Add((y, x + 1));
                        }
                        if (x > 0 && banNum[y, x - 1] == -1)
                        {
                            banNum[y, x - 1] = num + 2;
                            flag++;
                            b_list.Add((y, x - 1));
                        }
                        if (y > 0 && banNum[y - 1, x] == -1)
                        {
                            banNum[y - 1, x] = num + 2;
                            flag++;
                            b_list.Add((y - 1, x));
                        }
                        if (y < height - 1 && banNum[y + 1, x] == -1)
                        {
                            banNum[y + 1, x] = num + 2;
                            flag++;
                            b_list.Add((y + 1, x));
                        }
                    }
                }
            }
            if (flag > 0) return true;
            else return false;
        }

        public void Create_masu(int y, int x, string start)
        {
            height = y;
            width = x;
            banNum = new int[height, width];
            for (int i = 0; i < height; i++)
            {
                string str = Console.ReadLine();
                for (int j = 0; j < width; j++)
                {
                    if (str[j] == '.') banNum[i, j] = -1;
                    else if (str[j] == '#') banNum[i, j] = -99;
                    else if (str[j] == 'B')
                    {
                        banNum[i, j] = 1;
                        b_list.Add((i, j));
                    }
                    else if (str[j] == 'A' && start == "A")
                    {
                        banNum[i, j] = 0;
                        a_list.Add((i, j));
                    }
                    else if (str[j] == 'A' && start == "B")
                    {
                        banNum[i, j] = 2;
                        a_list.Add((i, j));
                    }
                }
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
