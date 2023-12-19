namespace VentAvto;


internal class Client
{
    private string Name;

    public string name
    {
        get { return Name; }

        set { Name = value; }
    }

    private string Surname;

    public string surname
    {
        get { return Surname; }

        set { Surname = value; }
    }

    private int Age;

    public int age
    {
        get { return Age; }
        set
        {
            if (value >= 18)
            {
                Age = value;
            }
            else
            {
                Console.WriteLine("Вам меньше 18 лет, аренда авто недоступна.");
                System.Environment.Exit(18);
            }
        }
    }
}
