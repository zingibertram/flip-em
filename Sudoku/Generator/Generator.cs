using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using Sudoku.Serialization;

namespace Sudoku.Core
{
    public class Generator
    {
        public static void Generate(int count = 10)
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var serializer = new FieldDataSerializer();
            for (int i = 0; i < count; ++i)
            {
                var data = new FieldData();
                using (var fstream = File.Create(Path.Combine(dir, string.Format("games\\field_{0}.sfd", i))))
                {
                    serializer.Serialize(fstream, data);
                }
            }
        }
    }
}
