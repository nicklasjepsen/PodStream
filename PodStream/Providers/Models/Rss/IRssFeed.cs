using System.Collections.Generic;

namespace PodStream.Providers.Models.Rss
{
	public interface IRssFeed<T>
	{
		List<T> GetRssChannels();
	}
}