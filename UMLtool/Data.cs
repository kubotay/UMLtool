using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UMLtool
{
    public class Data
    {
        public List<Node> nodes = new List<Node>();
        public List<Arc> arcs = new List<Arc>();
        public List<Comment> comments = new List<Comment>();
        public string fontstr = "";

        private System.ComponentModel.TypeConverter converter =
            System.ComponentModel.TypeDescriptor.GetConverter(typeof(Font));

        public Data() { }
        public void saveFont(Font font)
        {
            fontstr = converter.ConvertToString(font);
        }
        public Font loadFont()
        {
            return (Font)converter.ConvertFromString(fontstr);
        }
    }
}
