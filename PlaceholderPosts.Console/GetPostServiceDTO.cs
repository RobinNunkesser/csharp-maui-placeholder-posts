using PlaceholderPosts.Core.Ports;

namespace PlaceholderPosts.Console
{
    public class GetPostServiceDTO : IPostID
    {
        public long Id { get; set; }
    }
}
