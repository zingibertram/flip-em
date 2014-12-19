using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Media3D;

namespace Sudoku.Helpers
{
    public static class Itertools
    {
        public static IEnumerable<Point> Product(IEnumerable<int> ls1, IEnumerable<int> ls2)
        {
            return (from x in ls1 from y in ls2 select new Point(x, y)).ToList();
        }

        public static IEnumerable<Point3D> Product(IEnumerable<int> ls1, IEnumerable<int> ls2, IEnumerable<int> ls3)
        {
            return (from x in ls1 from y in ls2 from z in ls3 select new Point3D(x, y, z)).ToList();
        }
    }
}
