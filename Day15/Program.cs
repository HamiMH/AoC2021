using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Day15
{
    public class PointPrice : IComparable<PointPrice>, IEquatable<PointPrice>
    {
        public int x;
        public int y;
        public int price;

        public override string ToString()
        {
            return "(" + x + "," + y + "), pr = "+price;
        }
        public int CompareTo(PointPrice p1)
        {
            
            /*if (p1.price < this.price)
                return 1;
            if (p1.price > this.price)
                return -1;
            */
            int ret = this.price - p1.price;

            /*if (p1.x > this.x)
                return 1;
            if (p1.x < this.x)
                return -1;
            */
            if (ret == 0)
                ret = p1.x - this.x;
            else
                return ret;

            /* if (p1.y > this.y)
                 return 1;
             if (p1.y < this.y)
                 return -1;

             return 0;*/
            if (ret == 0)
                return p1.y - this.y;
            else
                return ret;
           
        }



        public bool Equals(PointPrice p1)
        {
            if (this.CompareTo(p1) == 0)
                return true;
            else
                return false;
        }

        public PointPrice(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
            this.price = int.MaxValue;
        }
    }
    class Program
    {


        static int[,] memo;
        static Boolean[,] inCloud;
        static PointPrice[,] pointerToSS;
        static SortedSet<PointPrice> pracBody;
        static int lenX;
        static int lenY;
        static void Main(string[] args)
        {
            List<string> input = new List<string>();
            string lineIn;
            while ((lineIn = Console.ReadLine()) != null)
            {
                if (lineIn == "")
                    break;
                input.Add(lineIn);
            }
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            int i, j, ii,jj, iAdd,jAdd;
            pracBody = new SortedSet<PointPrice>();



            lenY = input.Count;
            lenX = input[0].Length;

            memo = new int[lenY*5, lenX*5];
            inCloud = new Boolean[lenY*5, lenX*5];
            pointerToSS = new PointPrice[lenY*5, lenX*5];

            for (i = 0; i < lenY*5; i++)
            {
                ii = i % lenY;
                iAdd = i / lenY;
                for (j = 0; j < lenX*5; j++)
                {
                    jj = j % lenX;
                    jAdd = j / lenX;

                    memo[i, j] = 1+(iAdd+jAdd+input[ii][jj] - '0'-1)%9;
                    inCloud[i, j] = false;
                    pointerToSS[i, j] = new PointPrice(j, i);
                }
            }
            lenX *= 5;
            lenY *= 5;
            searchFromWithPrice(0, 0, 0);
            inCloud[0, 0] = true;

            PointPrice pp;
            while (!inCloud[lenY - 1, lenX - 1])
            {
                pp = pracBody.Min;
                inCloud[pp.y, pp.x] = true;
                searchFromWithPrice(pp.x, pp.y, pp.price);
                pracBody.Remove(pp);
            }
            stopwatch.Stop();
            Console.WriteLine("Price = {0}", pointerToSS[lenY - 1, lenX - 1].price);
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
        }

        private static void searchFromWithPrice(int x, int y, int price)
        {
            zpracujPozici(x - 1, y, price);
            zpracujPozici(x + 1, y, price);
            zpracujPozici(x, y - 1, price);
            zpracujPozici(x, y + 1, price);
        }

        private static void zpracujPozici(int x, int y, int price)
        {
            if (x < 0 || x >= lenX || y < 0 || y >= lenY)
                return;
            if (inCloud[y, x])
                return;

            PointPrice pp = pointerToSS[y, x];
            if (pp.price > price + memo[y, x])
            {
                //if (pracBody.Contains(pp))                    
                pracBody.Remove(pp);
                pp.price = price + memo[y, x];
                pracBody.Add(pp);
            }
        }
    }
}
