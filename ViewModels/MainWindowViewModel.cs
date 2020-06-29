using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using PSamples.Views;
using System;

namespace PSamples.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        public DelegateCommand SystemDateUpdateButton { get; }
        public DelegateCommand ShowViewAButton { get; }
        public DelegateCommand ShowViewBButton { get; }
        public DelegateCommand ShowViewCButton { get; }

        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;
        
        private string _title = "PSampes";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        public MainWindowViewModel(IRegionManager regionManager, 
                                   IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;
            
            SystemDateUpdateButton = new DelegateCommand(SystemDateUpdateButtonExecute);
            ShowViewAButton = new DelegateCommand(ShowViewAButtonExecute);
            ShowViewBButton = new DelegateCommand(ShowViewBButtonExecute);
            ShowViewCButton = new DelegateCommand(ShowViewCButtonExecute);
        }


        private string _systemDateLabel = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        public string SystemDateLabel
        {
            get { return _systemDateLabel; }
            set { SetProperty(ref _systemDateLabel, value); }
        }

        private void SystemDateUpdateButtonExecute()
        {
            SystemDateLabel = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        // ViewA를 천이하는 실행 함수
        private void ShowViewAButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(ViewA));
        }

        // ViewB를 천이하는 실행 함수
        private void ShowViewBButtonExecute()
        {
            var p = new NavigationParameters();
            p.Add(nameof(ViewBViewModel.MyLabel), SystemDateLabel);  //MyLabel의 key값으로  SystemDateLabel의 데이터를 넘김
            p.Add("a", Title);  //배열형식으로 "a"의 key값으로 Title의 데이터를 넘김.

            /*--------------------------------------------------------------------
              첫번째 인자는 컨텐츠 컨트롤의 RegionName 값을 지정, 표시할 View명칭, 
              NavigationParameters형식의 값을 넘김
              --------------------------------------------------------------------*/
            _regionManager.RequestNavigate("ContentRegion", nameof(ViewB), p);  
        }

        // ViewC를 천이하는 실행 함수
        private void ShowViewCButtonExecute()
        {
            var p = new DialogParameters();
            p.Add(nameof(ViewCViewModel.ViewCTextBox), SystemDateLabel);
            
            //dialog를 표시하는 함수(뷰명칭, 파라미터, 콜벡함수)
            _dialogService.ShowDialog(nameof(ViewC), p, ViewCClose);
        }

        //ShowDialog가 닫혔을때 실행하는 콜벡 함수
        private void ViewCClose(IDialogResult dialogResult)
        {
            if(dialogResult.Result == ButtonResult.OK)
            {
                SystemDateLabel = dialogResult.Parameters.GetValue<string>(nameof(ViewCViewModel.ViewCTextBox));
            }           
        }
    }
}
