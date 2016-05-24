namespace PodStream
{
    public interface IWebClient
    {
        string DownloadString(string url);
    }
}