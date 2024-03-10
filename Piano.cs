using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLabor10
{
    public class Piano : Musicalinstrument
    {
        
        public string KeyLayout { get; set; }
        public  int NumberOfKeys { get; set; }
        public static string[] KeyLayouts = { "Октавная", "Шкальная", "Дигитальная" };
        public int MaxKeysCount = 88;
        public int MinKeysCount = 76;

        public Piano()
        {
            NumberOfKeys = 0;
            KeyLayout = "Unknown";
        }
        public Piano(string name, string keylayout, int numberofkeys, int number) : base(name, number)
        {
            KeyLayout = keylayout;
            NumberOfKeys = numberofkeys;
        }        
        public override string ToString()
        {
            return base.ToString() + $"Раскладка клавиш: {KeyLayout}, Количество клавиш:{NumberOfKeys}";
        }
        public override bool Equals(object obj)
        {           

            Piano p = obj as Piano;

            return Name == p.Name
                && KeyLayout == p.KeyLayout
                && NumberOfKeys == p.NumberOfKeys;
        }
    


        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите раскладку клавиш:");
            KeyLayout = Console.ReadLine();

            Console.WriteLine("Введите количество клавиш:");
            try
            {
                NumberOfKeys = int.Parse(Console.ReadLine());
            }
            catch
            {
                NumberOfKeys = 88;
            }
        }
        public override void RandomInit()
        {
            base.RandomInit();
            KeyLayout = KeyLayouts[Musicalinstrument.rnd.Next(KeyLayouts.Length)];
            NumberOfKeys = Musicalinstrument.rnd.Next(MinKeysCount, MaxKeysCount);
        }
        public override void ShowVirtual()
        {
            base.ShowVirtual();
            Console.WriteLine($"Раскладка клавиш: {KeyLayout} Количество клавиш: {NumberOfKeys}");
        }
        public override void Show()
        {
            Console.WriteLine($"Название музыкального инструмента: {Name}, раскладка клавиш: {KeyLayout}, Количество клавиш: {NumberOfKeys}");
        }
    }
}
