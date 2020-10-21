using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using System;
using System.Threading.Tasks;
using XamarinNativeExamples.Droid.Controls;

namespace XamarinNativeExamples.Droid.Views.Dialogs
{
    public class AlertDialogFragment : DialogFragment
    {
        private BlurView _blurView;
        private TextView _titleView;
        private TextView _messageView;
        private bool _closeOnBackgroundClick;
        

        private Android.Widget.Button _positiveButton;
        private Android.Widget.Button _negativeButton;

        private readonly TaskCompletionSource<bool> _dialogTcs;

        private const string TITLE_ARG = "title";
        private const string MESSAGE_ARG = "message";
        private const string POSITIVE_LABEL_ARG = "positive_label";
        private const string NEGATIVE_LABEL_ARG = "negative_label";

        public AlertDialogFragment()
        {
            _dialogTcs = new TaskCompletionSource<bool>();
        }

        public Task<bool> DailogTask => _dialogTcs.Task;

        public static AlertDialogFragment NewInstance( string title, string message, string positive, string negative, bool closeOnBackgroundClick = true)
        {
            var bundle = new Bundle();
            if (!title.IsNullOrEmpty())
            {
                bundle.PutString(TITLE_ARG, title);
            }
            if (!message.IsNullOrEmpty())
            {
                bundle.PutString(MESSAGE_ARG, message);
            }
            if (!positive.IsNullOrEmpty())
            {
                bundle.PutString(POSITIVE_LABEL_ARG, positive);
            }
            if (!negative.IsNullOrEmpty())
            {
                bundle.PutString(NEGATIVE_LABEL_ARG, negative);
            }

            var fragment = new AlertDialogFragment();
            fragment.Arguments = bundle;

            fragment._closeOnBackgroundClick = closeOnBackgroundClick;

            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var dialogView = inflater.Inflate(Resource.Layout.dialog_alert, null);

            _blurView = dialogView.FindViewById<BlurView>(Resource.Id.dialog_alert_blur_background);
            _blurView.SetBlurredView(Activity.Window.DecorView);
            _blurView.Click += OnBackgroundClick;

            _titleView = dialogView.FindViewById<TextView>(Resource.Id.dialog_alert_title);
            _titleView.Visibility = Arguments.ContainsKey(TITLE_ARG) ? ViewStates.Visible : ViewStates.Gone;
            _titleView.Text = Arguments.GetString(TITLE_ARG, string.Empty);

            _messageView = dialogView.FindViewById<TextView>(Resource.Id.dialog_alert_message);
            _messageView.Visibility = Arguments.ContainsKey(MESSAGE_ARG) ? ViewStates.Visible : ViewStates.Gone;
            _messageView.Text = Arguments.GetString(MESSAGE_ARG, string.Empty);

            _positiveButton = dialogView.FindViewById<Android.Widget.Button>(Resource.Id.dialog_alert_positive_button);
            _positiveButton.Text = Core.Properties.Resources.Ok;
            _positiveButton.Click += OnPositiveClick;

            _negativeButton = dialogView.FindViewById<Android.Widget.Button>(Resource.Id.dialog_alert_negative_button);
            _negativeButton.Visibility = Arguments.ContainsKey(NEGATIVE_LABEL_ARG) ? ViewStates.Visible : ViewStates.Gone;
            _negativeButton.Text = Arguments.GetString(NEGATIVE_LABEL_ARG, string.Empty);
            _negativeButton.Click += OnNegativeClick;

            return dialogView;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetStyle(DialogFragment.StyleNoTitle, Resource.Style.AppTheme_AlertDialog);
        }

        public override void OnStart()
        {
            base.OnStart();
            UpdateLayout();
        }

        public override void OnConfigurationChanged(global::Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);

            UpdateLayout();
            Dialog.Window.SetSoftInputMode(SoftInput.StateAlwaysHidden);
        }

        public override void OnDismiss(IDialogInterface dialog)
        {
            base.OnDismiss(dialog);
            _dialogTcs.TrySetResult(false);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            _positiveButton.Click -= OnPositiveClick;
            _negativeButton.Click -= OnNegativeClick;
            _blurView.Click -= OnBackgroundClick;
        }

        private void OnPositiveClick(object sender, EventArgs e)
        {
            _dialogTcs.TrySetResult(true);
            Dismiss();
        }

        private void OnNegativeClick(object sender, EventArgs e)
        {
            _dialogTcs.TrySetResult(false);
            Dismiss();
        }

        private void OnBackgroundClick(object sender, EventArgs e)
        {
            if (_closeOnBackgroundClick)
            {
                Dismiss();
            }
        }

        private void UpdateLayout()
        {
            int width = ViewGroup.LayoutParams.MatchParent;
            int height = ViewGroup.LayoutParams.MatchParent;
            Dialog.Window.SetLayout(width, height);
            Dialog.Window.SetDimAmount(0.0f);

            Dialog.Window.SetBackgroundDrawable(new ColorDrawable(Color.Transparent));
        }
    }
}