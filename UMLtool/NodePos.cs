using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UMLtool
{
    public class NodePos
    {
        public Node n;
        public int pos;

        private int gap = 20;

        public NodePos() { }

        public NodePos(Node n, int pos)
        {
            this.n = n;
            this.pos = pos;
        }
        public Point getP()
        {
            return n.getBorder(pos);
        }
        public Point getNP()  // get Neighbor point
        {
            Point p = getP();
            return
                pos == 1 ? new Point(p.X, p.Y - gap) : //North
                pos == 2 ? new Point(p.X + gap, p.Y) : //East
                pos == 3 ? new Point(p.X, p.Y + gap) : //South
                pos == 4 ? new Point(p.X - gap, p.Y) : //West
                p;
        }
    }
}
