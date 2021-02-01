using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismSampleApp1.ViewModels
{
    public class ServiceDialogViewModel : BindableBase, IDialogAware
    {
        private string _title = "Notification";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public event Action<IDialogResult> RequestClose;
        public ServiceDialogViewModel()
        {

        }

        private string _mainMessage = "";
        public string MainMessage
        {
            get { return _mainMessage; }
            set { SetProperty(ref _mainMessage, value); }
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            var aaa = 1;
            MainMessage = parameters.GetValue<string>("Message1");
            
        }

    }
}
