using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadgets
{
    //Класс под смартфоны
    public class SmartPhone : Gadget
    {
        public int SimCardSlotsCount = 0; //количество слотов под sim карту
        public int CamerasMp = 0; //количество мегапикселей у камеры
        public int BatteryCapacity = 0; // емкость батареи

        //Получение информации о гаджетах
        public override String GetInfo()
        {
            var str = GadgetName;//название гаджета
            str += base.GetInfo(); // а тут заменил вызовом GetInfo базового класса, т.е. Gadgets
            str += String.Format("\nКоличество Sim-карт: {0}", this.SimCardSlotsCount);
            str += String.Format("\nКамера, Мп: {0}", this.CamerasMp);
            str += String.Format("\nБатарея: {0}", this.BatteryCapacity);
            return str;
        }

        public static SmartPhone Generate()
        {
            return new SmartPhone
            {
                GadgetName = "Смартфон",
                DisplaySize = GetRandomDoubleNumber(4, 7), // размер дисплея от 4.0 до 7.0
                SimCardSlotsCount = random.Next(1, 3),//количество сим карт от 1 до 2
                CamerasMp = random.Next(16, 108),//количесвто мегапикселей от 16 до 108       
                BatteryCapacity = random.Next(2000, 6000)//емкость батареи от 2200 до 6000
            };
        }
    }
}
