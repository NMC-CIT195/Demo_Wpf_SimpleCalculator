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
        private enum Units { feet, meters };

        Units _units;

        public MainWindow()
        {
            InitializeComponent();
            InitializeWindow();
        }

        private void InitializeWindow()
        {
            TextBox_Length.Focus();

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

        /// <summary>
        /// calculate the volume and display the value
        /// </summary>
        private void Button_Calculate_Click(object sender, RoutedEventArgs e)
        {
            double volume = 0;
            double shapeMultiplier = 1;
            string shape = ComboBox_Shape.SelectionBoxItem as string;
            string userFeedback;

            if (ValidInputs(out userFeedback))
            {
                volume =
                    Convert.ToDouble(TextBox_Length.Text) *
                    Convert.ToDouble(TextBox_Width.Text) *
                    Convert.ToDouble(TextBox_Height.Text);

                switch (shape)
                {
                    case "Rectangular Prism":
                        shapeMultiplier = 1;
                        break;
                    case "Pyramidal Prism":
                        shapeMultiplier = 1.0 / 3.0;
                        break;
                    default:
                        shapeMultiplier = 1;
                        break;
                }

                volume *= shapeMultiplier;

                TextBox_Volume.Text = String.Format("{0:0.##}", volume);
            }
            else
            {
                MessageBox.Show(userFeedback);
            }
        }

        /// <summary>
        /// validate all inputs and generate a user feedback message if necessary 
        /// </summary>
        /// <param name="userFeedback">user feedback message</param>
        /// <returns>valid inputs status</returns>
        private bool ValidInputs(out string userFeedback)
        {
            bool validInputs = true;
            userFeedback = "";

            if (!double.TryParse(TextBox_Length.Text, out double tempLength))
            {
                validInputs = false;
                userFeedback += "It appears that the value entered for Length is not a valid number." + Environment.NewLine;
            }
            if (!double.TryParse(TextBox_Width.Text, out double tempWidth))
            {
                validInputs = false;
                userFeedback += "It appears that the value entered for Width is not a valid number." + Environment.NewLine;
            }
            if (!double.TryParse(TextBox_Height.Text, out double tempHeight))
            {
                validInputs = false;
                userFeedback += "It appears that the value entered for Height is not a valid number." + Environment.NewLine;
            }

            return validInputs;
        }

        private void RadioButton_Units_Checked(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                UpdateUnits();
            }
        }

        /// <summary>
        /// update units in labels
        /// </summary>
        private void UpdateUnits()
        {
            if ((bool)RadioButton_Feet.IsChecked)
            {
                _units = Units.feet;
            }
            else if ((bool)RadioButton_Meters.IsChecked)
            {
                _units = Units.meters;
            }

            Label_Length.Content = "Length (" + _units + ")";
            Label_Width.Content = "Width (" + _units + ")";
            Label_Height.Content = "Height (" + _units + ")";
            Label_Volume.Content = "Volume (cubic " + _units + ")";
        }
    }
}
