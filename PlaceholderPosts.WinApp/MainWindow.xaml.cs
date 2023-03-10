using Italbytz.Ports.Common;
using PlaceholderPosts.Core;
using PlaceholderPosts.Core.Ports;
using PlaceholderPosts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlaceholderPosts.WinApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IService<IPostID, IPost> _service =
            new GetPostService(new PostRepositoryAdapter());

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(
            object sender,
            RoutedEventArgs e
        )
        {
            try
            {
                ResultLabel.Content = (
                    await _service.Execute(
                        new GetPostServiceDTO()
                        {
                            Id = int.Parse(IdTextBox.Text)
                        }
                    )
                ).ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
