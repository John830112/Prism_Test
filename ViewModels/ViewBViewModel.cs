using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSamples.ViewModels
{
    public class ViewBViewModel : BindableBase, INavigationAware
    {
        public ViewBViewModel()
        {

        }

        private string _myLabel = string.Empty;
        public string MyLabel
        {
            get { return _myLabel; }
            set { SetProperty(ref _myLabel, value); }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            /* -------------------------------------------------------------
               나비게이션이 옮겨 왔을때 실행된다. 파라미터를 받고 싶은 경우는 여기에서 
               navigationContext로부터 취득가능.
               -------------------------------------------------------------*/
            MyLabel = navigationContext.Parameters.GetValue<string>(nameof(MyLabel));
        }







        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            /* -------------------------------------------------------------
               인스턴스를 여기저기서 사용할지 안할지를 설정. 
               여기저기서 사용할 경우는 True. 
               다시 말하면, 나비게이션방식에서 화면을 표시하거나 비표시하거나 할
               경우에, 이전의 값을 기억해 놓을 필요가 있다면, True. 매번 새롭게
               태어난다면 False로 해 놓음.
               -------------------------------------------------------------*/
            return true;
        }






        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            /* -------------------------------------------------------------
               나비게이션이 다른쪽으로 옮겨갈때에 실행됩니다. 종료 처리가 
               있는 경우등에 여기에 기술합니다. 
               -------------------------------------------------------------*/

        }
    }
}
