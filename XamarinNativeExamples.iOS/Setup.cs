using MvvmCross;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Presenters;
using UIKit;
using XamarinNativeExamples.Core;
using XamarinNativeExamples.Core.Services.Interactions;
using XamarinNativeExamples.iOS.Bindings;
using XamarinNativeExamples.iOS.Services;

namespace XamarinNativeExamples.iOS
{
    public class Setup : MvxIosSetup<App>
    {
        protected override IMvxIosViewPresenter CreateViewPresenter()
        {
            return new CustomPresenter(ApplicationDelegate as UIApplicationDelegate, Window);
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.IoCProvider.RegisterSingleton<IDialogService>(() => Mvx.IoCProvider.IoCConstruct<DialogService>());
        }

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);

            registry.RegisterCustomBindingFactory<UITextField>("Filter", view => new TextFieldFilterBinding(view));
        }
    }
}