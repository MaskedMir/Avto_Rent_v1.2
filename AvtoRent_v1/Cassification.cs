namespace VentAvto;

public class Avto : Car
{
    public string Klass { get; set; }
    public string Available { get; set; }

    public Avto(string name, string model, long year, long price, string klass, string available) : base(
        name, model, year, price)
    {
        Klass = klass;
        Available = available;
    }
}