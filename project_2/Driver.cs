using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace project_2
{
    public enum GENDER { male, female, other };
    public enum COLOREYES { brown, green, blue };
    internal class Driver: INotifyPropertyChanged, IDataErrorInfo
    {
        int number;
        char class1;
        string name;
        string address;
        double hgt;
        DateTime dob;
        DateTime iss;
        DateTime exp;
        bool donor;
        string imagePath;
        GENDER gender;
        COLOREYES eyes;

        public Driver()
        {

        }

        public string this[string columnName] { 
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Class1":
                    {
                            if (Class1 < 'A' || Class1 > 'E') error = "неверная категория";
                    }break;
                        
                    case "Number":
                    {
                            bool isValidNumber = System.Text.RegularExpressions.Regex.IsMatch(
                                Number.ToString(), 
                                @"^[0-9]{6,}$"
                            );

                            if (!isValidNumber) error = "неверный номер удостоверения";
                    }break;                        
                    case "Exp":
                    {
                            if (Exp < DateTime.Now) error = "закончен срок действия";
                    }break;

                    case "Dob":
                    {
                            if (Dob < new DateTime(1920,1,1) || (int) DateTime.Now.Subtract(Dob).TotalDays/365.25 < 16) error = "неверно введенная дата рождения";
                    }
                    break;

                    case "Iss":
                    {
                            if (Iss > DateTime.Now || (int) DateTime.Now.Subtract(Dob).TotalDays/365.25 < 16) error = "неверно введенная дата выдачи";
                    }
                    break;

                    case "Name":
                    {
                            bool isValidNumber = System.Text.RegularExpressions.Regex.IsMatch(
                                Name.ToString(),
                                @"^[A-Za-z\s]{3,}$"
                            );
                            if (!isValidNumber) error = "неверно введенная имя";
                    }
                    break;
                }

                return error;
            }
        }

        public int Number { 
            get => number;
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }
        public char Class1 {
            get => class1;
            set
            {
                class1 = value;
                OnPropertyChanged("Class1");
            }
        }
        public string Name {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        
        public string Address {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }
        public double Hgt { 
            get => hgt;
            set
            {
                hgt = value;
                OnPropertyChanged("Hgt");
            }
        }
        public DateTime Dob { 
            get => dob;
            set
            {
                dob = value;
                OnPropertyChanged("Dob");
            }
        }
        public DateTime Iss {
            get => iss;
            set
            {
                iss = value;
                OnPropertyChanged("Iss");
            }
        }
        public DateTime Exp { 
            get => exp;
            set
            {
                exp = value;
                OnPropertyChanged("Exp");
            }
        }
        public bool Donor {
            get => donor;
            set
            {
                donor = value;
                OnPropertyChanged("Donor");
            }
        }
        public string ImagePath 
        { 
            get => imagePath;
            set
            {
                imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }
        public GENDER Gender {
            get => gender;
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }
        public COLOREYES Eyes { 
            get => eyes;
            set
            {
                eyes = value;
                OnPropertyChanged("Eyes");
            }
        }

        public string Error => throw new NotImplementedException();

        public event PropertyChangedEventHandler? PropertyChanged;

            public void OnPropertyChanged([CallerMemberName] string prop = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(prop));
                }
            }

            public override string? ToString()
            {
                return $"№ {Number} {Class1} from {Iss} to {Exp}. {Name}, {Gender} Dob({Dob}). {Address}. Height {Hgt}. Eyes {Eyes}." +
                       $"{(Donor ? "Donor" : "Not donor")} \n ImagePath {ImagePath}";
            }
     }
}