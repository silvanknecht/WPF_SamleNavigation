using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using SchoolManagementSystemWPF.ViewModel;
using SchoolManagementSystemWPF.ViewModel.Dashboard;

namespace SchoolManagementSystemWPF.Navigation
{

    public interface INavigator
    {
        ICollection<Button> NavElements { get; }
        void ConfigureNewViewModel(string content, ViewModelEnum key, ViewModelBase viewModelBase);
        event EventHandler<ViewModelBase> Navigating;
    }

    public class MainNavigator : Navigator
    {
        public MainNavigator(DashboardViewModel dashboardViewModel, ClassViewModel classViewModel)
        {
            this.ConfigureNewViewModel("Dashboard", ViewModelEnum.Dashboard, dashboardViewModel);
            this.ConfigureNewViewModel("Class", ViewModelEnum.Class, classViewModel);
        }
    }


    public class DashboardNavigator : Navigator
    {
        public DashboardNavigator(AttendanceViewModel attendanceViewModel, MarksViewModel marksViewModel)
        {
            this.ConfigureNewViewModel("Attendance", ViewModelEnum.Attendance, attendanceViewModel);
            this.ConfigureNewViewModel("Marks", ViewModelEnum.Marks, marksViewModel);
        }
    }

    public abstract class Navigator : INavigator
    {
        private readonly Stack<ViewModelBase> _viewModelStack = new Stack<ViewModelBase>();
        public ICollection<Button> NavElements { get; } = new List<Button>();
        private IDictionary<ViewModelEnum, ViewModelBase> NavItems { get; } = new Dictionary<ViewModelEnum, ViewModelBase>();

        public event EventHandler<ViewModelBase> Navigating;
        private readonly ICommand _navigateToCommand;

        protected Navigator()
        {
            _navigateToCommand = new RelayCommand<string>((s) =>
            {
                Enum.TryParse(s, true, out ViewModelEnum viewModelEnum);
                this.NavigateTo(viewModelEnum);
            });
        }


        public void ConfigureNewViewModel(string content, ViewModelEnum key, ViewModelBase viewModelBase)
        {

            NavItems.Add(key, viewModelBase);
            NavElements.Add(new Button() { Content = content, Command = _navigateToCommand, CommandParameter = key });
        }

        public void NavigateTo(ViewModelEnum key)
        {
            var vmToNavigateTo = NavItems[key];
            if (_viewModelStack.Count == 0)
            {
                _viewModelStack.Push(vmToNavigateTo);
            }
            else
            {
                if (_viewModelStack.Peek() != vmToNavigateTo)
                    _viewModelStack.Push(vmToNavigateTo);
            }

            Navigating?.Invoke(this, vmToNavigateTo);
        }


        public void NavigateBack()
        {
            if (_viewModelStack.Count > 1)
                _viewModelStack.Pop();

            Navigating?.Invoke(this, _viewModelStack.Peek());
        }
    }
}


