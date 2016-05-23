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
            return View(Mapper.Map<IEnumerable<PodcastServiceFeedItem>, List<FeedItem>>(
                podcastFeedService.GetFeedItems("")));
        }
    }
}