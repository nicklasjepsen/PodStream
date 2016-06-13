using System.Collections.Generic;

namespace PodStream.Core.Providers.Models.Rss
{
	public interface IRssChannel<T>
	{
		List<T> GetRssItems();
	}
}