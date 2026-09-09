// Program.cs - Práctica Semana 1: Listas Enlazadas Simples
using System;
class Alumno
{
    public string Codigo;
    public string Nombres;
    public int Edad;
    public string Correo;
    public string[] Cursos = new string[2] { "Lenguaje", "Matemática" };
    public int[,] Notas = new int[2, 2]; // [curso, nota1/nota2]
    public Alumno Siguiente; // puntero al siguiente nodo
}
class Program // Variables globales y menú principal
{
    static Alumno cabeza = null;   // primer nodo de la lista
    static Alumno ultimo = null;   // último nodo (para insertar al final)
    static int contador = 1000;    // generador de código autogenerado
    static int totalAlumnos = 0;

    static string GenerarCodigo()
    {
        string codigo = "N" + contador.ToString() + "P";

        if (contador < 9999)
            contador++;

        return codigo;
    }

    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine("\n===== MENÚ - LISTA DE ALUMNOS =====");
            Console.WriteLine("[1] Registrar");
            Console.WriteLine("[2] Mostrar Lista");
            Console.WriteLine("[3] Contar Alumnos");
            Console.WriteLine("[4] Buscar Alumno");
            Console.WriteLine("[5] Ordenar por Burbuja");
            Console.WriteLine("[6] Ordenar por Inserción (Código)");
            Console.WriteLine("[7] Ordenar por Selección (Nombre)");
            Console.WriteLine("[8] Búsqueda Binaria (Código)");
            Console.WriteLine("[9] Búsqueda por Interpolación (Nombre)");
            Console.WriteLine("[10] Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
{
    case 1: RegistrarAlumno(); break;
    //case 2: MostrarListaAlumnos(); break;
    //case 3: ContarAlumnos(); break;
    case 4: BuscarAlumno(); break;
    //case 5: OrdenarBurbuja(); break;
    //case 6: OrdenamientoInsercionCodigo(); break;
    //case 7: OrdenamientoSeleccionNombre(); break;
    //case 8: BusquedaBinariaCodigo(); break;
    //case 9: BusquedaInterpolacionNombre(); break;
    case 10: Console.WriteLine("Saliendo del sistema..."); break;
    default: Console.WriteLine("Opción inválida."); break;
}
        } while (opcion != 10);
    }

    static void BuscarAlumno()
{
    if (cabeza == null)
    {
        Console.WriteLine("No hay alumnos registrados.");
        return;
    }

    Console.WriteLine("Buscar por: [1] Código  [2] Nombre");
    int op = int.Parse(Console.ReadLine());
    Console.Write("Ingrese el dato a buscar: ");
    string dato = Console.ReadLine().Trim().ToLower();

    Alumno actual = cabeza;
    bool encontrado = false;
    while (actual != null)
    {
        bool coincide = (op == 1)
            ? actual.Codigo.ToLower() == dato
            : actual.Nombres.ToLower().Contains(dato);
            
        if (coincide)
        {
            Console.WriteLine($"\nEncontrado -> Código: {actual.Codigo} | Nombres: {actual.Nombres} | Edad: {actual.Edad} | Correo: {actual.Correo}");
            encontrado = true;
        }
        actual = actual.Siguiente;
    }
    if (!encontrado) Console.WriteLine("No se encontró ningún alumno con ese dato.");
}


    static void RegistrarAlumno()
    {
        Alumno nuevo = new Alumno();
        nuevo.Codigo = GenerarCodigo();
        Console.Write("Ingrese nombres y apellidos: ");
        nuevo.Nombres = Console.ReadLine();
        Console.Write("Ingrese edad: ");
        nuevo.Edad = int.Parse(Console.ReadLine());
        nuevo.Siguiente = null;
        if (cabeza == null)
        {cabeza = nuevo;ultimo = nuevo;}
        else
        {ultimo.Siguiente = nuevo;ultimo = nuevo;}
        totalAlumnos++;
        Console.WriteLine($"\nAlumno registrado. Código: {nuevo.Codigo}");
    }
}
