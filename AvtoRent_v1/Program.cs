using System.Runtime.InteropServices.ComTypes;
using Microsoft.Data.Sqlite;

namespace VentAvto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Запись данных киента
            db_handler.clientinput();

            // Запрос данных из БД в класс Avto
            var cars = db_handler.carlist();

            // Сортировка данных в классе
            var sortedCars = sortirvka.sortprice(cars);

            // Вывод данных
            Console.WriteLine("Хотите отсортировать автомобили по ценам?");
            Console.WriteLine("Введите цифру для вывода:");
            Console.WriteLine("1. Сортированнй");
            Console.WriteLine("2. Не сортированный");
            int vibor = Convert.ToInt32(Console.ReadLine());

            if (vibor == 1)
            {
                foreach (var car in sortedCars)
                {
                    Console.WriteLine(
                        "________________________________________________________________________________________________________________________________");
                    Console.WriteLine(
                        $"Автомобиль: {car.Name} {car.Model} \t год выпуска: {car.Year} \t класс автомобиля: {car.Klass} \t Цена аренды: {car.Price} \t Наличие: {car.Available}");
                    Console.WriteLine(
                        "________________________________________________________________________________________________________________________________");
                }
            }
            else
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(
                        "________________________________________________________________________________________________________________________________");
                    Console.WriteLine(
                        $"Автомобиль: {car.Name} {car.Model} \t год выпуска: {car.Year} \t класс автомобиля: {car.Klass} \t Цена аренды: {car.Price} \t Наличие: {car.Available}");
                    Console.WriteLine(
                        "________________________________________________________________________________________________________________________________");
                }
            }

            Console.WriteLine("Для выбора авто напишите модель:");
            string vibor_avto = Console.ReadLine();
            IEnumerable<Avto> results = cars.FindAll(x => x.Model == vibor_avto);

            while (results.Any() == false)
            {
                Console.WriteLine("Не найденого такого авто.");
                Console.WriteLine("Для выбора авто напишите модель:");
                vibor_avto = Console.ReadLine();
                results = cars.FindAll(x => x.Model == vibor_avto);
            }
            
            var ReservCar = results.First();
            Console.WriteLine($"Автомобиль {ReservCar.Name} {ReservCar.Model} зарезервирован за вами!");
            Console.WriteLine($"Для оплаты аренды явитесь в автосалон.");
            Console.WriteLine($"Стоимость аренды в сутки {ReservCar.Price}");
            db_handler.reservcar(ReservCar);
        }
    }
}