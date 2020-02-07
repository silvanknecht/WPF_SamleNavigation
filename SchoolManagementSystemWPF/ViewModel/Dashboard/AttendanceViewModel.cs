using System.Windows.Media;
using GalaSoft.MvvmLight;

namespace SchoolManagementSystemWPF.ViewModel.Dashboard
{
    public class AttendanceViewModel : ViewModelBase
    {
        public SolidColorBrush BackgroundColor { get; } = new SolidColorBrush(Colors.DarkRed);
    }
}
