using System.Collections.Generic;

namespace VideoStore
{
    public class VideoRepository
    {
        public List<Video> GetVideos()
        {
            return new List<Video>
            {
                new Video(){Title= "video1", Price = 10, Quantity = 3},
                new Video(){Title= "video2", Price = 15, Quantity = 2},
                new Video(){Title= "video3", Price = 5, Quantity = 1},
                new Video(){Title= "video4", Price = 5, Quantity = 0}
            };
        }


    }

}