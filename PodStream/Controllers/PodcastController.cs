using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using PodStream.Core.Providers;

namespace PodStream.Controllers
{
    public class PodcastController : Controller
    {
        private readonly IPodcastFeedProvider podcastFeedService;
        private readonly IPodcastProvider podcastProvider;

        public PodcastController(IPodcastFeedProvider podcastFeedService, IPodcastProvider podcastProvider)
        {
            if (podcastFeedService == null)
                throw new ArgumentNullException(nameof(podcastFeedService));
            this.podcastFeedService = podcastFeedService;

            if (podcastProvider == null)
                throw new ArgumentNullException(nameof(podcastProvider));
            this.podcastProvider = podcastProvider;
        }

        public ActionResult Index()
        {
            var podcast = new PodcastModel
            {
                AvailableChannels = podcastProvider.GetChannels().Select(c => new SelectListItem { Text = c, Value = c }),
                AvailableShows = new SelectListItem[0]
            };

            return View(podcast);
        }

        public ActionResult GetShows(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;
            var items = new List<SelectListItem>
            {
                new SelectListItem {Text = "Vælg program", Value = "0"}
            };
            
            items.AddRange(podcastProvider.GetShows(name).Select(s =>
                new SelectListItem
                {
                    Text = s.Title,
                    Value = JsonConvert.SerializeObject(s)
                }));

            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFeedItems(string feedUrl) 
        {
            if (string.IsNullOrEmpty(feedUrl))
                return null;
            var res = podcastFeedService.Get(feedUrl);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}