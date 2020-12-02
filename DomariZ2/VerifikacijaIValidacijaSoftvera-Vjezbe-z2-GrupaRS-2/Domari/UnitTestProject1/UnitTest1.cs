using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        ///Amer Beso - 68-ST - implementacija
        public void TestPromjenaSobeUStudentskomDomuIzbacivanjeSvihStudenata()
        {
            StudentskiDom sd = new StudentskiDom(100);
            sd.PromjenaSobe(new Soba(101, 2), 2);
            //provjera da li je uspjesna promjena kapaciteta sa 2 na 1
            Assert.AreEqual(sd.Sobe[0].Stanari.Count, 0);
        }
    }
}
