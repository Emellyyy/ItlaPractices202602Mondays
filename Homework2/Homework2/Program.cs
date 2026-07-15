using System;
using System.Collections.Generic;
using System.Linq;

Dictionary<int, string> nombres = new Dictionary<int, string>();
Dictionary<int, string> apellidos = new Dictionary<int, string>();
Dictionary<int, string> asignaturas = new Dictionary<int, string>();
Dictionary<int, double> calificaciones = new Dictionary<int, double>();

List<int> idsEstudiantes = new List<int>();

int opcion;
bool salir = false;

Console.WriteLine("Bienvenido al Registro de Estudiantes");

while (!salir)
{
    Console.WriteLine("\nSeleccione una opción:");
    Console.WriteLine("1. Agregar estudiante");
    Console.WriteLine("2. Mostrar estudiantes");
    Console.WriteLine("3. Buscar estudiante");
    Console.WriteLine("4. Modificar estudiante");
    Console.WriteLine("5. Eliminar estudiante");
    Console.WriteLine("6. Salir");

    int.TryParse(Console.ReadLine(), out opcion);

    switch (opcion)
    {
        case 1:
            AgregarEstudiante(nombres, apellidos, asignaturas, calificaciones, idsEstudiantes);
            break;

        case 2:
            MostrarEstudiantes(nombres, apellidos, asignaturas, calificaciones, idsEstudiantes);
            break;

        case 3:
            BuscarEstudiante(nombres, apellidos, asignaturas, calificaciones);
            break;

        case 4:
            Console.WriteLine("Ingrese el ID del estudiante que desea modificar:");

            if (int.TryParse(Console.ReadLine(), out int idModificar))
            {
                ModificarEstudiante(nombres, apellidos, asignaturas, calificaciones, idModificar);
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }

            break;

        case 5:
            Console.WriteLine("Ingrese el ID del estudiante que desea eliminar:");

            if (int.TryParse(Console.ReadLine(), out int idEliminar))
            {
                EliminarEstudiante(nombres, apellidos, asignaturas, calificaciones, idsEstudiantes, idEliminar);
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }

            break;

        case 6:
            Console.WriteLine("Cerrando aplicación...");
            salir = true;
            break;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }
}

Console.WriteLine("Gracias por utilizar el Registro de Estudiantes");


static int ObtenerNuevoId(List<int> idsEstudiantes)
{
    if (idsEstudiantes.Count == 0)
    {
        return 1;
    }

    return idsEstudiantes.Max() + 1;
}


static void AgregarEstudiante(
Dictionary<int, string> nombres,
Dictionary<int, string> apellidos,
Dictionary<int, string> asignaturas,
Dictionary<int, double> calificaciones,
List<int> idsEstudiantes)
{
    Console.WriteLine("\nAgregando nuevo estudiante...");

    int id = ObtenerNuevoId(idsEstudiantes);

    idsEstudiantes.Add(id);

    Console.WriteLine("Ingrese el nombre del estudiante:");
    nombres.Add(id, Console.ReadLine());

    Console.WriteLine("Ingrese el apellido del estudiante:");
    apellidos.Add(id, Console.ReadLine());

    Console.WriteLine("Ingrese la asignatura:");
    asignaturas.Add(id, Console.ReadLine());

    Console.WriteLine("Ingrese la calificación:");

    double nota;

    while (!double.TryParse(Console.ReadLine(), out nota))
    {
        Console.WriteLine("Ingrese una calificación válida:");
    }

    calificaciones.Add(id, nota);

    Console.WriteLine("Estudiante agregado correctamente.");
}


static void MostrarEstudiantes(
Dictionary<int, string> nombres,
Dictionary<int, string> apellidos,
Dictionary<int, string> asignaturas,
Dictionary<int, double> calificaciones,
List<int> idsEstudiantes)
{
    Console.WriteLine("\nLista de estudiantes:");

    Console.WriteLine("ID\tNombre\tApellido\tAsignatura\tNota");

    foreach (var id in idsEstudiantes)
    {
        Console.Write(id);
        Console.Write("\t" + nombres[id]);
        Console.Write("\t" + apellidos[id]);
        Console.Write("\t" + asignaturas[id]);
        Console.Write("\t" + calificaciones[id]);
        Console.WriteLine();
    }
}


static void BuscarEstudiante(
Dictionary<int, string> nombres,
Dictionary<int, string> apellidos,
Dictionary<int, string> asignaturas,
Dictionary<int, double> calificaciones)
{
    Console.WriteLine("Ingrese el nombre del estudiante:");

    string nombreBuscar = Console.ReadLine();

    foreach (var estudiante in nombres)
    {
        if (estudiante.Value.ToLower() == nombreBuscar.ToLower())
        {
            int id = estudiante.Key;

            Console.WriteLine("\nEstudiante encontrado:");
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Nombre: " + nombres[id]);
            Console.WriteLine("Apellido: " + apellidos[id]);
            Console.WriteLine("Asignatura: " + asignaturas[id]);
            Console.WriteLine("Nota: " + calificaciones[id]);

            return;
        }
    }

    Console.WriteLine("No se encontró el estudiante.");
}


static void ModificarEstudiante(
Dictionary<int, string> nombres,
Dictionary<int, string> apellidos,
Dictionary<int, string> asignaturas,
Dictionary<int, double> calificaciones,
int id)
{
    if (!nombres.ContainsKey(id))
    {
        Console.WriteLine("El estudiante no existe.");
        return;
    }

    Console.WriteLine("Ingrese el nuevo nombre:");
    nombres[id] = Console.ReadLine();

    Console.WriteLine("Ingrese el nuevo apellido:");
    apellidos[id] = Console.ReadLine();

    Console.WriteLine("Ingrese la nueva asignatura:");
    asignaturas[id] = Console.ReadLine();

    Console.WriteLine("Ingrese la nueva calificación:");

    double nuevaNota;

    while (!double.TryParse(Console.ReadLine(), out nuevaNota))
    {
        Console.WriteLine("Ingrese una calificación válida:");
    }

    calificaciones[id] = nuevaNota;

    Console.WriteLine("Estudiante modificado correctamente.");
}


static void EliminarEstudiante(
Dictionary<int, string> nombres,
Dictionary<int, string> apellidos,
Dictionary<int, string> asignaturas,
Dictionary<int, double> calificaciones,
List<int> idsEstudiantes,
int id)
{
    if (nombres.ContainsKey(id))
    {
        nombres.Remove(id);
        apellidos.Remove(id);
        asignaturas.Remove(id);
        calificaciones.Remove(id);
        idsEstudiantes.Remove(id);

        Console.WriteLine("Estudiante eliminado correctamente.");
    }
    else
    {
        Console.WriteLine("No existe un estudiante con ese ID.");
    }
}