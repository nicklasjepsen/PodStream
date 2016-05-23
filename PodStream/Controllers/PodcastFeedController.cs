using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using PodStream.Models;
using PodStreamService;

namespace PodStream.Controllers
{
    public class PodcastFeedController : Controller
    {

        private readonly IPodcastFeedService podcastFeedService;

        public PodcastFeedController(IPodcastFeedService podcastFeedService)
        {
            if (podcastFeedService == null)
                throw new ArgumentNullException(nameof(podcastFeedService));
            this.podcastFeedService = podcastFeedService;
        }
        
        public ActionResult Index()
        {
            var feed = podcastFeedService.GetFeed("http://www.dr.dk/mu/Feed/harddisken?format=podcast&limit=500");
            if (feed == null)
                return View();

            return View(Mapper.Map<PodcastFeed, Feed>(feed));
        }
    }
}