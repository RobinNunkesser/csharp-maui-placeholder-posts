using System;
using System.Threading.Tasks;
using Italbytz.Ports.Common;
using PlaceholderPosts.Core.Ports;

namespace PlaceholderPosts.Core
{
    public class GetPostService : IGetPostService
    {
        private readonly ICrudRepository<long, IPost> _repository;

        public GetPostService(
            ICrudRepository<long, IPost> repository
        )
        {
            _repository = repository;
        }

        public async Task<IPost?> Execute(IPostID commandDto) =>
            await _repository.Retrieve(commandDto.Id);
    }
}
