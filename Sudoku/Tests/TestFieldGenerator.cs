using System;
using System.Diagnostics;
using Sudoku.Core;

namespace Sudoku.Tests
{
    public class TestFieldGenerator
    {
        public static void TestFielfdGenerator()
        {
            var sw = new Stopwatch();

            for (var i = 0; i < 10; i++)
            {
                sw.Start();

                var source = FieldGenerator.Generate();
                FieldStriker.StrikeOut(source);

                sw.Stop();
                Console.WriteLine("Generating time " + sw.ElapsedMilliseconds / 1000.0 + " sec");
            }
        }
    }
}
