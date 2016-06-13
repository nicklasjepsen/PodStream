namespace PodStream.Core
{
    public interface IWebClient
    {
        string DownloadString(string url);
    }
}