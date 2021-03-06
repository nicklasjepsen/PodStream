﻿namespace PodStream.Core.Models
{
    public class PodcastFeedItem
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Url { get; set; }
        public string PublishDate { get; set; }

        public string Duration { get; set; }

        public long? SizeInBytes { get; set; }

        public string Size
        {
            get
            {
                if (SizeInBytes == null)
                    return "Unknown";
                return SizeInBytes/1048576 + "mb";
            }
        }
        public string ExternalItemId { get; set; }
    }
}
