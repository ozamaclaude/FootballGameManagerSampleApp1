using PrismSampleApp1.Views;
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
            containerRegistry.RegisterForNavigation<Views.SettingView>();
            containerRegistry.RegisterForNavigation<Views.Default>();
            containerRegistry.RegisterForNavigation<Views.GameRecord>();

            containerRegistry.Register<IPlayersInfoManager, PlayersInfoManager>();
        }
    }
}
