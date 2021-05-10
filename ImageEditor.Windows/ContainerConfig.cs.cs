using Autofac;
using ImageEditor.Library.Algorithms;
using ImageEditor.Library.Converter;
using ImageEditor.Library.Helpers;
using ImageEditor.Library.Tools;
using ImageEditor.ViewModel;
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
            builder.RegisterType<ContrastShrinkingAlgorithm>().As<IContrastShrinkingAlgorithm>();
            builder.RegisterType<ContrastStretchingAlgorithm>().As<IContrastStretchingAlgorithm>();
            builder.RegisterType<ImageConverter>().As<IImageConverter>();
            builder.RegisterType<ContrastRangeSelectionHelper>().As<IContrastRangeSelectionHelper>();
            builder.RegisterType<Flatten2DArrayHelper<float>>().As<IFlatten2DArrayHelper<float>>();
            builder.RegisterType<ImageIO>().As<IImageIO>();
            builder.RegisterType<LightingEnhancementTools>().As<ILightingEnhancementTools>();
            #endregion

            #region ViewModel
            builder.RegisterType<ImageProvider>().As<IImageProvider>().SingleInstance();
            builder.RegisterType<ImageViewViewModel>().As<IImageViewViewModel>();
            builder.RegisterType<MenuViewModel>().As<IMenuViewModel>();
            builder.RegisterType<LigthingEnhancementToolsViewModel>().As<ILightingEnhancementToolsViewModel>();
            #endregion

            #region UserControls
            builder.RegisterType<ImageViewUserControl>().AsSelf();
            #endregion

            return builder.Build();
        }
    }
}
