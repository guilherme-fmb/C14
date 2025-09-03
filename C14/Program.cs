using MathNet.Numerics.LinearAlgebra;

namespace SimpleAlgebraApp
{
    public class LinearAlgebraOperations
    {
        public Vector<double> CrossProduct(Vector<double> a, Vector<double> b)
        {
            return Vector<double>.Build.DenseOfArray(new double[]
            {
                a[1] * b[2] - a[2] * b[1],
                a[2] * b[0] - a[0] * b[2],
                a[0] * b[1] - a[1] * b[0]
            });
        }

        public double DotProduct(Vector<double> a, Vector<double> b)
        {
            return a.DotProduct(b);
        }

        public Vector<double> Add(Vector<double> a, Vector<double> b)
        {
            return a + b;
        }
        public Vector<double> Transform(Matrix<double> matrix, Vector<double> vector)
        {
            return matrix * vector;
        }
        public double Norm(Vector<double> v)
        {
            return v.L2Norm();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var operations = new LinearAlgebraOperations();

            var v1 = Vector<double>.Build.DenseOfArray(new double[] { 1, 2, 3 });
            var v2 = Vector<double>.Build.DenseOfArray(new double[] { 4, 5, 6 });
            var matrix = Matrix<double>.Build.DenseOfArray(new double[,]
            {
                { 1, 0, 2 },
                { 0, 1, 0 },
                { -1, 0, 1 }
            });

            var sum = operations.Add(v1, v2);
            var dot = operations.DotProduct(v1, v2);
            var cross = operations.CrossProduct(v1, v2);
            var transformed = operations.Transform(matrix, v1);
            var normV1 = operations.Norm(v1);
            var normV2 = operations.Norm(v2);

            Console.WriteLine("Vetor 1: " + v1);
            Console.WriteLine("Vetor 2: " + v2);
            Console.WriteLine("Soma: " + sum);
            Console.WriteLine("Produto escalar: " + dot);
            Console.WriteLine("Produto vetorial: " + cross);
            Console.WriteLine("Vetor 1 transformado pela matriz: " + transformed);
            Console.WriteLine("Norma do vetor 1: " + normV1);
            Console.WriteLine("Norma do vetor 2: " + normV2);

            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
