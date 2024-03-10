using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLabor10
{
    public class Guitar: Musicalinstrument
    {
        public int MaxStringCount = 12;
        public int MinStringCount = 4;
        protected int numberofstrings;

        static string[] NumberOfString = { "4", "5", "6", "7", "8", "9", "10", "11", "12" };
        public int NumberOfStrings
        {
            get => numberofstrings;
            set
            {
                if (value < MinStringCount || value > MaxStringCount)
                    numberofstrings = 0;
                else numberofstrings = value;
            }
        }

        public Guitar() : base()
        {
            NumberOfStrings = 0;
        }
        public Guitar(string name, int numberOfStrings,int number) : base(name,number)
        {
            if (numberOfStrings < MinStringCount || numberOfStrings > MaxStringCount)
            {
                NumberOfStrings = 0; 
            }
            else
            {
                NumberOfStrings = numberOfStrings;
            }
        }
        public override bool Equals(object obj)
        {
            Guitar guitar = obj as Guitar;
            if (guitar != null)
            {
                return Name == guitar.Name
                    && NumberOfStrings == guitar.NumberOfStrings;
            }
            return false;
        }
        public override string ToString()
        {
            return base.ToString() + $"Количество струн: {NumberOfStrings}";
        }               
        
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите количество струн");
            try
            {
                NumberOfStrings = int.Parse(Console.ReadLine());
            }
            catch
            {
                NumberOfStrings = 6;
            }
        }
        public override void RandomInit()
        {
            base.RandomInit();
            NumberOfStrings = Musicalinstrument.rnd.Next(4, 12);
        }
        public override void ShowVirtual()
        {
            base.ShowVirtual();
            Console.WriteLine($"Количество струн:{NumberOfStrings}");
        }
        public override void Show()
        {
            Console.WriteLine($"Название музыкального инструмента: {Name}, количество струн: {NumberOfStrings}");
        }
    }
}
