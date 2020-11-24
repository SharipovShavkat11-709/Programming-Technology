using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadgets
{
    //Базовый класс
    public class Gadget
    {
        public double DisplaySize = 0;

        // Поле для получения вывода информации об очереди
        public string GadgetName;

        //Создаем объект класса Random для заполнения рандомными числами
        protected static Random random = new Random();

        // ТУТ ДОБАВИЛ СЛОВО virtual ПОСЛЕ public
        // это надо чтобы функцию можно было переопределить
        // в классах наследниках  
        public virtual String GetInfo()
        {
            //инфомация о размере дисплея, f - означает количество цифр после запятой 
            var str = String.Format("\nРазмер дисплея: {0:f1}", this.DisplaySize);
            return str;
        }

        // Метод для получения рандомного вещественного числа в указанном диапазоне
        public static double GetRandomDoubleNumber(int minValue, int maxValue)
        {
            //NextDouble возвращает число двойной точности с плавающей запятой, 
            //которое больше или равно 0.0, и меньше 1.0
            //а Next как мы уже знаем, возвращает целое число в указанном диапазоне
            return random.NextDouble() + random.Next(minValue, maxValue);
        }
    }
}
