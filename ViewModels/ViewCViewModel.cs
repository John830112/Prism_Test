using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using PSamples.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using PSamples.Services;
using PSamples.Views;

namespace PSamples.ViewModels
{
    public class ViewCViewModel : BindableBase, IDialogAware
    {
        /* -------------------------------------------------------------
           PopUp화면을 표시하는 경우는 대상의 ViewModel에서 IDialogAware을 실장하고 있지 않으면 
           동작 하지 않는다.
           ------------------------------------------------------------- */
        public event Action<IDialogResult> RequestClose;
        public DelegateCommand OKButton { get; }

        IDialogService _dialogService;
        IMessageService _messageService;


        public string Title => "ViewC의 타이틀";

        private string _viewCTextBox = "XXX";
        public string ViewCTextBox
        {
            get { return _viewCTextBox; }
            set { SetProperty(ref _viewCTextBox, value); }
        }

        public ViewCViewModel(IDialogService dialogService) : this(dialogService, new MessageService())
        { }
        public ViewCViewModel(IDialogService dialogService, IMessageService messageService) 
        {
            OKButton = new DelegateCommand(OKButtonExecute);
            _dialogService = dialogService;
            _messageService = messageService;
        }

        private void OKButtonExecute()
        {
            //MessageBox.Show("Save 합니다.");
            
            //var message = new DialogParameters();
            //message.Add(nameof(MessageBoxViewModel.Message), "저장합니다");
            //_dialogService.ShowDialog(nameof(MessageBoxView), message, null);







            if(_messageService.Question("저장 합니까?") == MessageBoxResult.OK)
            {
                _messageService.ShowDialog("저장 했습니다");
            }


            var p = new DialogParameters();
            p.Add(nameof(ViewCTextBox), ViewCTextBox);
            /* -------------------------------------------------------------
               IDialogAware에 정의 되어 있는 RequestClose를 Invoke하면 화면이 
               닫치고 DialogResult와 파리미터가 호출처의 콜벡함수에 통지된다. 
               ------------------------------------------------------------- */
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, p));
        }

        public bool CanCloseDialog()
        {
            /* -------------------------------------------------------------
               이 화면을 닫을 수 있는지? 의미입니다. 닫을 수 있게 할려면  
               True로 한다.
               ------------------------------------------------------------- */
            return true;
        }

        public void OnDialogClosed()
        {
            /* -------------------------------------------------------------
               이 창이 닫힐때 동작한다.
               ------------------------------------------------------------- */
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            /* -------------------------------------------------------------
               이 창이 열릴 때 동작합니다. 파라미터를 받을 경우 여기서 받는다.
               ------------------------------------------------------------- */
            ViewCTextBox = parameters.GetValue<String>(nameof(ViewCTextBox));
        }
    }
}
