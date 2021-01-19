using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismSampleApp1.Commons;
using PrismSampleApp1.Services;
using System.Collections.ObjectModel;
using Unity;

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

        private string _playerName = "";
        public string PlayerName
        {
            get { return _playerName; }
            set { SetProperty(ref _playerName, value); }
        }

        private bool _gender = false;
        public bool Gender
        {
            get { return _gender; }
            set { SetProperty(ref _gender, value); }
        }

        private int _playerGrade = 0;
        public int PlayerGrade
        {
            get { return _playerGrade; }
            set { SetProperty(ref _playerGrade, value); }
        }

        private string _playerPosition = "";
        public string PlayerPosition
        {
            get { return _playerPosition; }
            set 
            {
                SetProperty(ref _playerPosition, value.Replace("System.Windows.Controls.ComboBoxItem: ", "")); 
            }
        }

        private IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        private IPlayersInfoManager _playersInfoManager;

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
        public DelegateCommand SaveCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
            _playersInfoManager = _container.Resolve<IPlayersInfoManager>();
            Setup();
        }
        private void Setup()
        {
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(Views.Default));
            NavigateCommand = new DelegateCommand<string>(Navigate);
            RegisterCommand = new DelegateCommand(RegisterMember);
            SaveCommand = new DelegateCommand(Save);
        }

        private void Navigate(string path)
        {
            if(path == null) { return; }

            _regionManager.RequestNavigate("ContentRegion", path);
        }

        private void RegisterMember()
        {
            var gender = "女子";
            if (this.Gender) { gender = "男子"; };
            var player = new Player
            {
                PlayerName = this.PlayerName,
                Gender = gender,
                Grade = this.PlayerGrade,
                Position = this.PlayerPosition
            };
            PlayersInfo.Add(player);

            _playersInfoManager.AddPlayer(player);
        }

        private void Save()
        {
            _playersInfoManager.Save();
        }
    }
}
