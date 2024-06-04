namespace NombresDeClases
{
    public abstract class cFigura
    {
        protected float aDiametro;
        
        public cFigura()
        {
            aDiametro = 0;
        }

        public cFigura(float pDiametro)
        {
            aDiametro = pDiametro;
        }

        public abstract void Dibujar(); 
    }
}