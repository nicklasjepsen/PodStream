using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Newtonsoft.Json;
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
                AvailableChannels = GetChannels().Select(c => new SelectListItem {Text = c, Value = c}),
                AvailableShows = new SelectListItem[0]
            };

            return View(podcast);

        }

        private IEnumerable<string> GetChannels()
        {
            return podcastProvider.GetChannels();
        }


        [Route("Podcast/Episodes/{channel}/{show}")]
        public string Episodes(string channel, string show)
        {
            return $"{channel} {show}";
        }

        public ActionResult GetShows(string name)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Vælg program", Value = "0" });

            var channelDetails = podcastProvider.GetShows(name);

            foreach (var show in channelDetails.Data)
            {
                items.Add(new SelectListItem {Text = show.Title, Value = show.XmlLink});
            }

            //if (name == "3")
            //{
            //    items.Add(new SelectListItem { Text = "Lågsus", Value = "1" });
            //    items.Add(new SelectListItem { Text = "Lågsus2", Value = "2" });
            //}
            //else
            //if (name == "1")
            //{
            //    items.Add(new SelectListItem { Text = "Harddisken", Value = "3" });
            //    items.Add(new SelectListItem { Text = "Harddisken2", Value = "4" });
            //}

            return Json(items, JsonRequestBehavior.AllowGet);
        }
    }
}