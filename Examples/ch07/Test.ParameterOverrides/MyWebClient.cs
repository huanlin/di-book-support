using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ParameterOverrides
{

    public interface IMyWebClient
    {
        string DownloadString();
    }

    public class MyWebClient : IMyWebClient
    {
        private readonly string _url;

        public MyWebClient(string url)
        {
            _url = url;
        }

        string IMyWebClient.DownloadString()
        {
            return $"Downloaded content from {_url}";
        }
    }
}
