using System.Threading.Tasks;

namespace PlaceholderPosts.Console
{
    class Program
    {
        private static Task Main(string[] args) =>
            new MainView().StartAsync();
    }
}
