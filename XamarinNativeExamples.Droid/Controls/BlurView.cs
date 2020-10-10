using System;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Renderscripts;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.Core.Content;
using Java.Lang;

namespace XamarinNativeExamples.Droid.Controls
{
    /// <summary>
    /// Derived from 500px-android-blur
    /// https://github.com/500px/500px-android-blur
    /// </summary>
    public class BlurView : View
    {
        private int _mDownsampleFactor;
        private Color _mOverlayColor;

        private View _mBlurredView;
        private int _mBlurredViewWidth, _mBlurredViewHeight;

        private bool _mDownsampleFactorChanged;
        private Bitmap _mBitmapToBlur, _mBlurredBitmap;
        private Canvas _mBlurringCanvas;
        private RenderScript _mRenderScript;
        private ScriptIntrinsicBlur _mBlurScript;
        private Allocation _mBlurInput, _mBlurOutput;

        protected BlurView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public BlurView(Context context) : base(context)
        {
            Initialize(context);
        }

        public BlurView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize(context, attrs);
        }

        public BlurView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Initialize(context, attrs);
        }

        public BlurView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Initialize(context, attrs);
        }

        private void Initialize(Context context, IAttributeSet attrs = null)
        {
            InitializeRenderScript(context);

            if (attrs == null) return;

            var defaultBlurRadius = Resources.GetInteger(Resource.Integer.default_blur_radius);
            var defaultDownsampleFactor = Resources.GetInteger(Resource.Integer.default_downsample_factor);

            var a = context.ObtainStyledAttributes(attrs, Resource.Styleable.BlurView);
            SetBlurRadius(a.GetInteger(Resource.Styleable.BlurView_blurRadius, defaultBlurRadius));
            SetDownsampleFactor(a.GetInteger(Resource.Styleable.BlurView_downsampleFactor,
                defaultDownsampleFactor));
            SetOverlayColor(a.GetColor(Resource.Styleable.BlurView_overlayColor, ContextCompat.GetColor(context, Resource.Color.defaultOverlayColor)));
            a.Recycle();
        }

        public void SetBlurredView(View blurredView)
        {
            _mBlurredView = blurredView;
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            if (_mBlurredView == null) return;
            if (Prepare())
            {
                // If the background of the blurred view is a color drawable, we use it to clear
                // the blurring canvas, which ensures that edges of the child views are blurred
                // as well; otherwise we clear the blurring canvas with a transparent color.
                if (_mBlurredView.Background is ColorDrawable drawable)
                {
                    _mBitmapToBlur.EraseColor(drawable.Color);
                }
                else
                {
                    _mBitmapToBlur.EraseColor(Color.Transparent);
                }

                _mBlurredView.Draw(_mBlurringCanvas);
                Blur();

                canvas.Save();
                canvas.Translate(_mBlurredView.GetX() - GetX(), _mBlurredView.GetY() - GetY());
                canvas.Scale(_mDownsampleFactor, _mDownsampleFactor);
                canvas.DrawBitmap(_mBlurredBitmap, 0, 0, null);
                canvas.Restore();
            }
            canvas.DrawColor(_mOverlayColor);
        }

        public void SetBlurRadius(int radius)
        {
            _mBlurScript.SetRadius(radius);
        }

        public void SetDownsampleFactor(int factor)
        {
            if (factor <= 0)
            {
                throw new IllegalArgumentException("Downsample factor must be greater than 0.");
            }

            if (_mDownsampleFactor == factor) return;
            _mDownsampleFactor = factor;
            _mDownsampleFactorChanged = true;
        }

        public void SetOverlayColor(Android.Graphics.Color color)
        {
            _mOverlayColor = color;
        }

        private void InitializeRenderScript(Context context)
        {
            _mRenderScript = RenderScript.Create(context);
            _mBlurScript = ScriptIntrinsicBlur.Create(_mRenderScript, Element.U8_4(_mRenderScript));
        }

        protected bool Prepare()
        {
            var width = _mBlurredView.Width;
            var height = _mBlurredView.Height;

            if (_mBlurringCanvas != null && !_mDownsampleFactorChanged && _mBlurredViewWidth == width &&
                _mBlurredViewHeight == height) return true;
            _mDownsampleFactorChanged = false;

            _mBlurredViewWidth = width;
            _mBlurredViewHeight = height;

            var scaledWidth = width / _mDownsampleFactor;
            var scaledHeight = height / _mDownsampleFactor;

            // The following manipulation is to avoid some RenderScript artifacts at the edge.
            scaledWidth = scaledWidth - scaledWidth % 4 + 4;
            scaledHeight = scaledHeight - scaledHeight % 4 + 4;

            if (_mBlurredBitmap == null
                || _mBlurredBitmap.Width != scaledWidth
                || _mBlurredBitmap.Height != scaledHeight)
            {
                _mBitmapToBlur = Bitmap.CreateBitmap(scaledWidth, scaledHeight,
                    Bitmap.Config.Argb8888);
                if (_mBitmapToBlur == null)
                {
                    return false;
                }

                _mBlurredBitmap = Bitmap.CreateBitmap(scaledWidth, scaledHeight,
                    Bitmap.Config.Argb8888);
                if (_mBlurredBitmap == null)
                {
                    return false;
                }
            }

            _mBlurringCanvas = new Canvas(_mBitmapToBlur);
            _mBlurringCanvas.Scale(1f / _mDownsampleFactor, 1f / _mDownsampleFactor);
            _mBlurInput = Allocation.CreateFromBitmap(_mRenderScript, _mBitmapToBlur,
                Allocation.MipmapControl.MipmapNone, AllocationUsage.Script);
            _mBlurOutput = Allocation.CreateTyped(_mRenderScript, _mBlurInput.Type);
            return true;
        }

        protected void Blur()
        {
            _mBlurInput.CopyFrom(_mBitmapToBlur);
            _mBlurScript.SetInput(_mBlurInput);
            _mBlurScript.ForEach(_mBlurOutput);
            _mBlurOutput.CopyTo(_mBlurredBitmap);
        }

        protected override void OnDetachedFromWindow()
        {
            base.OnDetachedFromWindow();
            _mRenderScript?.Destroy();
        }
    }
}