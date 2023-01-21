using System;

namespace Outlou.DataModels
{
    public class ReadNews
    {
        public int Id { get; set; }
        public int FeedId { get; set; }
        public DateTime NewsDate { get; set; }
        public string NewsId { get; set; }
        public bool IsRead { get; set; }
        public int UserId { get; set; }
    }
}
