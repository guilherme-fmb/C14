using MathNet.Numerics.LinearAlgebra;

namespace SimpleAlgebraApp
{
    class Program
    {
        static Vector<double> FuncaoProdutoVetorial(Vector<double> a, Vector<double> b)
        {
            return Vector<double>.Build.DenseOfArray(new double[]
            {
                a[1]*b[2] - a[2]*b[1],
                a[2]*b[0] - a[0]*b[2],
                a[0]*b[1] - a[1]*b[0]
            });
        }

        static void Main(string[] args)
        {
            var v1 = Vector<double>.Build.DenseOfArray(new double[] { 1, 2, 3 });
            var v2 = Vector<double>.Build.DenseOfArray(new double[] { 4, 5, 6 });

            var matrix = Matrix<double>.Build.DenseOfArray(new double[,]
            {
                { 1, 0, 2 },
                { 0, 1, 0 },
                { -1, 0, 1 }
            });

            var sum = v1 + v2;
            double dot = v1.DotProduct(v2);
            var cross = FuncaoProdutoVetorial(v1, v2);
            var transformed = matrix * v1; // multiplicando matriz por vetor
            double normV1 = v1.L2Norm();
            double normV2 = v2.L2Norm();


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
