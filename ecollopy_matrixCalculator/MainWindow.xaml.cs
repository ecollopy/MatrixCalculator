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

namespace ecollopy_matrixCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Matrix matrix1;
        Matrix matrix2;
        int matrixSize;
        Mode currentMode;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Calculate()
        {
            //Does Shit.
        }

        public void ChangeMode(Mode newMode)
        {
            currentMode = newMode;
            ColorChange();
            ButtonChange();
        }

        #region ButtonClickEvents
        private void AdditionButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeMode(Mode.Add);
        }

        private void SubtractionButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeMode(Mode.Subtract);
        }

        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeMode(Mode.Multiply);
        }

        private void ScaleTabButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeMode(Mode.Scale);
        }

        private void InvertButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeMode(Mode.Invert);
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
        }
        #endregion

        #region StylingMethods
        public void ColorChange()
        {
            SolidColorBrush color1 = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            SolidColorBrush color2 = new SolidColorBrush(Color.FromRgb(150, 150, 150));
            SolidColorBrush color3 = new SolidColorBrush(Color.FromRgb(100, 100, 100));
            if (currentMode == Mode.Add)
            {
                color1 = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                color2 = new SolidColorBrush(Color.FromRgb(150, 0, 0));
                color3 = new SolidColorBrush(Color.FromRgb(100, 0, 0));
            }
            if (currentMode == Mode.Subtract)
            {
                color1 = new SolidColorBrush(Color.FromRgb(255, 255, 0));
                color2 = new SolidColorBrush(Color.FromRgb(150, 150, 0));
                color3 = new SolidColorBrush(Color.FromRgb(100, 100, 0));
            }
            if (currentMode == Mode.Multiply)
            {
                color1 = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                color2 = new SolidColorBrush(Color.FromRgb(0, 150, 0));
                color3 = new SolidColorBrush(Color.FromRgb(0, 100, 0));
            }
            if (currentMode == Mode.Scale)
            {
                color1 = new SolidColorBrush(Color.FromRgb(0, 255, 255));
                color2 = new SolidColorBrush(Color.FromRgb(0, 150, 150));
                color3 = new SolidColorBrush(Color.FromRgb(0, 100, 100));
            }
            if (currentMode == Mode.Invert)
            {
                color1 = new SolidColorBrush(Color.FromRgb(0, 0, 255));
                color2 = new SolidColorBrush(Color.FromRgb(0, 0, 150));
                color3 = new SolidColorBrush(Color.FromRgb(0, 0, 100));
            }
            MainGrid.Background = color1;
            Header.Background = color2;
            Tabs.Background = color3;
            CalculationPanelGrid.Background = color2;
            BottomBar.Background = color3;
        }
        public void ButtonChange()
        {

        }
        #endregion
    }
}
