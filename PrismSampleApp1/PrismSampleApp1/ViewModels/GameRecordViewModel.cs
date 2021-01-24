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

        public ObservableCollection<PlayerData> PlayersGameData
        {
            get { return _playersGameData; }
            set { SetProperty(ref _playersGameData, value); }
        }
        private string _gameStatus = "試合開始";
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

        public DelegateCommand RegisterCommand { get; private set; }
        public DelegateCommand SaveCommand { get; private set; }

        private readonly IDialogService dlgService = null;

        public GameRecordViewModel(IDialogService dialogService)
        {

            dlgService = dialogService;
            RegisterCommand = new DelegateCommand(RegisterRecord);
            SaveCommand = new DelegateCommand(SaveRecord);
            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Tick += GetCurrentTime();
            //timer.Interval = new TimeSpan(0, 0, 1);
            //timer.Start();

        }

        private void RegisterRecord()
        {

        }

        private void SaveRecord()
        {

        }

        private void ShowDialog()
        {
            IDialogResult result = null;
            this.dlgService.ShowDialog("ServiceDialog",
                    new DialogParameters { { "Message1", "aaaa" }, { "Message2", "bbbb" } },
                    ret => result = ret);
        }

        private void GetCurrentTime(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            //return dt.ToString("yyyy/MM/dd HH:mm:ss");
            CurrentTime = dt.ToString("yyyy/MM/dd HH:mm:ss");
        }
    }
}
