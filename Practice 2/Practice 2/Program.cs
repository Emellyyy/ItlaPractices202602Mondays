using System;
using System.Collections.Generic;
// Registro :)
class Estudiante
{
    public int Id;
    public string Nombre;
    public string Matricula;
    public string Cedula;
    public string Materia;
    public double Nota;
}

class Program
{
    static List<Estudiante> lista = new List<Estudiante>();
    static int contador = 1;

    static void Main()
    {
        string opcion = "";

        while (opcion != "0")
        {
            Console.WriteLine("\n1. Agregar estudiante");
            Console.WriteLine("2. Buscar estudiante");
            Console.WriteLine("3. Modificar estudiante");
            Console.WriteLine("4. Eliminar estudiante");
            Console.WriteLine("5. Ver todos los estudiantes");
            Console.WriteLine("0. Salir");
            Console.Write("Opcion: ");
            opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Estudiante e = new Estudiante();
                e.Id = contador;

                Console.Write("Ingrese el nombre del estudiante: ");
                e.Nombre = Console.ReadLine();

                Console.Write("Cual es su matricula: ");
                e.Matricula = Console.ReadLine();

                Console.Write("Cual es su cedula: ");
                e.Cedula = Console.ReadLine();

                Console.Write("Ingrese la materia: ");
                e.Materia = Console.ReadLine();

                Console.Write("Ingrese la nota: ");
                string textoNota = Console.ReadLine();
                double nota;
                if (!double.TryParse(textoNota, out nota))
                {
                    Console.WriteLine("Eso no es una nota valida.");
                }
                else
                {
                    e.Nota = nota;
                    lista.Add(e);
                    contador++;
                    Console.WriteLine("Estudiante registrado.");
                }
            }

            if (opcion == "2")
            {
                Console.Write("Buscar por nombre, cedula o matricula: ");
                string buscar = Console.ReadLine();

                bool encontro = false;
                for (int i = 0; i < lista.Count; i++)
                {
                    if (lista[i].Nombre.ToLower().Contains(buscar.ToLower()) || lista[i].Cedula == buscar || lista[i].Matricula == buscar)
                    {
                        Console.WriteLine("ID: " + lista[i].Id + " | Nombre: " + lista[i].Nombre + " | Matricula: " + lista[i].Matricula + " | Cedula: " + lista[i].Cedula + " | Materia: " + lista[i].Materia + " | Nota: " + lista[i].Nota);
                        encontro = true;
                    }
                }

                if (!encontro)
                    Console.WriteLine("No se encontro nada.");
            }

            if (opcion == "3")
            {
                Console.Write("Ingrese el ID del estudiante que desea modificar: ");
                int id;
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("ID invalido.");
                }
                else
                {
                    bool encontro = false;
                    for (int i = 0; i < lista.Count; i++)
                    {
                        if (lista[i].Id == id)
                        {
                            encontro = true;

                            Console.Write("Nuevo nombre (" + lista[i].Nombre + "): ");
                            string nombre = Console.ReadLine();
                            if (nombre != "") lista[i].Nombre = nombre;

                            Console.Write("Nueva matricula (" + lista[i].Matricula + "): ");
                            string matricula = Console.ReadLine();
                            if (matricula != "") lista[i].Matricula = matricula;

                            Console.Write("Nueva cedula (" + lista[i].Cedula + "): ");
                            string cedula = Console.ReadLine();
                            if (cedula != "") lista[i].Cedula = cedula;

                            Console.Write("Nueva materia (" + lista[i].Materia + "): ");
                            string materia = Console.ReadLine();
                            if (materia != "") lista[i].Materia = materia;

                            Console.Write("Nueva nota (" + lista[i].Nota + "): ");
                            string textoNota = Console.ReadLine();
                            double nota;
                            if (textoNota != "" && double.TryParse(textoNota, out nota))
                                lista[i].Nota = nota;

                            Console.WriteLine("Estudiante modificado.");
                            break;
                        }
                    }

                    if (!encontro)
                        Console.WriteLine("No se encontro ese estudiante.");
                }
            }

            if (opcion == "4")
            {
                Console.Write("Ingrese el ID del estudiante que desea eliminar: ");
                int id;
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("ID invalido.");
                }
                else
                {
                    bool encontro = false;
                    for (int i = 0; i < lista.Count; i++)
                    {
                        if (lista[i].Id == id)
                        {
                            encontro = true;
                            Console.Write("Seguro que desea eliminar a " + lista[i].Nombre + "? (s/n): ");
                            string conf = Console.ReadLine();
                            if (conf == "s")
                            {
                                lista.RemoveAt(i);
                                Console.WriteLine("Estudiante eliminado.");
                            }
                            else
                            {
                                Console.WriteLine("Cancelado.");
                            }
                            break;
                        }
                    }

                    if (!encontro)
                        Console.WriteLine("No se encontro ese estudiante.");
                }
            }

            if (opcion == "5")
            {
                if (lista.Count == 0)
                {
                    Console.WriteLine("No hay estudiantes registrados.");
                }
                else
                {
                    for (int i = 0; i < lista.Count; i++)
                    {
                        Console.WriteLine("ID: " + lista[i].Id + " | Nombre: " + lista[i].Nombre + " | Matricula: " + lista[i].Matricula + " | Cedula: " + lista[i].Cedula + " | Materia: " + lista[i].Materia + " | Nota: " + lista[i].Nota);
                    }
                }
            }

            if (opcion == "0")
                Console.WriteLine("Adios.");
        }
    }
}