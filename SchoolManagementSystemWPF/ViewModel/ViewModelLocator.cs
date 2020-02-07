/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:SchoolManagementSystemWPF"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using SchoolManagementSystemWPF.Navigation;
using SchoolManagementSystemWPF.ViewModel.Dashboard;


namespace SchoolManagementSystemWPF.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<DashboardViewModel>();
            SimpleIoc.Default.Register<ClassViewModel>();
            SimpleIoc.Default.Register<MainNavigator>();
            SimpleIoc.Default.Register<DashboardNavigator>();
            SimpleIoc.Default.Register<MarksViewModel>();
            SimpleIoc.Default.Register<AttendanceViewModel>();

        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public DashboardViewModel Dashboard => ServiceLocator.Current.GetInstance<DashboardViewModel>();
        public ClassViewModel Class => ServiceLocator.Current.GetInstance<ClassViewModel>();
        public MarksViewModel Marks => ServiceLocator.Current.GetInstance<MarksViewModel>();
        public AttendanceViewModel Attendance => ServiceLocator.Current.GetInstance<AttendanceViewModel>();

        public static void Cleanup()
        {
            SimpleIoc.Default.Unregister<MainViewModel>();
            SimpleIoc.Default.Unregister<DashboardViewModel>();
            SimpleIoc.Default.Unregister<ClassViewModel>();
            SimpleIoc.Default.Unregister<MainNavigator>();
            SimpleIoc.Default.Unregister<DashboardNavigator>();
            SimpleIoc.Default.Unregister<MarksViewModel>();
            SimpleIoc.Default.Unregister<AttendanceViewModel>();
        }
    }
}