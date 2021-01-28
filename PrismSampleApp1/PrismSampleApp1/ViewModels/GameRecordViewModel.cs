using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using PrismSampleApp1.Commons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Threading;

namespace PrismSampleApp1.ViewModels
{
    public class GameRecordViewModel : BindableBase
    {
        private ObservableCollection<PlayerData> _playersGameData
            = new ObservableCollection<PlayerData>();

        private const string _labelGameStart = "試合開始";
        private const string _labelGameEnd = "試合終了";
        private const string _timeFormat = "HH:mm:ss";
        private const string _blank = "-";

        public ObservableCollection<PlayerData> PlayersGameData
        {
            get { return _playersGameData; }
            set { SetProperty(ref _playersGameData, value); }
        }
        private string _gameStatus = _labelGameStart;
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
        public DelegateCommand MeasureTimeCommand { get; private set; }
        public DelegateCommand SaveCommand { get; private set; }

        public DelegateCommand GetPointCommand { get; private set; }

        private readonly IDialogService dlgService = null;

        public GameRecordViewModel(IDialogService dialogService)
        {

            dlgService = dialogService;
            MeasureTimeCommand = new DelegateCommand(MeasureTime);
            RegisterCommand = new DelegateCommand(RegisterRecord);
            SaveCommand = new DelegateCommand(SaveRecord);
            GetPointCommand = new DelegateCommand(AddPoint);
        }

        private void MeasureTime()
        {
            if(GameStatus == _labelGameStart) 
            {
                GameStatus = _labelGameEnd;
                StartTime = DateTime.Now.ToString(_timeFormat);
                EndTime = _blank;
                return;
            }
            GameStatus = _labelGameStart;
            EndTime = DateTime.Now.ToString(_timeFormat);
        }

        private void RegisterRecord()
        {

        }

        private void SaveRecord()
        {

        }

        private void AddPoint() { }

        private void ShowDialog()
        {
            IDialogResult result = null;
            this.dlgService.ShowDialog("ServiceDialog",
                    new DialogParameters { { "Message1", "aaaa" }, { "Message2", "bbbb" } },
                    ret => result = ret);
        }


    }
}
