using System;
// Calcula
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. Calculadora");
            Console.WriteLine("2. Aprobo el estudiante?");
            Console.WriteLine("0. Salir");
            Console.Write("Opcion: ");
            string opcion = Console.ReadLine();

            if (opcion == "0")
            {
                Console.WriteLine("Adios");
                break;
            }

            if (opcion == "1")
            {
                Console.Write("Dame el primer numero: ");
                double a = double.Parse(Console.ReadLine());

                Console.Write("Dame el segundo numero: ");
                double b = double.Parse(Console.ReadLine());

                Console.WriteLine("\nLa suma total es: " + (a + b));
                Console.WriteLine("La resta total es: " + (a - b));
                Console.WriteLine("La multiplicacion total es: " + (a * b));

                if (b == 0)
                    Console.WriteLine("La division no se puede, no se divide entre cero");
                else
                    Console.WriteLine("La division total es: " + (a / b));
            }

            if (opcion == "2")
            {
                Console.Write("Nombre del estudiante: ");
                string nombre = Console.ReadLine();

                Console.Write("Nota del estudiante: ");
                double nota = double.Parse(Console.ReadLine());

                if (nota >= 60)
                    Console.WriteLine(nombre + " aprobo con " + nota);
                else
                    Console.WriteLine(nombre + " reprobo con " + nota);
            }
        }
    }
}
