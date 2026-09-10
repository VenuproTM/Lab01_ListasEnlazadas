
// Program.cs - Práctica Semana 2: Listas Enlazadas Simples
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

    static string GenerarCodigo()
    {
        string codigo = "N" + contador.ToString() + "P";

        if (contador < 9999)
        {
            contador++;
        }

        return codigo;
    }

    static string GenerarCorreo(string nombres)
    {
        string[] partes = nombres.Trim().Split(' ');
        string primerNombre = partes[0].ToLower();
        string iniciales = "";

        for (int i = 1; i < partes.Length; i++)
        {
            iniciales += partes[i][0];
        }

        return primerNombre + iniciales.ToLower() + "@upn.edu.pe";
    }

    static void Main()
    {
        int opcion;

        do
        {
            Console.WriteLine();
            Console.WriteLine("===== MENU - LISTA DE ALUMNOS =====");
            Console.WriteLine("[1] Registrar");
            Console.WriteLine("[2] Mostrar lista de alumnos");
            Console.WriteLine("[3] N° Alumnos registrados");
            Console.WriteLine("[4] Buscar (codigo o nombre)");
            Console.WriteLine("[5] Ordenar (burbuja)");
            Console.WriteLine("[6] Ordenamiento por Insercion (codigo)");
            Console.WriteLine("[7] Ordenamiento por Seleccion (nombre)");
            Console.WriteLine("[8] Busqueda binaria (codigo)");
            Console.WriteLine("[9] Busqueda por interpolacion (nombre)");
            Console.WriteLine("[10] Salir");
            Console.Write("Seleccione una opcion: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    RegistrarAlumno();
                    break;

                case 6:
                    OrdenamientoInsercionCodigo();
                    break;

                case 7:
                    OrdenamientoSeleccionNombre();
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

    static void RegistrarAlumno()
    {
        Alumno nuevo = new Alumno();

        nuevo.Codigo = GenerarCodigo();

        Console.Write("Ingrese nombres y apellidos: ");
        nuevo.Nombres = Console.ReadLine();

        nuevo.Correo = GenerarCorreo(nuevo.Nombres);

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

        Console.WriteLine();
        Console.WriteLine("Alumno registrado con exito.");
        Console.WriteLine("Codigo : " + nuevo.Codigo);
        Console.WriteLine("Correo : " + nuevo.Correo);
    }

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

        int[,] notas = a.Notas;
        a.Notas = b.Notas;
        b.Notas = notas;
    }

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

        Alumno t = cabeza;

        while (t.Siguiente != null)
        {
            t = t.Siguiente;
        }

        ultimo = t;

        Console.WriteLine("Lista ordenada por insercion segun codigo.");
    }

    static void OrdenamientoSeleccionNombre()
    {
        if (cabeza == null)
        {
            Console.WriteLine("No hay alumnos registrados.");
            return;
        }

        Alumno actual = cabeza;

        while (actual != null)
        {
            Alumno menor = actual;
            Alumno recorrido = actual.Siguiente;

            while (recorrido != null)
            {
                if (string.Compare(recorrido.Nombres, menor.Nombres) < 0)
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
}