using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using PodStream;
using PodStream.Controllers;
using PodStream.Core.Models;
using PodStream.Core.Providers;
using PodStream.Core.Providers.Models.PodcastApi;

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
        public void TestGetShows()
        {
            var podcastFeedProvider = new Mock<IPodcastFeedProvider>();
            podcastFeedProvider.Setup(provider => provider.Get(""))
                .Returns(new PodcastFeed
                {
                    FeedItems = new List<PodcastFeedItem>
                    {
                        new PodcastFeedItem()
                    }
                });

            var podcastProvider = new Mock<IPodcastProvider>();
            podcastProvider.Setup(provider => provider.GetShows("testChannel"))
                .Returns(new List<Show> { new Show { Title = "TestTitle", XmlLink = "http://www.dr.dk" } });

            var controller = new PodcastController(podcastFeedProvider.Object, podcastProvider.Object);

            var result = controller.GetShows("testChannel") as JsonResult;
            Assert.IsNotNull(result);
            var listItems = ((IEnumerable<SelectListItem>) result.Data).ToList();
            Assert.AreEqual(2, listItems.Count());
            Assert.IsNotNull(listItems.Single(li => li.Text == "TestTitle"));
        }

        [Test]
        public void TestGetEpisodes()
        {
            Assert.Inconclusive("Needs to be tested.");
        }

        [Test]
        public void TestFeedItemsAreMapped()
        {
            Assert.Inconclusive("Needs to be tested.");
        }
    }
}
