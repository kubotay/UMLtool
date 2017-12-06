using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UMLtool
{
    public class NodeMove : MouseProc
    {
        private Form1 fm;
        private Node n;
        private Point oldp;
        private bool isDown = false;
        private static bool gridMode = true;

        public NodeMove(Form1 fm, Node n)
        {
            this.fm = fm;
            this.n = n;
        }
        public void down(Point p)
        {
            isDown = true;
            oldp = p;
        }
        public void move(Point p)
        {
            if (isDown)
            {
                n.rec.Location = n.rec.Location + new Size(p.X - oldp.X, p.Y - oldp.Y);
                oldp = p;
            }
        }
        public void up(Point p)
        {
            fm.nodeInfMakeEnable(n.nodeArea(p));
            if (gridMode )
                n.rec.Location += ajust(n.rec);
            isDown = false;
        }
        public static void setGridMode(bool mode)
        {
            gridMode = mode;
        }
        public Size ajust(Rectangle rec) //微調整：中心をグリッドに合わせる
        {
            int xd = (rec.X + rec.Width / 2) % 9;
            int yd = (rec.Y + rec.Height / 2) % 9;
            return new Size(xd <= 4 ? -xd : 9 - xd, yd <= 4 ? -yd : 9 - yd);
        }
    }
}
