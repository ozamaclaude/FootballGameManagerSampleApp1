using PrismSampleApp1.Views;
using PrismSampleApp1.ViewModels;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using PrismSampleApp1.Services;

namespace PrismSampleApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<ServiceDialog, ViewModels.ServiceDialogViewModel>();
            containerRegistry.RegisterForNavigation<Views.SettingView>();
            containerRegistry.RegisterForNavigation<Views.Default>();
            containerRegistry.RegisterForNavigation<Views.GameRecord>();
            containerRegistry.RegisterForNavigation<Views.GameResults>();

            containerRegistry.Register<IPlayersInfoManager, PlayersInfoManager>();
        }
    }
}
