using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//importamos
using Ikaros.Infrastructure.Navigation;
using Ikaros.Desktop.ViewModels;

namespace Ikaros.Desktop
{
    /// <summary>
    /// Lógica de interacción para Shell.xaml
    /// </summary>
    public partial class Shell : Window
    {
        private readonly INavigationService _navigationService;

        public Shell(ShellViewModel viewModel, INavigationService navigationService)
        {
            InitializeComponent();

            _navigationService = navigationService;
            this.DataContext = viewModel;
        }
    }
}
