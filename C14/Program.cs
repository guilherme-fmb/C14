using MathNet.Numerics.LinearAlgebra;

namespace SimpleAlgebraApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2 vetores 3d
            var v1 = Vector<double>.Build.DenseOfArray(new double[] { 1, 2, 3 });
            var v2 = Vector<double>.Build.DenseOfArray(new double[] { 4, 5, 6 });

            // adição de vetores
            var sum = v1 + v2;

            // produto escalar
            double dot = v1.DotProduct(v2);

            Console.WriteLine("Vetor 1: " + v1);
            Console.WriteLine("Vetor2: " + v2);
            Console.WriteLine("Soma: " + sum);
            Console.WriteLine("Produto escalar: " + dot);

            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
