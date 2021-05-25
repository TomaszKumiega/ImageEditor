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
        private MenuView MenuView { get; }
        private LightingEnhancementToolsUserControl LightingEnhancementTools { get; }
        private ColorEnhancementToolsUserControl ColorEnhancementTools { get; }
        private EffectsToolsUserControl EffectsTools { get; }

        public MainWindow(ImageViewUserControl imageView, MenuView menuView, 
            LightingEnhancementToolsUserControl lightingEnhancementTools, ColorEnhancementToolsUserControl colorEnhancementTools,
            EffectsToolsUserControl effectsTools)
        {
            ImageView = imageView;
            MenuView = menuView;
            LightingEnhancementTools = lightingEnhancementTools;
            ColorEnhancementTools = colorEnhancementTools;
            EffectsTools = effectsTools;
            InitializeComponent();
            AddControlsToTheView();
        }

        private void AddControlsToTheView()
        {
            MainGrid.Children.Add(ImageView);
            ImageView.HorizontalAlignment = HorizontalAlignment.Stretch;
            ImageView.VerticalAlignment = VerticalAlignment.Stretch;
            Grid.SetColumn(ImageView, 0);
            Grid.SetRow(ImageView, 1);

            MainGrid.Children.Add(MenuView);
            MenuView.HorizontalAlignment = HorizontalAlignment.Stretch;
            MenuView.VerticalAlignment = VerticalAlignment.Stretch;
            Grid.SetColumn(MenuView, 0);
            Grid.SetRow(MenuView, 2);

            LightTabItem.Content = LightingEnhancementTools;
            LightingEnhancementTools.HorizontalAlignment = HorizontalAlignment.Stretch;
            LightingEnhancementTools.VerticalAlignment = VerticalAlignment.Stretch;

            ColorTabItem.Content = ColorEnhancementTools;
            ColorEnhancementTools.HorizontalAlignment = HorizontalAlignment.Stretch;
            ColorEnhancementTools.VerticalAlignment = VerticalAlignment.Stretch;

            EffectsTabItem.Content = EffectsTools;
            EffectsTools.HorizontalAlignment = HorizontalAlignment.Stretch;
            EffectsTools.VerticalAlignment = VerticalAlignment.Stretch;
        }

        private void RectangleTitleBarBackground_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
