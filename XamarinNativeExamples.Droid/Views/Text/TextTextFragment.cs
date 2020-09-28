using MvvmCross.Platforms.Android.Presenters.Attributes;
using XamarinNativeExamples.Core.ViewModels.Text;
using XamarinNativeExamples.Core.ViewModels.Text.Items;
using XamarinNativeExamples.Droid.Views.Base;

namespace XamarinNativeExamples.Droid.Views.Text
{
    [MvxFragmentPresentation(ActivityHostViewModelType = typeof(TextViewModel), FragmentContentId = Resource.Id.text_text_frame)]
    public class TextTextFragment : BaseFragment<TextTextItemViewModel>
    {
        protected override int LayoutResource => Resource.Layout.fragment_text_text;
    }
}