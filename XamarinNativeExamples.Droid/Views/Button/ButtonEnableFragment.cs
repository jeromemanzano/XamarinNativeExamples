using MvvmCross.Platforms.Android.Presenters.Attributes;
using XamarinNativeExamples.Core.ViewModels.Button;
using XamarinNativeExamples.Core.ViewModels.Button.Items;
using XamarinNativeExamples.Droid.Views.Base;

namespace XamarinNativeExamples.Droid.Views.Button
{

    [MvxFragmentPresentation(ActivityHostViewModelType = typeof(ButtonViewModel), FragmentContentId = Resource.Id.button_enable_frame)]
    public class ButtonEnableFragment : BaseFragment<ButtonEnableItemViewModel>
    {
        protected override int LayoutResource => Resource.Layout.fragment_button_enable;
    }
}