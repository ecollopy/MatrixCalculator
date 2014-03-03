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

namespace ecollopy_matrixCalculator
{
    /// <summary>
    /// Interaction logic for MathWindow.xaml
    /// </summary>
    public partial class MathWindow : Window
    {
        Matrix matrix1 = new Matrix(new double[,] { { 1, 3 }, { -2, 4 } });
        Matrix matrix2 = new Matrix(new double[,] { { 5, 6 }, { 7, 8 } });
        int matrixSize;
        int scalar = 2;
        Mode currentMode;
        
        public MathWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            //MatrixMath.Test(matrix1, matrix2, scalar);
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
            AddGrid.Visibility = Visibility.Collapsed;
            SubtractGrid.Visibility = Visibility.Collapsed;
            MultiplyGrid.Visibility = Visibility.Collapsed;
            ScaleGrid.Visibility = Visibility.Collapsed;
            InvertGrid.Visibility = Visibility.Collapsed;

            if (currentMode == Mode.Add)
            {
                AddGrid.Visibility = Visibility.Visible;
            }
            if (currentMode == Mode.Subtract)
            {
                SubtractGrid.Visibility = Visibility.Visible;
            }
            if (currentMode == Mode.Multiply)
            {
                MultiplyGrid.Visibility = Visibility.Visible;
            }
            if (currentMode == Mode.Scale)
            {
                ScaleGrid.Visibility = Visibility.Visible;
            }
            if (currentMode == Mode.Invert)
            {
                InvertGrid.Visibility = Visibility.Visible;
            }            
        }
        #endregion
    }
    }
}
