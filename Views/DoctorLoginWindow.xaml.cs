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
using System.Windows.Shapes;
using TP2_POO2.ViewModels;

namespace TP2_POO2.Views
{
    /// <summary>
    /// Logique d'interaction pour DoctorLoginWindow.xaml
    /// </summary>
    public partial class DoctorLoginWindow : Window
    {
        public DoctorLoginWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.DoctorViewModel(this);
            (DataContext as DoctorViewModel).RequestClose += (s, e) => this.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
