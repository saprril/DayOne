namespace Day6OperatorOverload
{
    public class Matrix2D
    {

        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }


        public Matrix2D(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
        }

        public static Matrix2D operator +(Matrix2D matrix1, Matrix2D matrix2)
        {
            return new Matrix2D(matrix1.X1 + matrix2.X1, matrix1.Y1 + matrix2.Y1, matrix1.X2 + matrix2.X2, matrix1.Y2 + matrix2.Y2);
        }

        public static Matrix2D operator -(Matrix2D matrix1, Matrix2D matrix2)
        {
            return new Matrix2D(matrix1.X1 - matrix2.X1, matrix1.Y1 - matrix2.Y1, matrix1.X2 - matrix2.X2, matrix1.Y2 - matrix2.Y2);
        }

        public static Matrix2D operator *(Matrix2D matrix1, Matrix2D matrix2)
        {
            double newX1 = matrix1.X1 * matrix2.X1 + matrix1.Y1 * matrix2.X2;
            double newY1 = matrix1.X1 * matrix2.Y1 + matrix1.Y1 * matrix2.Y2;
            double newX2 = matrix1.X2 * matrix2.X1 + matrix1.Y2 * matrix2.X2;
            double newY2 = matrix1.X2 * matrix2.Y1 + matrix1.Y2 * matrix2.Y2;
            return new Matrix2D(newX1, newY1, newX2, newY2);
        }

        public static Matrix2D operator *(int mult, Matrix2D matrix1)
        {
            return new Matrix2D(matrix1.X1 * mult, matrix1.Y1 * mult, matrix1.X2 * mult, matrix1.Y2 * mult);
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"[[{this.X1}, {this.Y1}],");
            Console.WriteLine($" [{this.X2}, {this.Y2}]]");

        }

    }
}