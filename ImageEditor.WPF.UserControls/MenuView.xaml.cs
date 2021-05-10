using ImageEditor.ViewModel;
using ImageEditor.WPF.UserControls.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;

namespace ImageEditor.WPF.UserControls
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : UserControl
    {
        public MenuView(IMenuViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }

        private void SaveAsImageButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            DialogResult result = dialog.ShowDialog(this.GetIWin32Window());
            var viewModel = DataContext as IMenuViewModel; 

            if(result == System.Windows.Forms.DialogResult.OK)
            {
                viewModel.SaveImageAs(dialog.FileName);
            }
        }

        private void LoadImageButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            var result = dialog.ShowDialog(this.GetIWin32Window());
            var viewModel = DataContext as IMenuViewModel;

            if(result == DialogResult.OK)
            {
                viewModel.LoadImage(dialog.FileName);
            }
        }
    }
}
