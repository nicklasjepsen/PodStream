using System;
using NUnit.Framework;
using PodStreamService;

namespace PodStream_UnitTest
{
    [TestFixture]
    public class RssServiceUnitTest
    {
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
            Assert.AreEqual(null, new RssService().GetFeedItems("http://dr.dk/podcasts404"));
        }
    }
}
