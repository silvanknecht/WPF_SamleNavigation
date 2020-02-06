using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace SchoolManagementSystemWPF.Navigation
{

    internal interface INavigator
    {
        void NavigatTo(ViewModelBase viewModelBase);
        void NavigateBack();
        void StartNavigationAt(ViewModelBase viewModelBase);
        event EventHandler<ViewModelBase> Navigating;
    }

    public class Navigator : INavigator
    {
        private Stack<ViewModelBase> viewModelStack = new Stack<ViewModelBase>();

        public void NavigatTo(ViewModelBase viewModelBase)
        {
            viewModelStack.Push(viewModelBase);
            Navigating?.Invoke(this, viewModelStack.Peek());
        }

        public void NavigateBack()
        {
            if (viewModelStack.Count <= 1) Navigating?.Invoke(this, viewModelStack.Peek());

            viewModelStack.Pop();
            Navigating?.Invoke(this, viewModelStack.Peek());
        }

        public void StartNavigationAt(ViewModelBase viewModelBase)
        {
            viewModelStack.Push(viewModelBase);
            Navigating?.Invoke(this, viewModelStack.Peek());
        }

        public event EventHandler<ViewModelBase> Navigating;
    }
}
