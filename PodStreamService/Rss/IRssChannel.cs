using System.Collections.Generic;

namespace PodStreamService.Rss
{
	public interface IRssChannel<T>
	{
		List<T> GetRssItems();
	}
}