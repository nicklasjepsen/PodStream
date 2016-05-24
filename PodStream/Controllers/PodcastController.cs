using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PodStream.Models;
using PodStream.Providers;

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
            var podcast = new Podcast
            {
                AvailableChannels = podcastProvider.GetChannels().Select(c => new SelectListItem { Text = c, Value = c }),
                AvailableShows = new SelectListItem[0]
            };

            return View(podcast);
        }

        public ActionResult GetEpisodes(string xmlUrl)
        {
            var res = podcastFeedService.Get(xmlUrl);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetShows(string name)
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem {Text = "Vælg program", Value = "0"}
            };

            var allShows = podcastProvider.GetShows(name).ToList();
            items.AddRange(allShows.Select(s =>
                new SelectListItem
                {
                    Text = s.Title,
                    Value = s.XmlLink
                }));

            return Json(items, JsonRequestBehavior.AllowGet);
        }
    }
}