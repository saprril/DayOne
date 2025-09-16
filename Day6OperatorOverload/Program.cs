namespace Day6OperatorOverload
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix2D identityMatrix = new Matrix2D(1.0, 0.0, 0.0, 1.0);
            Matrix2D randomMatrix = new Matrix2D(1.0, 2.0, 3.0, 4.0);

            Matrix2D multipliedMatrix = randomMatrix * identityMatrix;
            multipliedMatrix.DisplayInfo();

            Matrix2D addedMatrix = randomMatrix + randomMatrix;
            addedMatrix.DisplayInfo();

            Matrix2D addedMatrix1 = 2 * randomMatrix;
            addedMatrix1.DisplayInfo();
        }   
    }
}