using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
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

        private string _playerGrade = "";
        public string PlayerGrade
        {
            get { return _playerGrade; }
            set { SetProperty(ref _playerGrade, value.Replace("System.Windows.Controls.ComboBoxItem: ", "")); }
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

        private readonly IDialogService dlgService = null;

        public MainWindowViewModel(IRegionManager regionManager, IUnityContainer container,
            IDialogService dialogService)
        {
            _regionManager = regionManager;
            dlgService = dialogService;
            _container = container;
            _playersInfoManager = _container.Resolve<IPlayersInfoManager>();
            Setup();
        }
        private void Setup()
        {
            var players = _playersInfoManager.ReadFile();
            players.ForEach(x => {
                AddPlayer(x.PlayerName, x.Gender, x.Grade, x.Position);
            });

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
            if (!IsValidate()) 
            { 
                ShowDialog();
                return;
            }

            var gender = "女子";
            if (this.Gender) { gender = "男子"; };
            AddPlayer(this.PlayerName, gender, this.PlayerGrade, this.PlayerPosition);

            InitializePlayer();

            //var player = new Player
            //{
            //    PlayerName = this.PlayerName,
            //    Gender = gender,
            //    Grade = this.PlayerGrade,
            //    Position = this.PlayerPosition
            //};
            //PlayersInfo.Add(player);

            //_playersInfoManager.AddPlayer(player);
        }
        private void InitializePlayer()
        {
            this.PlayerName = "";
            this.Gender = false;
            this.PlayerGrade = "";
            this.PlayerPosition = "";
        }

        private void AddPlayer(string name, string gender, string grade, string pos)
        {
            var player = new Player
            {
                PlayerName = name,
                Gender = gender,
                Grade = grade,
                Position = pos
            };
            PlayersInfo.Add(player);

            _playersInfoManager.AddPlayer(player);
        }

        private bool IsValidate()
        {
            if(this.PlayerName == "" || this.PlayerPosition == "") { return false; }
            return true;
        }

        private void Save()
        {
            _playersInfoManager.FlushContents();
            _playersInfoManager.Save();
        }
        private void ShowDialog()
        {
            IDialogResult result = null;
            this.dlgService.ShowDialog("ServiceDialog",
                    new DialogParameters { { "Message1", "aaaa" }, { "Message2", "bbbb" } },
                    ret => result = ret);
        }
    }
}
