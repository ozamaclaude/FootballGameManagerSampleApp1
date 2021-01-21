using Prism.Commands;
using Prism.Mvvm;
using PrismSampleApp1.Commons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

        public GameRecordViewModel()
        {
        }
    }
}
