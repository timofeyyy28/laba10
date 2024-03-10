using ClassLibraryLabor10.laba99;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLabor10
{
    public class IdNumber
    {
        public int number;
        public IdNumber(int n)
        {
            this.number = n;
        }
        public override string ToString()
        {
            return number.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj is IdNumber mi)
                return this.number == mi.number;
            return false;
        }
    }
    public class Musicalinstrument : IInit, IComparable, ICloneable
    {
        protected string name;
        public static Random rnd = new Random();
        protected string ID;
        public static string[] Names = { "Инструмент №1", "Инструмент №2", "Инструмент №3", "Инструмент №4", "Инструмент №5" };
        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                }
                else
                {            
                    throw new ArgumentException("Имя инструмента не может быть пустым или содержать только пробельные символы.");
                }
            }
        }
        public IdNumber id;
        public Musicalinstrument()
        {
            Name = "Unknown";
            id = new IdNumber(1);
        }

        public Musicalinstrument(string name, int number)
        {
            Name = name;
            id = new IdNumber(number);
        }
        public virtual bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is Musicalinstrument mi)
            {
                return this.Name == mi.Name;
            }
            return false;                                  
        }
        public virtual void Show()
        {
            Console.WriteLine($"Название музыкального инструмента: {Name}");
        }
        public virtual void Init()
        {
            Console.WriteLine("Введите название музыкального инструмента");
            Name = Console.ReadLine();
            Console.WriteLine("Введите id музыкального инструмента");
            try
            {
                id.number = int.Parse(Console.ReadLine());
            }
            catch 
            {
                id.number = 0;
            }

        }
        public virtual void RandomInit()
        {
            Name = Names[rnd.Next(0,Names.Length - 1)];
            id.number = rnd.Next(1,100);
        }
        public virtual string ToString()
        {
            return "${Name}, {ID}";
            

        }
        public virtual void ShowVirtual()
        {
            Console.WriteLine($"\nID: {this.id}\nНАзвание музыкального инструмента: {this.Name}");
        }
        public static double AverageCountOfStringsOfGuitars(Musicalinstrument[] instruments)
        {
            int totalStrings = 0;
            int guitarCount = 0;

            foreach (var instrument in instruments)
            {
                if (instrument is Guitar)
                {
                    Guitar guitar = instrument as Guitar;
                    totalStrings += guitar.NumberOfStrings;
                    guitarCount++;
                }
            }

            if (guitarCount == 0)
            {
                return 0; 
            }

            return (double)totalStrings / guitarCount;
        }
        public static int CountOfStringsOfElectricGuitarWithFixedPowerSupply(Musicalinstrument[] instruments)
        {
            int totalStrings = 0;
            bool foundMatchingGuitar = false;

            foreach (var instrument in instruments)
            {
                if (instrument is ElectricGuitar && (instrument as ElectricGuitar).PowerSupply == "Фиксированный источник питания")
                {
                    totalStrings += (instrument as ElectricGuitar).NumberOfStrings;
                    foundMatchingGuitar = true;
                }
            }

            if (!foundMatchingGuitar)
            {
                return 0;
            }

            return totalStrings;
        }

        public static int MaxCountKeylayoutsOfPianoWithOctav(Musicalinstrument[] instruments)
        {
            int maxCount = 0;

            foreach (var instrument in instruments)
            {
                if (instrument.GetType() == typeof(Piano) && ((Piano)instrument).KeyLayout == "Октавная")
                {
                    if (((Piano)instrument).NumberOfKeys > maxCount)
                    {
                        maxCount = ((Piano)instrument).NumberOfKeys;
                    }
                }
            }

            return maxCount;
        }

        public int CompareTo(object obj)
        {
            Musicalinstrument mi = obj as Musicalinstrument;
            return string.Compare(this.Name, mi.Name);
        }

        public object Clone()
        {
            return new Musicalinstrument(Name, id.number);
        }
        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

    }
}

