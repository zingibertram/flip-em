using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Media3D;
using Sudoku.Helpers;

using StrP = System.Tuple<string, System.Windows.Point>;
using StrPColl = System.Collections.Generic.IEnumerable<System.Tuple<string, System.Windows.Point>>;
using StrPCollDict = System.Collections.Generic.Dictionary<System.Windows.Media.Media3D.Point3D, System.Collections.Generic.IEnumerable<System.Tuple<string, System.Windows.Point>>>;
using StrPSetDict = System.Collections.Generic.Dictionary<System.Tuple<string, System.Windows.Point>, System.Collections.Generic.HashSet<System.Windows.Media.Media3D.Point3D>>;
using TuplePSetPcoll = System.Tuple<System.Collections.Generic.Dictionary<System.Tuple<string, System.Windows.Point>, System.Collections.Generic.HashSet<System.Windows.Media.Media3D.Point3D>>, System.Collections.Generic.Dictionary<System.Windows.Media.Media3D.Point3D, System.Collections.Generic.IEnumerable<System.Tuple<string, System.Windows.Point>>>>;

namespace Sudoku.Core
{
    public class FieldSolver
    {
        private static readonly IEnumerable<int> _indicies = Enumerable.Range(0, S.F);
        private static readonly IEnumerable<int> _numbers = Enumerable.Range(1, S.F);

        public static Field Solve(Field source)
        {

            var xList = CreateXList();
            var yDict = CreateYDict();

            var xy = ExactCover(xList, yDict);
            var x = xy.Item1;
            var y = xy.Item2;

            return null;
        }

        private static StrPColl CreateXList()
        {
            var rcList = from rc in Itertools.Product(_indicies, _indicies) select new Tuple<string, Point>("rc", rc);
            var rnList = from rn in Itertools.Product(_indicies, _numbers) select new Tuple<string, Point>("rn", rn);
            var cnList = from cn in Itertools.Product(_indicies, _numbers) select new Tuple<string, Point>("cn", cn);
            var bnList = from bn in Itertools.Product(_indicies, _numbers) select new Tuple<string, Point>("bn", bn);

            return rcList.Concat(rnList).Concat(cnList).Concat(bnList);
        }

        private static StrPCollDict CreateYDict()
        {
            var yDict = new StrPCollDict();
            foreach (var p in Itertools.Product(_indicies, _indicies, _numbers))
            {
                var r = (int)p.X;
                var c = (int)p.Y;
                var n = (int)p.Z;

                var b = (r / S.N) * S.N + c / S.N;

                yDict[p] = new List<Tuple<string, Point>>
                {
                    new Tuple<string, Point>("rc", new Point(r, c)),
                    new Tuple<string, Point>("rn", new Point(r, n)),
                    new Tuple<string, Point>("cn", new Point(c, n)),
                    new Tuple<string, Point>("bn", new Point(b, n)),
                };
            }
            return yDict;
        }

        private static TuplePSetPcoll ExactCover(StrPColl xList, StrPCollDict yDict)
        {
            var xDict = CreateXDict(xList);

            foreach (var y in yDict)
            {
                foreach (var key in y.Value)
                {
                    xDict[key].Add(y.Key);
                }
            }

            return new TuplePSetPcoll(xDict, yDict);
        }

        private static StrPSetDict CreateXDict(IEnumerable<Tuple<string, Point>> x)
        {
            return x.ToDictionary(elem => elem, elem => new HashSet<Point3D>());
        }

        private static void Selection()
        {
            for (int i = 0; i < S.F; ++i)
            {
                for (int j = 0; j < S.F; ++j)
                {
                    
                }
            }
        }
    }
}
