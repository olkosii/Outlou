using System;

namespace Outlou.DomainModels
{
    public class UnreadNewsFromDateRequest
    {
        public int UserId { get; set; }
        public int FeedId { get; set; }
        public DateTime FromDate { get; set; }
    }
}
