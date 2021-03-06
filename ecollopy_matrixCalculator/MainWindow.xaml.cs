﻿using System;
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
        Matrix matrix1 = new Matrix(new double[,] { { 1, 3 }, { -2, 4 } });
        Matrix matrix2 = new Matrix(new double[,] { { 5, 6 }, { 7, 8 } });
        int matrixSize;
        int scalar = 2;
        Mode currentMode;
        
        public MainWindow()
        {
            InitializeComponent();
            //MatrixMath.Test(matrix1, matrix2, scalar);
        }

        public void Calculate()
        {
            Matrix result = new Matrix(new double[matrixSize, matrixSize]);
            matrix1 = new Matrix(new double[matrixSize, matrixSize]);
            matrix1 = new Matrix(new double[matrixSize, matrixSize]);
            try
            {
                scalar = Convert.ToInt32(ScalarInput.Text);
            }
            catch (FormatException e)
            {

            }
            try
            {
                //Do the calculation
                if (currentMode == Mode.Add)
                {
                    for (int i = 0; i < matrixSize; i++)
                    {
                        for (int j = 0; j < matrixSize; j++)
                        {
                            TextBox textBox1 = AddInput1MatrixGrid.Children[i * matrixSize + j] as TextBox;
                            matrix1.SetValue(i, j, Convert.ToDouble(textBox1.Text));
                            TextBox textBox2 = AddInput2MatrixGrid.Children[i * matrixSize + j] as TextBox;
                            matrix2.SetValue(i, j, Convert.ToDouble(textBox2.Text));
                        }
                    }
                    result = MatrixMath.Add(matrix1, matrix2);
                }
                if (currentMode == Mode.Subtract)
                {
                    for (int i = 0; i < matrixSize; i++)
                    {
                        for (int j = 0; j < matrixSize; j++)
                        {
                            TextBox textBox1 = SubtractInput1MatrixGrid.Children[i * matrixSize + j] as TextBox;
                            matrix1.SetValue(i, j, Convert.ToDouble(textBox1.Text));
                            TextBox textBox2 = SubtractInput2MatrixGrid.Children[i * matrixSize + j] as TextBox;
                            matrix2.SetValue(i, j, Convert.ToDouble(textBox2.Text));
                        }
                    }
                    result = MatrixMath.Subtract(matrix1, matrix2);
                }
                if (currentMode == Mode.Multiply)
                {
                    for (int i = 0; i < matrixSize; i++)
                    {
                        for (int j = 0; j < matrixSize; j++)
                        {
                            TextBox textBox1 = MultiplyInput1MatrixGrid.Children[i * matrixSize + j] as TextBox;
                            matrix1.SetValue(i, j, Convert.ToDouble(textBox1.Text));
                            TextBox textBox2 = MultiplyInput2MatrixGrid.Children[i * matrixSize + j] as TextBox;
                            matrix2.SetValue(i, j, Convert.ToDouble(textBox2.Text));
                        }
                    }
                    result = MatrixMath.Multiply(matrix1, matrix2);
                }
                if (currentMode == Mode.Scale)
                {
                    for (int i = 0; i < matrixSize; i++)
                    {
                        for (int j = 0; j < matrixSize; j++)
                        {
                            TextBox textBox1 = ScaleInputMatrixGrid.Children[i * matrixSize + j] as TextBox;
                            matrix1.SetValue(i, j, Convert.ToDouble(textBox1.Text));
                        }
                    }
                    result = MatrixMath.Scale(matrix1, scalar);
                }
                if (currentMode == Mode.Invert)
                {
                    for (int i = 0; i < matrixSize; i++)
                    {
                        for (int j = 0; j < matrixSize; j++)
                        {
                            TextBox textBox1 = InvertInputMatrixGrid.Children[i * matrixSize + j] as TextBox;
                            matrix1.SetValue(i, j, Convert.ToDouble(textBox1.Text));
                        }
                    }
                    result = MatrixMath.Invert(matrix1);
                }

                //Make the output show in the GUI.
                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j < matrixSize; j++)
                    {
                        TextBox textBox = ResultGrid.Children[i * ResultGrid.ColumnDefinitions.Count + j] as TextBox; //HOLY MATH BATMAN!
                        textBox.Text = "" + result.GetValue(i, j);
                    }
                }
            }
            catch (FormatException e)
            {
                //Make the output show in the GUI.
                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j < matrixSize; j++)
                    {
                        TextBox textBox = ResultGrid.Children[i * ResultGrid.ColumnDefinitions.Count + j] as TextBox; //HOLY MATH BATMAN!
                        textBox.Text = "X";
                    }
                }
            }
        }

        public void ChangeMode(Mode newMode)
        {
            currentMode = newMode;
            ColorChange();
            ButtonChange();

        }

        #region MatrixResizing
        public void ChangeSize()
        {
            List<Grid> Matricies = new List<Grid>();
            Matricies.Add(AddInput1MatrixGrid);
            Matricies.Add(AddInput2MatrixGrid);
            Matricies.Add(SubtractInput1MatrixGrid);
            Matricies.Add(SubtractInput2MatrixGrid);
            Matricies.Add(MultiplyInput1MatrixGrid);
            Matricies.Add(MultiplyInput2MatrixGrid);
            Matricies.Add(ScaleInputMatrixGrid);
            Matricies.Add(InvertInputMatrixGrid);
            Matricies.Add(ResultGrid);

            foreach (Grid grid in Matricies)
            {
                grid.ColumnDefinitions.Clear();
                grid.RowDefinitions.Clear();
            }

            for (int i = 0; i < matrixSize; i++)
            {
                AddColumn(Matricies);
                AddRow(Matricies);
            }

            foreach (Grid grid in Matricies)
            {
                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j < matrixSize; j++){
                        TextBox textBox = new TextBox();
                        textBox.Width = 70;
                        textBox.Height = 70;
                        textBox.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                        textBox.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                        textBox.FontSize = 25;
                        //textBox.Margin = (Thickness) 3;
                        Grid.SetRow(textBox, i);
                        Grid.SetColumn(textBox, j);
                        grid.Children.Add(textBox);
                    }
                }
            }
        }

        public void AddColumn(List<Grid> grids)
        {
            foreach (Grid grid in grids)
            {
                ColumnDefinition coldef = new ColumnDefinition();
                grid.ColumnDefinitions.Add(coldef);
            }
        }

        public void AddRow(List<Grid> grids)
        {
            foreach (Grid grid in grids)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
        }

        private void MatrixSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            matrixSize = MatrixSizeComboBox.SelectedIndex + 2;
            ChangeSize();
        }
        #endregion

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
