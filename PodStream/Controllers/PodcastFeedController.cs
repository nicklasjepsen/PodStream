using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using PodStream.Models;
using PodStream.Providers;

namespace PodStream.Controllers
{
    public class PodcastFeedController : Controller
    {

        private readonly IPodcastFeedProvider podcastFeedService;

        public PodcastFeedController(IPodcastFeedProvider podcastFeedService)
        {
            if (podcastFeedService == null)
                throw new ArgumentNullException(nameof(podcastFeedService));
            this.podcastFeedService = podcastFeedService;
        }
        
        public ActionResult Index()
        {
            var feed = podcastFeedService.Get("http://www.dr.dk/mu/Feed/harddisken?format=podcast&limit=500");
            if (feed == null)
                return View();

            return View(feed);
        }
    }
}