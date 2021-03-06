using OldStore.Client.Managers;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OldStore.Client.Controls
{
    /// <summary>
    /// Логика взаимодействия для MiniCardBigBannerControl.xaml
    /// </summary>
    public partial class MiniCardBigBannerControl : UserControl
    {
        public MiniCardBigBannerControl()
        {
            InitializeComponent();

            this.Loaded += MiniCardBigBannerControl_Loaded;

            BannersManager.BannerOpenedEvent += BannerService_ShowBannerEvent;


        }

        public static readonly DependencyProperty IsSelectedProperty =
           DependencyProperty.Register("IsSelected", typeof(bool), typeof(MiniCardBigBannerControl), new PropertyMetadata(false));


        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set
            {
                SetValue(IsSelectedProperty, value);
            }
        }

        public Banner Banner { get; set; }



        private void MiniCardBigBannerControl_Loaded(object sender, RoutedEventArgs e)
        {

            TextAlbum.Text = Banner.Title;
            ImageCard.ImageSource = new BitmapImage(new Uri(Banner.Image)) { DecodePixelHeight = 100, DecodePixelWidth = 190, CacheOption = BitmapCacheOption.None };

            if (IsSelected)
            {
                this.BackgroundImage.Opacity = 0.7;
                this.BackgroundImage.Visibility = Visibility.Visible;
                this.BorderCard.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#23B0DD");
                this.TextAlbum.Opacity = 1;
                this.TextAlbum.Visibility = Visibility.Visible;
            }
            else
            {
                this.BackgroundImage.Opacity = 0;
                this.BackgroundImage.Visibility = Visibility.Visible;

                this.BorderCard.BorderBrush = Brushes.Transparent;

                this.TextAlbum.Visibility = Visibility.Visible;


                this.TextAlbum.Opacity = 0;

            }
        }

        private void BannerService_ShowBannerEvent(Banner banner)
        {
            if (banner.Id != Banner.Id)
            {

                if (IsSelected)
                {
                    var amim = (Storyboard)(this.Resources["CloseAmination"]);
                    amim.Begin();
                }

                IsSelected = false;



                this.TextAlbum.Opacity = 0.0;
                this.BackgroundImage.Opacity = 0.0;
                this.BorderCard.BorderBrush = Brushes.Transparent;
            }
            else
            {
                IsSelected = true;
                this.BackgroundImage.Opacity = 0.7;
                this.BackgroundImage.Visibility = Visibility.Visible;
                this.BorderCard.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#23B0DD");
                this.TextAlbum.Opacity = 1;
                this.TextAlbum.Visibility = Visibility.Visible;
            }
        }

        public void CloseBanner()
        {

        }

        private void BorderCard_MouseEnter(object sender, MouseEventArgs e)
        {
            if (IsSelected) return;

            var amim = (Storyboard)(this.Resources["OpenAmination"]);
            amim.Begin();

        }

        private void BorderCard_MouseLeave(object sender, MouseEventArgs e)
        {
            if (IsSelected) return;


            var amim = (Storyboard)(this.Resources["CloseAmination"]);
            amim.Begin();



        }

        private void BorderCard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (IsSelected) return;

            BannersManager.Invoke(Banner);

            //IsSelected = true;

        }
    }
}
