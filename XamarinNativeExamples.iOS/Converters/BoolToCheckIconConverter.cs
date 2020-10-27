using System;
using System.Globalization;
using MvvmCross.Converters;
using UIKit;

namespace XamarinNativeExamples.iOS.Converters
{
    public class BoolToCheckIconConverter : MvxValueConverter<bool, UIImage>
    {
        protected override UIImage Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return value ? UIImage.FromBundle("CheckIcon") : UIImage.FromBundle("CrossIcon");
        }
    }
}