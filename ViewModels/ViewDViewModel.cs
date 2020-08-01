using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PSamples.ViewModels
{
    public class ViewDViewModel : BindableBase
    {

        MainWindowViewModel _mainWindowViewModel;

        public DelegateCommand<object[]> ProductsSelectionChanged { get; }
        public ViewDViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _ares.Add("나라");
            _ares.Add("나고야");
            _ares.Add("금실역");

            _products.Add(new ComboBoxViewModel(10, "방"));
            _products.Add(new ComboBoxViewModel(20, "우유"));
            _products.Add(new ComboBoxViewModel(30, "우산"));

            ProductsSelectionChanged = new DelegateCommand<object[]>(ProductsSelectionChangedExecute);
        }

        private void ProductsSelectionChangedExecute(object[] selectedItems)
        {
            try
            {
                var selectedItem = selectedItems[0] as ComboBoxViewModel;
                SelectedText = selectedItem.Value + ":" + selectedItem.DisplayValue;

                _mainWindowViewModel.Title = SelectedText;
            }
            catch
            { }
        }

        private string _selectedText = "";
        public string SelectedText
        {
            get { return _selectedText; }
            set { SetProperty(ref _selectedText, value); }
        }

        //ComboBox의 선택된 아이템
        private ComboBoxViewModel _selectedProduct = null;
        public ComboBoxViewModel SelectedProduct
        {
            get { return _selectedProduct; }
            set { SetProperty(ref _selectedProduct, value); }
        }


        //ListBox의 ItemSource 바인드 객체
        private ObservableCollection<string> _ares = new ObservableCollection<string>();
        public ObservableCollection<string> Areas
        {
            get { return _ares; }
            set { SetProperty(ref _ares, value); }
        }

        //ViewD의 ComboBox의 Item모델의 객체 생성
        private ObservableCollection<ComboBoxViewModel> _products = new ObservableCollection<ComboBoxViewModel>();
        public ObservableCollection<ComboBoxViewModel> Products
        {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }
    }
}
