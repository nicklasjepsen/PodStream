using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PodStream
{
    public class TestableWebClient : IWebClient
    {
        public string DownloadString(string url)
        {
            return new WebClient {Encoding = Encoding.UTF8}.DownloadString(url);
        }
    }
}
