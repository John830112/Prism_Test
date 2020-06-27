using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PSamples.Views;
using System;

namespace PSamples.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        public DelegateCommand SystemDateUpdateButton { get; }
        public DelegateCommand ShowViewAButton { get; }
        public DelegateCommand ShowViewBButton { get; }

        private readonly IRegionManager _regionManager;
        
        private string _title = "PSampes";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }




        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            SystemDateUpdateButton = new DelegateCommand(SystemDateUpdateButtonExecute);
            ShowViewAButton = new DelegateCommand(ShowViewAButtonExecute);
            ShowViewBButton = new DelegateCommand(ShowViewBButtonExecute);
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

        private void ShowViewAButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(ViewA));
        }

        private void ShowViewBButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(ViewB));
        }
    }
}
