using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayInfo.Attributes
{
    public class Method
    {
        // variables
        public string Name { get; private set; }
        public string Attributes { get; private set; }
        public string ReturnType { get; private set; }
        public string[] Parameters { get; }


        // methods
        public Method(string attributes, string returnType, string name, string[] parameters)
        {
            Name = name;
            Attributes = attributes;
            ReturnType = returnType;
            Parameters = parameters;
        }

        public override string ToString()
        {
            return "METHOD:   " + Attributes + " " + ReturnType + " " + Name + "(" + String.Join(", ", Parameters) + ")";
        }
    }
}
