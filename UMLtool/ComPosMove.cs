using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UMLtool
{
    public class ComPosMove : MouseProc
    {
        private Comment com;
        private bool isDown = false;
        public ComPosMove(Comment com)
        {
            this.com = com;
        }
        public void down(Point p)
        {
            isDown = true;
            com.setPos(p);
        }
        public void move(Point p)
        {
            if (isDown)
                com.setPos(p);
        }
        public void up(Point p)
        {
            isDown = false;
        }
    }
}
