using System;

namespace PlaceholderPosts.Core.Ports
{
    public interface IPost
    {
        long UserId { get; set; }
        long Id { get; set; }
        string? Title { get; set; }
        string? Body { get; set; }
    }
}
