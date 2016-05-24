using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PodStream.Models;

namespace PodStream
{
    public class Automap
    {
        public static void ConfigureAutoMapper()
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<PodcastFeedItem, PodcastFeedItem>());
            //Mapper.Initialize(cfg => cfg.CreateMap<PodcastFeed, PodcastFeed>());
        }
    }
}
