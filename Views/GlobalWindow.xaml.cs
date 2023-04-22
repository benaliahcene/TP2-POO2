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
    /// Logique d'interaction pour GlobalWindow.xaml
    /// </summary>
    public partial class GlobalWindow : Window
    {
        public GlobalWindow(int selectIdDoctor)
        {
            InitializeComponent();
            DataContext = new ViewModels.GlobalViewModel(selectIdDoctor,this);
            (DataContext as GlobalViewModel).RequestClose += (s, e) => this.Close();
        }
     /*   public GlobalWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.GlobalViewModel(this);
            (DataContext as GlobalViewModel).RequestClose += (s, e) => this.Close();
        }*/

    }
}
