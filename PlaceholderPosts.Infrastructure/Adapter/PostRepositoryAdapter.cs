using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HTTPbin.Infrastructure;
using Italbytz.Ports.Common;
using PlaceholderPosts.Core.Ports;

namespace PlaceholderPosts.Infrastructure
{
    public class PostRepositoryAdapter
        : ICrudRepository<long, IPost>
    {
        public async Task<long> Create(IPost entity)
        {
            var post = await JSONPlaceholderAPI.CreatePost(
                new Post()
                {
                    Id = entity.Id,
                    UserId = entity.UserId,
                    Title = entity.Title,
                    Body = entity.Body
                }
            );
            return ((long?)post?.Id) ?? -1;
        }

        public async Task<IPost?> Retrieve(long id)
        {
            var post = await JSONPlaceholderAPI.ReadPost(id);
            return (IPost?)post;
        }

        public async Task<List<IPost>?> RetrieveAll()
        {
            var posts = await JSONPlaceholderAPI.ReadAllPosts();
            return posts?.Select(post => (IPost)post).ToList();
        }

        public Task<bool> Update(long id, IPost entity) =>
            throw new System.NotImplementedException();

        public Task<bool> Delete(long id) =>
            throw new System.NotImplementedException();
    }
}
