using MathNet.Numerics.LinearAlgebra;

namespace C14
{
    class Program
    {
        /// <summary>
        /// Requere um vetor dentro do padrão inferido. Persiste até o usuário digitar o vetor de input corretamente.
        /// </summary>
        /// <returns></returns>
        static Vector<double> ReadVectorCorrectInput()
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Entrada vazia. Tente novamente.");
                    continue;
                }
                var parts = input.Split(',');
                if (parts.Length != 3)
                {
                    Console.WriteLine("Por favor, informe exatamente 3 valores separados por vírgula.");
                    continue;
                }
                try
                {
                    var nums = new double[3];
                    for (int i = 0; i < 3; i++) nums[i] = double.Parse(parts[i].Trim(), System.Globalization.CultureInfo.InvariantCulture);

                    return Vector<double>.Build.DenseOfArray(nums);
                }
                catch
                {
                    Console.WriteLine("Valores inválidos. Use números (ex.: 1, 2.5, -3). Tente novamente.");
                }
            }
        }

        static void Main(string[] args)
        {
            var operations = new LinearAlgebraOperations();

            Console.WriteLine("Digite o vetor v1 (3 dimensões) separado por vírgulas. Exemplo: 1,2,3");
            Vector<double> v1 = ReadVectorCorrectInput();

            Console.WriteLine("Digite o vetor v2 (3 dimensões) separado por vírgulas. Exemplo: 1,2,3");
            Vector<double> v2 = ReadVectorCorrectInput();

            var sum         = operations.Add(v1, v2);
            var dot         = operations.DotProduct(v1, v2);
            var cross       = operations.CrossProduct(v1, v2);
            var normV1      = operations.Norm(v1);
            var normV2      = operations.Norm(v2);
            var sub         = operations.Subtract(v2, v1);
            var escalar     = operations.Scale(v1, 2);
            var normalizado = operations.Normalize(v1);
            var angulo      = operations.Angle(v1, v2);
            var proj        = operations.Projection(v1, v2);
            var distancia   = operations.Distance(v1, v2);
            var hadamard    = operations.Hadamard(v1, v2);
            var externo     = operations.OuterProduct(v1, v2);
            var ortogonal   = operations.IsOrthogonal(v1, v2);
            var colinear    = operations.IsCollinear(v1, v2);

            Console.WriteLine("Vetor 1: " + v1);
            Console.WriteLine("Vetor 2: " + v2);
            Console.WriteLine("Soma: " + sum);
            Console.WriteLine("Produto escalar: " + dot);
            Console.WriteLine("Produto vetorial: " + cross);
            Console.WriteLine("Norma do vetor 1: " + normV1);
            Console.WriteLine("Norma do vetor 2: " + normV2);
            Console.WriteLine("Subtração (v2 - v1): " + sub);
            Console.WriteLine("Escalonamento (2*v1): " + escalar);
            Console.WriteLine("Normalização de v1: " + normalizado);
            Console.WriteLine("Ângulo entre v1 e v2 (rad): " + angulo);
            Console.WriteLine("Projeção de v1 em v2: " + proj);
            Console.WriteLine("Distância entre v1 e v2: " + distancia);
            Console.WriteLine("Produto de Hadamard: " + hadamard);
            Console.WriteLine("Produto externo (matriz):\n" + externo);
            Console.WriteLine("v1 e v2 são ortogonais? " + ortogonal);
            Console.WriteLine("v1 e v2 são colineares? " + colinear);

            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
