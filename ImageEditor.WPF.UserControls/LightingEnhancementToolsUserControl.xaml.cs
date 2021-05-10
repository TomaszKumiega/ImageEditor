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
    /// Interaction logic for LightingEnhancementToolsUserControl.xaml
    /// </summary>
    public partial class LightingEnhancementToolsUserControl : UserControl
    {
        public LightingEnhancementToolsUserControl(ILightingEnhancementToolsViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }

        private void BrightnessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var viewModel = DataContext as ILightingEnhancementToolsViewModel;
            viewModel.Brightness = (float) BrightnessSlider.Value;
        }

        private void ContrastSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var viewModel = DataContext as ILightingEnhancementToolsViewModel;
            viewModel.Contrast = (float) ContrastSlider.Value;
        }
    }
}
