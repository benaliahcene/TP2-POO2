using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Logique d'interaction pour NewDoctorWindow.xaml
    /// </summary>
    public partial class NewDoctorWindow : Window
    {
        public NewDoctorWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.NewDoctorViewModel(this);
            (DataContext as NewDoctorViewModel).RequestClose += (s, e) => this.Close();


        }
    }
    public class StringToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string stringValue = value as string;
            string targetValue = parameter as string;

            return stringValue == targetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isChecked = (bool)value;
            string targetValue = parameter as string;

            if (isChecked)
            {
                return targetValue;
            }
            else
            {
                return null;
            }
        }
    }


}
