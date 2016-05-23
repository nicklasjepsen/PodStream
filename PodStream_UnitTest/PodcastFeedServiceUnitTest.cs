using System;
using Moq;
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
            Assert.Throws<ArgumentNullException>(() => 
                new PodcastFeedService(new Mock<IRssService>().Object).GetFeedItems(null));
        }
    }
}
