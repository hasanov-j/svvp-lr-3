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
using Microsoft.Win32;

namespace project_1
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
            foreach (COLOREYES color in Enum.GetValues(typeof(COLOREYES)))
            {
                comboBoxEyes.Items.Add(color);
            }
            comboBoxEyes.SelectedIndex = 0;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            driver.Name = textBoxName.Text;
            driver.Address = textBoxAddress.Text;
            Int32.TryParse(textBoxNumber.Text, out int a);
            driver.Number = a;
            if (textBoxClass.Text.Length > 0)
            {
                driver.Class1 = textBoxClass.Text[0];
            }
            else
            {
                driver.Class1 = 'A';
            }
            if (datePickerDOB.SelectedDate.HasValue)
            {
                driver.Dob = datePickerDOB.SelectedDate.Value;
            }
            if (datePickerISS.SelectedDate.HasValue)
            {
                driver.Iss = datePickerISS.SelectedDate.Value;
            }
            if (datePickerEXP.SelectedDate.HasValue)
            {
                driver.Exp = datePickerEXP.SelectedDate.Value;
            }
            driver.Donor = checkBoxDonor.IsChecked.Value;
            driver.Hgt = sliderHGT.Value;

            if (radioButtonMale.IsChecked == true)
            {
                driver.Gender = GENDER.male;
            }
            if (radioButtonFemale.IsChecked == true)
            {
                driver.Gender = GENDER.female;
            }
            if (radioButtonOther.IsChecked == true)
            {
                driver.Gender = GENDER.other;
            }

            if (comboBoxEyes.SelectedValue != null)
            {
                driver.Eyes = (COLOREYES)comboBoxEyes.SelectedValue;
            }

            MessageBox.Show(driver.ToString());
        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            driver = new Driver()
            {
                Name = "Harry Windsor",
                Class1 = 'A',
                Address = "Colorado",
                Number = 2156461,
                Hgt = 185,
                Dob = new DateTime(1992, 9, 15),
                Iss = new DateTime(2022, 12, 12),
                Exp = new DateTime(2027, 12, 12),
                Donor = true,
                Gender = GENDER.male,
                Eyes = COLOREYES.brown,
                ImagePath = "images/harry-windsor.jpg",
            };

            textBoxName.Text = driver.Name;
            textBoxClass.Text = driver.Class1.ToString();
            textBoxNumber.Text = driver.Number.ToString();
            textBoxAddress.Text = driver.Address;
            datePickerDOB.SelectedDate = driver.Dob;
            datePickerISS.SelectedDate = driver.Iss;
            datePickerEXP.SelectedDate = driver.Exp;
            checkBoxDonor.IsChecked = driver.Donor;
            sliderHGT.Value = driver.Hgt;
            switch (driver.Gender)
            {
                case GENDER.male: radioButtonMale.IsChecked = true; break;
                case GENDER.female: radioButtonFemale.IsChecked = true; break;
                case GENDER.other: radioButtonOther.IsChecked = true; break;
            }
            comboBoxEyes.SelectedItem = driver.Eyes;
            image.Source = new BitmapImage(new Uri(driver.ImagePath, UriKind.RelativeOrAbsolute));
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
