using System;

namespace Outlou.DomainModels
{
    public class ReadNewsDto
    {
        public int FeedId { get; set; }
        public DateTime NewsDate { get; set; }
        public string NewsId { get; set; }
        public bool IsRead { get; set; }
        public int UserId { get; set; }
    }
}
