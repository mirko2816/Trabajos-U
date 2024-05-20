namespace EspacioDeNombres
{
    public abstract class cVehiculo
    {
        protected string aPlaca;
        protected string aMarca;
        protected string aModelo;

        public cVehiculo()
        {
            aPlaca = "";
            aMarca = "";
            aModelo = "";
        }
        public cVehiculo(string pPlaca, string pMarca, string pModelo)
        {
            aPlaca = pPlaca;
            aMarca = pMarca;
            aModelo = pModelo;
        }
        // Propiedades
        public string Placa
        {
            get { return aPlaca; }
            set { aPlaca = value; }
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
        // Metodos
        public virtual void Mostrar()
        {
            Console.WriteLine($"Placa: {aPlaca}");
            Console.WriteLine($"Marca: {aMarca}");
            Console.WriteLine($"Modelo: {aModelo}");
        }
        public abstract int CalcularPeaje();
        public abstract void Leer();
        public override bool Equals(object pPlaca)
        {
            return aPlaca.Equals(pPlaca.ToString());
        }
    }

    public class cAuto : cVehiculo
    {
        private int aAnio;

        // Constructores
        public cAuto() : base() 
        {
            aAnio = 1886;
        }

        public cAuto(string pPlaca, string pMarca, string pModelo, int pAnio) : base(pPlaca, pMarca, pModelo)
        {
            if (pAnio >= 1886)
            {
                aAnio = pAnio;
            }
            else 
            {
                aAnio = 1886;
            }
        }

        // Propiedades
        public int Anio
        {
            get { return aAnio; }
            set
            {
                if (value >= 1886)
                {
                    aAnio = value;
                }
            }
        }
        // Metodos
        public override void Leer()
        {
            Console.Write("Placa:");
            Placa = Console.ReadLine();
            Console.Write("Marca:");
            Marca = Console.ReadLine();
            Console.Write("Modelo:");
            Modelo = Console.ReadLine();
            Console.Write("Año:");
            Anio = int.Parse(Console.ReadLine());
        }
        public override void Mostrar()
        {
            Console.WriteLine($"Placa: {Placa}");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Año: {Anio}");
        }
        public override int CalcularPeaje()
        {
            int anioActual = DateTime.Now.Year;
            int Antiguedad = anioActual - aAnio;
            if (Antiguedad > 20)
            {
                return 20;
            }
            else if (Antiguedad > 15)
            {
                return 10;
            }
            else    
            {
                return 0;
            }
        }
    }

    public class cCamion : cVehiculo
    {
        // Atributos
        private int aNroRuedas;

        // Constructores
        public cCamion() : base()
        {
            aNroRuedas = 4;
        }

        public cCamion(string pPlaca, string pMarca, string pModelo, int pNroRuedas) : base(pPlaca, pMarca, pModelo)
        {
            if (pNroRuedas < 4)
            {
                aNroRuedas = 4;
            }
            else if (pNroRuedas%2 == 0)
            {
                aNroRuedas = pNroRuedas;
            }
            else
            {
                aNroRuedas = 4;
            }
        }

        // Propiedades
        public int NroRuedas
        {
            get { return aNroRuedas;}
            set
            {
                if ((value < 0)) {
                    aNroRuedas = 0;
                } 
                else {
                    aNroRuedas = value;
                }
            }
        }
        // Metodos
        public override void Leer()
        {
            Console.Write("Placa:");
            Placa = Console.ReadLine();
            Console.Write("Marca:");
            Marca = Console.ReadLine();
            Console.Write("Modelo:");
            Modelo = Console.ReadLine();
            Console.Write("Nro de Ruedas:");
            NroRuedas = int.Parse(Console.ReadLine()) ;
        }
        public override void Mostrar()
        {
            Console.WriteLine($"Placa: {Placa}");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Nro Ruedas: {NroRuedas}");
        }
        public override int CalcularPeaje() // segun al numero de ruedas
        {
            if (aNroRuedas > 4)
            {
                return 20;
            } 
            else { return 10; }
        }
    }

    public static class Control
    {   
        // Retornara True si el vehiculo esta en la lista y False si no lo esta
        private static bool VerificarVehiculo(cVehiculo vehiculo, cVehiculo[] lista)
        {
            bool isIn = false; // por defecto consideramos que no esta en la lista
            for (int i = 0; i < lista.Length; i++)
            {
                if (lista[i] != null)
                {
                    if (vehiculo.Equals(lista[i].Placa))
                    {
                        isIn = true;
                    }
                }
            }
            return isIn;
        }
        // Metodos que reciben la opcion y el array
        public static int ElegirOpcion()
        {
            Console.WriteLine("MENU DE VEHICULOS");
            Console.WriteLine("1. Listar");
            Console.WriteLine("2. Insertar");
            Console.WriteLine("3. Buscar");
            Console.WriteLine("4. Total Peaje");
            Console.WriteLine("5. Nro de autos y camiones");
            Console.Write("Opcion --> ");
            int opcion = int.Parse(Console.ReadLine() ??  string.Empty);
            return opcion;
        }

        public static void Listar(cVehiculo[] listaDeVehiculos)
        {
            Console.WriteLine("\n---LISTA DE VEHICULOS---\n");
            for (int i = 0;i < listaDeVehiculos.Length; i++)
            {
                if (listaDeVehiculos[i] != null)
                {
                    listaDeVehiculos[i].Mostrar();  
                    Console.WriteLine("");
                }
            }
        }

        public static void Insertar(cVehiculo[] listaDeVehiculos)
        {
            bool isFull = true; 
            Console.WriteLine("\nDigite el numero del Vehiculo que desea agregar:");
            Console.WriteLine("1. Auto");
            Console.WriteLine("2. Camion");
            Console.Write("Opcion -->");
            int opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
            {
                for(int i = 0; i < listaDeVehiculos.Length; i++)
                {
                    if (listaDeVehiculos[i] == null)
                    {
                        // insertar el vehiculo en la posicion i y marca que NO esta lleno
                        cVehiculo v = new cAuto();
                        v.Leer();
                        // Verificamos que no este en la lista
                        if(! VerificarVehiculo(v, listaDeVehiculos))
                        {
                            isFull = false;
                            listaDeVehiculos[i] = v; 
                        }
                        else {Console.WriteLine($"El vehiculo de placa {v.Placa} ya se encuentra registrado");}
                    }
                }
            }
            else if (opcion == 2)
            {
                for(int i = 0; i < listaDeVehiculos.Length; i++)
                {
                    if (listaDeVehiculos[i] == null)
                    {
                        // insertar el vehiculo en la posicion i y marca que NO esta lleno
                        cVehiculo v = new cCamion();
                        v.Leer();
                        // Verificamos que no este en la lista
                        if(! VerificarVehiculo(v, listaDeVehiculos))
                        {
                            isFull = false;
                            listaDeVehiculos[i] = v; 
                        }
                        else {Console.WriteLine($"El vehiculo de placa {v.Placa} ya se encuentra registrado");}
                    }
                }
            }
            else {Console.WriteLine("No se escogio ninguna opcion expuesta.");}

            if (isFull) {Console.WriteLine("La lista se encuentra llena");}
        }
    }
}