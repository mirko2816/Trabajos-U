using System.IO.Pipes;

namespace AppCuentas;

public class cCtaBancaria
{
    // Atributos
    protected string aNroCuenta;
    protected string aRazonSocial;
    protected string aDireccion;
    
    // Propiedades
    public string NroCuenta
    {
        get { return aNroCuenta; }
        set { aNroCuenta = value; }
    }
    public string RazonSocial
    {
        get { return aRazonSocial; }
        set { aRazonSocial = value; }
    }
    public string Direccion
    {
        get { return aDireccion; }
        set { aDireccion = value; }
    }

    // Metodos
    public virtual void Leer()
    {
        Console.Write("Ingrese Nro de cuenta: ");
        NroCuenta = Console.ReadLine();
        Console.Write("Ingrese Razon social: ");
        RazonSocial = Console.ReadLine();
        Console.Write("Ingrese Direccion: ");
        Direccion = Console.ReadLine();
        
    }

    public virtual void Escribir()
    {
        Console.WriteLine($"Nro de cuenta: {NroCuenta}");
        Console.WriteLine($"Nro de cuenta: {RazonSocial}");
        Console.WriteLine($"Nro de cuenta: {Direccion}");
    }

    public virtual void Mostrar()
    {
        Console.WriteLine($"Nro de cuenta: {NroCuenta}");
        Console.WriteLine($"Nro de cuenta: {RazonSocial}");
        Console.WriteLine($"Nro de cuenta: {Direccion}");
    }
}