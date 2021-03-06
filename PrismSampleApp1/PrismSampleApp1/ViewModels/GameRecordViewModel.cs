﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using PrismSampleApp1.Commons;
using PrismSampleApp1.Services;
using PrismSampleApp1.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Threading;
using Unity;

namespace PrismSampleApp1.ViewModels
{
    public class GameRecordViewModel : BindableBase
    {
        private const string _labelRepresent = "代表";
        private const string _labelJunior = "ジュニア";
        private const string _labelUnder2nd = "2年以下";
        private const string _labelUnder3rd = "3年以下";
        private const string _label6th = "6";
        private const string _label5th = "5";
        private const string _label4th = "4";
        private const string _label3rd = "3";
        private const string _label2nd = "2";
        private const string _label1st = "1";
        private const string _labelInfant = "幼児";

        private const string _timeFormat = Labels.FmtDateTimeFormat1;
        private const string _blank = "-";

        private string _place = "";
        public string Place
        {
            get { return _place; }
            set { SetProperty(ref _place, value); }
        }

        private string _summary = "";
        public string Summary
        {
            get { return _summary; }
            set { SetProperty(ref _summary, value); }
        }

        private string _total = "0";
        public string Total
        {
            get { return _total; }
            set { SetProperty(ref _total, value); }
        }

        private string _opponentTotal = "0";
        public string OpponentTotal
        {
            get { return _opponentTotal; }
            set { SetProperty(ref _opponentTotal, value); }
        }

        private string _opponent = "";
        public string Opponent
        {
            get { return _opponent; }
            set { SetProperty(ref _opponent, value); }
        }

        private string _gameDate = DateTime.Now.ToString(Labels.FmtDateTimeFormat2);
        public string GameDate
        {
            get { return _gameDate; }
            set { SetProperty(ref _gameDate, value); }
        }

        private string _changingTime= "";
        public string ChangingTime
        {
            get { return _changingTime; }
            set {SetProperty(ref _changingTime, value); }
        }

        private string _selectedGrade = "";
        public string SelectedGrade
        {
            get { return _selectedGrade; }
            set 
            { 
                SetProperty(ref _selectedGrade, value.Replace(Labels.TagReplaceCombo, ""));
                HandleSelectionGradeList(_selectedGrade);
            }
        }

        private string _gameId = "";
        public string GameId
        {
            get { return _gameId; }
            set 
            {
                SetProperty(ref _gameId, value);
            }
        }

        private PlayerData _currentRowItem;
        public PlayerData CurrentRowItem
        { 
            get { return _currentRowItem; }
            set { SetProperty(ref _currentRowItem, value); }
        }

        private ObservableCollection<GameData> _gameResults
            = new ObservableCollection<GameData>();

        public ObservableCollection<GameData> GameResults
        {
            get { return _gameResults; }
            set { SetProperty(ref _gameResults, value); }
        }

        private ObservableCollection<PlayerData> _playersGameData
            = new ObservableCollection<PlayerData>();
        public ObservableCollection<PlayerData> PlayersGameData
        {
            get { return _playersGameData; }
            set { SetProperty(ref _playersGameData, value); }
        }
        private string _gameStatus = Labels.LabelGameStart;
        public string GameStatus
        {
            get { return _gameStatus; }
            set { SetProperty(ref _gameStatus, value); }
        }
        private string _currentTime = "";
        public string CurrentTime
        {
            get { return _currentTime; }
            set { SetProperty(ref _currentTime, value); }
        }

        private string _startTime = "";
        public string StartTime
        {
            get { return _startTime; }
            set { SetProperty(ref _startTime, value); }
        }

        private string _endTime = "";
        public string EndTime
        {
            get { return _endTime; }
            set { SetProperty(ref _endTime, value); }
        }
        public DelegateCommand RegisterCommand { get; private set; }
        public DelegateCommand OpponentAddScoreCommand { get; private set; }
        public DelegateCommand MeasureTimeCommand { get; private set; }
        public DelegateCommand SaveCommand { get; private set; }

        //public DelegateCommand<PlayerData> GetPointCommand { get; private set; }
        public DelegateCommand GetPointCommand { get; private set; }
        public DelegateCommand GetPlayersDetailsCommand { get; private set; }
        public DelegateCommand ChangeMemberCommand { get; private set; }

        private readonly IDialogService dlgService = null;
        private IUnityContainer _container;
        private IPlayersInfoManager _playersInfoManager;

        private List<Player> _players = new List<Player>();

        public GameRecordViewModel(IDialogService dialogService, IUnityContainer container)
        {

            dlgService = dialogService;
            MeasureTimeCommand = new DelegateCommand(MeasureTime);
            RegisterCommand = new DelegateCommand(RegisterRecord);
            SaveCommand = new DelegateCommand(SaveRecord);
            //GetPointCommand = new DelegateCommand<PlayerData>(AddPoint);
            GetPointCommand = new DelegateCommand(AddPoint);
            OpponentAddScoreCommand = new DelegateCommand(AddOpponentScore);
            ChangeMemberCommand = new DelegateCommand(ChangeMember);
            GetPlayersDetailsCommand = new DelegateCommand(DisplayPlayersDetails);
            _container = container;
            _playersInfoManager = _container.Resolve<IPlayersInfoManager>();
            _players = _playersInfoManager.ReadFile();
        }

        private void DisplayPlayersDetails()
        {
            var aaa = "";
        }

        private void AddOpponentScore()
        {
            var tempScore = int.Parse(OpponentTotal);
            tempScore++;
            OpponentTotal = tempScore.ToString();
        }

        private void MeasureTime()
        {
            if(GameStatus == Labels.LabelGameStart) 
            {
                GameStatus = Labels.LabelGameEnd;
                StartTime = DateTime.Now.ToString(_timeFormat);
                GameId = DateTime.Now.ToString(Labels.FmtDateTimeFormat3);
                EndTime = _blank;
                return;
            }
            GameStatus = Labels.LabelGameStart;
            EndTime = DateTime.Now.ToString(_timeFormat);
        }

        private void RegisterRecord()
        {
            if(Opponent == "")
            {
                ShowDialog(Labels.WD_InsufficientRequiredParameters);
                return;
            }
            var gamePlayers = PlayersGameData.ToList();
            gamePlayers.ForEach(x => x.GameId = GameId);

            var result = new GameData { 
                GameId = GameId,
                TeamDivision = SelectedGrade,
                GameDate = GameDate,
                Place = Place,
                OpponentTeam = Opponent,
                Result = "",
                StartTime = StartTime,
                EndTime = EndTime,
                Summary = Summary,
                GameDetails = "",
                Half = ""
            };
            GameResults.Add(result);
        }

        private void SaveRecord()
        {

        }

        private void ChangeMember()
        {
            var newRec = new PlayerData(CurrentRowItem);
            newRec.ChangingTime = DateTime.Now.ToString("HH:mm:ss");
            var index = PlayersGameData.IndexOf(CurrentRowItem);
            PlayersGameData.Remove(CurrentRowItem);
            PlayersGameData.Insert(index, newRec);
        }

        private void AddPoint()
        {
            var newRec = new PlayerData(CurrentRowItem);
            newRec.Score++;
            var index = PlayersGameData.IndexOf(CurrentRowItem);
            PlayersGameData.Remove(CurrentRowItem);
            PlayersGameData.Insert(index, newRec);
            var tempScore = int.Parse(Total);
            tempScore++;
            Total = tempScore.ToString();
        }

        private void ShowDialog(string msg, bool isWarn = true)
        {
            IDialogResult result = null;
            var isWarning = isWarn.ToString();
            this.dlgService.ShowDialog("ServiceDialog",
                    new DialogParameters { { "Message1", msg }, { "Message2", isWarning } },
                    ret => result = ret);
        }

        private void HandleSelectionGradeList(string grade)
        {
            PlayersGameData.Clear();
            
            var pData = new List<Player>();
            if (grade == _labelRepresent) { _players.ForEach(x => { 
                if (x.Grade == _label6th || x.Grade == _label5th) { pData.Add(x); } }); }

            else if (grade == _labelJunior) { _players.ForEach(x => { 
                 if (x.Grade == _label4th || x.Grade == _label3rd) { pData.Add(x); } }); }

            else if(grade == _labelUnder2nd){ _players.ForEach(x => { 
                 if (x.Grade == _label2nd || x.Grade == _label1st || x.Grade == _labelInfant) { pData.Add(x); } }); }
            else if (grade == _labelUnder3rd)
            {
                _players.ForEach(x => {
                    if (x.Grade == _label3rd || x.Grade == _label2nd || x.Grade == _label1st || x.Grade == _labelInfant) { pData.Add(x); }
                });
            }
            else
            {
                _players.ForEach(x => {
                    if (x.Grade == grade) { pData.Add(x); }
                });
            }

            //pData.ForEach(x => PlayersGameData.Add((PlayerData)x));
            foreach (var p in pData) 
            {
                var x = new PlayerData(p);
                PlayersGameData.Add(x);
            }
            
            var aaa = 1;
            //_playersInfoManager.Players
            //PlayersGameData
        }

    }
}
