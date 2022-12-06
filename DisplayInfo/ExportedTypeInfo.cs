using DisplayInfo.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayInfo
{
    public class ExportedTypeInfo
    {
        // variables
        public string Name { get; private set; }
        public string Attributes { get; private set; }
        /*        public List<Field> Fields { get; private set; }*/
        public List<Property> Properties { get; private set; }
        public List<Method> Methods { get; private set; }



        // methods
        public ExportedTypeInfo(string name, string attributes/*, List<Field> fields*/, List<Property> properties, List<Method> methods)
        {
            Name = name;
            Attributes = attributes;
            /*            Fields = fields;*/
            Properties = properties;
            Methods = methods;
        }



        public override string ToString()
        {
            return Attributes + " " + Name;
        }
    }
}
