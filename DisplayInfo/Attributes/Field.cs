using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayInfo.Attributes
{
    public class Field
    {
        // methods
        public string Name { get; private set; }
        public string Attributes { get; private set; }
        public string Type { get; private set; }


        // methods
        public Field(string name, string attributes, string type)
        {
            Name = name;
            Attributes = attributes;
            Type = type;
        }

        public override string ToString()
        {
            return "FIELD:   " + Attributes + " " + Type + " " + Name;
        }
    }
}
