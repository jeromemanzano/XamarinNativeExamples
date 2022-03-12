using AutoMapper;
using MvvmCross;

namespace XamarinNativeExamples.Core.Managers.Base
{
    internal abstract class BaseManager
    {
        protected BaseManager() 
        {
            Mapper = Mvx.IoCProvider.Resolve<IMapper>();
        }

        protected IMapper Mapper { get; }
    }
}
