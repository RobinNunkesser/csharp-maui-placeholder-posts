using PlaceholderPosts.Core.Ports;

namespace PlaceholderPosts.WinApp
{
    internal class GetPostServiceDTO : IPostID
    {
        public long Id { get; set; }
    }
}
