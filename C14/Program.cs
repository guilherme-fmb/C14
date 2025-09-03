using MathNet.Numerics.LinearAlgebra;

namespace C14
{    
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