using System;
using System.Globalization;
using MvvmCross.Converters;

namespace XamarinNativeExamples.Droid.Converters
{
    public class BoolToCheckIconConverter : MvxValueConverter<bool, int>
    {
        protected override int Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return value ? Resource.Drawable.ic_check : Resource.Drawable.ic_cross;
        }
    }
}