using System;
using System.Collections.Generic;

namespace Day20
{

    public class Point : IComparable<Point>, IEquatable<Point>
    {
        public int x;
        public int y;

        public override string ToString()
        {
            return "(" + x + "," + y + ")";
        }
        public int CompareTo(Point p1)
        {

            if (p1.x > this.x)
                return 1;
            if (p1.x < this.x)
                return -1;

            if (p1.y > this.y)
                return 1;
            if (p1.y < this.y)
                return -1;

            return 0;
        }



        public bool Equals(Point p1)
        {
            if (this.CompareTo(p1) == 0)
                return true;
            else
                return false;
        }

        public Point(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }
    }
    class Program
    {
        static SortedSet<Point> ssp1;
        static SortedSet<Point> ssp2;
        static SortedSet<Point> calcul;
        static string pravidla = "";
        static void Main(string[] args)
        {
            List<string> inputCol = new List<string>();
            string lineIn1;
            while ((lineIn1 = Console.ReadLine()) != null)
            {
                if (lineIn1 == "")
                    break;
                pravidla=lineIn1;
            }
            while ((lineIn1 = Console.ReadLine()) != null)
            {
                if (lineIn1 == "")
                    break;
                inputCol.Add(lineIn1);
            }

            int i, j, inputLenY, inputLenX,x,y;

            inputLenY = inputCol.Count;
            inputLenX = inputCol[0].Length;
            ssp1 = new SortedSet<Point>();
            for (i = 0; i < inputLenY; i++)
            {
                lineIn1 = inputCol[i];
                for (j = 0; j < inputLenX; j++)
                    if (lineIn1[j] == '#')
                        ssp1.Add(new Point(j, i));
            }

           // Console.WriteLine("count = {0}, prlen = {1}", ssp1.Count, pravidla.Length);
            for (int iter = 0; iter < 2; iter++)
           {

                ssp2 = new SortedSet<Point>();
                calcul = new SortedSet<Point>();
                foreach (Point pt in ssp1)
                {
                    x = pt.x;
                    y = pt.y;
                    for (i = y - 1; i <= y + 1; i++)
                        for (j = x - 1; j <= x + 1; j++)
                        {
                            zpracuj(j, i);
                        }
                }
            ssp1 = ssp2;
            }

            for (i = -5; i < inputLenY+5; i++)
            {
                for (j = -5; j < inputLenX + 5; j++)
                {
                    if(ssp2.Contains(new Point(j, i)))
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                   
                }
                Console.WriteLine("");
            }
            

            Console.WriteLine("count = {0}, prlen = {1}",ssp2.Count,pravidla.Length);
        }

        private static void zpracuj(int x, int y)
        {
            Point pt = new Point(x, y);
           /* if (calcul.Contains(pt))
                return;*/
            int i, j;
            int result = 0;
            for (i = y - 1; i <= y + 1; i++)
                for (j = x - 1; j <= x + 1; j++)
                {
                    result <<= 1;
                    if (ssp1.Contains(new Point(j, i)))
                    {
                        result |= 1;
                    }
                }

            if (pravidla[result] == '#')
                ssp2.Add(pt);

            calcul.Add(pt);

        }
    }
}
