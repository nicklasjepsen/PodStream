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
    public class PodcastController : Controller
    {
        private readonly IPodcastFeedProvider podcastFeedService;

        public PodcastController(IPodcastFeedProvider podcastFeedService)
        {
            if (podcastFeedService == null)
                throw new ArgumentNullException(nameof(podcastFeedService));
            this.podcastFeedService = podcastFeedService;
        }

        public ActionResult Index()
        {
            return View(new Podcast
            {
                AvailableChannels = new[]
                {
                    new SelectListItem { Value = "1", Text = "P1" },
                    new SelectListItem { Value = "2", Text = "P2" },
                   new SelectListItem { Value = "3", Text = "P3" }
                },
                AvailableShows = new[] { new SelectListItem { Text = "Vælg udsendelse", Value = "0" } }
            });

        }

        [Route("Podcast/Episodes/{channel}/{show}")]
        public string Episodes(string channel, string show)
        {
            return $"{channel} {show}";
        }

        public ActionResult GetShows(string name)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem {Text = "Vælg udsendelse", Value = "0"});
            if (name == "3")
            {
                items.Add(new SelectListItem { Text = "Lågsus", Value = "1" });
                items.Add(new SelectListItem { Text = "Lågsus2", Value = "2" });
            }
            else
            if (name == "1")
            {
                items.Add(new SelectListItem { Text = "Harddisken", Value = "3" });
                items.Add(new SelectListItem { Text = "Harddisken2", Value = "4" });
            }
            //items.Add(new SelectListItem() { Text = "Sub Item 1", Value = "1" });
            //items.Add(new SelectListItem() { Text = "Sub Item 2", Value = "8" });
            // you may replace the above code with data reading from database based on the id

            return Json(items, JsonRequestBehavior.AllowGet);
        }
    }
}