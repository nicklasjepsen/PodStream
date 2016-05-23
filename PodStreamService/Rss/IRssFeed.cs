using System.Collections.Generic;

namespace PodStreamService.Rss
{
	public interface IRssFeed<T>
	{
		List<T> GetRssChannels();
	}
}