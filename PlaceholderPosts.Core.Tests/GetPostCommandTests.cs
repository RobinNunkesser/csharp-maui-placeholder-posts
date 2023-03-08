using Italbytz.Ports.Common;
using Moq;
using NUnit.Framework;
using PlaceholderPosts.Core.Ports;
using System.Threading.Tasks;

namespace PlaceholderPosts.Core.Tests
{
    public class GetPostCommandTests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public async Task TestExecute()
        {
            var mock = new Mock<ICrudRepository<long, IPost>>();
            var mockEntity = new MockPost();
            mock.Setup(f => f.Retrieve(1))
                .ReturnsAsync(mockEntity);
            var service = new GetPostService(mock.Object);
            Assert.AreEqual(
                mockEntity,
                await service.Execute(new MockPostID() { Id = 1 })
            );
            mock.Verify(f => f.Retrieve(1), Times.AtMostOnce());
        }
    }

    internal class MockPostID : IPostID
    {
        public long Id { get; set; }
    }

    internal class MockPost : IPost
    {
        public long UserId { get; set; }
        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
