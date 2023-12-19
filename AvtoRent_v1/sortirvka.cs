namespace VentAvto;

public static class sortirvka
{
    public static IOrderedEnumerable<Avto> sortprice(List<Avto> cars)
    {
        var sortedCars = from p in cars
            orderby p.Price, p.Klass
            select p;

        return sortedCars;
    }
}