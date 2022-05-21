using OldStore.Client.Controls;
using OldStore.Client.ViewModels;
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

        private readonly HomeViewModel vm;

        public HomeView()
        {
            this.vm = new HomeViewModel(new Services.ApiService());
            this.DataContext = vm;

            InitializeComponent();
            this.Loaded += HomeView_Loaded;

        }

        private async void HomeView_Loaded(object sender, RoutedEventArgs e)
        {

            await this.vm.LoadContentAsync();
        }

        private void BlocksScrollView_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {

        }
    }
}
