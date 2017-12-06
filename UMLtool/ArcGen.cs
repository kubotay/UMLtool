using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UMLtool
{
    public class ArcGen : MouseProc
    {
        private Arc a;
        private Form1 fm;

        public ArcGen(Arc a, Form1 fm)
        {
            this.a = a;
            this.fm = fm;
        }
        public void down(Point p)
        {
            a.setP(p);
        }
        public void move(Point p)
        {
            a.setP(p);
            fm.setCurrN(fm.findNode(p));
        }
        public void up(Point p)
        {
            Node n2 = fm.findNode(p);
            if (n2 == null)
                fm.removeArc(a);
            else
            {
                int npos = n2.NPos(p);
                if (npos == 0)
                    fm.removeArc(a);
                else if (a.n1.n == n2 && a.n1.pos == npos)
                    fm.removeArc(a);
                else
                    a.setN2(new NodePos(n2, npos));
                fm.setCurrN(null);
            }
        }
    }
}
