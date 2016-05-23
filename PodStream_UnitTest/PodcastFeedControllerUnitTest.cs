using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using PodStream;
using PodStream.Controllers;
using PodStream.Models;
using PodStreamService;

namespace PodStream_UnitTest
{
    [TestFixture]
    public class PodcastFeedControllerUnitTest
    {
        [SetUp]
        public void Init()
        {
            Automap.ConfigureAutoMapper();
        }

        [Test]
        public void TestFeedItemsAreMapped()
        {
            Assert.Inconclusive("Needs to be tested.");
            //var serviceMock = new Mock<IPodcastFeedService>();
            //serviceMock.Setup(sm => sm.GetFeed(""))
            //    .Returns(new PodcastFeed
            //    {
            //        FeedItems = new List<PodcastServiceFeedItem>
            //        {
            //            new PodcastServiceFeedItem()
            //        }
            //    });
            //var controller = new PodcastFeedController(serviceMock.Object);
            //var result = controller.Index() as ViewResult;
            //Assert.IsInstanceOf<FeedItem>(result.Model);
        }
    }
}
