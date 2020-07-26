using System.Threading.Tasks;
using MvvmCross.ViewModels;

namespace XamarinNativeExamples.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterCustomAppStart<AppStart>();
        }
    }
}
