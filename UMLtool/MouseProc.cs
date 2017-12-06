using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UMLtool
{
    public interface MouseProc
    {
        void down(Point p);
        void move(Point p);
        void up(Point p);
    }
}
