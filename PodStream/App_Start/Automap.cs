using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PodStream.Models;
using PodStreamService;

namespace PodStream
{
    public class Automap
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PodcastServiceFeedItem, FeedItem>());
        }
    }
}
