using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestTri {
    [TestClass]
    public class TriangleUnitTest {
        [TestMethod]
        public void ConstructorDoubleDoubleDoubleTest() {
            Triangle tri = new Triangle(1.0, 0.5, 2.0);
            CollectionAssert.AreEqual(new double[] { 1, 0.5, 2 }, (double[]) GetFieldValue(tri, "sides"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorDoubleDoubleDoubleNegativeValuesTest() {
            Triangle tri = new Triangle(-1.0, 0.5, 2.0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorDoubleDoubleDoubleZeroValuesTest() {
            Triangle tri = new Triangle(-1.0, 0, 2.0);
        }

        [TestMethod]
        public void ConstructorDoubleArrayTest() {
            Triangle tri = new Triangle(new double[] { 1, 0.5, 2 });
            CollectionAssert.AreEqual(new double[] { 1, 0.5, 2 }, (double[]) GetFieldValue(tri, "sides"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorDoubleArrayInvalidLengthTest() {
            Triangle tri = new Triangle(new double[] { 1, 0.5, 2, 3 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorDoubleArrayNegativeValuesTest() {
            Triangle tri = new Triangle(new double[] { -1, 0.5, 2 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorDoubleArrayZeroValuesTest() {
            Triangle tri = new Triangle(new double[] { -1, 0, 2 });
        }

        [TestMethod]
        public void ConstructorPointPointPointTest() {
            Point a, b, c;
            a = new Point(0, 0);
            b = new Point(4, 0);
            c = new Point(0, 3);
            Triangle tri = new Triangle(a, c, b);
            CollectionAssert.AreEqual(new double[] { 3, 4, 5 }, (double[]) GetFieldValue(tri, "sides"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorPointPointPointSamePointTest() {
            Point a = new Point(0, 0);
            Triangle tri = new Triangle(a, a, a);
        }

        [TestMethod]
        public void ConstructorPointArrayTest() {
            Point a, b, c;
            a = new Point(0, 0);
            b = new Point(4, 0);
            c = new Point(0, 3);
            Triangle tri = new Triangle(new Point[] {a, c, b});
            CollectionAssert.AreEqual(new double[] { 3, 4, 5 }, (double[]) GetFieldValue(tri, "sides"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorPointArrayInvalidLengthTest() {
            Point a, b, c, d;
            a = new Point(0, 0);
            b = new Point(4, 0);
            c = new Point(0, 4);
            d = new Point(4, 4);
            Triangle tri = new Triangle(new Point[] { a, b, c, d});
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorPointArraySamePointTest() {
            Point a = new Point(0, 0);
            Triangle tri = new Triangle(new Point[] { a, a, a });
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
