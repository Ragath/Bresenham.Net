namespace Bresenham;

public static class BresenhamLine
{
    public static void Traverse(int x, int y, int x2, int y2, Action<int, int> action)
    {
        var w = x2 - x;
        var h = y2 - y;

        var dx1 = Math.Sign(w);
        var dx2 = dx1;

        var dy1 = Math.Sign(h);
        var dy2 = 0;

        var longest = Math.Abs(w);
        var shortest = Math.Abs(h);
        if (longest <= shortest)
        {
            longest = Math.Abs(h);
            shortest = Math.Abs(w);

            dy2 = dy1;
            dx2 = 0;
        }

        var numerator = longest >> 1;
        for (var i = 0; i <= longest; i++)
        {
            action(x, y);
            numerator += shortest;
            if (numerator < longest)
            {
                x += dx2;
                y += dy2;
            }
            else
            {
                numerator -= longest;
                x += dx1;
                y += dy1;
            }
        }
    }

    public static void Traverse(int x, int y, int x2, int y2, ref Span<(int x, int y)> result)
    {
        var w = x2 - x;
        var h = y2 - y;

        var dx1 = Math.Sign(w);
        var dx2 = dx1;

        var dy1 = Math.Sign(h);
        var dy2 = 0;

        var longest = Math.Abs(w);
        var shortest = Math.Abs(h);
        if (longest <= shortest)
        {
            longest = Math.Abs(h);
            shortest = Math.Abs(w);

            dy2 = dy1;
            dx2 = 0;
        }

        var numerator = longest >> 1;
        for (var i = 0; i <= longest; i++)
        {
            result[i] = (x, y);
            numerator += shortest;
            if (numerator < longest)
            {
                x += dx2;
                y += dy2;
            }
            else
            {
                numerator -= longest;
                x += dx1;
                y += dy1;
            }
        }
    }

    public static IEnumerable<(int x, int y)> Traverse(int x, int y, int x2, int y2)
    {
        var w = x2 - x;
        var h = y2 - y;

        var dx1 = Math.Sign(w);
        var dx2 = dx1;

        var dy1 = Math.Sign(h);
        var dy2 = 0;

        var longest = Math.Abs(w);
        var shortest = Math.Abs(h);
        if (longest <= shortest)
        {
            longest = Math.Abs(h);
            shortest = Math.Abs(w);

            dy2 = dy1;
            dx2 = 0;
        }

        var numerator = longest >> 1;
        for (var i = 0; i <= longest; i++)
        {
            yield return (x, y);
            numerator += shortest;
            if (numerator < longest)
            {
                x += dx2;
                y += dy2;
            }
            else
            {
                numerator -= longest;
                x += dx1;
                y += dy1;
            }
        }
    }
}