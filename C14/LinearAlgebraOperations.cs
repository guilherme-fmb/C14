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
    }
}