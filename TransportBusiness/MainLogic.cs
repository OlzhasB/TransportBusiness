using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportBusiness
{
    class MainLogic
    {
        public void start()
        {
            while (true)
            {
                Console.WriteLine("1 - оформить заявку");
                Console.WriteLine("2 - отобразить список выполняемых заявок");
                Console.WriteLine("3 - отобразить список выполненных заявок");
                Console.WriteLine("4 - отобразить список свободных перевозчиков");
                Console.WriteLine("5 - отобразить список всех перевозчиков");
                Console.WriteLine("6 - отобразить список свободного транспорта");
                Console.WriteLine("7 - отобразить список всех транспортных средств");
                Console.WriteLine("8 - выход");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        createOrder();
                        break;
                }
            }
        }
        Order ord = new Order();
        private void createOrder()
        {
            Order ord = new Order();
            infoFromCustomer(ord);
            infoFromCarrier(ord);
        }
        private void infoFromCustomer(Order ord)
        {
            Console.Write(" Введите ваше имя: ");
            ord.customer.firstname = Console.ReadLine();
            Console.Write(" Введите вашу фамилию: ");
            ord.customer.lastname = Console.ReadLine();
            Console.Write(" Введите ваш телефон: ");
            ord.customer.phone = Console.ReadLine();

            while (true)
            {
                Cargo crg = new Cargo();
                Console.Write("Введите название товара: ");
                crg.name = Console.ReadLine();
                Console.Write("Введите объем товара: ");
                crg.volume = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите вес товара: ");
                crg.weight = Convert.ToDouble(Console.ReadLine());

                ord.Cargoes.Add(crg);
                Console.Write("Добавить еще один груз? 1 или 0: ");
                if (Convert.ToInt32(Console.ReadLine()) == 0)
                    break;
            }

            Console.Write("Введите город отправки: ");
            ord.departureCity = Console.ReadLine();
            Console.Write("Введите город доставки: ");
            ord.arrivalCity = Console.ReadLine();
            Console.Write("Введите дату доставки: ");
            ord.arrivalDate = Convert.ToDateTime(Console.ReadLine());
            ord.creationDate = DateTime.Now;
        }
        private void infoFromCarrier(Order ord)
        {

        }
    }
}
