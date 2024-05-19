using EspacioDeNombres;
using System;
using System.Timers;

class Program 
{
    static void Main(string[] args)  
    {
        cVehiculo v1 = new cAuto("ABC", "TOYOTA", "AVA", 2020);
        cVehiculo v2 = new cCamion("ABC", "HYUNDAI", "SANTAFE", 2022);

        if (v1.Equals(v2.Placa))
        {
            Console.WriteLine("SON IWALES");

        }
        else
        {
            Console.WriteLine("NO SON IWALES");
        }
    }

    public void Menu()
    {
        Console.WriteLine("MENU DE AUTOS");
        Console.WriteLine("1. Listar");
        Console.WriteLine("2. Insertar");
        Console.WriteLine("3. Buscar");
        Console.WriteLine("4. Total Peaje");
        Console.WriteLine("5. Nro de autos y camiones");
    }
}

