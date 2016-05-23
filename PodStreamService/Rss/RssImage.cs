using System;
using System.Xml.Serialization;

namespace PodStreamService.Rss
{
    [Serializable]
    public class RssImage
    {
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("url")]
        public string Url { get; set; }
        [XmlElement("link")]
        public string Link { get; set; }
    }
}
