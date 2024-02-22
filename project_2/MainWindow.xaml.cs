using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Drawing;
using System.Net;

namespace project_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Driver driver = new Driver();
        public MainWindow()
        {
            InitializeComponent();
            //foreach (COLOREYES color in Enum.GetValues(typeof(COLOREYES)))
            //{
            //    comboBoxEyes.Items.Add(color);
            //}
            comboBoxEyes.SelectedIndex = 0;
            newDriver();
            grid.DataContext = driver;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(driver.ToString());
        }

        private void newDriver()
        {
            driver.Name = "Harry Windsor";
            driver.Class1 = 'A';
            driver.Address = "Colorado";
            driver.Number = 2156461;
            driver.Hgt = 185;
            driver.Dob = new DateTime(1992, 9, 15);
            driver.Iss = new DateTime(2022, 12, 12);
            driver.Exp = new DateTime(2027, 12, 12);
            driver.Donor = true;
            driver.Gender = GENDER.male;
            driver.Eyes = COLOREYES.brown;
            driver.ImagePath = "images/harry-windsor.jpg";
        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {

            driver.Name = "Leonardo Dicaprio";
            driver.Class1 = 'C';
            driver.Address = "Washington";
            driver.Number = 789451;
            driver.Hgt = 200;
            driver.Dob = new DateTime(1995, 9, 15);
            driver.Iss = new DateTime(2015, 12, 12);
            driver.Exp = new DateTime(2024, 12, 12);
            driver.Donor = false;
            driver.Gender = GENDER.other;
            driver.Eyes = COLOREYES.blue;
            driver.ImagePath = "images/leo.jpeg";

        }

        private void image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Файлы (jpg)|*.jpg|Все файлы|*.*";
            if (dialog.ShowDialog() == true)
            {
                driver.ImagePath = dialog.FileName;
                image.Source = new BitmapImage(new Uri(driver.ImagePath, UriKind.RelativeOrAbsolute));
            }

        }

        private void ButtonCLear_Click(object sender, RoutedEventArgs e)
        {
            textBoxName.Clear();
            textBoxClass.Clear();
            textBoxNumber.Clear();
            textBoxAddress.Clear();
            datePickerDOB.SelectedDate = null;
            datePickerISS.SelectedDate = null;
            datePickerEXP.SelectedDate = null;
            checkBoxDonor.IsChecked = false;
            sliderHGT.Value = sliderHGT.Minimum;
            radioButtonFemale.IsChecked = false;
            radioButtonOther.IsChecked = false;
            radioButtonMale.IsChecked = false;
            comboBoxEyes.SelectedItem = null;
            image.Source = new BitmapImage(new Uri("images/avatar.png", UriKind.RelativeOrAbsolute));
        }
    }
}
