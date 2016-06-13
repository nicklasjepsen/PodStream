using System.Net;
using System.Text;

namespace PodStream.Core
{
    public class TestableWebClient : IWebClient
    {
        public string DownloadString(string url)
        {
            return new WebClient {Encoding = Encoding.UTF8}.DownloadString(url);
        }
    }
}
