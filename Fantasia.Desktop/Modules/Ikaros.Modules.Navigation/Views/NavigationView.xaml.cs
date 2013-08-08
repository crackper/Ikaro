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
using Ikaros.Modules.Navigation.ViewModels;

namespace Ikaros.Modules.Navigation.Views
{
    /// <summary>
    /// Lógica de interacción para NavigationView.xaml
    /// </summary>
    public partial class NavigationView : UserControl
    {
        public NavigationView(NavigationViewModel viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
