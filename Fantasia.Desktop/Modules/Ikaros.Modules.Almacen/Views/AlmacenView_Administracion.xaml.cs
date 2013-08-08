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
using Ikaros.Modules.Almacen.ViewModels;

namespace Ikaros.Modules.Almacen.Views
{
    /// <summary>
    /// Lógica de interacción para AlmacenView_Administracion.xaml
    /// </summary>
    public partial class AlmacenView_Administracion : UserControl
    {
        public AlmacenView_Administracion(AlmacenAdministracionViewModel viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
