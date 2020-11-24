using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gadgets
{
    public partial class Form1 : Form
    {
        //Добавил очередь, тип Gadget, чтобы реализовать отображение состояния очереди
        Queue<Gadget> queue = new Queue<Gadget>();

        //Добавил список, тип Gadget
        List<Gadget> gadgetsList = new List<Gadget>();

        public Form1()
        {
            InitializeComponent();
            ShowInfo();//чтобы при запуске приложения что-то показывалось на форме
        }

        private void btnRefill_Click(object sender, EventArgs e)
        {
            //Сперва удаляем все элементы списка List<Gadget>
            this.gadgetsList.Clear();
            var rnd = new Random();//Создаем объект класса Random
            for (var i = 0; i < 10; ++i)
            {
                switch (rnd.Next() % 3) // генерирую случайное число от 0 до 2
                {
                    case 0: // если 0, то ноутбук
                            // всю работу по созданию экземпляра класса
                            // берет на себя метод Generate
                            // поэтому нам не нужно больше использовать new
                        this.gadgetsList.Add(Laptop.Generate());
                        break;
                    case 1: // если 1, то планшет
                        this.gadgetsList.Add(Tablet.Generate());
                        break;
                    case 2: // если 2, то смартфон
                        this.gadgetsList.Add(SmartPhone.Generate());
                        break;
                        // появление других чисел маловероятно
                }
            }
            ShowInfo(); // И СЮДА
        }

        // функция выводит информацию о количестве гаджетов на форму
        private void ShowInfo()
        {
            txtQueue.Clear();
            // заведем счетчики под каждый тип
            int laptopsCount = 0;
            int tabletsCount = 0;
            int smartPhonesCount = 0;

            // пройдемся по всему списку
            foreach (var gadget in this.gadgetsList)
            {
                // помните, что в списки у нас лежат гаджеты,
                // то есть объекты типа Gadget
                // поэтому чтобы проверить какой именно гаджет
                // мы в данный момент обозреваем, мы используем ключевое слово is
                if (gadget is Laptop) // читается почти как чистый английский, "если gadget есть Ноутбук"
                {
                    laptopsCount += 1;
                }
                else if (gadget is Tablet)
                {
                    tabletsCount += 1;
                }
                else if (gadget is SmartPhone)
                {
                    smartPhonesCount += 1;
                }
                //отображение состояния очереди (чтобы было видно 
                //какие объекты в каком порядке сейчас находятся в автомате)
                txtQueue.Text += gadget.GadgetName + "\n";
            }

            // а ну и вывести все это надо на форму
            txtInfo.Text = "Ноутбук\tПланшет\t Смартфон";
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t{1}\t{2}", laptopsCount, tabletsCount, smartPhonesCount);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            // если список пуст, то напишем что пусто и выйдем из функции
            if (this.gadgetsList.Count == 0)
            {
                txtOut.Text = "Пусто Q_Q";
                return;
            }

            // взяли первый гаджет
            var gadget = this.gadgetsList[0];
            // тут вам не реальность, взятие это на самом деле создание указателя на область в памяти
            // где хранится экземпляр класса, так что если хочешь удалить, делай это сам
            this.gadgetsList.RemoveAt(0);

            txtOut.Text = gadget.GetInfo();
            // обновим информацию о количестве товара на форме
            ShowInfo();
        }
    }
}
