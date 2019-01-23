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

namespace Wpf_SimpleCalculator
{
    /// <summary>
    /// Interaction logic for SolutionWindow.xaml
    /// </summary>
    public partial class SolutionWindow : Window
    {
        private double _answer;

        public SolutionWindow(double answer)
        {
            _answer = answer;
            InitializeComponent();
            InitializeWindow();
        }

        private void InitializeWindow()
        {
            Label_Answer.Content = _answer;
        }
    }
}
