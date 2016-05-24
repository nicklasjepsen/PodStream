using System.Collections.Generic;

namespace PodStream.Providers.Models.Rss
{
	public interface IRssChannel<T>
	{
		List<T> GetRssItems();
	}
}