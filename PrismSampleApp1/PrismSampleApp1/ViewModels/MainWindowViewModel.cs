using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismSampleApp1.Commons;
using System.Collections.ObjectModel;

namespace PrismSampleApp1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "ゲーム管理";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _settingMenu = "選手登録";
        public string SettingMenu
        {
            get { return _settingMenu; }
            set { SetProperty(ref _settingMenu, value); }
        }

        private string _gameRecord = "ゲームの記録";
        public string GameRecord
        {
            get { return _gameRecord; }
            set { SetProperty(ref _gameRecord, value); }
        }

        private readonly IRegionManager _regionManager;

        private ObservableCollection<Player> _playersInfo
            = new ObservableCollection<Player>();

        public ObservableCollection<Player> PlayersInfo
        {
            get { return _playersInfo; }
            set { SetProperty(ref _playersInfo, value); }
        }

        private ObservableCollection<PlayerData> _playersGameData
            = new ObservableCollection<PlayerData>();

        public ObservableCollection<PlayerData> PlayersGameData
        {
            get { return _playersGameData; }
            set { SetProperty(ref _playersGameData, value); }
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }

        public DelegateCommand RegisterCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            Setup();
        }
        private void Setup()
        {
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(Views.Default));
            NavigateCommand = new DelegateCommand<string>(Navigate);
            RegisterCommand = new DelegateCommand(RegisterMember);
        }

        private void Navigate(string path)
        {
            if(path == null) { return; }

            _regionManager.RequestNavigate("ContentRegion", path);
        }

        private void RegisterMember()
        {

        }
    }
}
