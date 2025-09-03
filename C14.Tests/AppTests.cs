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
}