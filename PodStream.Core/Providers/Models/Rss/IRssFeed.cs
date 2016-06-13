using System.Collections.Generic;

namespace PodStream.Core.Providers.Models.Rss
{
	public interface IRssFeed<T>
	{
		List<T> GetRssChannels();
	}
}