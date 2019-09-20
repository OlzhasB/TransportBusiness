using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


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
                Console.WriteLine("8 -  интерфейс для разработчика(staff only)");
                Console.WriteLine("9 - выход");
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
            findTransport(ord);
            if (ord.transport != null)
                findDriver(ord);
            if (ord.driver != null)
                calculatePrice(ord);
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
            ord.creationDate = DateTime.Now;
        }
        private void findTransport(Order ord)
        {
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder();
            connStr.IntegratedSecurity = true;
            connStr.InitialCatalog = "TransportBusiness";
            connStr.DataSource = "localhost";
            List<Transport> transports = new List<Transport>();
            using (SqlConnection conn = new SqlConnection(connStr.ToString()))
            {
                try
                {
                    conn.Open();
                    transports = conn.Query<Transport>("SELECT * FROM Transport").ToList();
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            double totalWeight = 0;
            double totalVolume = 0;
            foreach (var c in ord.Cargoes)
            {
                totalVolume += c.volume;
                totalWeight += c.weight;
            }
            Transport foundTransport = null;
            foreach (var t in transports)
            {
                if (t.freeWeight >= totalWeight && t.freeVolume >= totalVolume && t.isFree)
                {
                    t.isFree = false;
                    foundTransport = t;
                    break;
                }
            }
            if (foundTransport == null)
                Console.WriteLine("Извините. Подходящего транспорта не найдено!");
            else
            {
                using (SqlConnection conn = new SqlConnection(connStr.ToString()))
                {
                    try
                    {
                        conn.Open();
                        string sql = $"UPDATE Transport SET isFree = false WHERE transportID = {Convert.ToString(foundTransport.transportID)}";
                        SqlCommand comm = new SqlCommand(sql, conn);
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            ord.transport = foundTransport;
        }
        private void findDriver(Order ord)
        {
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder();
            connStr.IntegratedSecurity = true;
            connStr.InitialCatalog = "TransportBusiness";
            connStr.DataSource = "localhost";
            List<Driver> drivers = new List<Driver>();
            using (SqlConnection conn = new SqlConnection(connStr.ToString()))
            {
                try
                {
                    conn.Open();
                    drivers = conn.Query<Driver>("SELECT * FROM Driver").ToList();
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Driver foundDriver = null;
            foreach (var d in drivers)
            {
                if (d.IsAgree && d.IsAgree)
                {
                    d.IsAgree = false;
                    foundDriver = d;
                    break;
                }
            }
            if (foundDriver == null)
                Console.WriteLine("Извините. Свободного водителя не найдено!");
            else
            {
                using (SqlConnection conn = new SqlConnection(connStr.ToString()))
                {
                    try
                    {
                        conn.Open();
                        string sql = $"UPDATE Driver SET isFree = false WHERE driverID = {Convert.ToString(foundDriver.driverID)}";
                        SqlCommand comm = new SqlCommand(sql, conn);
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            ord.driver = foundDriver;
        }
        private void calculatePrice(Order ord)
        {
            double perKgPrice = 25;
            double perMetre3Price = 2000;
            double perKmPrice = 100;
        }
    }
}
