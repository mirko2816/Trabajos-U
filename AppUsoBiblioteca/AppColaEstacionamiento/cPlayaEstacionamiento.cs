using BibliotecaTDA;
namespace AppColaEstacionamiento;

public class cPlayaEstacionamiento
{
    // Atributos
    private cCola aPlaya;
    private cCola aEspacioAux;

    // Metodos especiales
    public void IngresarCarro()
    {
        Console.WriteLine("\nIngresar Carro al Estacionamiento");
        Console.WriteLine("*********************************");
        Console.Write("Placa: ");
        string placa = Console.ReadLine();
        aPlaya.Acolar(placa); // Agrega el nombre de la placa al estacionamiento
    }

    public void RetirarCarro()
    {
        Console.WriteLine("\nRetirar Carro del Estacionamiento");
        Console.WriteLine("*********************************");
        Console.Write("Placa: ");
        string placa = Console.ReadLine();

        aEspacioAux = new cCola();
        RetirarCarrosAEspacioAux(placa);
        Reingresar();
    }

    public void RetirarCarrosAEspacioAux(string placa)
    {
        if(!aPlaya.EsVacia())
        {
            if(!aPlaya.Cima().Equals(placa))
            {
                aEspacioAux.Acolar(aPlaya.Cima());
            }
            aPlaya.Desacolar();
            RetirarCarrosAEspacioAux(placa);
        }
    }

    public void Reingresar()
    {
        if(!aEspacioAux.EsVacia())
        {
            aPlaya.Acolar(aEspacioAux.Cima());
            aEspacioAux.Desacolar();
            Reingresar();
        }
    }

    public void ListarCarros()
    {
        Console.WriteLine("\nCarros En la Playa de estacionamiento: ");
        aPlaya.Listar();
    }
}
