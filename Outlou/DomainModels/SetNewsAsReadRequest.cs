namespace Outlou.DomainModels
{
    public class SetNewsAsReadRequest
    {
        public int FeedId { get; set; }
        public int UserId { get; set; }
        public string NewsId { get; set; }
    }
}
