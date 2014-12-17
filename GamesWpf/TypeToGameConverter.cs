using System;
using System.Windows.Data;
using Games.Core;

namespace GamesWpf
{
    public class TypeToGameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value == null ? null : value.GetType();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var type = value as IGameInfo;
            if (type != null)
            {
                var content = Activator.CreateInstance(type.ContentType) as IGameViews;
                if (content == null)
                    return null;

                content.Title = type.Name;
                return content;
            }
            return null;
        }
    }
}
