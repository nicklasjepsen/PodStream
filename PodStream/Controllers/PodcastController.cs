using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using PodStream.Models;
using PodStream.Providers;
using PodStream.Providers.Models.PodcastApi;

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
                AvailableChannels = GetChannels().Select(c => new SelectListItem { Text = c, Value = c }),
                AvailableShows = new SelectListItem[0]
            };

            return View(podcast);

        }

        private IEnumerable<string> GetChannels()
        {
            return podcastProvider.GetChannels();
        }

        //[HttpPost]
        //[Route("Podcast/Episodes/{channel}/{show}")]
        public ActionResult GetEpisodes(string xmlUrl)
        {
            //if (!shows.ContainsKey(show))
            //    return HttpNotFound();
            //return View(podcastFeedService.Get(shows[show]));
            //return View();
            var res = podcastFeedService.Get(xmlUrl);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        private Dictionary<string, string> shows = new Dictionary<string, string>();


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

            foreach (var show in allShows)
            {
                if (shows.ContainsKey(show.Title))
                    continue;
                shows.Add(show.Title, show.XmlLink);
            }

            return Json(items, JsonRequestBehavior.AllowGet);
        }
    }
}