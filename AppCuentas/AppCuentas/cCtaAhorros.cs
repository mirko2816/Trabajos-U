namespace AppCuentas;

public class cCtaAhorros : cCtaBancaria
{
    // Atributos 
    protected string aTipoAhorro;
    protected double aTasaInteres;

    // Propiedades
    public string TipoAhorro
    {
        get { return aTipoAhorro; }
        set { aTipoAhorro = value; }
    }

    public double TasaInteres
    {
        get { return aTasaInteres; }
        set { aTasaInteres = value; }
    }

    public override void Leer()
    {
        base.Leer();
        Console.Write("Ingrese Tipo de Ahorro: ");
        aTipoAhorro = Console.ReadLine();
        Console.Write("Ingrese Tasa de Interes: ");
        aTasaInteres = Convert.ToInt32(Console.ReadLine());
    }

    public override void Mostrar()
    {
        base.Mostrar();
        Console.WriteLine($"Tipo de ahorro: {TipoAhorro}");
        Console.WriteLine($"Tasa de Interes: {TasaInteres}");
    }
}