using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace UMLtool
{
    public class Arc
    {
        public NodePos n1, n2;
        public Point p;
        public int atype = 0;  // 0:Gen(△), 1:Comp(◇),  2:Rel(→) 
        public string name = "";
        public string mult = "";

        public Arc() { }

        public Arc(NodePos n1, int atype)
        {
            this.n1 = n1;
            n2 = null;
            this.atype = atype;
        }
        public void setP(Point p)
        {
            this.p = p;
        }
        public void setN2(NodePos n2)
        {
            this.n2 = n2;
        }
        public bool isIn(Point p)
        {
            List<Point> ps = points();
            for (int i = 0; i < ps.Count - 1; i++)
                if (onLine(ps[i], ps[i + 1], p))
                    return true;
            return false;
        }
        private bool onLine(Point p1, Point p2, Point p) //pが、line<p1,p2>上にあるか? 但しlineは縦または横線とする
        {
            if (p1.X == p2.X)
            {
                return Math.Abs(p1.X - p.X) < 4 &&
                    p.Y >= Math.Min(p1.Y, p2.Y) && p.Y <= Math.Max(p1.Y, p2.Y);
            }
            else
            {
                return Math.Abs(p1.Y - p.Y) < 4 &&
                    p.X >= Math.Min(p1.X, p2.X) && p.X <= Math.Max(p1.X, p2.X);
            }
        }

        private Point namePos(SizeF sz)
        {
            Point p = n1.getP();
            if (n1.pos == 1) //North
                return new Point(p.X + 10, p.Y - 2 - (int)sz.Height);
            else if (n1.pos == 2) //East
                return new Point(p.X + 10, p.Y + 5);
            else if (n1.pos == 3) //South
                return new Point(p.X + 10, p.Y + 5);
            else  //West
                return new Point(p.X - 2 - (int)sz.Width, p.Y + 5);
        }

        private Point multPos(SizeF sz)
        {
            Point p = n2.getP();
            if (n2.pos == 1) //North
                return new Point(p.X + 10, p.Y - 2 - (int)sz.Height);
            else if (n2.pos == 2) //East
                return new Point(p.X + 10, p.Y + 5);
            else if (n2.pos == 3) //South
                return new Point(p.X + 10, p.Y + 5);
            else  //West
                return new Point(p.X - 2 - (int)sz.Width, p.Y + 5);
        }

        private void drawArc(PaintEventArgs e, Color color)
        {
            Pen pen = new Pen(color, 1);
            //汎化関係でn1がinterfaceでなくn2がinterfaceの場合は破線、それ以外は実線
            if ((atype == 0 && n1.n.inf.ctype != 2 && n2.n.inf.ctype == 2) || atype == 2)
            {
                pen.DashStyle = DashStyle.Dash;
                pen.DashPattern = new float[] { 5.0F, 2.0F };
            }
            else
                pen.DashStyle = DashStyle.Solid;
            e.Graphics.DrawLines(pen, points().ToArray<Point>());
            pen.DashStyle = DashStyle.Solid;
            if (atype == 0) //汎化関係なら、三角の表示
            {
                Point[] pp = arrow(12, 12).ToArray<Point>();
                e.Graphics.FillPolygon(Brushes.White, pp);
                e.Graphics.DrawPolygon(pen, pp);
            }
            else if (atype == 1) //集約関係ならひし形、関係名、関係数を表示
            {
                Point[] pp = diamond().ToArray<Point>();
                e.Graphics.FillPolygon(Brushes.White, pp);
                e.Graphics.DrawPolygon(pen, pp);
                pp = arrow(7, 10).ToArray<Point>();
                e.Graphics.DrawLines(pen, pp);
                e.Graphics.DrawString(name, Form1.font, Brushes.Black,
                    namePos(e.Graphics.MeasureString(name, Form1.font)));
                e.Graphics.DrawString(mult, Form1.font, Brushes.Black,
                    multPos(e.Graphics.MeasureString(mult, Form1.font)));
            }
            else //依存関係なら矢印を表示
            {
                Point[] pp = arrow(7, 10).ToArray<Point>();
                e.Graphics.DrawLines(pen, pp);
            }
        }

        public void draw(PaintEventArgs e)
        {
            if (n2 == null)
            {
                e.Graphics.DrawLine(Pens.Red, n1.getP(), p);
            }
            else
            {
                drawArc(e, Color.Black);
            }
        }
        public void drawCurr(PaintEventArgs e)
        {   
            if (n2 != null)
            {
                drawArc(e, Color.Red);
            }
        }
        private List<Point> diamond()
        {
            int w = 7;
            List<Point> ps = new List<Point>();

            Point p = n1.getP();
            ps.Add(p);
            if (n1.pos == 1) //North
            {
                ps.Add(new Point(p.X - w, p.Y - w));
                ps.Add(new Point(p.X, p.Y - w * 2));
                ps.Add(new Point(p.X + w, p.Y - w));
            }
            else if (n1.pos == 2) //East
            {
                ps.Add(new Point(p.X + w, p.Y - w));
                ps.Add(new Point(p.X + w * 2, p.Y));
                ps.Add(new Point(p.X + w, p.Y + w));
            }
            else if (n1.pos == 3) //South
            {
                ps.Add(new Point(p.X - w, p.Y + w));
                ps.Add(new Point(p.X, p.Y + w * 2));
                ps.Add(new Point(p.X + w, p.Y + w));
            }
            else //West
            {
                ps.Add(new Point(p.X - w, p.Y - w));
                ps.Add(new Point(p.X - w * 2, p.Y));
                ps.Add(new Point(p.X - w, p.Y + w));
            }
            return ps;
        }

        private List<Point> arrow(int w, int h) //n2側の矢印or三角の点を求める
        {
            List<Point> ps = new List<Point>();
            if (n2 == null) return ps;

            Point p = n2.getP();
            
            if (n2.pos == 1) // North
            {
                ps.Add(new Point(p.X - w / 2, p.Y - h));
                ps.Add(p);
                ps.Add(new Point(p.X + w / 2, p.Y - h));
            }
            else if (n2.pos == 2) // East
            {
                ps.Add(new Point(p.X + h, p.Y - w / 2));
                ps.Add(p);
                ps.Add(new Point(p.X + h, p.Y + w / 2));
            }
            else if (n2.pos == 3) // South
            {
                ps.Add(new Point(p.X - w / 2, p.Y + h));
                ps.Add(p);
                ps.Add(new Point(p.X + w / 2, p.Y + h));
            }
            else
            {
                ps.Add(new Point(p.X - h, p.Y - w / 2));
                ps.Add(p);
                ps.Add(new Point(p.X - h, p.Y + w / 2));
            }
            return ps;
        }

        private List<Point> points() //n1からn2への折れ線の中間点
        {
            List<Point> ps = new List<Point>();
            Point p1 = n1.getP(); //始点
            ps.Add(p1);
            if (n2 == null)
            {
                ps.Add(p);
                return ps;
            }
            Point p1n = n1.getNP(); 
            Point p2 = n2.getP();
            Point p2n = n2.getNP();
            Point pm = mid(p1, p2);

            if (n1.pos == n2.pos)
            {
                if (n1.pos == 1 || n1.pos == 3) // N->N || S->S
                {
                    int y = (n1.pos == 1 ? Math.Min(p1n.Y, p2n.Y) : Math.Max(p1n.Y, p2n.Y));
                    ps.Add(new Point(p1.X, y));
                    ps.Add(new Point(p2.X, y));
                }
                else
                {                   // E->E || W->W
                    int x = (n1.pos == 2 ? Math.Max(p1n.X, p2n.X) : Math.Min(p1n.X, p2n.X));
                    ps.Add(new Point(x, p1.Y));
                    ps.Add(new Point(x, p2.Y));
                }
            }
            else if ((n1.pos == 1 && n2.pos == 3) || (n1.pos == 3 && n2.pos == 1)) // N->S || S->N
            {
                bool b = (n1.pos == 1 ? p1n.Y > p2n.Y : p1n.Y < p2n.Y);
                if (b)
                {
                    ps.Add(new Point(p1.X, pm.Y));
                    ps.Add(new Point(p2.X, pm.Y));
                }
                else
                {
                    ps.Add(new Point(p1.X, p1n.Y));
                    ps.Add(new Point(pm.X, p1n.Y));
                    ps.Add(new Point(pm.X, p2n.Y));
                    ps.Add(new Point(p2.X, p2n.Y));
                }
            }
            else if ((n1.pos == 2 && n2.pos == 4) || (n1.pos == 4 && n2.pos == 2)) // E->W || W->E
            {
                bool b = (n1.pos == 2 ? p1n.X < p2n.X : p1n.X > p2n.X);
                if (b)
                {
                    ps.Add(new Point(pm.X, p1.Y));
                    ps.Add(new Point(pm.X, p2.Y));
                }
                else
                {
                    ps.Add(new Point(p1n.X, p1.Y));
                    ps.Add(new Point(p1n.X, pm.Y));
                    ps.Add(new Point(p2n.X, pm.Y));
                    ps.Add(new Point(p2n.X, p2.Y));
                }
            }
            else if (n1.pos == 1 || n1.pos == 3)   // N->E, N->W, S->E, S->W
            {
                bool b1 = (n1.pos == 1 ? p1.Y > p2.Y : p1.Y < p2.Y);
                bool b2 = (n2.pos == 2 ? p1.X > p2.X : p1.X < p2.X);
                if (b1 && b2)
                {
                    ps.Add(new Point(p1.X, p2.Y));
                }
                else if (!b1 && b2)
                {
                    ps.Add(new Point(p1.X, p1n.Y));
                    ps.Add(new Point(pm.X, p1n.Y));
                    ps.Add(new Point(pm.X, p2.Y));
                }
                else
                {
                    ps.Add(new Point(p1.X, p1n.Y));
                    ps.Add(new Point(p2n.X, p1n.Y));
                    ps.Add(new Point(p2n.X, p2.Y));
                }
            }
            else          // E->N, E->S, W->N, W->S
            {
                bool b1 = (n1.pos == 2 ? p1.X < p2.X : p1.X > p2.X);
                bool b2 = (n2.pos == 1 ? p1.Y < p2.Y : p1.Y > p2.Y);
                if (b1 && b2)
                {
                    ps.Add(new Point(p2.X, p1.Y));
                }
                else if (!b1 && b2)
                {
                    ps.Add(new Point(p1n.X, p1.Y));
                    ps.Add(new Point(p1n.X, pm.Y));
                    ps.Add(new Point(p2.X, pm.Y));
                }
                else
                {
                    ps.Add(new Point(p1n.X, p1.Y));
                    ps.Add(new Point(p1n.X, p2n.Y));
                    ps.Add(new Point(p2.X, p2n.Y));
                }
            }
            ps.Add(p2);
            return ps;
        }
        private Point mid(Point p1, Point p2)
        {
            return new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
        }
    }
}
