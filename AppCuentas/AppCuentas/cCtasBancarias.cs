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
    public void AgregarCtaAhorro()
    {
        cCtaAhorros cta = new cCtaAhorros();
        cta.Leer(); 
        for (int i = 0; i < lCuentas.Length; i++)
        {
            if (lCuentas[i] != null)
            {
                if (cta.NroCuenta == lCuentas[i].NroCuenta)
                {
                    Console.WriteLine("La cuenta ya se encuentra registrada.");
                    break;
                }
                else if (lCuentas[i] != null)
                {
                    lCuentas[i] = cta;
                    Console.WriteLine("Cuenta registrada correctamente."); 
                }
            }
            
        }
    }
    
    public void ListarCuentas()
    {
        for (int i = 0; i < lCuentas.Length; i++)
        {
            if (lCuentas[i] != null)
            {
                lCuentas[i].Mostrar();
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
            if (opcion == 1){cuentas.AgregarCtaAhorro();}

            if (opcion == 3){cuentas.ListarCuentas();}
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