namespace CalculatorFiguresLib.Figures
{
    public class Triangle : Shape
    {
        public double SideA { get; private set; }
        public double SideB { get; private set; }
        public double SideC { get; private set; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                throw new ArgumentOutOfRangeException(null, "Любая сторона треугольника должна быть положительной");

            // Не совсем понял какого рода проверка нужна
            // Но на всякий добавлю тут проверку, если она тут нужна - раскомментить код
            //var errors = new double[] { SideA + SideB - SideC, SideA + SideC - SideB, SideB + SideC - SideA };
            //if (errors.Where(x => Math.Abs(x) > 1e-10).Any()) 
            //    throw new ArgumentException(null, "Сумма длин любых двух сторон должна быть больше длины третьей стороны");

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }


        protected override double CalculateArea()
        {
            double s = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }

        public bool IsRightTriangle()
        {
            double[] sides = { SideA, SideB, SideC };
            Array.Sort(sides);

            return Math.Abs(Math.Pow(sides[2], 2) - (Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2))) < 1e-10;
        }
    }
}
