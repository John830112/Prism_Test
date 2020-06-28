using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using PSamples.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PSamples.ViewModels
{
    public class ViewCViewModel : BindableBase, IDialogAware
    {
        private string _viewCTextBox = "XXX";

        public event Action<IDialogResult> RequestClose;

        public DelegateCommand OKButton { get; }

        IDialogService _dialogService;


        public string ViewCTextBox
        {
            get
            {
                return _viewCTextBox;
            }
            set
            {
                SetProperty(ref _viewCTextBox, value);
            }
        }

        public string Title => "ViewC의 타이틀";

        public ViewCViewModel(IDialogService dialogService)
        {
            OKButton = new DelegateCommand(OKButtonExecute);
            _dialogService = dialogService;
        }

        private void OKButtonExecute()
        {
            // MessageBox.Show("Save 합니다.");

            var message = new DialogParameters();
            message.Add(nameof(MessageBoxViewModel.Message), "저장합니다");
            _dialogService.ShowDialog(nameof(MessageBoxView), message, null);


            var p = new DialogParameters();
            p.Add(nameof(ViewCTextBox), ViewCTextBox);
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, p));
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
            ViewCTextBox = parameters.GetValue<String>(nameof(ViewCTextBox));
        }
    }
}
