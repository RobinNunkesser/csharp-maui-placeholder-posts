using Italbytz.Ports.Common;
using PlaceholderPosts.Core;
using PlaceholderPosts.Core.Ports;
using PlaceholderPosts.Infrastructure;

namespace PlaceholderPosts;

public partial class MainPage : ContentPage
{
    private readonly IService<IPostID, IPost> _service =
        new GetPostService(new PostRepositoryAdapter());

    public MainPage()
    {
        InitializeComponent();
    }

    private async void Retrieve_Button_Clicked(
        object sender,
        EventArgs e
    )
    {
        try
        {
            ResultLabel.Text = (
                await _service.Execute(
                    new GetPostServiceDTO()
                    {
                        Id = int.Parse(IdEntry.Text)
                    }
                )
            ).ToString();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fehler", ex.Message, "OK");
        }
    }
}
