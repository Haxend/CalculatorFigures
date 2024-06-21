namespace CalculatorFiguresLib
{
    public abstract class Shape
    {
        /// <summary>
        /// Вычисляет площадь фигуры
        /// </summary>
        protected abstract double CalculateArea();

        /// <summary>
        /// При первом вызове будет рассчитана площадь фигуры.
        /// </summary>
        protected readonly Lazy<double> _area;

        /// <summary>
        /// Площадь фигуры
        /// </summary>
        /// <exception cref="OverflowException">Когда область фигуры слишком велика, чтобы уместиться в double</exception>
        public double Area
        {
            get
            {
                if (_area.Value <= 0 || double.IsInfinity(_area.Value))
                    throw new OverflowException("Площадь фигуры слишком велика");

                return _area.Value;
            }
        }

        protected Shape() => _area = new Lazy<double>(CalculateArea);
    }
}
