using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadgets
{
    //Класс под планшеты, тоже наследует от класса Gadget
    public class Tablet : Gadget
    {
        public bool HasCameras = false; //наличие камеры
        public int ScreenDPI = 0; // dpi экрана 

        public override String GetInfo()
        {
            var str = GadgetName;//название гаджета
            str += base.GetInfo(); // а тут заменил вызовом GetInfo базового класса, т.е. Gadgets
            str += String.Format("\nНаличие камеры: {0}", this.HasCameras);
            str += String.Format("\ndpi: {0}", this.ScreenDPI);
            return str;
        }

        public static Tablet Generate()
        {
            return new Tablet
            {
                GadgetName = "Планшет",
                DisplaySize = GetRandomDoubleNumber(7, 12), //размер дисплея от 7 до 12
                HasCameras = random.Next(2) == 0, // наличие камеры
                ScreenDPI = random.Next(200, 520) // dpi экрана от 200 до 520
            };
        }
    }
}
