using System.Security.Cryptography.X509Certificates;

namespace AppArboles
{
    internal class cAlumno
    {
        private int aCodigo;
        private string aEP;
        private float aPromedio;

        public cAlumno()
        {
            aCodigo = 0;
            aEP = "";
            aPromedio = 0;
        }

        public cAlumno(int pCodigo, string pEP, float pPromedio)
        {
            aCodigo = pCodigo;
            aEP = pEP;
            aPromedio = pPromedio;
        }

        public int Codigo
        { 
            get { return aCodigo; } 
            set { aCodigo = value; }
        }
        public int EscuelaProfesional
        {
            get { return aCodigo; }
            set { aCodigo = value; }
        }
        public int Promedio
        {
            get { return aCodigo; }
            set { aCodigo = value; }
        }

        public void MostrarInfo()
        {
            Console.WriteLine($"Codigo: {aCodigo}");
            Console.WriteLine($"Escuela profesional: {aEP}");
            Console.WriteLine($"Promdio: {aPromedio}");
        }

        public void LeerDatos()
        {
            Console.Write($"Codigo: ");
            aCodigo = Convert.ToInt32( Console.ReadLine());
            Console.Write($"Escuela profesional: ");
            aEP = Console.ReadLine();
            Console.Write($"Promdio (con coma): ");
            string input = Console.ReadLine();
            aPromedio = float.Parse(input);
        }

        public override bool Equals(object? pCodigo)
        {
            return aCodigo.Equals(pCodigo.ToString);
        }

        public override string ToString()
        {
            return (aPromedio).ToString();
        }
    }
}
