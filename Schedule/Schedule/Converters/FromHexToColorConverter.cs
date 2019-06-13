using System;
using Xamarin.Forms;

namespace Schedule.Converters
{
    [Xamarin.Forms.Xaml.TypeConversion(typeof(Color))]
    public sealed class FromHexToColorConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                return Color.FromHex(value);
            }

            throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" into {1}", value, typeof(Color)));
        }
    }
}
