using System;
using NUnit.Framework;
using PodStreamService;

namespace PodStream_UnitTest
{
    [TestFixture]
    public class PodcastFeedServiceUnitTest
    {
        [Test]
        public void TestGetFeedItems_ParamIsNull()
        {
            var service = new PodcastFeedService();
            service.GetFeedItems(null);
            Assert.Throws<ArgumentNullException>(() => service.GetFeedItems(null));
        }
    }
}
