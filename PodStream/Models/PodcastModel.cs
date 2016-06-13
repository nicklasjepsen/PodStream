using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// ReSharper disable once CheckNamespace
namespace PodStream
{
    public class PodcastModel
    {
        public string SelectedChannel { get; set; }
        public IEnumerable<SelectListItem> AvailableChannels { get; set; }
        public ShowModel SelectedShow { get; set; }
        public IEnumerable<SelectListItem> AvailableShows { get; set; }
    }
}