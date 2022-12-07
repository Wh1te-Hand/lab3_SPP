using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssemblyBrowser
{
    public class ClassTest1
    {
        public float publicField;
        private float privateField;
        public int PublicProperty { get; set; }
        public int PropertyWithPrivateSet { get; private set; }

        public string Method1()
        {
            return "Good";
        }

        public int MethodWithParams(int x, double y)
        {
            return 666;
        }
        private void PrivateMethod()
        {

        }
    }
}
