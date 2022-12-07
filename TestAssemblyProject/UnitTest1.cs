using DisplayInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace TestAssemblyProject
{
    [TestClass]
    public class UnitTest1
    {
        public string pathToDll()
        {
            return System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\Examples\\TestAssemblyBrowser.dll");
        }

        [TestMethod]
        public void TestMethod1()
        {
            AssemblyBrowser ab = AssemblyLoader.Load(pathToDll());
            Assert.IsTrue(ab.Name.StartsWith("TestAssemblyBrowser"));
            Assert.AreEqual(ab.Namespaces.Count, 1);
            Assert.AreEqual(ab.Namespaces["TestAssemblyBrowser"].Name, "TestAssemblyBrowser");
            Assert.AreEqual(ab.Namespaces["TestAssemblyBrowser"].Types.Count, 2);
            Assert.AreEqual(ab.Namespaces["TestAssemblyBrowser"].Types[0].Name, "TestAssemblyBrowser.ClassTest1");
        }
    }
}
