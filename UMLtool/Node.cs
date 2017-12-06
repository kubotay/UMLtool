using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UMLtool
{
    public class Node
    {
        public Rectangle rec;
        public ClassInf inf = new ClassInf();
        public int fn = 0, mn = 0;  // フィールドとメソッドの表示位置

        private static Size defaultSize = new Size(100, 100);
        private int yheader, yfield, ymethod;
        private int ymin = 10;
        private int gap = 5;

        private Rectangle rechead;  //ヘッダー部
        private Rectangle recfield; //フィールド部
        private Rectangle recmethod;//メソッド部

        public Node() { }

        public Node(Point p)
        {
            rec = new Rectangle(p, defaultSize);
        }

        public Node clone()
        {
            Node n = new Node();
            n.rec = this.rec;
            n.inf = new ClassInf();
            n.inf.ctype = this.inf.ctype;
            n.inf.name = this.inf.name;
            foreach (FMInf fm in this.inf.fields)
            {
                if (fm.body != null && fm.body.Replace(" ", "") != "")
                {
                    FMInf f = new FMInf();
                    f.isAbstract = fm.isAbstract;
                    f.isStatic = fm.isStatic;
                    f.body = fm.body;
                    n.inf.fields.Add(f);
                }
            }
            foreach (FMInf fm in this.inf.methods)
            {
                if (fm.body != null && fm.body.Replace(" ", "") != "")
                {
                    FMInf f = new FMInf();
                    f.isAbstract = fm.isAbstract;
                    f.isStatic = fm.isStatic;
                    f.body = fm.body;
                    n.inf.methods.Add(f);
                }
            }
            return n;
        }

        public bool isIn(Point p)
        {
            Rectangle bigrec = new Rectangle(rec.X - 3, rec.Y - 3, rec.Width + 6, rec.Height + 6);
            return bigrec.Contains(p);
        }
        public int NPos(Point p)  // return 1:North, 2:East, 3:South, 4:West  0:None
        {
            List<Point> pos = BPos();
            for (int i = 0; i < 4; i++)
                if (distance(p, pos[i]) < 7)
                    return i + 1;
            return 0;
        }
        public Point getBorder(int n)
        {
            List<Point> pos = BPos();
            if (n > 0 && n <= 4)
                return pos[n - 1];
            return center();
        }
        public Point center()
        {
            return new Point(rec.X + rec.Width / 2, rec.Y + rec.Height / 2);
        }
        private List<Point> BPos()  //北東南西の４点を求める
        {
            return new List<Point>{ 
                new Point(rec.X+rec.Width/2, rec.Y), new Point(rec.X+rec.Width, rec.Y+rec.Height/2),
                new Point(rec.X+rec.Width/2, rec.Y+rec.Height), new Point(rec.X, rec.Y+rec.Height/2) };
        }
        private int distance(Point p1, Point p2)
        {
            return (int)Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }

        public void drawCurr(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Red, rec);
            foreach (Point p in BPos())
                e.Graphics.DrawEllipse(Pens.Red, new Rectangle(p.X - 3, p.Y - 3, 6, 6));
        }

        public int nodeArea(Point p) // 0:name, 1:field, 2:method -1:else
        {
            return
                rechead.Contains(p)   ? 0 :
                recfield.Contains(p)  ? 1 :
                recmethod.Contains(p) ? 2 : -1;
        }

        public void draw(PaintEventArgs e)
        {
            SizeF sz;
            calcSize(e);
            rechead = new Rectangle(rec.X, rec.Y, rec.Width, yheader);
            recfield = new Rectangle(rec.X, rec.Y + yheader, rec.Width, yfield);
            recmethod = new Rectangle(rec.X, rec.Y + yheader + yfield, rec.Width, ymethod);

            e.Graphics.FillRectangle(Brushes.LightSalmon, rechead);
            e.Graphics.FillRectangle(Brushes.LightBlue, recfield);
            e.Graphics.FillRectangle(Brushes.LightGreen, recmethod);
            e.Graphics.DrawRectangle(Pens.Black, rechead);
            e.Graphics.DrawRectangle(Pens.Black, recfield);
            e.Graphics.DrawRectangle(Pens.Black, recmethod);

            float x, y = rec.Y + gap;
            if (inf.ctype == 2)
            {
                sz = e.Graphics.MeasureString("<<interface>>", Form1.font);
                x = rec.X + (rec.Width - (int)sz.Width) / 2;
                e.Graphics.DrawString("<<interface>>", Form1.font, Brushes.Black, x, y);
                y += sz.Height;
            }
            Font ft = inf.ctype == 0 ? Form1.font : Form1.fita;
            sz = e.Graphics.MeasureString(inf.name, ft);
            x = rec.X + (rec.Width - (int)sz.Width) / 2;
            e.Graphics.DrawString(inf.name, ft, Brushes.Black, x, y);
            y += sz.Height;
            y += gap * 2;
            foreach (FMInf fminf in inf.fields)
            {
                ft = fminf.isAbstract ? Form1.fita : fminf.isStatic ? Form1.fund : Form1.font;
                sz = e.Graphics.MeasureString(fminf.body, ft);
                e.Graphics.DrawString(fminf.body, ft, Brushes.Black, rec.X + 2, y);
                y += sz.Height;
            }
            y += gap * 2;
            foreach (FMInf fminf in inf.methods)
            {
                ft = fminf.isAbstract ? Form1.fita : fminf.isStatic ? Form1.fund : Form1.font;
                if (inf.ctype == 2) // interface
                    ft = Form1.fita;
                sz = e.Graphics.MeasureString(fminf.body, ft);
                e.Graphics.DrawString(fminf.body, ft, Brushes.Black, rec.X + 2, y);
                y += sz.Height;
            }
        }

        private void calcSize(PaintEventArgs e)
        {
            SizeF sz;
            float y = gap, xmax = 50;
            if (inf.ctype == 2) //interface
            {
                sz = e.Graphics.MeasureString("<<interface>>", Form1.font);
                y += sz.Height;
                if (sz.Width > xmax) xmax = sz.Width;
            }
            Font ft = inf.ctype == 1 ? Form1.fita : Form1.font;
            sz = e.Graphics.MeasureString(inf.name, ft);
            y += sz.Height;
            if (sz.Width > xmax) xmax = sz.Width;
            y += gap;
            yheader = (int)y > ymin ? (int)y : ymin;
            y = gap;
            foreach (FMInf fminf in inf.fields)
            {
                ft = fminf.isAbstract ? Form1.fita : fminf.isStatic ? Form1.fund : Form1.font;
                sz = e.Graphics.MeasureString(fminf.body, ft);
                y += sz.Height;
                if (sz.Width > xmax) xmax = sz.Width;
            }
            y += gap;
            yfield = (int)y > ymin ? (int)y : ymin;
            y = gap;
            foreach (FMInf fminf in inf.methods)
            {
                ft = fminf.isAbstract ? Form1.fita : fminf.isStatic ? Form1.fund : Form1.font;
                sz = e.Graphics.MeasureString(fminf.body, ft);
                y += sz.Height;
                if (sz.Width > xmax) xmax = sz.Width;
            }
            y += gap;
            ymethod = (int)y > ymin ? (int)y : ymin;
            rec.Size = new Size((int)xmax + 4, yheader + yfield + ymethod);
            //rec.Location += NodeMove.ajust(rec); //グリッド微調整
        }
    }
}
