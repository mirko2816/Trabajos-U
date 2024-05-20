using EspacioDeNombres;
using System;
using System.Timers;

class Program 
{
    static void Main(string[] args)  
    {
        cVehiculo v1 = new cAuto("ABC", "TOYOTA", "AVA", 2020);
        cVehiculo v2 = new cCamion("ABC", "HYUNDAI", "SANTAFE", 2022);

        cVehiculo[] lVehiculos = new cVehiculo[10];
        int opcion = 0;

        while (opcion != 6)
        {
            opcion = Control.ElegirOpcion();
            if (opcion == 1)
            {
                Control.Opcion(1, lVehiculos);
            }
            if (opcion == 2)
            {
                
            }
            if (opcion == 3)
            {
                
            }
            if (opcion == 4)
            {
                
            }
            if (opcion == 5)
            {
                
            }
        }
        
    }
}



