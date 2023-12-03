namespace Bresenham;

[TestClass]
public class BresenhamLineTests
{
    [TestMethod]
    [DataRow(0, 0, 0, 0)]
    [DataRow(-3, 2, 3, -2)]
    public void TraverseTest(int x, int y, int x2, int y2)
    {
        var resultA = new List<(int x, int y)>();
        var resultC = new (int x, int y)[100].AsSpan();
        BresenhamLine.Traverse(x, y, x2, y2, (x, y) => resultA.Add((x, y)));
        var resultB = BresenhamLine.Traverse(x, y, x2, y2).ToList();
        
            BresenhamLine.Traverse(x, y, x2, y2, ref resultC);

        Assert.IsNotNull(resultA);
        Assert.IsTrue(resultA.Any());
        CollectionAssert.AreEqual(resultA, resultB);
        CollectionAssert.AreEqual(resultA, resultC[..resultA.Count].ToArray());
    }
}