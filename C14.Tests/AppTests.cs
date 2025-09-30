using MathNet.Numerics.LinearAlgebra;
using Xunit;
using C14;
using System;

public class LinearAlgebraOperationsTests
{
    private readonly LinearAlgebraOperations ops = new LinearAlgebraOperations();

    // ---------------- POSITIVE TESTS ----------------

    [Fact]
    public void Test_Addition()
    {
        var v1 = Vector<double>.Build.DenseOfArray(new double[] { 1, 2, 3 });
        var v2 = Vector<double>.Build.DenseOfArray(new double[] { 4, 5, 6 });
        var result = ops.Add(v1, v2);

        Assert.Equal(new double[] { 5, 7, 9 }, result.ToArray());
    }

    [Fact]
    public void Test_DotProduct()
    {
        var v1 = Vector<double>.Build.DenseOfArray(new double[] { 1, 2, 3 });
        var v2 = Vector<double>.Build.DenseOfArray(new double[] { 4, 5, 6 });
        var dot = ops.DotProduct(v1, v2);

        Assert.Equal(32, dot, 5);
    }

    [Fact]
    public void Test_CrossProduct()
    {
        var v1 = Vector<double>.Build.DenseOfArray(new double[] { 1, 2, 3 });
        var v2 = Vector<double>.Build.DenseOfArray(new double[] { 4, 5, 6 });
        var cross = ops.CrossProduct(v1, v2);

        Assert.Equal(new double[] { -3, 6, -3 }, cross.ToArray());
    }

    [Fact]
    public void Test_Transform()
    {
        var matrix = Matrix<double>.Build.DenseOfArray(new double[,]
        {
            { 1, 0, 2 },
            { 0, 1, 0 },
            { -1, 0, 1 }
        });
        var v = Vector<double>.Build.DenseOfArray(new double[] { 1, 2, 3 });
        var transformed = ops.Transform(matrix, v);

        Assert.Equal(new double[] { 7, 2, 2 }, transformed.ToArray());
    }

    [Fact]
    public void Test_Norm()
    {
        var v = Vector<double>.Build.DenseOfArray(new double[] { 1, 2, 2 });
        var norm = ops.Norm(v);

        Assert.Equal(3, norm, 5);
    }

    // ---------------- NEGATIVE TESTS ----------------

    [Fact]
    public void Add_MismatchedVectorSizes_Throws()
    {
        var v1 = Vector<double>.Build.DenseOfArray(new double[] { 1, 2 });
        var v2 = Vector<double>.Build.DenseOfArray(new double[] { 3, 4, 5 });

        Assert.Throws<ArgumentException>(() => ops.Add(v1, v2));
    }

    [Fact]
    public void Transform_InvalidMatrixDimensions_Throws()
    {
        var matrix = Matrix<double>.Build.DenseOfArray(new double[,] { { 1, 2 }, { 3, 4 } });
        var v = Vector<double>.Build.DenseOfArray(new double[] { 1, 2, 3 });

        Assert.Throws<ArgumentException>(() => ops.Transform(matrix, v));
    }

    [Fact]
    public void Test_Subtract()
    {
        var v1 = Vector<double>.Build.DenseOfArray(new double[] { 4, 5, 6 });
        var v2 = Vector<double>.Build.DenseOfArray(new double[] { 1, 2, 3 });
        var result = ops.Subtract(v1, v2);
        Assert.Equal(new double[] { 3, 3, 3 }, result.ToArray());
    }

    [Fact]
    public void Test_Scale()
    {
        var v = Vector<double>.Build.DenseOfArray(new double[] { 1, -2, 3 });
        var r = ops.Scale(v, 2.5);
        Assert.Equal(new double[] { 2.5, -5, 7.5 }, r.ToArray());
    }

    [Fact]
    public void Test_Normalize()
    {
        var v = Vector<double>.Build.DenseOfArray(new double[] { 3, 4, 0 });
        var n = ops.Normalize(v);
        Assert.Equal(1, n.L2Norm(), 8);
    }

    [Fact]
    public void Normalize_ZeroVector_Throws()
    {
        var v = Vector<double>.Build.DenseOfArray(new double[] { 0, 0, 0 });
        Assert.Throws<ArgumentException>(() => ops.Normalize(v));
    }

    [Fact]
    public void Test_Angle()
    {
        var a = Vector<double>.Build.DenseOfArray(new double[] { 1, 0, 0 });
        var b = Vector<double>.Build.DenseOfArray(new double[] { 0, 1, 0 });
        var ang = ops.Angle(a, b);
        Assert.Equal(Math.PI / 2, ang, 8);
    }

    [Fact]
    public void Angle_WithZeroVector_Throws()
    {
        var a = Vector<double>.Build.DenseOfArray(new double[] { 0, 0, 0 });
        var b = Vector<double>.Build.DenseOfArray(new double[] { 1, 0, 0 });
        Assert.Throws<ArgumentException>(() => ops.Angle(a, b));
    }

    [Fact]
    public void Test_Projection()
    {
        var a = Vector<double>.Build.DenseOfArray(new double[] { 1, 2, 3 });
        var b = Vector<double>.Build.DenseOfArray(new double[] { 1, 0, 0 });
        var p = ops.Projection(a, b);
        Assert.Equal(new double[] { 1, 0, 0 }, p.ToArray());
    }

    [Fact]
    public void Projection_OntoZero_Throws()
    {
        var a = Vector<double>.Build.DenseOfArray(new double[] { 1, 2, 3 });
        var b = Vector<double>.Build.DenseOfArray(new double[] { 0, 0, 0 });
        Assert.Throws<ArgumentException>(() => ops.Projection(a, b));
    }

    [Fact]
    public void Test_Distance()
    {
        var a = Vector<double>.Build.DenseOfArray(new double[] { 1, 2, 3 });
        var b = Vector<double>.Build.DenseOfArray(new double[] { 4, 6, 3 });
        var d = ops.Distance(a, b);
        Assert.Equal(5, d, 8);
    }

    [Fact]
    public void Test_Hadamard()
    {
        var a = Vector<double>.Build.DenseOfArray(new double[] { 1, 2, 3 });
        var b = Vector<double>.Build.DenseOfArray(new double[] { 4, 5, 6 });
        var h = ops.Hadamard(a, b);
        Assert.Equal(new double[] { 4, 10, 18 }, h.ToArray());
    }

    [Fact]
    public void Test_OuterProduct()
    {
        var a = Vector<double>.Build.DenseOfArray(new double[] { 1, 2 });
        var b = Vector<double>.Build.DenseOfArray(new double[] { 3, 4, 5 });
        var m = ops.OuterProduct(a, b);
        Assert.Equal(new double[,] { { 3, 4, 5 }, { 6, 8, 10 } }, m.ToArray());
    }

    [Fact]
    public void Test_Determinant()
    {
        var m = Matrix<double>.Build.DenseOfArray(new double[,] { { 1, 2 }, { 3, 4 } });
        var det = ops.Determinant(m);
        Assert.Equal(-2, det, 8);
    }

    [Fact]
    public void Test_Inverse()
    {
        var m = Matrix<double>.Build.DenseOfArray(new double[,] { { 4, 7 }, { 2, 6 } });
        var inv = ops.Inverse(m);
        var id = m * inv;
        var diff = id - Matrix<double>.Build.DenseIdentity(2);
        Assert.True(diff.InfinityNorm() < 1e-8);
    }

    [Fact]
    public void Test_Rank()
    {
        var m = Matrix<double>.Build.DenseOfArray(new double[,] { { 1, 2 }, { 2, 4 } });
        var r = ops.Rank(m);
        Assert.Equal(1, r);
    }

    [Fact]
    public void Test_IsOrthogonal()
    {
        var a = Vector<double>.Build.DenseOfArray(new double[] { 1, 0, 0 });
        var b = Vector<double>.Build.DenseOfArray(new double[] { 0, 1, 0 });
        Assert.True(ops.IsOrthogonal(a, b));
    }

    [Fact]
    public void Test_IsCollinear()
    {
        var a = Vector<double>.Build.DenseOfArray(new double[] { 2, 4, 6 });
        var b = Vector<double>.Build.DenseOfArray(new double[] { 1, 2, 3 });
        Assert.True(ops.IsCollinear(a, b));
    }

    [Fact]
    public void IsOrthogonal_False()
    {
        var a = Vector<double>.Build.DenseOfArray(new double[] { 1, 1, 0 });
        var b = Vector<double>.Build.DenseOfArray(new double[] { 1, 0, 0 });
        Assert.False(ops.IsOrthogonal(a, b));
    }

    [Fact]
    public void IsCollinear_False()
    {
        var a = Vector<double>.Build.DenseOfArray(new double[] { 1, 2, 3 });
        var b = Vector<double>.Build.DenseOfArray(new double[] { 1, 2, 4 });
        Assert.False(ops.IsCollinear(a, b));
    }
}
