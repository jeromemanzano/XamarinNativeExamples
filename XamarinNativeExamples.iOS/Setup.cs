using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Presenters;
using UIKit;
using XamarinNativeExamples.Core;
using XamarinNativeExamples.iOS.Bindings;

namespace XamarinNativeExamples.iOS
{
    public class Setup : MvxIosSetup<App>
    {
        protected override IMvxIosViewPresenter CreateViewPresenter()
        {
            return new CustomPresenter(ApplicationDelegate as UIApplicationDelegate, Window);
        }

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);

            registry.RegisterCustomBindingFactory<UITextField>("Filter", view => new TextFieldFilterBinding(view));
        }
    }
}