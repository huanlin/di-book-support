using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Unity;
using Unity.Resolution;

namespace Test.ParameterOverrides
{
    public interface IMyWebClientFactory
    {
        IMyWebClient Create(string url);
    }

    public sealed class MyWebClientFactory : IMyWebClientFactory
    {
        private readonly IUnityContainer _container;

        public MyWebClientFactory(IUnityContainer container)
        {
            _container = container;
        }

        IMyWebClient IMyWebClientFactory.Create(string url)
        {
            return _container.Resolve<IMyWebClient>(new ParameterOverride("url", url));
        }
    }
}
