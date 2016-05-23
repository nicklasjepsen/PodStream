using System;
using System.Linq;
using NUnit.Framework;
using PodStreamService;

namespace PodStream_UnitTest
{
    [TestFixture]
    public class RssServiceUnitTest
    {
        private const string ValidFeedUrl = "http://www.dr.dk/mu/Feed/harddisken?format=podcast&limit=500";
        private const string InvalidFeedUrl = "http://dr.dk/podcast404";

        [Test]
        public void TestGetRssItems_InvalidUrl()
        {
            // Assert both empty and null url throws
            Assert.Throws<ArgumentException>(() =>new RssService().GetFeedItems(null));
            Assert.Throws<ArgumentException>(() => new RssService().GetFeedItems(""));
        }

        [Test]
        public void TestGetRssItems_NotFound()
        {
            // Returns null if url is not found
            Assert.AreEqual(null, new RssService().GetFeedItems(InvalidFeedUrl));
        }

        [Test]
        public void TestGetRssItems()
        {
            var rssItems = new RssService().GetFeedItems(ValidFeedUrl);

            Assert.IsNotNull(rssItems);
            Assert.IsNotNull(rssItems.GetRssChannels());
            Assert.IsNotNull(rssItems.GetRssChannels().First());
            Assert.IsTrue(rssItems.GetRssChannels().First().RssItems.Count > 0);
        }
    }
}
