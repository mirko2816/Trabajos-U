namespace NombresDeClases
{
    public class cTriangulo : cFigura
    {

        public cTriangulo(float pDiametro) : base (pDiametro){}

        public override void Dibujar()
        {
            Console.WriteLine($"Se dibujo un triangulo {aDiametro}");
        }

        public override string ToString()
        {
            return "Soy un triangulo";
        }
    }
}