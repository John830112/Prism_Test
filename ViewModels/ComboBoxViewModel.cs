using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSamples.ViewModels
{
    public class ComboBoxViewModel : BindableBase
    {
        public ComboBoxViewModel(int value, string displayValue)
        {
            Value = value;
            DisplayValue = displayValue;
        }

        public int Value { get; }
        public string DisplayValue { get; }
    }
}
