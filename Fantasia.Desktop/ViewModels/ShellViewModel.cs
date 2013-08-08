using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//importamos
using System.ComponentModel;
using System.Windows;
using Microsoft.Practices.Prism.Events;
using Ikaros.Infrastructure.Navigation;


namespace Ikaros.Desktop.ViewModels
{
    public class ShellViewModel:INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public ShellViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
        }

        private Visibility navigationPaneVisibility = Visibility.Collapsed;
        public Visibility NavigationPaneVisibility
        {
            get { return navigationPaneVisibility; }

            set
            {
                if (navigationPaneVisibility != value)
                {
                    navigationPaneVisibility = value;
                    NotifyPropertyChanged("NavigationPaneVisibility");
                }
            }
        }

        private string version;
        public string Version
        {
            get { return version; }

            set
            {
                if (version != value)
                {
                    version = value;
                    NotifyPropertyChanged("Version");
                }
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        
    }
}
