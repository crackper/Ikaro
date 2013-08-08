using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//importamos
using System.Windows.Threading;

namespace Ikaros.Infrastructure.MVVM
{
    public class ViewModelBase : ObservableObject
    {
        private bool isBusy = true;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    RaisePropertyChanged("IsBusy");
                }
            }
        }

        public ViewModelBase()
        {
            IsBusy = true;

            Dispatcher.CurrentDispatcher.BeginInvoke((Action)delegate
            {
                Initialize();

                IsBusy = false;
            }, DispatcherPriority.SystemIdle);
        }

        protected virtual void Initialize()
        {
        }
    }
}
