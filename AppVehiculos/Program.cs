using EspacioDeNombres;
using System;

cVehiculo v1 = new cAuto("ABC", "TOYOTA", "AVA", 2020);
cVehiculo v2 = new cAuto("ABC", "TOYOTA", "AVA", 2020);

if (v1.Equals(v2.Placa))
{
    Console.WriteLine("Son iwales");
}
else
{
    Console.WriteLine("No son iwales");
}

