using System;
using Italbytz.Common.Abstractions;

namespace PlaceholderPosts.Core.Ports
{
    public interface IGetPostService
        : IAsyncService<IPostID, IPost?> { }
}
