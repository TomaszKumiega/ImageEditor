﻿using ImageEditor.ViewModel;
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
    /// Logika interakcji dla klasy ColorEnhancementToolsUserControl.xaml
    /// </summary>
    public partial class ColorEnhancementToolsUserControl : UserControl
    {
        public ColorEnhancementToolsUserControl(IColorEnhancementToolsViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
