using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestTri {
    [TestClass]
    public class TriangleUnitTest {
        [TestMethod]
        public void ConstructorDoubleDoubleDoubleTest() {
            Triangle tri = new Triangle(1.0, 0.5, 2.0);
            Console.WriteLine((double[]) GetFieldValue(tri, "sides"));
            CollectionAssert.AreEqual(new double[] { 1, 0.5, 2 }, (double[]) GetFieldValue(tri, "sides"));
        }

        [TestMethod]
        public void ConstructorDoubleArrayTest() {
            Triangle tri = new Triangle(new double[] { 1, 0.5, 2 });
            Console.WriteLine((double[]) GetFieldValue(tri, "sides"));
            CollectionAssert.AreEqual(new double[] { 1, 0.5, 2 }, (double[]) GetFieldValue(tri, "sides"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorDoubleArrayInvalidLengthTest() {
            Triangle tri = new Triangle(new double[] { 1, 0.5, 2, 3 });
        }

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

        private static object GetFieldValue(object o, string name) {
            var field = o.GetType().GetField(name, BindingFlags.NonPublic | BindingFlags.Instance);
            if (field == null) {
                throw new ApplicationException(String.Format("FEL! Det privata fältet {0} saknas.", name));
            }
            return field.GetValue(o);
        }
    }
}
