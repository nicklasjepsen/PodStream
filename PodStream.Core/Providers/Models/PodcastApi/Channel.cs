﻿namespace PodStream.Core.Providers.Models.PodcastApi
{
    public class Channel
    {
        public Show[] Data { get; set; }
        public int TotalCount { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
