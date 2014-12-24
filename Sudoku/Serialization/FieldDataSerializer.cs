using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Sudoku.Core;

namespace Sudoku.Serialization
{
    public class FieldDataSerializer
    {
        public readonly BinaryFormatter _serialiser;

        public FieldDataSerializer()
        {
            _serialiser = new BinaryFormatter();
        }

        public void Serialize(Stream s, FieldData fd)
        {
            var obj = SerializableFieldData.Get(fd);
            _serialiser.Serialize(s, obj);
        }

        public FieldData Deserialize(Stream s)
        {
            var obj = _serialiser.Deserialize(s) as int[];
            if (obj == null)
            {
                throw new InvalidCastException();
            }

            return SerializableFieldData.Set(obj);
        }
    }
}
