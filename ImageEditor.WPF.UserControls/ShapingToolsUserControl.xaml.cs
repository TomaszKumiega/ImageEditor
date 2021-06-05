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
    /// Interaction logic for ShapingToolsUserControl.xaml
    /// </summary>
    public partial class ShapingToolsUserControl : UserControl
    {
        public ShapingToolsUserControl(IShapingToolsViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
