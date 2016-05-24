using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodStream.Models
{
    public class PodcastFeedItem
    {
        public string Title { get; set; }
        [DisplayName("Beskrivelse")]
        public string Summary { get; set; }
        [DisplayName("Link")]
        public string Url { get; set; }
        [DisplayName("Udgivelses dato")]
        public DateTime PublishDate { get; set; }

        public TimeSpan Duration { get; set; }

        public long? SizeInBytes { get; set; }

        public string Size
        {
            get
            {
                if (SizeInBytes == null)
                    return "Unknown";
                return SizeInBytes/1048576 + " mb";
            }
        }
        public string ExternalItemId { get; set; }
    }
}
