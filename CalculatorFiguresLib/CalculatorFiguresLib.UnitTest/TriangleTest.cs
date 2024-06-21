using CalculatorFiguresLib.Figures;

namespace CalculatorFiguresLib.UnitTest
{
    [TestFixture]
    public class TriangleTest
    {
        [Test]
        public void TriangleArea_5_4_3_Return_6()
        {
            Triangle triangle = new Triangle(5, 4, 3);

            Assert.That(triangle.Area, Is.EqualTo(6));
        }

        [Test]
        public void TriangleArea()
        {
            Random r = new Random();
            var triangles = new Triangle[10];
            for (int i = 0; i < triangles.Length; i++)
            {
                triangles[i] = new Triangle(r.NextDouble() * 100 + 1, r.NextDouble() * 100 + 1, r.NextDouble() * 100 + 1);
            }

            double[] expectedAreas = triangles.Select(x =>
            {
                double s = (x.SideA + x.SideB + x.SideC) / 2;
                return Math.Sqrt(s * (s - x.SideA) * (s - x.SideB) * (s - x.SideC));
            }).ToArray();
            var libAreas = triangles.Select(x => x.Area).ToArray();

            for (int i = 0; i < expectedAreas.Length; i++)
            {
                Assert.That(libAreas[i], Is.EqualTo(expectedAreas[i]).Within(1e-10));
            }
        }

        [Test]
        public void IsRightTriangle_NotRight()
        {
            var triangle = new Triangle(2, 3, 4);

            Assert.IsFalse(triangle.IsRight);
        }

        [Test]
        public void IsRightTriangle_Right()
        {
            var triangle = new Triangle(3, 4, 5);

            Assert.IsTrue(triangle.IsRight);
        }

        [Test]
        public void NonPositiveSides()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0,0,0));
        }
    }
}
