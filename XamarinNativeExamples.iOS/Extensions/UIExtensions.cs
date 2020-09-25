using System;
using CoreGraphics;

namespace UIKit
{
    public static class UIExtensions
    {
        public static UIImage Blend(this UIImage image, nfloat alpha, CGColor fillColor, CGBlendMode blendMode = CGBlendMode.Normal)
        {
            UIGraphics.BeginImageContextWithOptions(image.Size, false, 0);

            var rect = new CGRect(0, 0, image.Size.Width, image.Size.Height);

            if (fillColor != null)
            {
                var context = UIGraphics.GetCurrentContext();
                context.SetFillColor(fillColor);
                context.FillRect(rect);
            }

            image.Draw(rect, blendMode, alpha);

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