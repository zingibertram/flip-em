using System;
using System.Collections;
using System.ComponentModel;

namespace Games.Core
{
    public class EnumViewModel
    {
        private Type enumType;

        public IEnumerable Values
        {
            get;
            private set;
        }

        [TypeConverter(typeof(TypeConverter))]
        public Type EnumType
        {
            get
            {
                return this.enumType;
            }
            set
            {
                enumType = value;
                Values = Enum.GetValues(enumType);
            }
        }
    }
}
