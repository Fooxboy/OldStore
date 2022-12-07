using OldStore.Client.Managers;
using OldStore.Shared.Enitites;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;


namespace OldStore.Client.Controls
{
    /// <summary>
    /// Логика взаимодействия для BigBannerControl.xaml
    /// </summary>
    public partial class BigBannerControl : UserControl
    {
        public BigBannerControl()
        {
            InitializeComponent();
            this.Loaded += BigBannerControl_Loaded;
            this.Unloaded += BigBannerControl_Unloaded;

            BannersManager.BannerOpenedEvent += BannerService_ShowBannerEvent;
        }

        private void BigBannerControl_Unloaded(object sender, RoutedEventArgs e)
        {
            runAutoNext = false;
        }

        private void BigBannerControl_Loaded(object sender, RoutedEventArgs e)
        {

            CurrentBanner = Banners[0];

            this.Title.Text = Banners[0].Title;
            this.SubTitle.Text = Banners[0].Subtitle;

            this.Description.Text = Banners[0].Description;
            this.ImageCover.ImageSource = new BitmapImage(new Uri(Banners[0].Image)) { DecodePixelHeight = 600, DecodePixelWidth = 1000, CacheOption = BitmapCacheOption.None };

            int index = 0;
            foreach (var banner in Banners)
            {
                var b = new MiniCardBigBannerControl() { Banner = banner, IsSelected = true };

                if (index == 0) {
                    b.IsSelected = true;
                    this.Cards.Children.Add(b);

                }
                else
                {
                    b.IsSelected = false;
                    this.Cards.Children.Add(b);
                }
                index++;
            }


            new Thread(AutoNext).Start();
        }

        Banner CurrentBanner;

        private void BannerService_ShowBannerEvent(Banner banner)
        {
            this.CurrentBanner = banner;
            var amim = (Storyboard)(this.Resources["OpenAnimation"]);

            amim.Completed += Amim_Completed;

            amim.Begin();

        }

        public List<Banner> Banners { get; set; }

        private async void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
               
            }

        }

        private void Amim_Completed(object? sender, EventArgs e)
        {
            this.Title.Text = CurrentBanner.Title;
            this.SubTitle.Text = CurrentBanner.Subtitle;

            this.Description.Text = CurrentBanner.Description;
            this.ImageCover.ImageSource = new BitmapImage(new Uri(CurrentBanner.Image)) { DecodePixelHeight = 600, DecodePixelWidth = 1000, CacheOption = BitmapCacheOption.None };

            var amim = (Storyboard)(this.Resources["CloseAnimation"]);


            amim.Begin();
        }

        bool runAutoNext = true;

        private void AutoNext()
        {

            while (runAutoNext)
            {
                Thread.Sleep(5000);
                try
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                       
                        var currentIndex = Banners.IndexOf(CurrentBanner);

                        if (currentIndex + 1 > Banners.Count - 1)
                        {
                            currentIndex = -1;
                        }

                        BannersManager.Invoke(Banners[currentIndex +1]);
                    });
                }
                catch (Exception ex)
                {
                    runAutoNext = false;
                }

            }

        }
    }
}
