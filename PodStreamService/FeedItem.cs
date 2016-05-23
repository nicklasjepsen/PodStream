using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodStreamService
{
    public class PodcastServiceFeedItem
    {
        public string Summary { get; set; }
        public string Url { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
