using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FlipEm.Core
{
    public enum StepType
    {
        Cross,
        BorderCross,
        DiagonalCross,
        BorderDiagonalCross,
        Border,
        Square,
    }

    public class NeighbourHelper
    {
        public static Point[] GetAll(int i, int j, StepType t)
        {
            switch (t)
            {
                case StepType.Cross:
                    return new Point[]
                    {
                        new Point(i - 1, j),
                        new Point(i, j - 1),
                        new Point(i + 1, j),
                        new Point(i, j + 1),
                    };
                case StepType.BorderCross :
                    return new Point[]
                    {
                        new Point(i, j),
                        new Point(i - 1, j),
                        new Point(i, j - 1),
                        new Point(i + 1, j),
                        new Point(i, j + 1),
                    };
                case StepType.DiagonalCross:
                    return new Point[]
                    {
                        new Point(i - 1, j - 1),
                        new Point(i + 1, j - 1),
                        new Point(i + 1, j + 1),
                        new Point(i - 1, j + 1),
                    };
                case StepType.BorderDiagonalCross :
                    return new Point[]
                    {
                        new Point(i, j),
                        new Point(i - 1, j - 1),
                        new Point(i + 1, j - 1),
                        new Point(i + 1, j + 1),
                        new Point(i - 1, j + 1),
                    };
                case StepType.Square:
                    return new Point[]
                    {
                        new Point(i - 1, j),
                        new Point(i, j - 1),
                        new Point(i + 1, j),
                        new Point(i, j + 1),
                        new Point(i - 1, j - 1),
                        new Point(i + 1, j - 1),
                        new Point(i + 1, j + 1),
                        new Point(i - 1, j + 1),
                    };
                case StepType.Border :
                    return new Point[]
                    {
                        new Point(i, j),
                        new Point(i - 1, j),
                        new Point(i, j - 1),
                        new Point(i + 1, j),
                        new Point(i, j + 1),
                        new Point(i - 1, j - 1),
                        new Point(i + 1, j - 1),
                        new Point(i + 1, j + 1),
                        new Point(i - 1, j + 1),
                    };
                default :
                    return new Point[] { };
            }
        }

        public static IEnumerable<Point> GetNeighbours(int size, int i, int j, StepType t)
        {
            return GetAll(i, j, t).Where(p => -1 < p.X && p.X < size && -1 < p.Y && p.Y < size);
        }

        public static bool IsSelfChecked(StepType step)
        {
            return step == StepType.Cross || step == StepType.DiagonalCross || step == StepType.Square;
        }

    }
}