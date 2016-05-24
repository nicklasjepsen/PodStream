using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PodStream.Models
{
    public class Podcast
    {
        public string SelectedChannel { get; set; }
        public IEnumerable<SelectListItem> AvailableChannels { get; set; }
        public string SelectedShow { get; set; }
        public IEnumerable<SelectListItem> AvailableShows { get; set; }
        //public PodcastFeed PodcastFeed { get; set; }

    }
}
