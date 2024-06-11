namespace AppCuentas;

public class cCtaCorriente : cCtaBancaria
{
    // Atributos 
    private int aCostoManten;

    // Propiedades
    public int CostoMantenimiento
    {
        get { return aCostoManten; }
        set { aCostoManten = value; }
    }

    // Metodos 
    public override void Leer()
    {
        base.Leer();
        Console.Write("Ingrese Costo de mantenimiento: ");
        NroCuenta = Console.ReadLine();
    }

    public override void Mostrar()
    {
        base.Mostrar();
        Console.WriteLine($"Costo de mantenimiento: {CostoMantenimiento}");
    }
}