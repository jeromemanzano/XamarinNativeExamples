using System;
using CoreGraphics;

namespace UIKit
{
    public static class UIExtensions
    {
        public static UIImage SetAlpha(this UIImage image, nfloat alpha, CGBlendMode blendMode = CGBlendMode.Normal)
        {
            UIGraphics.BeginImageContextWithOptions(image.Size, false, 0);

            image.Draw(new CGRect(0,0,image.Size.Width, image.Size.Height), blendMode, alpha);

            var newImage = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            return newImage;
        }

        public static UIImage CreateImageFromColor(this UIColor color)
        {
            var imageRect = new CGRect(0, 0, 1f, 1f);

            UIGraphics.BeginImageContextWithOptions(imageRect.Size, false, 0);

            var context = UIGraphics.GetCurrentContext();
            context.SetFillColor(color.CGColor);
            context.FillRect(imageRect);

            var image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            return image;
        }
    }
}