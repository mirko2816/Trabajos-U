namespace NombresDeClases
{
    public class cCirculo : cFigura
    {

        public cCirculo(float pDiametro) : base (pDiametro){}

        public override void Dibujar()
        {
            Console.WriteLine($"Se dibujo un circulo {aDiametro}");
        }

        public override string ToString()
        {
            return "Soy un circulo";
        }
    }
}