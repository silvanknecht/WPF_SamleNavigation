using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using SchoolManagementSystemWPF.Navigation;

namespace SchoolManagementSystemWPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly MainNavigator _mainNavigator;

        private ViewModelBase _currentVm;
        public ViewModelBase CurrentVm
        {
            get => _currentVm;
            set
            {
                if (_currentVm == value) return;
                _currentVm = value;
                RaisePropertyChanged();
            }
        }

        public ICollection<Button> NavElements { get; }
        public ICommand NavigateBack { get; }

        public MainViewModel(MainNavigator mainNavigator)
        {
            _mainNavigator = mainNavigator;
            NavElements = _mainNavigator.NavElements;

            _mainNavigator.Navigating += Navigator_Navigating;
            _mainNavigator.NavigateTo(ViewModelEnum.Class);

            NavigateBack = new RelayCommand((() => _mainNavigator.NavigateBack()));
        }

        private void Navigator_Navigating(object sender, ViewModelBase e)
        {
            if (sender == _mainNavigator)
                CurrentVm = e;
        }
    }
}

