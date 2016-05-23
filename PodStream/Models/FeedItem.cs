using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodStream.Models
{
    public class FeedItem
    {
        [DisplayName("Beskrivelse")]
        public string Summary { get; set; }
        [DisplayName("Link")]
        public string Url { get; set; }
        [DisplayName("Udgivelses dato")]
        public DateTime PublishDate { get; set; }
    }
}
