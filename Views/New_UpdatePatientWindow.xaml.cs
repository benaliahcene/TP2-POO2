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
    /// Logique d'interaction pour New_UpdatePatientWindow.xaml
    /// </summary>
    public partial class New_UpdatePatientWindow : Window
    {
        public New_UpdatePatientWindow(int selectIdDoctor)
        {
            InitializeComponent();
            DataContext = new ViewModels.NewPatientViewModel(selectIdDoctor, this);
            (DataContext as NewPatientViewModel).RequestClose += (s, e) => this.Close();
        }
    }
}
