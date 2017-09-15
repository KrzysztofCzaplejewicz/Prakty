using System.Collections.Generic;

namespace Kwalifikacyjna
{
    public class VideoRepository
    {
        public List<Video> GetVideos()
        {
            return new List<Video>
            {
                new Video(){Title = "title 1", Price = 10},
                new Video(){Title = "title 2", Price = 10},
                new Video(){Title = "title 3", Price = 10},
            };
        }
    };

    public class Video
    {
        public string Title { get; set; }
        public int Price { get; set; }
    };
}
