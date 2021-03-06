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

namespace OldStore.Client.Controls
{
    /// <summary>
    /// Логика взаимодействия для CompactGameControl.xaml
    /// </summary>
    public partial class CompactGameControl : UserControl
    {
        public CompactGameControl()
        {
            InitializeComponent();
            this.Loaded += CompactGameControl_Loaded;
        }

        private void CompactGameControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.CoverGame.ImageSource = new BitmapImage(new Uri(this.Game.Cover.Url));
            this.GameName.Text = this.Game.Title;
        }

        public Game Game { get; set; }

    }
}
