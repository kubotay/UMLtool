using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UMLtool
{
    public class CommMove : MouseProc
    {
        private Comment com;
        private Point oldp;
        private bool isDown = false;
        public CommMove(Comment com)
        {
            this.com = com;
        }
        public void down(Point p)
        {
            this.oldp = p;
            isDown = true;
        }
        public void move(Point p)
        {
            if (isDown)
            {
                Size sz = new Size(p.X - oldp.X, p.Y - oldp.Y);
                com.move(sz);
                com.pos += sz;
                oldp = p;
            }
        }
        public void up(Point p)
        {
            isDown = false;
        }
    }
}
