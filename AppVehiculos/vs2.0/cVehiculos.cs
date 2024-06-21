using BibliotecaTDA;
namespace vs2
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
            Console.Write("Placa: ");
            Placa = Console.ReadLine();
            Console.Write("Marca: ");
            Marca = Console.ReadLine();
            Console.Write("Modelo: ");
            Modelo = Console.ReadLine();
            Console.Write("Año: ");
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
            Console.Write("Placa: ");
            Placa = Console.ReadLine();
            Console.Write("Marca: ");
            Marca = Console.ReadLine();
            Console.Write("Modelo: ");
            Modelo = Console.ReadLine();
            Console.Write("Nro de Ruedas: ");
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
        private static bool VerificarVehiculo(cVehiculo vehiculo, cListaIterativa lista)
        {
            bool isIn = false; // por defecto consideramos que no esta en la lista

            for (int i = 0; i < lista.Longitud(); i++)
            {
                if (lista.Iesimo(i) != null) // Verifica que no comparemos con un objeto null
                {
                    if (lista.Iesimo(i) == vehiculo)
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
            Console.WriteLine("\n--- MENU DE VEHICULOS 2.0 ---");
            Console.WriteLine("1. Listar");
            Console.WriteLine("2. Insertar");
            Console.WriteLine("3. Buscar");
            Console.WriteLine("4. Total Peaje");
            Console.WriteLine("5. Nro de autos y camiones");
            Console.WriteLine("6. Salir");
            Console.Write("Opcion --> ");
            int opcion = int.Parse(Console.ReadLine() ??  string.Empty);
            return opcion;
        }

        public static void Listar(cListaIterativa listaDeVehiculos)
        {
            Console.WriteLine("\n--- LISTA DE VEHICULOS ---\n");
            for (int i = 0;i < listaDeVehiculos.Longitud(); i++)
            {
                if (listaDeVehiculos.Iesimo(i) != null)
                {
                    listaDeVehiculos.Iesimo(i).ToString();
                    Console.WriteLine("");
                }
            }
        }
        static bool isFull = false;
        public static void Insertar(cListaIterativa lista)
        {
            if (isFull) 
            {
                Console.WriteLine("\nLa lista se encuentra LLENA");
            }
            else
            {
                Console.WriteLine("\nDigite el numero del Vehiculo que desea agregar:");
                Console.WriteLine("1. Auto");
                Console.WriteLine("2. Camion");
                Console.Write("Opcion --> ");
                int opcion = int.Parse(Console.ReadLine());

                if (opcion == 1)
                {
                    for(int i = 0; i < lista.Longitud(); i++)
                    {
                        if (lista.Iesimo(i) == null)
                        {
                            // Leemos los datos del vehiculo a insertar 
                            cVehiculo v = new cAuto();
                            v.Leer();
                            // Verificamos que no este en la lista
                            if(! VerificarVehiculo(v, lista))
                            {
                                if (i == lista.Longitud() - 1) // Si el indice llega al final
                                {
                                    isFull = true;
                                }
                                lista.Agregar(v);
                                break;
                            }
                            else {Console.WriteLine($"El vehiculo de placa {v.Placa} ya se encuentra registrado");break;}
                        }
                    }
                }
                else if (opcion == 2)
                {
                    for(int i = 0; i < lista.Longitud(); i++)
                    {
                        if (lista.Iesimo(i) == null)
                        {
                            // Leemos los datos del vehiculo a insertar 
                            cVehiculo v = new cCamion();
                            v.Leer();
                            // Verificamos que no este en la lista
                            if(! VerificarVehiculo(v, lista))
                            {
                                if (i == lista.Longitud() - 1) // Si el indice llega al final
                                {
                                    isFull = true;
                                }
                                lista.Agregar(v); 
                                break;
                            }
                            else {Console.WriteLine($"El vehiculo de placa {v.Placa} ya se encuentra registrado");break;}
                        }
                    }
                }
                else {Console.WriteLine("No eligio una opcion habilitada.");}
            }
            
        }

        public static void Buscar(cListaIterativa lista)
        {
            bool isIn = false;
            int pos = 0;

            // Pedimos el dato significativo (placa) que se desea buscar
            Console.WriteLine("\n---BUSQUEDA POR PLACA---");
            Console.Write("Placa: ");
            string placa = Console.ReadLine();
            
            for (int i = 0; i < lista.Longitud(); i++)
            {
                if (lista.Iesimo != null)
                {
                    if (lista.Iesimo(i).Equals(placa))
                    {
                        pos = i;
                        isIn = true;
                    }
                }
            }

            if (isIn)
            {
                Console.WriteLine($"\nVehiculo de placa: {placa}");
                Console.WriteLine($"Posicion: {pos+1}");
            }
            else
            {
                Console.WriteLine($"\nVehiculo de placa: {placa} no fue encontrado.");
            }  
        }

        public static void CalcularTotalPeaje(cListaIterativa lista)
        {
            int totalPeaje = 0;

            for (int i = 0; i < lista.Longitud(); i++)
            {   
                if (lista.Iesimo(i) != null)
                {
                    totalPeaje = lista.Iesimo(i).CalcularPeaje();
                }
            }
            Console.WriteLine("\n--- PEAJE ---");
            Console.WriteLine($"El peaje total es de S/.{totalPeaje}");
        }

        public static void ContarAutosCamiones(cListaIterativa lista)
        {
            int nroAutos = 0;
            int nroCamiones = 0;

            for (int i = 0; i < lista.Longitud(); i++)
            {   
                if (lista.Iesimo(i) != null)
                {
                    if (lista.Iesimo(i) is cAuto){nroAutos++;}
                    else {nroCamiones++;}
                }
            }

            Console.WriteLine($"\n--- CANTIDAD ---");
            Console.WriteLine($"Autos: {nroAutos}");
            Console.WriteLine($"Camiones: {nroCamiones}");
        }
    }
}