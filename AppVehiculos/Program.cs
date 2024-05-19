
class Program
{
    static void Main(string[] args)
    {
        DateTime fecha = DateTime.Now;
        double precio = 12.33;

        string texto1 = string.Format("Costo: {0:C}", precio );
        string texto2 = string.Format("Fecha: {0:dddd}", fecha);
        
        Console.WriteLine(texto1);
        Console.WriteLine(texto2);
    }

}


