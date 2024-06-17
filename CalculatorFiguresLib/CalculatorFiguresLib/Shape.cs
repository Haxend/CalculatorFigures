namespace CalculatorFiguresLib
{
    public abstract class Shape
    {
        protected abstract double CalculateArea();

        protected readonly Lazy<double> _area;

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
