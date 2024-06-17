using CalculatorFiguresLib.Figures;

namespace CalculatorFiguresLib.UnitTest
{
    [TestFixture]
    public class CircleTest
    {
        [Test]
        public void CircleArea()
        {
            Random r = new Random();
            var circle = new Circle[10];
            for (int i = 0; i < circle.Length; i++)
            {
                circle[i] = new Circle(r.NextDouble() * 100 + 1);
            }

            double[] expectedAreas = circle.Select(x => Math.Pow(x.Radius, 2) * Math.PI).ToArray();
            double[] libAreas = circle.Select(x => x.Area).ToArray();

            for (int i = 0; i < expectedAreas.Length; i++)
            {
                Assert.That(libAreas[i], Is.EqualTo(expectedAreas[i]).Within(1e-10));
            }
        }

        [Test]
        public void NonPositiveRadius()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(0));
        }
    }
}
