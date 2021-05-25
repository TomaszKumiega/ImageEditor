using Autofac;
using ImageEditor.Library.Algorithms;
using ImageEditor.Library.Converter;
using ImageEditor.Library.Helpers;
using ImageEditor.Library.Tools;
using ImageEditor.ViewModel;
using ImageEditor.ViewModel.Commands;
using ImageEditor.WPF.UserControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Windows
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            #region Library
            builder.RegisterType<ChangeBrightnessAlgorithm>().As<IChangeBrightnessAlgorithm>();
            builder.RegisterType<ContrastStretchingAlgorithm>().As<IContrastStretchingAlgorithm>();
            builder.RegisterType<ImageConverter>().As<IImageConverter>();
            builder.RegisterType<ColorConverter>().As<IColorConverter>();
            builder.RegisterType<ImageIO>().As<IImageIO>();
            builder.RegisterType<LightingEnhancementTools>().As<ILightingEnhancementTools>();
            builder.RegisterType<ChangeTintAlgorithm>().As<IChangeTintAlgorithm>();
            builder.RegisterType<ChangeSaturationAlgorithm>().As<IChangeSaturationAlgorithm>();
            builder.RegisterType<GrayscaleAlgorithm>().As<IGrayscaleAlgorithm>();
            builder.RegisterType<NegativeAlgorithm>().As<INegativeAlgorithm>();
            builder.RegisterType<ColorEnhancementTools>().As<IColorEnhancementTools>();
            builder.RegisterType<EffectsTools>().As<IEffectsTools>();
            builder.RegisterType<ShapingTools>().As<IShapingTools>();
            builder.RegisterType<WhiteBalanceAlgorithm>().As<IWhiteBalanceAlgorithm>();
            builder.RegisterType<HistogramStatisticsHelper>().As<IHistogramStatisticsHelper>();
            #endregion

            #region ViewModel
            builder.RegisterType<ImageProvider>().As<IImageProvider>().SingleInstance();
            builder.RegisterType<ImageViewViewModel>().As<IImageViewViewModel>();
            builder.RegisterType<MenuViewModel>().As<IMenuViewModel>();
            builder.RegisterType<LigthingEnhancementToolsViewModel>().As<ILightingEnhancementToolsViewModel>();
            builder.RegisterType<CommandFactory>().As<ICommandFactory>();
            builder.RegisterType<ColorEnhancementToolsViewModel>().As<IColorEnhancementToolsViewModel>();
            builder.RegisterType<EffectsToolsViewModel>().As<IEffectsToolsViewModel>();
            #endregion

            #region UserControls
            builder.RegisterType<ImageViewUserControl>().AsSelf();
            builder.RegisterType<MenuView>().AsSelf();
            builder.RegisterType<LightingEnhancementToolsUserControl>().AsSelf();
            builder.RegisterType<ColorEnhancementToolsUserControl>().AsSelf();
            builder.RegisterType<EffectsToolsUserControl>().AsSelf();
            #endregion

            #region Windows
            builder.RegisterType<MainWindow>().AsSelf();
            #endregion

            return builder.Build();
        }
    }
}
