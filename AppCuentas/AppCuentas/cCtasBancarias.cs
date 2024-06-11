namespace AppCuentas;

public class cCtasBancarias
{
    // Atributos
    cCtaAhorros[] lCuentas;
    int aNroCuentas;

    // Constructores
    public cCtasBancarias()
    {
        lCuentas = new cCtaAhorros[10];
        aNroCuentas = 0;
    }

    // Metodos de la clase
    private cCtaAhorros RecuperarCtaAhorros(string Cta)
    {
        for (int i = 0; i < aNroCuentas; i++)
        {
            if (lCuentas[i] != null && lCuentas[i].NroCuenta == Cta)
            {
                return lCuentas[i];
            }
        }
        return null; 
    }

    public void AgregarCtaAhorros()
    {
        if (aNroCuentas >= lCuentas.Length)
        {
            Console.WriteLine("No se pueden agregar más cuentas de ahorros.");
            return;
        }
        else
        {
            cCtaAhorros nuevaCuenta = new cCtaAhorros();
            nuevaCuenta.Leer();
            lCuentas[aNroCuentas] = nuevaCuenta;
            aNroCuentas++;
            Console.WriteLine("Cuenta de ahorros agregada exitosamente.");
        }
        
    }

    public void BuscarCtaAhorros()
    {
        Console.Write("Ingrese el número de cuenta a buscar: ");
        string numeroCuenta = Console.ReadLine();
        cCtaAhorros cuenta = RecuperarCtaAhorros(numeroCuenta); // devolvera una cuenta con este numero de cuenta
        if (cuenta != null)
        {
            cuenta.Mostrar();
        }
        else
        {
            Console.WriteLine("Cuenta no encontrada.");
        }
    }

    public void ListarCtas()
    {
        Console.WriteLine("\nListar todas las cuentas de ahorros:");
        for (int i = 0; i < aNroCuentas; i++)
        {
            lCuentas[i].Mostrar();
            Console.WriteLine();
        }
    }

    public void ListarPorTipoAhorro()
    {
        Console.Write("Ingrese el tipo de ahorro a listar: ");
        string tipoAhorro = Console.ReadLine();
        Console.WriteLine("\nCuentas de ahorros del tipo " + tipoAhorro + ":");
        for (int i = 0; i < aNroCuentas; i++)
        {
            if (lCuentas[i].TipoAhorro == tipoAhorro)
            {
                lCuentas[i].Mostrar();
                Console.WriteLine();
            }
        }
    }
}

public class Programa
{
    private static cCtasBancarias cuentas = new cCtasBancarias();
    public static void Ejecutar()
    {
        int opcion = 0;

        while (opcion != 5)
        {
            Menu();
            opcion = Convert.ToInt32(Console.ReadLine());
            if (opcion == 1){cuentas.AgregarCtaAhorros();}
            if (opcion == 2){cuentas.BuscarCtaAhorros();}
            if (opcion == 3){cuentas.ListarCtas();}
            if (opcion == 4){cuentas.ListarPorTipoAhorro();}
        }
    }

    

    private static void Menu()
    {
        Console.WriteLine("----------------------------");
        Console.WriteLine("||    Cuentas Bancarias   ||");
        Console.WriteLine("----------------------------");
        Console.WriteLine("1. Agregar Cuenta de Ahorro.");
        Console.WriteLine("2. Buscar Cuenta de Ahorro.");
        Console.WriteLine("3. Listar Cuentas de Ahorro.");
        Console.WriteLine("4. Listar por tipo de Ahorro.");
        Console.WriteLine("5. Salir.");
        Console.Write("Opcion --> ");
    }
}