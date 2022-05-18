using OldStore.Client.Controls;
using OldStore.Shared.Enitites;
using System;
using System.Collections.Generic;
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

namespace OldStore.Client.Views
{
    /// <summary>
    /// Логика взаимодействия для HomeView.xaml
    /// </summary>
    public partial class HomeView : Page
    {
        public HomeView()
        {
            InitializeComponent();
            this.Loaded += HomeView_Loaded;
        }

        private void HomeView_Loaded(object sender, RoutedEventArgs e)
        {

            var banners = new List<Banner>();

            banners.Add(new Banner() { Id=0, Title="Крутой баннер", Subtitle = "Ну или не очень", Description = "очень крутое описание", Image = "E:\\banner.jpg"});
            banners.Add(new Banner() { Id=1, Title="Крутой баннер 1", Subtitle = "Ну или не очень", Description = "очень крутое описание", Image = "E:\\banner.jpg"});
            banners.Add(new Banner() { Id=2, Title="Крутой баннер 2", Subtitle = "Ну или не очень", Description = "очень крутое описание", Image = "E:\\banner.jpg"});
            banners.Add(new Banner() { Id=3, Title="Крутой баннер 3", Subtitle = "Ну или не очень", Description = "очень крутое описание", Image = "E:\\banner.jpg"});
            banners.Add(new Banner() { Id=4, Title="Крутой баннер 4", Subtitle = "Ну или не очень", Description = "очень крутое описание", Image = "E:\\banner.jpg"});
            banners.Add(new Banner() { Id=5, Title="Крутой баннер 5", Subtitle = "Ну или не очень", Description = "очень крутое описание", Image = "E:\\banner.jpg"});

            Banners.Banners = banners;


            TopGames.Children.Add(new GameControl()
            {
                Game = new Game() { Cover = new Cover() { Url = "E:\\game.png"}, Title = "Имя игры" }
               
            });

            TopGames.Children.Add(new GameControl()
            {
                Game = new Game() { Cover = new Cover() { Url = "E:\\game.png" }, Title = "Имя игры", },
                Margin = new Thickness(10,0,0,0)
            });

            TopGames.Children.Add(new GameControl()
            {
                Game = new Game() { Cover = new Cover() { Url = "E:\\game.png" }, Title = "Имя игры" },
                Margin = new Thickness(10, 0, 0, 0)


            });

            TopGames.Children.Add(new GameControl()
            {
                Game = new Game() { Cover = new Cover() { Url = "E:\\game.png" }, Title = "Имя игры" },
                Margin = new Thickness(10, 0, 0, 0)


            });

            TopGames.Children.Add(new GameControl()
            {
                Game = new Game() { Cover = new Cover() { Url = "E:\\game.png" }, Title = "Имя игры" },
                Margin = new Thickness(10, 0, 0, 0)


            });
        }
    }
}
