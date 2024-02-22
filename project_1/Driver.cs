using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1
{
    public enum GENDER { male, female, other};
    public enum COLOREYES { brown, green, blue};
    internal class Driver
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

        public int Number { get => number; set => number = value; }
        public char Class1 { get => class1; set => class1 = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public double Hgt { get => hgt; set => hgt = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public DateTime Iss { get => iss; set => iss = value; }
        public DateTime Exp { get => exp; set => exp = value; }
        public bool Donor { get => donor; set => donor = value; }
        public string ImagePath { get => imagePath; set => imagePath = value; }
        public GENDER Gender { get => gender; set => gender = value; }
        public COLOREYES Eyes { get => eyes; set => eyes = value; }

        public override string? ToString()
        {
            return $"№ {Number} {Class1} from {Iss} to {Exp}. {Name}, {Gender} Dob({Dob}). {Address}. Height {Hgt}. Eyes {Eyes}." +
                $"{(Donor ? "Donor" : "Not donor")} \n ImagePath {ImagePath}";
        }
    }
}
