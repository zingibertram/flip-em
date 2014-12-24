using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Core
{
    [Serializable]
    public class FieldData
    {
        private readonly Field _source;
        private readonly Field _field;

        public FieldData()
        {
            _source = FieldGenerator.Generate();
            _field = FieldStriker.StrikeOut(_source);
        }

        public FieldData(Field f, Field s)
        {
            _field = f;
            _source = s;
        }

        public Field Source
        {
            get { return _source; }
        }

        public Field Field
        {
            get { return _field; }
        }
    }
}
