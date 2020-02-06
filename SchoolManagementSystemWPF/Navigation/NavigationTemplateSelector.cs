using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SchoolManagementSystemWPF.ViewModel;

namespace SchoolManagementSystemWPF.Navigation
{
    public class NavigationTemplateSelector : DataTemplateSelector
    {

        public DataTemplate DashboardTemplate { get; set; }
        public DataTemplate ClassTemplate { get; set; }


        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {

            if (item == null) return null;

            switch (item)
            {
                case DashboardViewModel vvm: return DashboardTemplate;
                case ClassViewModel vm: return ClassTemplate;
                default: throw new NotImplementedException("This View has not been implemented yet");
            }
        }
    }
}
