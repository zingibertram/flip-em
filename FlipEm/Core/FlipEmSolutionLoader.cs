using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace FlipEm.Core
{
    public class FlipEmSolutionLoader
    {
        public static IEnumerable<Point> GetSolution(FlipEmSettings settings)
        {
            var propertyName = string.Format("{0}_{1}", settings.Step.ToString(), settings.Size);

            var type = typeof(Res.Resource);
            var property = type.GetProperty(propertyName);

            if (property != null)
            {
                var solution = property.GetValue(null, null) as string;
                if (string.IsNullOrEmpty(solution))
                    return null;

                using (var reader = new StringReader(solution))
                {
                    var steps = new List<Point>();

                    var num = int.Parse(reader.ReadLine());
                    for (int i = 0; i < num; ++i)
                    {
                        steps.Add(ParseRow(reader.ReadLine()));
                    }

                    return steps;
                }
            }

            return null;
        }

        private static Point ParseRow(string row)
        {
            var cells = row.Split(' ');
            
            if (row.Length > 1)
            {
                try
                {
                    return new Point(int.Parse(cells[0]), int.Parse(cells[1]));
                }
                catch (FormatException)
                {
                    return new Point();
                }
            }

            return new Point();
        }
    }
}
