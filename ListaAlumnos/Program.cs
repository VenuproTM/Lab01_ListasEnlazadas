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
            Console.WriteLine("[4] Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1: RegistrarAlumno(); break;
                case 4: Console.WriteLine("Saliendo del sistema..."); break;
                default: Console.WriteLine("Opción inválida."); break;
            }
        } while (opcion != 4);
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

        Console.WriteLine($"\nAlumno registrado. Código: {nuevo.Codigo}");
    }
}