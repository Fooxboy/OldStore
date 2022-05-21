using OldStore.Shared.Enitites;
using OldStore.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
    /// Логика взаимодействия для BlockControl.xaml
    /// </summary>
    public partial class BlockControl : UserControl
    {
        public BlockControl()
        {
            InitializeComponent();

            this.Loaded += BlockControl_Loaded;
        }

        public static readonly DependencyProperty BlockProperty =
        DependencyProperty.Register("Block", typeof(BlockModel), typeof(BlockControl), new PropertyMetadata(null));

        public BlockModel Block
        {
            get { return (BlockModel)GetValue(BlockProperty); }
            set
            {
                SetValue(BlockProperty, value);
            }
        }


        private void BlockControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.Block == null) return;

            this.BlockTitle.Text = this.Block.Title;

            if (Block.Type == Shared.Enums.BlockType.Banner)
            {
                this.BlockTitle.Visibility = Visibility.Collapsed;
                var items = new List<Banner>();


                foreach (var item in Block.Items)
                {
                    var jsItem = (JsonElement)item;

                    var i = jsItem.Deserialize<Banner>();

                    items.Add(i);
                }
                this.BlockPanel.Children.Add(new BigBannerControl() { Banners = items });

                return;

            } else if (Block.Type == Shared.Enums.BlockType.CompactGame)
            {
                var items = new List<Game>();

                foreach (var item in Block.Items)
                {
                    var jsItem = (JsonElement)item;

                    var i = jsItem.Deserialize<Game>();

                    items.Add(i);
                }

                this.BlockPanel.Orientation = Orientation.Horizontal;

                foreach (var game in items)
                {
                    this.BlockPanel.Children.Add(new CompactGameControl() { Game = game, Margin = new Thickness(0, 0, 15, 0) });
                }

                return;
            } else if (Block.Type == Shared.Enums.BlockType.Game)
            {
                var items = new List<Game>();

                foreach (var item in Block.Items)
                {
                    var jsItem = (JsonElement)item;

                    var i = jsItem.Deserialize<Game>();

                    items.Add(i);
                }

                this.BlockPanel.Orientation = Orientation.Horizontal;

                foreach (var game in items)
                {
                    this.BlockPanel.Children.Add(new GameControl() { Game = game, Margin = new Thickness(0, 0, 15, 0) });
                }

                return;
            } else if (Block.Type == Shared.Enums.BlockType.Category)
            {
                var items = new List<CategoryModel>();

                foreach (var item in Block.Items)
                {
                    var jsItem = (JsonElement)item;

                    var i = jsItem.Deserialize<CategoryModel>();

                    items.Add(i);
                }

                this.BlockPanel.Orientation = Orientation.Horizontal;

                foreach (var cat in items)
                {
                    this.BlockPanel.Children.Add(new CategoryCardControl() { Category= cat, Margin = new Thickness(0, 0, 15, 0) });
                }
            }


        }
    }
}
