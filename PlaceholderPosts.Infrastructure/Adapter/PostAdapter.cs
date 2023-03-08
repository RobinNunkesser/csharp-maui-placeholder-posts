using PlaceholderPosts.Core.Ports;

namespace PlaceholderPosts.Infrastructure
{
    public partial class Post : IPost
    {
        public override string ToString() =>
            $"UserId: {UserId}\nId: {Id}\nTitle: {Title}\nBody: {Body}\n";
    }
}
