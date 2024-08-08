using System;
namespace ExamenPrograII;

public class cVehiculo
{
    // Atributos
    string aNroPlaca;
    string aMarca;
    string aModelo;
    string aDescripcion;
    string aTipo;
    int aAnio;

    // Constructores
    public cVehiculo()
    {
        aNroPlaca = string.Empty;
        aMarca = string.Empty;
        aModelo = string.Empty;
        aDescripcion = string.Empty;
        aTipo = string.Empty;
        aAnio = 0;
    }

    public cVehiculo(string pNroPlaca, string pMarca, string pModelo, string pDescripcion, string pTipo, int pAnio)
    {
        aNroPlaca = pNroPlaca;
        aMarca = pMarca;
        aModelo = pModelo;
        aDescripcion = pDescripcion;
        aTipo = pTipo;
        aAnio = pAnio;
    }

    // Setters y Getters
    public string NroPlaca
    {
        get { return aNroPlaca; }
        set { aNroPlaca = value; }
    }

    public string Marca
    {
        get { return aMarca; }
        set { aMarca = value; }
    }

    public string Modelo
    {
        get { return aModelo; }
        set { aModelo = value; }
    }

    public string Descripcion
    {
        get { return aDescripcion; }
        set { aDescripcion = value; }
    }

    public string Tipo
    {
        get { return aTipo; }  
        set { aTipo = value; }
    }

    public int Anio
    {
        get { return aAnio; }
        set { aAnio = value; }
    }

    // Metodos
    public void MostrarInfo()
    {
        Console.WriteLine($"Placa: {aNroPlaca}");
        Console.WriteLine($"Marca: {aMarca}");
        Console.WriteLine($"Modelo: {aModelo}");
        Console.WriteLine($"Descripcion: {aDescripcion}");
        Console.WriteLine($"Tipo: {aTipo}");
        Console.WriteLine($"Anio: {aAnio}");
    }

    public override string ToString()
    {
        return aNroPlaca.ToString();
    }
}
