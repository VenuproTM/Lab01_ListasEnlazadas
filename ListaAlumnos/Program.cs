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
    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine("\n===== MENÚ - LISTA DE ALUMNOS =====");
            Console.WriteLine("[1] Registrar");
            Console.WriteLine("[2] Mostrar lista de alumnos");
            Console.WriteLine("[3] N° Alumnos registrados");
            Console.WriteLine("[4] Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1: RegistrarAlumno(); break;
                case 2: MostrarListaAlumnos(); break;
                case 3: ContarAlumnos(); break;
                case 4: Console.WriteLine("Saliendo del sistema..."); break;
                default: Console.WriteLine("Opción inválida."); break;
            }
        } while (opcion != 4);
    }
}