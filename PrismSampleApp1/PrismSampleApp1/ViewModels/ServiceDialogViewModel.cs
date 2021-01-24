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
        public string Title => "タイトル";
        public event Action<IDialogResult> RequestClose;
        public ServiceDialogViewModel()
        {

        }
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        { }

    }
}
