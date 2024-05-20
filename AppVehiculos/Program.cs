using EspacioDeNombres;

class Program 
{
    static void Main(string[] args)  
    {
        cVehiculo v1 = new cAuto("DEF", "TOYOTA", "AVA", 2024);
        cVehiculo v2 = new cCamion("ABC", "HYUNDAI", "SANTAFE", 4);

        cVehiculo[] lVehiculos = new cVehiculo[3];

        lVehiculos[0] = v1;
        lVehiculos[1] = v2;

        int opcion = 0;

        while (opcion != 6)
        {
            opcion = Control.ElegirOpcion();
            if (opcion == 1)
            {
                Control.Listar(lVehiculos);
            }
            if (opcion == 2)
            {
                Control.Insertar(lVehiculos);
            }
            if (opcion == 3)
            {
                Control.Buscar(lVehiculos);
            }
            if (opcion == 4)
            {
                Control.CalcularTotalPeaje(lVehiculos);
            }
            if (opcion == 5)
            {
                Control.ContarAutosCamiones(lVehiculos);
            }
        }
        
    }
}



