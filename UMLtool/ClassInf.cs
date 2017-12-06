using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UMLtool
{
    public class ClassInf
    {
        public string name = "";
        public int ctype = 0; // 0:class, 1:abs-class, 2:interface
        public List<FMInf> fields = new List<FMInf>();
        public List<FMInf> methods = new List<FMInf>();
        public string comment = "";
        public ClassInf() { }
    }
}
