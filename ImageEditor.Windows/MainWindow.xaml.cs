using ImageEditor.WPF.UserControls;
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

namespace ImageEditor.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImageViewUserControl ImageView { get; }

        public MainWindow(ImageViewUserControl imageView)
        {
            ImageView = imageView;
            InitializeComponent();
            AddControlsToTheView();
        }

        private void AddControlsToTheView()
        {
            MainGrid.Children.Add(ImageView);
            ImageView.HorizontalAlignment = HorizontalAlignment.Stretch;
            ImageView.VerticalAlignment = VerticalAlignment.Stretch;
            Grid.SetColumn(ImageView, 0);
            Grid.SetRow(ImageView, 0);
        }

        private void RectangleTitleBarBackground_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
