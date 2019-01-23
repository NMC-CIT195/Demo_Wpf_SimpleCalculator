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

namespace Wpf_SimpleCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _units;

        public MainWindow()
        {
            InitializeComponent();
            InitializeWindow();
        }

        private void InitializeWindow()
        {
            TextBox_Length.BorderBrush = Brushes.Red;

            UpdateUnits();
        }

        private void Button_ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }

        private void Button_Calculate_Click(object sender, RoutedEventArgs e)
        {
            double answer = 0;

            if (ComboBox_Shape.SelectionBoxItem as string == "Rectangular Prism")
            {
                answer = 5;
            }

            SolutionWindow solutionWindow = new SolutionWindow(answer);
            solutionWindow.ShowDialog();
        }

        private void TextBox_Length_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(TextBox_Length.Text, out double temp))
            {
                TextBox_Length.Focus();
                MessageBox.Show("You must enter a number");
                TextBox_Length.Text = null;
            }
            else
            {
                TextBox_Length.BorderBrush = Brushes.Black;
            }
        }

        private void RadioButton_Units_Checked(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                UpdateUnits();
            }
        }

        private void UpdateUnits()
        {
            if ((bool)RadioButton_Feet.IsChecked)
            {
                _units = "feet";
            }
            else if ((bool)RadioButton_Meters.IsChecked)
            {
                _units = "meters";
            }

            Label_Length.Content = "Length (" + _units + ")";
            Label_Width.Content = "Width (" + _units + ")";
            Label_Height.Content = "Height (" + _units + ")";
            Label_Volume.Content = "Volume (cubic " + _units + ")";
        }

        private void TextBox_Height_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_Width_LostFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
