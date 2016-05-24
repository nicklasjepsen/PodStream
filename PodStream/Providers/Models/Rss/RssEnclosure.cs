using System;
using System.Xml.Serialization;

namespace PodStream.Providers.Models.Rss
{
    [Serializable]
    [XmlRoot("enclosure", IsNullable = false)]
    public class RssEnclosure
    {
        [XmlAttribute("url")]
        public string Url { get; set; }
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlAttribute("length")]
        public long Lenght { get; set; }
    }
}
