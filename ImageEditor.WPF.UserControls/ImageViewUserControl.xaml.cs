using ImageEditor.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageEditor.WPF.UserControls
{
    /// <summary>
    /// Interaction logic for ImageViewUserControl.xaml
    /// </summary>
    public partial class ImageViewUserControl : UserControl
    {
        public ImageViewUserControl(IImageViewViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
