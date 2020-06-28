﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSamples.ViewModels
{
    public class MessageBoxViewModel : BindableBase, IDialogAware
    {
        public DelegateCommand OKButton { get; }

        public MessageBoxViewModel()
        {
            OKButton = new DelegateCommand(OKButtonExecute);
        }


        public string Title => "Test용";

        public event Action<IDialogResult> RequestClose;

        private string _message = string.Empty;
        public string Message
        {
            get { return _message; }
            set
            {
                SetProperty(ref _message, value);
            }
        }

        private void OKButtonExecute()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        }


        public bool CanCloseDialog()
        {
            return false;
        }

        public void OnDialogClosed()
        {
            throw new NotImplementedException();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message = parameters.GetValue<string>(nameof(Message));
        }
    }
}
