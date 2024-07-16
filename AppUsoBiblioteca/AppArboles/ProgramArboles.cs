using AppArboles;
using BibliotecaTDA;

internal class ProgramArboles
{
    private static void Main(string[] args)
    {
        cArbolBB abb1 = new cArbolBB();
        cAlumno a1 = new cAlumno(123456, "IIF", 11.43F);
        cAlumno a2 = new cAlumno(123457, "CON", 13.53F);
        cAlumno a3 = new cAlumno(123458, "FAR", 16.32F);
        cAlumno a4 = new cAlumno(123456, "IIF", 18.45F);
        cAlumno a5 = new cAlumno(123456, "IIF", 10.56F);
        cAlumno a6 = new cAlumno(123457, "CON", 12.53F);

        abb1.Altura();

        abb1.Agregar(a1);
        abb1.Agregar(a2);
        abb1.Agregar(a3);
        abb1.Agregar(a4);
        abb1.Agregar(a5);
        abb1.Agregar(a6);

        abb1.RecorrerInOrden();

    }
}