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
    /// Logika interakcji dla klasy EffectsToolsUserControl.xaml
    /// </summary>
    public partial class EffectsToolsUserControl : UserControl
    {
        public EffectsToolsUserControl(IEffectsToolsViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
