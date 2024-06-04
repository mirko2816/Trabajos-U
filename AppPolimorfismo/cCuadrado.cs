namespace NombresDeClases
{
    public class cCuadrado : cFigura
    {

        public cCuadrado(float pDiametro) : base (pDiametro){}

        public override void Dibujar()
        {
            Console.WriteLine($"Se dibujo un cuadrado {aDiametro}");
        }

        public override string ToString()
        {
            return "Soy un cuadrao";
        }
    }
}