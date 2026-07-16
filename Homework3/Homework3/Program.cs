using System;
using System.Collections.Generic;

Console.WriteLine("=========================================");
Console.WriteLine(" Registro de Estudiantes y Calificaciones");
Console.WriteLine("=========================================");

ControlAcademico control = new ControlAcademico();

bool salir = false;

while (!salir)
{
    Console.WriteLine();
    Console.WriteLine("1. Agregar estudiante");
    Console.WriteLine("2. Listar estudiantes");
    Console.WriteLine("3. Buscar estudiante");
    Console.WriteLine("4. Modificar estudiante");
    Console.WriteLine("5. Eliminar estudiante");
    Console.WriteLine("6. Salir");
    Console.Write("Seleccione una opción: ");

    int opcion;

    while (!int.TryParse(Console.ReadLine(), out opcion))
    {
        Console.Write("Opción inválida. Intente otra vez: ");
    }

    try
    {
        switch (opcion)
        {
            case 1:
                control.AgregarEstudiante();
                break;

            case 2:
                control.ListarEstudiantes();
                break;

            case 3:
                control.BuscarEstudiante();
                break;

            case 4:
                control.ModificarEstudiante();
                break;

            case 5:
                control.EliminarEstudiante();
                break;

            case 6:
                salir = true;
                Console.WriteLine("Hasta luego.");
                break;

            default:
                Console.WriteLine("Opción inválida.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Ocurrió un error: " + ex.Message);
    }
}


class Estudiante
{
    public int Id;
    public string Nombre;
    public string Apellido;
    public string Asignatura;
    public int Nota;
}


class ControlAcademico
{
    List<Estudiante> estudiantes = new List<Estudiante>();


    public void AgregarEstudiante()
    {
        Estudiante estudiante = new Estudiante();

        int ultimoId = 0;

        foreach (var estudianteActual in estudiantes)
        {
            if (estudianteActual.Id > ultimoId)
            {
                ultimoId = estudianteActual.Id;
            }
        }

        estudiante.Id = ultimoId + 1;

        Console.Write("Nombre: ");
        estudiante.Nombre = Console.ReadLine();

        Console.Write("Apellido: ");
        estudiante.Apellido = Console.ReadLine();

        Console.Write("Asignatura: ");
        estudiante.Asignatura = Console.ReadLine();

        Console.Write("Nota: ");

        int nota;

        while (!int.TryParse(Console.ReadLine(), out nota))
        {
            Console.Write("Ingrese una nota válida: ");
        }

        estudiante.Nota = nota;

        estudiantes.Add(estudiante);

        Console.WriteLine("Estudiante agregado correctamente.");
    }


    public void ListarEstudiantes()
    {
        if (estudiantes.Count == 0)
        {
            Console.WriteLine("No hay estudiantes registrados.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("ID\tNombre\tApellido\tAsignatura\tNota");

        foreach (var estudiante in estudiantes)
        {
            Console.WriteLine($"{estudiante.Id}\t{estudiante.Nombre}\t{estudiante.Apellido}\t{estudiante.Asignatura}\t{estudiante.Nota}");
        }
    }


    public void BuscarEstudiante()
    {
        Console.Write("Ingrese el ID del estudiante: ");

        int id;

        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.Write("ID inválido: ");
        }

        Estudiante encontrado = null;

        foreach (var estudiante in estudiantes)
        {
            if (estudiante.Id == id)
            {
                encontrado = estudiante;
                break;
            }
        }

        if (encontrado == null)
        {
            Console.WriteLine("Estudiante no encontrado.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("ID: " + encontrado.Id);
        Console.WriteLine("Nombre: " + encontrado.Nombre);
        Console.WriteLine("Apellido: " + encontrado.Apellido);
        Console.WriteLine("Asignatura: " + encontrado.Asignatura);
        Console.WriteLine("Nota: " + encontrado.Nota);
    }


    public void ModificarEstudiante()
    {
        Console.Write("Ingrese el ID del estudiante: ");

        int id;

        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.Write("ID inválido: ");
        }

        Estudiante encontrado = null;

        foreach (var estudiante in estudiantes)
        {
            if (estudiante.Id == id)
            {
                encontrado = estudiante;
                break;
            }
        }

        if (encontrado == null)
        {
            Console.WriteLine("Estudiante no encontrado.");
            return;
        }

        Console.Write("Nuevo nombre: ");
        encontrado.Nombre = Console.ReadLine();

        Console.Write("Nuevo apellido: ");
        encontrado.Apellido = Console.ReadLine();

        Console.Write("Nueva asignatura: ");
        encontrado.Asignatura = Console.ReadLine();

        Console.Write("Nueva nota: ");

        int nota;

        while (!int.TryParse(Console.ReadLine(), out nota))
        {
            Console.Write("Ingrese una nota válida: ");
        }

        encontrado.Nota = nota;

        Console.WriteLine("Estudiante modificado correctamente.");
    }


    public void EliminarEstudiante()
    {
        Console.Write("Ingrese el ID del estudiante: ");

        int id;

        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.Write("ID inválido: ");
        }

        Estudiante encontrado = null;

        foreach (var estudiante in estudiantes)
        {
            if (estudiante.Id == id)
            {
                encontrado = estudiante;
                break;
            }
        }

        if (encontrado == null)
        {
            Console.WriteLine("Estudiante no encontrado.");
            return;
        }

        estudiantes.Remove(encontrado);

        Console.WriteLine("Estudiante eliminado correctamente.");
    }
}