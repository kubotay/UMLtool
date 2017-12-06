using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UMLtool
{
    public class Comment
    {
        public Point pos; //指示点
        public Rectangle rec;
        public string body = "";
        public string fontstr = "";

        private Font font = new Font("Arial", 9);

        private System.ComponentModel.TypeConverter converter =
            System.ComponentModel.TypeDescriptor.GetConverter(typeof(Font));

        public Comment() { }

        public Comment(Point p)
        {
            rec = new Rectangle(p, new Size(30, 30));
            pos = new Point(rec.X + rec.Width / 2, rec.Y - 20);
        }
        public void setBody(string body)
        {
            this.body = body;
        }
        public void setFont(Font font)
        {
            this.font = font;
        }
        public void setPos(Point pos)
        {
            this.pos = pos;
        }
        public void move(Size sz)
        {
            rec.Location += sz;
        }
        public bool isIn(Point p)
        {
            return rec.Contains(p);
        }

        public bool onPos(Point p) //pがコメントの指示点を指しているか？
        {
            return distance(p, pos) < 7;
        }

        public void saveFont()
        {
            fontstr = converter.ConvertToString(font);
        }

        public void loadFont()
        {
            font = (Font)converter.ConvertFromString(fontstr);
        }

        private int distance(Point p1, Point p2)
        {
            return (int)Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }
        private int getDir(Rectangle rec, Point p)  //0:N, 1:E, 2:S, 3:W
        {
            float drec = (float)rec.Height / rec.Width;
            Point c = new Point(rec.X + rec.Width / 2, rec.Y + rec.Height / 2);
            int dx = p.X - c.X, dy = p.Y - c.Y;
            if (dx == 0)
                return dy < 0 ? 0 : 2;
            float dpos = Math.Abs((float)dy / dx);
            if (dpos > drec)
                return dy < 0 ? 0 : 2;
            else
                return dx < 0 ? 3 : 1;
        }

        private List<Point> getPList()
        {
            List<Point> ps = new List<Point>();
            int dir = getDir(rec, pos);
            int x0 = rec.X, y0 = rec.Y, x1 = rec.X + rec.Width, y1 = rec.Y + rec.Height;
            ps.Add(new Point(x0, y0));
            if (dir == 3) // W
            {
                ps.Add(new Point(x0, y0 + rec.Height / 2 - 5));
                ps.Add(pos);
                ps.Add(new Point(x0, y0 + rec.Height / 2 + 5));
            }
            ps.Add(new Point(x0, y1));
            if (dir == 2) // S
            {
                ps.Add(new Point(x0 + rec.Width / 2 - 5, y1));
                ps.Add(pos);
                ps.Add(new Point(x0 + rec.Width / 2 + 5, y1));
            }
            ps.Add(new Point(x1, y1));
            if (dir == 1) // W
            {
                ps.Add(new Point(x1, y0 + rec.Height / 2 + 5));
                ps.Add(pos);
                ps.Add(new Point(x1, y0 + rec.Height / 2 - 5));
            }
            ps.Add(new Point(x1, y0 + 5));
            ps.Add(new Point(x1 - 5, y0));
            if (dir == 0) // S
            {
                ps.Add(new Point(x0 + rec.Width / 2 + 5, y0));
                ps.Add(pos);
                ps.Add(new Point(x0 + rec.Width / 2 - 5, y0));
            }
            return ps;
        }

        private Point[] PEdge()
        {
            int x = rec.X + rec.Width, y = rec.Y;
            Point[] ps = new Point[] { new Point(x, y + 5), new Point(x - 5, y + 5), new Point(x - 5, y) };
            return ps;
        }


        public void draw(PaintEventArgs e)
        {
            SizeF sz = e.Graphics.MeasureString(body, font);
            rec.Size = new Size(Math.Max((int)sz.Width + 6, 30), Math.Max((int)sz.Height + 6, 30));

            Point[] ps = getPList().ToArray<Point>();
            SolidBrush br = new SolidBrush(Color.FromArgb(80, Color.Yellow));
            e.Graphics.FillPolygon(br, ps);
            e.Graphics.DrawPolygon(Pens.Black, ps);
            e.Graphics.DrawLines(Pens.Black, PEdge());

            e.Graphics.DrawString(body, font, Brushes.Black, rec.X + 3, rec.Y + 3);
        }

        public void drawCurr(PaintEventArgs e)  // 線のみ赤で描画
        {
            Point[] ps = getPList().ToArray<Point>();
            e.Graphics.DrawPolygon(Pens.Red, ps);
            e.Graphics.DrawLines(Pens.Red, PEdge());
            e.Graphics.DrawEllipse(Pens.Red, new Rectangle(pos.X-3, pos.Y-3, 6, 6));
        }
    }
}
