using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLabor10
{
    public class ElectricGuitar : Guitar 
    {
        public string PowerSupply { get; set; }
        protected Random rnd = new Random();
        
        string[] powerSupplies = { "Батарейка", "Аккумулятор", "Фиксированный источник питания", "USB" };
        static string[] NumberOfString = { "4", "5", "6", "7", "8", "9", "10", "11", "12" };
        public ElectricGuitar() : base()
        {
            PowerSupply = "Отсутствует";
        }
        
        public string GuitarPowerSupply
        {
            get { return PowerSupply; }
            set
            {
                if (Array.IndexOf(powerSupplies, value) != -1)
                {
                    PowerSupply = value;
                }
                else
                {
                    Console.WriteLine("Недопустимый источник питания!");
                }
            }
        }


        public ElectricGuitar(string name, string powersupply, int numberOfStrings,int number) : base(name, numberOfStrings, number)
        {
            PowerSupply = powersupply;
            NumberOfStrings = numberOfStrings;

        }
        public override bool Equals(object obj)
        {
            ElectricGuitar electricGuitar = obj as ElectricGuitar;
            if (electricGuitar != null)
            {
                return Name == electricGuitar.Name
                    && PowerSupply == electricGuitar.PowerSupply;
            }
            return false;
        }
        public override string ToString()
        {
            return $"Название музыкального инструмента: {Name}, Number: {ID}, Количество струн: {NumberOfStrings}, Источник питания: {PowerSupply}";
        }
        public void ShowElectricGuitar()
        {
            Console.WriteLine($"Название музыкального инструмента: {Name}, источник питания: {PowerSupply}");
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите источник питания");
            PowerSupply = Console.ReadLine();
        }
        public override void RandomInit()
        {
            base.RandomInit();           
            PowerSupply = powerSupplies[Musicalinstrument.rnd.Next(powerSupplies.Length)];
        }
        public override void ShowVirtual()
        {
            base.ShowVirtual();
            Console.WriteLine($"Источник питания: {PowerSupply}");
        }
        public override void Show()
        {
            Console.WriteLine($"Название музыкального инструмента: {Name}, источник питания: {PowerSupply}");
        }
        

    }
}
