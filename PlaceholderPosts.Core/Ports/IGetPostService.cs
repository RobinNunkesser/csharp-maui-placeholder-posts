using System;
using Italbytz.Ports.Common;

namespace PlaceholderPosts.Core.Ports
{
    public interface IGetPostService
        : IService<IPostID, IPost?> { }
}
