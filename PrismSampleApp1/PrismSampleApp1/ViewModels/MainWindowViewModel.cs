using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using PrismSampleApp1.Commons;
using PrismSampleApp1.Services;
using System.Collections.ObjectModel;
using Unity;
using System.Linq;
using System.Collections.Generic;
using PrismSampleApp1.Utils;

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

        private string _settingMenu = Labels.LabelSettingMenu;
        public string SettingMenu
        {
            get { return _settingMenu; }
            set { SetProperty(ref _settingMenu, value); }
        }

        private string _gameRecord = Labels.LabelGameRecord;
        public string GameRecord
        {
            get { return _gameRecord; }
            set { SetProperty(ref _gameRecord, value); }
        }

        private string _gameResults = Labels.LabelGameResult;
        public string GameResults
        {
            get { return _gameResults; }
            set { SetProperty(ref _gameResults, value); }
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
            set { SetProperty(ref _playerGrade, value.Replace(Labels.TagReplaceCombo, "")); }
        }

        private string _playerPosition = "";
        public string PlayerPosition
        {
            get { return _playerPosition; }
            set 
            {
                SetProperty(ref _playerPosition, value.Replace(Labels.TagReplaceCombo, "")); 
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
            if(players == null)
            {
                ShowDialog(Labels.WD_FileNotFound, false);
                return;
            }
            players.ForEach(x => {
                AddPlayer(x.PlayerName, x.Gender, x.Grade, x.Position);
            });

            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(Views.Default));
            NavigateCommand = new DelegateCommand<string>(Navigate);
            RegisterCommand = new DelegateCommand(RegisterMember);
            SaveCommand = new DelegateCommand(SavePlayers);
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
                ShowDialog(Labels.WD_InsufficientRequiredParameters);
                return;
            }

            var gender = Labels.LabelWomen;
            if (this.Gender) { gender = Labels.LabelMen; };
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

            //_playersInfoManager.AddPlayer(player);
        }

        private bool IsValidate()
        {
            if(this.PlayerName == "" || this.PlayerPosition == "") { return false; }
            return true;
        }

        private void SavePlayers()
        {
            var saveData = new List<Player>();
            PlayersInfo.ToList().ForEach(x => saveData.Add(x));
            _playersInfoManager.FlushContents();
            _playersInfoManager.SavePlayers(saveData);
        }
        private void ShowDialog(string msg, bool isWarn = true)
        {
            IDialogResult result = null;
            var isWarning = isWarn.ToString();
            this.dlgService.ShowDialog("ServiceDialog",
                    new DialogParameters { { "Message1", msg }, { "Message2", isWarning } },
                    ret => result = ret);
        }
    }
}
