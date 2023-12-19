namespace VentAvto;

public class Car
{
    public string Name { get; set; }
    public string Model { get; set; }
    public long Year { get; set; }
    public long Price { get; set; }

    public Car(string name, string model, long year, long price)
    {
        Name = name;
        Model = model;
        Year = year;
        Price = price;
    }
}