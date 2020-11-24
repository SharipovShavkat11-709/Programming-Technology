using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadgets
{
    //Класс под ноутбуки, наследуется от класса Gadget
    public class Laptop : Gadget
    {
        public bool HasKeyboardBackligth = false; //наличие подсветки клавиатуры        
        public int CoresCount = 0; //количество ядер
        public int HardDiscSpace = 0; //объем жесткого диска

        // А ТУТ ПЕРЕОПРЕДЕЛИЛ МЕТОД
        public override String GetInfo()
        {
            var str = GadgetName;
            str += base.GetInfo(); // а тут заменил вызовом GetInfo базового класса, т.е. Gadgets
            str += String.Format("\nНаличие подсветки клавиатуры: {0}", this.HasKeyboardBackligth);
            str += String.Format("\nКоличество ядер: {0}", this.CoresCount);
            str += String.Format("\nОбъем жесткого диска: {0}", this.HardDiscSpace);
            return str;
        }
    
        public static Laptop Generate()
        {
            return new Laptop
            {
                GadgetName = "Ноутбук",
                DisplaySize = GetRandomDoubleNumber(10, 17), //размер дисплея от 10 до 17 
                HasKeyboardBackligth = random.Next(2) == 0, //наличие подсветки клавиатуры
                CoresCount = random.Next(2, 10), //количество ядер от 2 до 10
                HardDiscSpace = random.Next(128, 1024) //объем жесткого диска от 128 до 1024
            };
        }
    }
}
