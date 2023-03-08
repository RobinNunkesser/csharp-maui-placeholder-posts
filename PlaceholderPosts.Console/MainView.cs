using Italbytz.Ports.Common;
using PlaceholderPosts.Core;
using PlaceholderPosts.Core.Ports;
using PlaceholderPosts.Infrastructure;
using System.Threading.Tasks;

namespace PlaceholderPosts.Console
{
    public class MainView
    {
        private readonly IService<IPostID, IPost> _service =
            new GetPostService(new PostRepositoryAdapter());

        public async Task StartAsync()
        {
            System.Console.WriteLine("Id of post? ");
            var id = System.Console.ReadLine();
            try
            {
                System.Console.Write(
                    await _service.Execute(
                        new GetPostServiceDTO()
                        {
                            Id = int.Parse(id)
                        }
                    )
                );
            }
            catch (System.Exception ex)
            {
                System.Console.Error.WriteLine(ex.Message);
            }
            System.Console.ReadKey();
        }
    }
}
