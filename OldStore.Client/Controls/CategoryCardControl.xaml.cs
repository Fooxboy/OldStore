using OldStore.Shared.Models;
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
    /// Логика взаимодействия для CategoryCardControl.xaml
    /// </summary>
    public partial class CategoryCardControl : UserControl
    {
        public CategoryCardControl()
        {
            InitializeComponent();

            this.Loaded += CategoryCardControl_Loaded;
        }

        private void CategoryCardControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.CategoryName.Text = Category.Title;
        }

        public CategoryModel Category { get; set; }


    }
}
