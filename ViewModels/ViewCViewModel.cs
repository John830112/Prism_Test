using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSamples.ViewModels
{
    public class ViewCViewModel : BindableBase, IDialogAware
    {
        private string _viewCTextBox = "XXX";

        public event Action<IDialogResult> RequestClose;

        public DelegateCommand OKButton { get; }


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

        public ViewCViewModel()
        {
            OKButton = new DelegateCommand(OKButtonExecute);

        }

        private void OKButtonExecute()
        {
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
