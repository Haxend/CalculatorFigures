namespace CalculatorFiguresLib.Figures
{
    public class Triangle : Shape
    {
        /// <summary>
        ///  Сторона A
        /// </summary>
        public double SideA { get; private set; }

        /// <summary>
        ///  Сторона B
        /// </summary>
        public double SideB { get; private set; }

        /// <summary>
        ///  Сторона C
        /// </summary>
        public double SideC { get; private set; }

        /// <summary>
        /// True, если треугольник прямоугольный
        /// </summary>
        protected readonly Lazy<bool> _isRight;

        public bool IsRight => _isRight.Value;

        /// <summary>
        /// Треуголник. Три стороны
        /// </summary>
        /// <param name="sideA">Сторона A</param>
        /// <param name="sideB">Сторона B</param>
        /// <param name="sideC">Сторона C</param>
        /// <exception cref="ArgumentOutOfRangeException">Когда какая-либо из сторон не является положительной.</exception>
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                throw new ArgumentOutOfRangeException(null, "Любая сторона треугольника должна быть положительной");

            // Не совсем понял какого рода проверка нужна
            // Но на всякий добавлю тут проверку в виде комментария и в виде метода
            //var errors = new double[] { SideA + SideB - SideC, SideA + SideC - SideB, SideB + SideC - SideA };
            //if (errors.Where(x => Math.Abs(x) > 1e-10).Any()) 
            //    throw new ArgumentException(null, "Сумма длин любых двух сторон должна быть больше длины третьей стороны");

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;

            _isRight = new Lazy<bool>(IsRightTriangle);
        }

        /// <summary>
        /// Расчитываем площадь треугольника по трем сторонам (формула Герона)
        /// </summary>
        /// <returns></returns>
        protected override double CalculateArea()
        {
            double s = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }

        /// <summary>
        /// Проверяет, является ли этот треугольник прямоуголньым
        /// </summary>
        /// <returns>True если трегольник прямоугольный, иначе False</returns>
        protected bool IsRightTriangle()
        {
            double[] sides = { SideA, SideB, SideC };
            Array.Sort(sides);

            return Math.Abs(Math.Pow(sides[2], 2) - (Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2))) < 1e-10;
        }
    }
}
