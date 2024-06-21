namespace CalculatorFiguresLib.Figures
{
    public class Circle : Shape
    {
        /// <summary>
        /// Радиус окружности
        /// </summary>
        public double Radius { get; private set; }

        /// <summary>
        /// Окружность
        /// </summary>
        /// <param name="radius">Радиус окружности. Positive number</param>
        /// <exception cref="ArgumentOutOfRangeException">Если радиус отрицательный</exception>
        public Circle(double radius)
        {
            if (radius <= 0) throw new ArgumentOutOfRangeException(nameof(radius), "Требуется положительное число");

            Radius = radius;
        }

        /// <summary>
        /// Расчитываем площадь круга
        /// </summary>
        /// <returns></returns>
        protected override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
