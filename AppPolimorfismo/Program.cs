using NombresDeClases;

public class Program
{
    public static void Main(string[] args)
    {
        List<cFigura> lista = new List<cFigura>();

        lista.Add(new cCirculo(3));
        lista.Add(new cCuadrado(4));
        lista.Add(new cTriangulo(5));

        lista.ForEach(f => f.Dibujar());
        
        Console.ReadKey();
    }
}