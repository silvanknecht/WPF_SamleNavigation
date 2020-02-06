using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using SchoolManagementSystemWPF.Navigation;

namespace SchoolManagementSystemWPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        public ICommand NavigateTo { get; }

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

        private readonly Dictionary<string, ViewModelBase> _mainNavigationViews = new Dictionary<string, ViewModelBase>()
        {
            {"Dashboard", new DashboardViewModel()},
            {"Class", new ClassViewModel()}
        };

        private Navigator _navigator;

        public MainViewModel()
        {
            _navigator = new Navigator();
            _navigator.Navigating += Navigator_Navigating;


            _navigator.StartNavigationAt(_mainNavigationViews["Dashboard"]);

            NavigateTo = new RelayCommand<string>((s => _navigator.NavigatTo(_mainNavigationViews[s])));
        }

        private void Navigator_Navigating(object sender, ViewModelBase e)
        {
            CurrentVm = e;
        }
    }

}

