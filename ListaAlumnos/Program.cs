using System;

class Alumno
{
    public string Codigo;
    public string Nombres;
    public int Edad;
    public string Correo;
    public string[] Cursos = new string[2] { "Lenguaje", "Matemática" };
    public int[,] Notas = new int[2, 2];
    public Alumno Siguiente;
}

class Program
{
    static Alumno cabeza = null;
    static Alumno ultimo = null;
    static int contador = 1000;
    static int totalAlumnos = 0;

    // =========================================================
    // GENERAR CODIGO
    // =========================================================
    static string GenerarCodigo()
    {
        string codigo = "N" + contador.ToString() + "P";

        if (contador < 9999)
            contador++;

        return codigo;
    }

    // =========================================================
    // GENERAR CORREO
    // =========================================================
    static string GenerarCorreo(string nombres)
    {
        string[] partes = nombres.Trim().Split(' ');

        string correo = partes[0].ToLower();

        if (partes.Length > 1)
            correo += partes[partes.Length - 1].Substring(0, 1).ToLower();

        return correo + "@upn.edu.pe";
    }

    // =========================================================
    // MENU PRINCIPAL
    // =========================================================
    static void Main()
    {
        int opcion;

        do
        {
            Console.WriteLine("\n===== MENU - LISTA DE ALUMNOS =====");
            Console.WriteLine("[1] Registrar");
            Console.WriteLine("[2] Mostrar Lista");
            Console.WriteLine("[3] Contar Alumnos");
            Console.WriteLine("[4] Buscar Alumno");
            Console.WriteLine("[5] Ordenar por Burbuja");
            Console.WriteLine("[6] Ordenar por Insercion (Codigo)");
            Console.WriteLine("[7] Ordenar por Seleccion (Nombre)");
            Console.WriteLine("[8] Busqueda Binaria (Codigo)");
            Console.WriteLine("[9] Busqueda por Interpolacion (Nombre)");
            Console.WriteLine("[10] Salir");
            Console.Write("Seleccione una opcion: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    RegistrarAlumno();
                    break;

                case 2:
                    MostrarListaAlumnos();
                    break;

                case 3:
                    ContarAlumnos();
                    break;

                case 4:
                    BuscarAlumno();
                    break;

                case 5:
                    OrdenarBurbuja();
                    break;

                case 6:
                    OrdenamientoInsercionCodigo();
                    break;

                case 7:
                    OrdenamientoSeleccionNombre();
                    break;

                case 8:
                    BusquedaBinariaCodigo();
                    break;

                case 9:
                    BusquedaInterpolacionNombre();
                    break;

                case 10:
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opcion invalida.");
                    break;
            }

        } while (opcion != 10);
    }

    // =========================================================
    // 1. REGISTRAR ALUMNO
    // =========================================================
    static void RegistrarAlumno()
    {
        Alumno nuevo = new Alumno();

        nuevo.Codigo = GenerarCodigo();

        Console.Write("Ingrese nombres y apellidos: ");
        nuevo.Nombres = Console.ReadLine();

        Console.Write("Ingrese edad: ");
        nuevo.Edad = int.Parse(Console.ReadLine());

        nuevo.Correo = GenerarCorreo(nuevo.Nombres);

        nuevo.Siguiente = null;

        if (cabeza == null)
        {
            cabeza = nuevo;
            ultimo = nuevo;
        }
        else
        {
            ultimo.Siguiente = nuevo;
            ultimo = nuevo;
        }

        totalAlumnos++;

        Console.WriteLine("\nAlumno registrado correctamente.");
        Console.WriteLine("Codigo: " + nuevo.Codigo);
        Console.WriteLine("Nombre: " + nuevo.Nombres);
        Console.WriteLine("Edad: " + nuevo.Edad);
        Console.WriteLine("Correo: " + nuevo.Correo);
    }

    // =========================================================
    // 2. MOSTRAR LISTA
    // =========================================================
    static void MostrarListaAlumnos()
    {
        if (cabeza == null)
        {
            Console.WriteLine("No hay alumnos registrados.");
            return;
        }

        Alumno actual = cabeza;

        Console.WriteLine("\n===== LISTA DE ALUMNOS =====");

        while (actual != null)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Codigo: " + actual.Codigo);
            Console.WriteLine("Nombres: " + actual.Nombres);
            Console.WriteLine("Edad: " + actual.Edad);
            Console.WriteLine("Correo: " + actual.Correo);

            actual = actual.Siguiente;
        }

        Console.WriteLine("--------------------------------");
    }

    // =========================================================
    // 3. CONTAR ALUMNOS
    // =========================================================
    static void ContarAlumnos()
    {
        Console.WriteLine("\nNumero de alumnos registrados: " + totalAlumnos);
    }

    // =========================================================
    // 4. BUSQUEDA SECUENCIAL
    // =========================================================
    static void BuscarAlumno()
    {
        if (cabeza == null)
        {
            Console.WriteLine("No hay alumnos registrados.");
            return;
        }

        Console.WriteLine("\nBuscar por:");
        Console.WriteLine("[1] Codigo");
        Console.WriteLine("[2] Nombre");
        Console.Write("Seleccione: ");

        int op = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el dato a buscar: ");
        string dato = Console.ReadLine().Trim().ToLower();

        Alumno actual = cabeza;
        bool encontrado = false;

        while (actual != null)
        {
            bool coincide = false;

            if (op == 1)
            {
                coincide = actual.Codigo.ToLower() == dato;
            }
            else if (op == 2)
            {
                coincide = actual.Nombres.ToLower().Contains(dato);
            }

            if (coincide)
            {
                Console.WriteLine("\n===== ALUMNO ENCONTRADO =====");
                Console.WriteLine("Codigo: " + actual.Codigo);
                Console.WriteLine("Nombres: " + actual.Nombres);
                Console.WriteLine("Edad: " + actual.Edad);
                Console.WriteLine("Correo: " + actual.Correo);

                encontrado = true;
            }

            actual = actual.Siguiente;
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontro ningun alumno con ese dato.");
        }
    }

    // =========================================================
    // INTERCAMBIAR DATOS
    // =========================================================
    static void IntercambiarDatos(Alumno a, Alumno b)
    {
        string codigo = a.Codigo;
        a.Codigo = b.Codigo;
        b.Codigo = codigo;

        string nombres = a.Nombres;
        a.Nombres = b.Nombres;
        b.Nombres = nombres;

        int edad = a.Edad;
        a.Edad = b.Edad;
        b.Edad = edad;

        string correo = a.Correo;
        a.Correo = b.Correo;
        b.Correo = correo;

        int nota00 = a.Notas[0, 0];
        int nota01 = a.Notas[0, 1];
        int nota10 = a.Notas[1, 0];
        int nota11 = a.Notas[1, 1];

        a.Notas[0, 0] = b.Notas[0, 0];
        a.Notas[0, 1] = b.Notas[0, 1];
        a.Notas[1, 0] = b.Notas[1, 0];
        a.Notas[1, 1] = b.Notas[1, 1];

        b.Notas[0, 0] = nota00;
        b.Notas[0, 1] = nota01;
        b.Notas[1, 0] = nota10;
        b.Notas[1, 1] = nota11;
    }

    // =========================================================
    // 5. ORDENAMIENTO BURBUJA POR CODIGO
    // =========================================================
    static void OrdenarBurbuja()
    {
        if (cabeza == null || cabeza.Siguiente == null)
        {
            Console.WriteLine("No hay suficientes alumnos para ordenar.");
            return;
        }

        bool intercambio;

        do
        {
            intercambio = false;

            Alumno actual = cabeza;

            while (actual.Siguiente != null)
            {
                if (string.Compare(actual.Codigo, actual.Siguiente.Codigo) > 0)
                {
                    IntercambiarDatos(actual, actual.Siguiente);
                    intercambio = true;
                }

                actual = actual.Siguiente;
            }

        } while (intercambio);

        Console.WriteLine("Lista ordenada por burbuja segun codigo.");
    }

    // =========================================================
    // 6. ORDENAMIENTO POR INSERCION POR CODIGO
    // =========================================================
    static void OrdenamientoInsercionCodigo()
    {
        if (cabeza == null || cabeza.Siguiente == null)
        {
            Console.WriteLine("No hay suficientes alumnos para ordenar.");
            return;
        }

        Alumno ordenada = null;
        Alumno actual = cabeza;

        while (actual != null)
        {
            Alumno siguienteOriginal = actual.Siguiente;

            if (ordenada == null ||
                string.Compare(actual.Codigo, ordenada.Codigo) < 0)
            {
                actual.Siguiente = ordenada;
                ordenada = actual;
            }
            else
            {
                Alumno temp = ordenada;

                while (temp.Siguiente != null &&
                       string.Compare(temp.Siguiente.Codigo, actual.Codigo) < 0)
                {
                    temp = temp.Siguiente;
                }

                actual.Siguiente = temp.Siguiente;
                temp.Siguiente = actual;
            }

            actual = siguienteOriginal;
        }

        cabeza = ordenada;

        ultimo = cabeza;

        while (ultimo.Siguiente != null)
        {
            ultimo = ultimo.Siguiente;
        }

        Console.WriteLine("Lista ordenada por insercion segun codigo.");
    }

    // =========================================================
    // 7. ORDENAMIENTO POR SELECCION POR NOMBRE
    // =========================================================
    static void OrdenamientoSeleccionNombre()
    {
        if (cabeza == null || cabeza.Siguiente == null)
        {
            Console.WriteLine("No hay suficientes alumnos para ordenar.");
            return;
        }

        Alumno actual = cabeza;

        while (actual != null)
        {
            Alumno menor = actual;
            Alumno recorrido = actual.Siguiente;

            while (recorrido != null)
            {
                if (string.Compare(
                    recorrido.Nombres,
                    menor.Nombres,
                    StringComparison.OrdinalIgnoreCase) < 0)
                {
                    menor = recorrido;
                }

                recorrido = recorrido.Siguiente;
            }

            if (menor != actual)
            {
                IntercambiarDatos(actual, menor);
            }

            actual = actual.Siguiente;
        }

        Console.WriteLine("Lista ordenada por seleccion segun nombre.");
    }

    // =========================================================
    // CONVERTIR LISTA A ARREGLO
    // =========================================================
    static Alumno[] ListaAArreglo()
    {
        Alumno[] arreglo = new Alumno[totalAlumnos];

        Alumno actual = cabeza;
        int i = 0;

        while (actual != null)
        {
            arreglo[i] = actual;
            actual = actual.Siguiente;
            i++;
        }

        return arreglo;
    }

    // =========================================================
    // ORDENAR ARREGLO POR CODIGO
    // =========================================================
    static void OrdenarArregloPorCodigo(Alumno[] arreglo)
    {
        for (int i = 0; i < arreglo.Length - 1; i++)
        {
            for (int j = 0; j < arreglo.Length - 1 - i; j++)
            {
                if (string.Compare(arreglo[j].Codigo, arreglo[j + 1].Codigo) > 0)
                {
                    Alumno temporal = arreglo[j];
                    arreglo[j] = arreglo[j + 1];
                    arreglo[j + 1] = temporal;
                }
            }
        }
    }

    // =========================================================
    // ORDENAR ARREGLO POR NOMBRE
    // =========================================================
    static void OrdenarArregloPorNombre(Alumno[] arreglo)
    {
        for (int i = 0; i < arreglo.Length - 1; i++)
        {
            for (int j = 0; j < arreglo.Length - 1 - i; j++)
            {
                if (string.Compare(
                    arreglo[j].Nombres,
                    arreglo[j + 1].Nombres,
                    StringComparison.OrdinalIgnoreCase) > 0)
                {
                    Alumno temporal = arreglo[j];
                    arreglo[j] = arreglo[j + 1];
                    arreglo[j + 1] = temporal;
                }
            }
        }
    }

    // =========================================================
    // 8. BUSQUEDA BINARIA POR CODIGO
    // =========================================================
    static void BusquedaBinariaCodigo()
    {
        if (cabeza == null)
        {
            Console.WriteLine("No hay alumnos registrados.");
            return;
        }

        Alumno[] arreglo = ListaAArreglo();

        OrdenarArregloPorCodigo(arreglo);

        Console.Write("Ingrese el codigo a buscar: ");

        string codigo = Console.ReadLine().Trim().ToUpper();

        int izquierda = 0;
        int derecha = arreglo.Length - 1;

        while (izquierda <= derecha)
        {
            int medio = (izquierda + derecha) / 2;

            int comparacion = string.Compare(
                arreglo[medio].Codigo,
                codigo,
                StringComparison.OrdinalIgnoreCase);

            if (comparacion == 0)
            {
                Console.WriteLine("\n===== ALUMNO ENCONTRADO =====");
                Console.WriteLine("Codigo: " + arreglo[medio].Codigo);
                Console.WriteLine("Nombres: " + arreglo[medio].Nombres);
                Console.WriteLine("Edad: " + arreglo[medio].Edad);
                Console.WriteLine("Correo: " + arreglo[medio].Correo);
                return;
            }

            if (comparacion < 0)
            {
                izquierda = medio + 1;
            }
            else
            {
                derecha = medio - 1;
            }
        }

        Console.WriteLine("Codigo no encontrado.");
    }

    // =========================================================
    // VALOR NUMERICO PARA INTERPOLACION
    // =========================================================
    static long ValorNumerico(string texto)
    {
        string t = texto.Trim().ToUpper();

        long valor = 0;
        int cantidad = 0;

        for (int i = 0; i < t.Length && cantidad < 8; i++)
        {
            char caracter = t[i];

            if (caracter >= 'A' && caracter <= 'Z')
            {
                int numero = caracter - 'A' + 1;

                valor = valor * 27 + numero;

                cantidad++;
            }
        }

        while (cantidad < 8)
        {
            valor = valor * 27;
            cantidad++;
        }

        return valor;
    }

    // =========================================================
    // 9. BUSQUEDA POR INTERPOLACION POR NOMBRE
    // =========================================================
    static void BusquedaInterpolacionNombre()
    {
        if (cabeza == null)
        {
            Console.WriteLine("No hay alumnos registrados.");
            return;
        }

        Alumno[] arreglo = ListaAArreglo();

        OrdenarArregloPorNombre(arreglo);

        Console.Write("Ingrese el nombre completo a buscar: ");

        string nombre = Console.ReadLine().Trim();

        int izquierda = 0;
        int derecha = arreglo.Length - 1;

        long clave = ValorNumerico(nombre);

        while (izquierda <= derecha)
        {
            long valorIzquierda = ValorNumerico(arreglo[izquierda].Nombres);
            long valorDerecha = ValorNumerico(arreglo[derecha].Nombres);

            if (valorIzquierda == valorDerecha)
            {
                for (int i = izquierda; i <= derecha; i++)
                {
                    if (string.Equals(
                        arreglo[i].Nombres,
                        nombre,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("\n===== ALUMNO ENCONTRADO =====");
                        Console.WriteLine("Codigo: " + arreglo[i].Codigo);
                        Console.WriteLine("Nombres: " + arreglo[i].Nombres);
                        Console.WriteLine("Edad: " + arreglo[i].Edad);
                        Console.WriteLine("Correo: " + arreglo[i].Correo);
                        return;
                    }
                }

                break;
            }

            if (clave < valorIzquierda || clave > valorDerecha)
            {
                break;
            }

            int posicion = izquierda +
                (int)(((double)(clave - valorIzquierda) *
                (derecha - izquierda)) /
                (valorDerecha - valorIzquierda));

            if (posicion < izquierda)
                posicion = izquierda;

            if (posicion > derecha)
                posicion = derecha;

            int comparacion = string.Compare(
                arreglo[posicion].Nombres,
                nombre,
                StringComparison.OrdinalIgnoreCase);

            if (comparacion == 0)
            {
                Console.WriteLine("\n===== ALUMNO ENCONTRADO =====");
                Console.WriteLine("Codigo: " + arreglo[posicion].Codigo);
                Console.WriteLine("Nombres: " + arreglo[posicion].Nombres);
                Console.WriteLine("Edad: " + arreglo[posicion].Edad);
                Console.WriteLine("Correo: " + arreglo[posicion].Correo);
                return;
            }

            if (comparacion < 0)
            {
                izquierda = posicion + 1;
            }
            else
            {
                derecha = posicion - 1;
            }
        }

        // Verificacion final para garantizar que un nombre existente
        // no sea rechazado por la aproximacion numerica.
        for (int i = 0; i < arreglo.Length; i++)
        {
            if (string.Equals(
                arreglo[i].Nombres,
                nombre,
                StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\n===== ALUMNO ENCONTRADO =====");
                Console.WriteLine("Codigo: " + arreglo[i].Codigo);
                Console.WriteLine("Nombres: " + arreglo[i].Nombres);
                Console.WriteLine("Edad: " + arreglo[i].Edad);
                Console.WriteLine("Correo: " + arreglo[i].Correo);
                return;
            }
        }

        Console.WriteLine("Nombre no encontrado.");
    }
}