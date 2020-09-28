using MvvmCross.Platforms.Android.Presenters.Attributes;
using XamarinNativeExamples.Core.ViewModels.Button;
using XamarinNativeExamples.Core.ViewModels.Button.Items;
using XamarinNativeExamples.Droid.Views.Base;

namespace XamarinNativeExamples.Droid.Views.Button
{
    [MvxFragmentPresentation(ActivityHostViewModelType = typeof(ButtonViewModel), FragmentContentId = Resource.Id.button_click_frame)]
    public class ButtonClickFragment : BaseFragment<ButtonClickItemViewModel>
    {
        protected override int LayoutResource => Resource.Layout.fragment_button_click;
    }
}