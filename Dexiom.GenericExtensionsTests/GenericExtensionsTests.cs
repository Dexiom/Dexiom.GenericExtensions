using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dexiom.GenericExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Dexiom.GenericExtensions.Tests
{
    [TestClass()]
    public class GenericExtensionsTests
    {
        [TestMethod()]
        public void WithTest()
        {
            var temp = new Exception();
            temp.With(n => n.Source = "toto");
            Assert.IsTrue(temp.Source == "toto");
        }

        [TestMethod()]
        public void InTest()
        {
            const string temp = "toto";
            Assert.IsTrue(temp.In("toto", "titi", "tata"));
            Assert.IsFalse(temp.In("titi", "tata"));
        }

        [TestMethod()]
        public void NotInTest()
        {
            const string temp = "toto";
            Assert.IsFalse(temp.NotIn("toto", "titi", "tata"));
            Assert.IsTrue(temp.NotIn("titi", "tata"));
        }

        [TestMethod()]
        public void IsDefaultForTypeTest()
        {
            int intValue1 = 0;
            int intValue2 = 1;
            Assert.IsTrue(intValue1.IsDefaultForType());
            Assert.IsFalse(intValue2.IsDefaultForType());
        }

        [TestMethod()]
        public void CloneTest()
        {
            var temp = new Exception {Source = "toto"};
            var tempClone = temp.Clone();
            temp.Source += "Source";
            tempClone.Source += "Clone";

            Assert.IsTrue(temp.Source == "totoSource");
            Assert.IsTrue(tempClone.Source == "totoClone");
        }
    }
}