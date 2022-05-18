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
    /// Логика взаимодействия для GameControl.xaml
    /// </summary>
    public partial class GameControl : UserControl
    {
        public GameControl()
        {
            InitializeComponent();

            this.Loaded += GameControl_Loaded;
            
        }

        private void GameControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.NameGame.Text = Game.Title;
                this.CoverGame.ImageSource = new BitmapImage(new Uri(Game.Cover.Url));
            }catch(Exception ex)
            {

            }
        }

        public Game Game { get; set; }
    }
}
