using PlaceholderPosts.Core.Ports;

namespace PlaceholderPosts
{
    public class GetPostServiceDTO : IPostID
    {
        public long Id { get; set; }
    }
}
