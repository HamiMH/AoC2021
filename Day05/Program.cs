using System;
using System.Collections.Generic;
namespace Day05
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

        

        public  bool Equals(Point p1)
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
    public class Line : IComparable<Line>
    {
        public Point p1;
        public Point p2;

        public int CompareTo(Line li)
        {
            int comp1 = li.p1.CompareTo(this.p1);
            if (comp1!=0) 
                return comp1;
            else
                return li.p2.CompareTo(this.p2); 
        }
        public Point Intersect(Line li)
        {

            if (this.p1.x == this.p2.x)
            {
                if (li.p1.y == li.p2.y)
                {
                    if(li.p1.x<= this.p1.x && this.p1.x <= li.p2.x)
                    {
                        if (this.p1.y <= li.p1.y && li.p1.y <= this.p2.y)
                        {
                            return new Point(this.p1.x, li.p1.y);
                        }
                    }
                }
            }
            else if (this.p1.y == this.p2.y)
            {

            }


            return null;
        }

        public override string ToString()
        {
            return p1.ToString() + " -> " + p2.ToString();

        }
        public Line(Point _p1, Point _p2)
        {
            if (_p1.CompareTo(_p2) > 0)
            {
                p1 = _p1;
                p2 = _p2;
            }
            else
            {
                p1 = _p2;
                p2 = _p1;
            }
        }

        public Line(int _p1x, int _p1y, int _p2x, int _p2y)
        {
            Point _p1 = new Point(_p1x, _p1y);
            Point _p2 = new Point(_p2x, _p2y);

            if (_p1.CompareTo(_p2) > 0)
            {
                p1 = _p1;
                p2 = _p2;
            }
            else
            {
                p1 = _p2;
                p2 = _p1;
            }
        }
    }
    public class Program
    {
        public static List<Line>[] LineList = new List<Line>[4];
        static void StepOne()
        {
            string lineIn;
            string[] lineArr = new string[2];
            string[] lineArr2 = new string[2];
            string direct;
            int len;
            int x = 0;
            int y = 0;
            Point p1;
            Point p2;
            Line li;
            LineList[0] = new List<Line>();
            LineList[1] = new List<Line>();
            LineList[2] = new List<Line>();
            LineList[3] = new List<Line>();
            while ((lineIn = Console.ReadLine()) != null)
            {
                if (lineIn == "")
                    break;
                lineArr = lineIn.Split("->");
                lineArr2 = lineArr[0].Trim().Split(",");
                p1 = new Point(Convert.ToInt32(lineArr2[0], 10), Convert.ToInt32(lineArr2[1], 10));
                lineArr2 = lineArr[1].Trim().Split(",");
                p2= new Point(Convert.ToInt32(lineArr2[0], 10), Convert.ToInt32(lineArr2[1], 10));
                li = new Line(p1, p2);
                if (p1.x == p2.x)
                {
                    LineList[0].Add(li);
                }else if (p1.y == p2.y)
                {
                    LineList[1].Add(li);
                }else if (p1.y < p2.y)
                {
                    LineList[2].Add(li);
                }
                else 
                {
                    LineList[3].Add(li);
                }

            }
            LineList[0].Sort();
            LineList[1].Sort();
            LineList[2].Sort();
            LineList[3].Sort();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < LineList[i].Count; j++)
                {
                    Console.WriteLine("{0}", LineList[i][j].ToString() );
                }
                Console.WriteLine("");
            }

            //Console.WriteLine("Multiply of x = {0} and y = {1}: {2}", x, y, x * y);
        }
        
        static void Main(string[] args)
        {
            StepOne();
        }
    }
}
