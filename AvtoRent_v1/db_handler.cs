using Microsoft.Data.Sqlite;

namespace VentAvto;

public static class db_handler
{
    public static List<Avto> carlist() // Создание элементов класса при помощи БД
    {
        List<Avto> cars = new List<Avto>();
        using (var connection =
               new SqliteConnection(
                   "Data Source= C:\\Users\\Masked\\RiderProjects\\AvtoRent_v1\\AvtoRent_v1\\AvtoRent.db"))
        {
            connection.Open();
            string sqlExpression = "SELECT * FROM avto WHERE status='Свободно'";
            SqliteCommand command = new SqliteCommand(sqlExpression, connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        string name = (string)reader.GetValue(1);
                        string model = (string)reader.GetValue(2);
                        Int64 year = (Int64)reader.GetValue(3);
                        Int64 price = (Int64)reader.GetValue(4);
                        string klass = (string)reader.GetValue(5);
                        string aval = (string)reader.GetValue(6);
                        cars.Add((new Avto(name, model, year, price, klass, aval)));
                    }
                }
            }
        }

        return cars;
    }

    public static void clientinput()
    {
        Client client = new Client();

        Console.WriteLine("Введите имя: ");
        client.name = Console.ReadLine();
        Console.WriteLine("Введите фамилию: ");
        client.surname = Console.ReadLine();
        Console.WriteLine("Введите возраст: ");
        client.age = Convert.ToInt32(Console.ReadLine());
        using (var connection = new SqliteConnection(
                   "Data Source= C:\\Users\\Masked\\RiderProjects\\AvtoRent_v1\\AvtoRent_v1\\AvtoRent.db;Mode=ReadWriteCreate"))
        {
            connection.Open();
            string sqlExpression = "INSERT INTO User (Name, Surname, Age) VALUES (@Name, @Surname, @Age)";
            SqliteCommand command = new SqliteCommand(sqlExpression, connection);
            command.Connection = connection;
            command.Parameters.AddWithValue("@Name", client.name);
            command.Parameters.AddWithValue("@Surname", client.surname);
            command.Parameters.AddWithValue("@Age", client.age);
            command.ExecuteNonQuery();
        }
    }


    public static void reservcar(Avto car)
    {
        using (var connection = new SqliteConnection(
                   "Data Source= C:\\Users\\Masked\\RiderProjects\\AvtoRent_v1\\AvtoRent_v1\\AvtoRent.db;Mode=ReadWriteCreate"))
        {
            connection.Open();
            string sqlExpression = "UPDATE avto SET status = 'Зарезервированно' WHERE model=@CarName";
            SqliteCommand command = new SqliteCommand(sqlExpression, connection);
            command.Connection = connection;
            command.Parameters.AddWithValue("@CarName", car.Model);
            command.ExecuteNonQuery();
        }
    }
}