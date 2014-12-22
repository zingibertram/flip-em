using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Media3D;
using Sudoku.Helpers;

using StrP = System.Tuple<string, System.Windows.Point>;
using StrPColl = System.Collections.Generic.List<System.Tuple<string, System.Windows.Point>>;
using StrPCollDict = System.Collections.Generic.Dictionary<System.Windows.Media.Media3D.Point3D, System.Collections.Generic.List<System.Tuple<string, System.Windows.Point>>>;
using StrPSetDict = System.Collections.Generic.Dictionary<System.Tuple<string, System.Windows.Point>, System.Collections.Generic.HashSet<System.Windows.Media.Media3D.Point3D>>;
using TuplePSetPcoll = System.Tuple<System.Collections.Generic.Dictionary<System.Tuple<string, System.Windows.Point>, System.Collections.Generic.HashSet<System.Windows.Media.Media3D.Point3D>>, System.Collections.Generic.Dictionary<System.Windows.Media.Media3D.Point3D, System.Collections.Generic.List<System.Tuple<string, System.Windows.Point>>>>;
using P3DSet = System.Collections.Generic.HashSet<System.Windows.Media.Media3D.Point3D>;
using P3DSetColl = System.Collections.Generic.List<System.Collections.Generic.HashSet<System.Windows.Media.Media3D.Point3D>>;

namespace Sudoku.Core
{
    public class FieldSolver
    {
        private static readonly IEnumerable<int> _indicies = Enumerable.Range(0, S.F);
        private static readonly IEnumerable<int> _numbers = Enumerable.Range(1, S.F);
        public static Int64 iterCnt;

        public static IEnumerable<Field> Solve(Field source)
        {
            var field = new Field(source);

            var xList = CreateXList();
            var yDict = CreateYDict();

            var xy = ExactCover(xList, yDict);
            var x = xy.Item1;
            var y = xy.Item2;

            Selection(field, x, y);

            foreach (var solution in Solve(x, y, new List<Point3D>()))
            {
                foreach (var point3D in solution)
                {
                    var r = (int)point3D.X;
                    var c = (int)point3D.Y;
                    var n = (int)point3D.Z;
                    field[r, c] = n;
                }
                yield return field;
            }
        }

        private static StrPColl CreateXList()
        {
            var rcList = from rc in Itertools.Product(_indicies, _indicies) select new Tuple<string, Point>("rc", rc);
            var rnList = from rn in Itertools.Product(_indicies, _numbers) select new Tuple<string, Point>("rn", rn);
            var cnList = from cn in Itertools.Product(_indicies, _numbers) select new Tuple<string, Point>("cn", cn);
            var bnList = from bn in Itertools.Product(_indicies, _numbers) select new Tuple<string, Point>("bn", bn);

            return rcList.Concat(rnList).Concat(cnList).Concat(bnList).ToList();
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

        private static void Selection(Field f, StrPSetDict xDict, StrPCollDict yDict)
        {
            for (int i = 0; i < S.F; ++i)
            {
                for (int j = 0; j < S.F; ++j)
                {
                    if (f[i, j] != 0)
                    {
                        Select(xDict, yDict, new Point3D(i, j, f[i, j]));
                        iterCnt++;
                    }
                }
            }
        }

        private static P3DSetColl Select(StrPSetDict xDict, StrPCollDict yDict, Point3D row)
        {
            var cols = new P3DSetColl();
            foreach (var j in yDict[row])
            {
                foreach (var i in xDict[j])
                {
                    foreach (var k in yDict[i])
                    {
                        if (!k.Equals(j))
                        {
                            xDict[k].Remove(i);
                            iterCnt++;
                        }
                    }
                }
                cols.Add(xDict[j]);
                xDict.Remove(j);
            }
            return cols;
        }

        private static void Deselect(StrPSetDict xDict, StrPCollDict yDict, Point3D row, P3DSetColl cols)
        {
            for (int l = yDict[row].Count - 1; l >= 0; --l)
            {
                var j = yDict[row][l];
                xDict[j] = cols.Last();
                cols.Remove(xDict[j]);
                foreach (var i in xDict[j])
                {
                    foreach (var k in yDict[i])
                    {
                        if (!k.Equals(j))
                        {
                            xDict[k].Add(i);
                            iterCnt++;
                        }
                    }
                }
            }
        }

        private static IEnumerable<IEnumerable<Point3D>> Solve(StrPSetDict xDict, StrPCollDict yDict, List<Point3D> solution)
        {
            if (xDict == null || xDict.Count == 0)
            {
                yield return solution;
            }
            else
            {
                var c = xDict.Min(elem => elem.Value.Count);
                List<Point3D> row = null;
                foreach (var x in xDict)
                {
                    if (c == 0)
                    {
                        row = x.Value.ToList();
                        break;
                    }
                    c--;
                }
                foreach (var r in row)
                {
                    solution.Add(r);
                    var cols = Select(xDict, yDict, r);
                    foreach (var s in Solve(xDict, yDict, solution))
                    {
                        yield return s;
                    }
                    Deselect(xDict, yDict, r, cols);
                    solution.RemoveAt(solution.Count - 1);
                    iterCnt++;
                }
            }
        }
    }
}
