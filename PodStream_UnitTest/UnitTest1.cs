using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using NUnit.Framework;
using PodStreamService;

namespace PodStream_UnitTest
{
    [TestFixture]
    public class PodcastFeedServiceUnitTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetFeedItems_ParamIsNull()
        {
            var service = new PodcastFeedService();
            service.GetFeedItems(null);
        }
    }
}
