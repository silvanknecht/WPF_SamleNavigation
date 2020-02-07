using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using SchoolManagementSystemWPF.Navigation;

namespace SchoolManagementSystemWPF.ViewModel
{
    public class DashboardViewModel : ViewModelBase
    {
        private readonly DashboardNavigator _dashboardNavigator;
        public SolidColorBrush BackgroundColor { get; } = new SolidColorBrush(Colors.White);

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

        private string _testString;

        public string TestString
        {
            get => _testString;

            set
            {
                if (_testString == value) return;
                _testString = value;
                RaisePropertyChanged();
            }
        }

        public ICollection<Button> NavElements { get; }

        public DashboardViewModel(DashboardNavigator dashboardNavigator)
        {
            _dashboardNavigator = dashboardNavigator;
            NavElements = _dashboardNavigator.NavElements;

            _dashboardNavigator.Navigating += DashboardNavigator_Navigating;
            _dashboardNavigator.NavigateTo(ViewModelEnum.Attendance);


            TestString = "Dashboard";
        }

        private void DashboardNavigator_Navigating(object sender, ViewModelBase e)
        {
            if (sender == _dashboardNavigator)
                CurrentVm = e;
        }
    }
}
