using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestTri {
    [TestClass]
    public class TriangleUnitTest {
        [TestMethod]
        public void isScaleneTest() {
            Triangle tri = new Triangle(1.0, 0.5, 2.0);
            Assert.IsTrue(tri.isScalene());
            tri = new Triangle(1.0, 1.0, 2.0);
            Assert.IsFalse(tri.isScalene());
        }

        [TestMethod]
        public void isIsoscelesTest() {
            Triangle tri = new Triangle(1.0, 0.5, 1.0);
            Assert.IsTrue(tri.isIsosceles());
            tri = new Triangle(1.0, 0.5, 2.0);
            Assert.IsFalse(tri.isIsosceles());
        }

        [TestMethod]
        public void isEquilateralTest() {
            Triangle tri = new Triangle(1.0, 1.0, 1.0);
            Assert.IsTrue(tri.isEquilateral());
            tri = new Triangle(1.0, 1.0, 2.0);
            Assert.IsFalse(tri.isEquilateral());
        }
    }
}
