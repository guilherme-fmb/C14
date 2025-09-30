using MathNet.Numerics.LinearAlgebra;

namespace C14
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

        public Vector<double> Subtract(Vector<double> a, Vector<double> b)
        {
            return a - b;
        }

        public Vector<double> Scale(Vector<double> v, double s)
        {
            return s * v;
        }

        public Vector<double> Normalize(Vector<double> v)
        {
            var n = v.L2Norm();
            if (n == 0) throw new ArgumentException("Vetor nulo não pode ser normalizado.");
            return v / n;
        }

        public double Angle(Vector<double> a, Vector<double> b)
        {
            var na = a.L2Norm();
            var nb = b.L2Norm();
            if (na == 0 || nb == 0) throw new ArgumentException("Vetores nulos não possuem ângulo definido.");
            var cos = a.DotProduct(b) / (na * nb);
            if (cos > 1) cos = 1;
            if (cos < -1) cos = -1;
            return Math.Acos(cos);
        }

        public Vector<double> Projection(Vector<double> a, Vector<double> b)
        {
            var denom = b.DotProduct(b);
            if (denom == 0) throw new ArgumentException("Projeção indefinida para vetor nulo.");
            var factor = a.DotProduct(b) / denom;
            return factor * b;
        }

        public double Distance(Vector<double> a, Vector<double> b)
        {
            return (a - b).L2Norm();
        }

        public Vector<double> Hadamard(Vector<double> a, Vector<double> b)
        {
            return a.PointwiseMultiply(b);
        }

        public Matrix<double> OuterProduct(Vector<double> a, Vector<double> b)
        {
            return a.OuterProduct(b);
        }

        public double Determinant(Matrix<double> m)
        {
            return m.Determinant();
        }

        public Matrix<double> Inverse(Matrix<double> m)
        {
            return m.Inverse();
        }

        public int Rank(Matrix<double> m)
        {
            return m.Rank();
        }

        public Vector<double> Solve(Matrix<double> a, Vector<double> b)
        {
            return a.Solve(b);
        }

        public bool IsOrthogonal(Vector<double> a, Vector<double> b, double tolerance = 1e-10)
        {
            return Math.Abs(a.DotProduct(b)) <= tolerance;
        }

        public bool IsCollinear(Vector<double> a, Vector<double> b, double tolerance = 1e-10)
        {
            var bb = b.DotProduct(b);
            if (bb == 0) return a.DotProduct(a) == 0;
            var lambda = a.DotProduct(b) / bb;
            return (a - lambda * b).L2Norm() <= tolerance;
        }
    }
}
