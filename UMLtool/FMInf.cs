using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UMLtool
{
    public class FMInf
    {
        public bool isAbstract = false;
        public bool isStatic = false;
        public string body = "";
        public string comment = "";
        public FMInf() { }
        public FMInf clone()
        {
            FMInf fm = new FMInf();
            fm.body = this.body;
            fm.isAbstract = this.isAbstract;
            fm.isStatic = this.isStatic;
            return fm;
        }
    }
}
