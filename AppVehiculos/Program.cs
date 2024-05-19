using EspacioDeNombres;
using System;

static void Main() {
    Console.WriteLine("Prueba");
cVehiculo v1 = new cAuto("01", "m1", "mo1", 1990);
cVehiculo v2 = new cAuto("02", "m1", "mo1", 1980);
cVehiculo v3 = new cAuto("01", "m1", "mo1", 2020);

if (v1.Equals(v3))
{
    Console.WriteLine("Son iguales");
}
else
{
    Console.WriteLine("No son iguales");
}
}
