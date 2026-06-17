Console.WriteLine("Sistema de Registros de Estudiantes");
// Emelly Victoria 2025-2504 

try
{
    SistemaEstudiantes sistema = new SistemaEstudiantes();

    bool running = true;
    while (running)
    {
        Console.Write("1. Agregar Estudiante      ");
        Console.Write("2. Ver Estudiantes     ");
        Console.Write("3. Buscar Estudiante      ");
        Console.Write("4. Modificar Estudiante        ");
        Console.Write("5. Eliminar Estudiante     ");
        Console.WriteLine("6. Salir");
        Console.Write("Elige una opción: ");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                sistema.AgregarEstudiante();
                break;
            case 2:
                sistema.VerEstudiantes();
                break;
            case 3:
                sistema.BuscarEstudiante();
                break;
            case 4:
                sistema.ModificarEstudiante();
                break;
            case 5:
                sistema.EliminarEstudiante();
                break;
            case 6:
                running = false;
                break;
            default:
                Console.WriteLine("Opción no válida");
                break;
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine("Ha ocurrido un error: " + ex.Message);
}

class Estudiante
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Edad { get; set; }
    public string Matricula { get; set; }
    public string Carrera { get; set; }
}

class SistemaEstudiantes
{
    List<Estudiante> estudiantes = new List<Estudiante>();

    public void AgregarEstudiante()
    {
        int id = estudiantes.Count + 1;

        Console.Write("Digite el Nombre: ");
        var nombre = Console.ReadLine();

        Console.Write("Digite el Apellido: ");
        var apellido = Console.ReadLine();

        Console.Write("Digite la Edad: ");
        var edad = Convert.ToInt32(Console.ReadLine());

        Console.Write("Digite la Matrícula: ");
        var matricula = Console.ReadLine();

        Console.Write("Digite la Carrera: ");
        var carrera = Console.ReadLine();

        estudiantes.Add(new Estudiante
        {
            Id = id,
            Nombre = nombre,
            Apellido = apellido,
            Edad = edad,
            Matricula = matricula,
            Carrera = carrera
        });

        Console.WriteLine("Estudiante agregado");
        Console.WriteLine();
    }

    public void VerEstudiantes()
    {
        Console.WriteLine("Id      Nombre          Apellido        Edad        Matrícula        Carrera");
        Console.WriteLine("____________________________________________________________________________");

        foreach (var e in estudiantes)
        {
            Console.WriteLine($"{e.Id}    {e.Nombre}      {e.Apellido}      {e.Edad}     {e.Matricula}     {e.Carrera}");
        }
    }

    public void BuscarEstudiante()
    {
        VerEstudiantes();

        Console.WriteLine("Digite un Id de Estudiante para Mostrar");
        int idSeleccionado = Convert.ToInt32(Console.ReadLine());

        foreach (var e in estudiantes)
        {
            if (e.Id == idSeleccionado)
            {
                Console.Write($"Nombre: {e.Nombre} ");
                Console.Write($"Apellido: {e.Apellido} ");
                Console.Write($"Edad: {e.Edad} ");
                Console.Write($"Matrícula: {e.Matricula} ");
                Console.Write($"Carrera: {e.Carrera}");
                Console.WriteLine();
            }
        }
    }

    public void ModificarEstudiante()
    {
        VerEstudiantes();

        Console.WriteLine("Digite un Id de Estudiante para Modificar");
        int idSeleccionado = Convert.ToInt32(Console.ReadLine());

        Estudiante seleccionado = null;

        foreach (var e in estudiantes)
        {
            if (e.Id == idSeleccionado)
                seleccionado = e;
        }

        Console.Write($"El nombre es: {seleccionado.Nombre}, Digite el Nuevo Nombre: ");
        seleccionado.Nombre = Console.ReadLine();

        Console.Write($"El apellido es: {seleccionado.Apellido}, Digite el Nuevo Apellido: ");
        seleccionado.Apellido = Console.ReadLine();

        Console.Write($"La edad es: {seleccionado.Edad}, Digite la Nueva Edad: ");
        seleccionado.Edad = Convert.ToInt32(Console.ReadLine());

        Console.Write($"La matrícula es: {seleccionado.Matricula}, Digite la Nueva Matrícula: ");
        seleccionado.Matricula = Console.ReadLine();

        Console.Write($"La carrera es: {seleccionado.Carrera}, Digite la Nueva Carrera: ");
        seleccionado.Carrera = Console.ReadLine();

        Console.WriteLine("Estudiante modificado");
    }

    public void EliminarEstudiante()
    {
        VerEstudiantes();

        Console.WriteLine("Digite un Id de Estudiante para Eliminar");
        int idSeleccionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Seguro que desea eliminar? 1. Si, 2. No");
        int opcion = Convert.ToInt32(Console.ReadLine());

        if (opcion == 1)
        {
            Estudiante seleccionado = null;

            foreach (var e in estudiantes)
            {
                if (e.Id == idSeleccionado)
                    seleccionado = e;
            }

            estudiantes.Remove(seleccionado);

            Console.WriteLine("Estudiante eliminado");
        }
    }
}
```
