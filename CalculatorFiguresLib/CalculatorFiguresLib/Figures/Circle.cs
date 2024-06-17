namespace CalculatorFiguresLib.Figures
{
    public class Circle : Shape
    {
        public double Radius { get; private set; }

        public Circle(double radius)
        {
            if (radius <= 0) throw new ArgumentOutOfRangeException(nameof(radius), "Требуется положительное число");

            Radius = radius;
        }

        protected override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
