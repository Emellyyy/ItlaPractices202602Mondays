using Homework4.Data;
using Homework4.Entities;

var dataContext = new DataContext();

Console.WriteLine("==============================");
Console.WriteLine("     Student Registry");
Console.WriteLine("==============================");

bool exit = false;

while (!exit)
{
    Console.WriteLine();
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. Show Students");
    Console.WriteLine("3. Delete Student");
    Console.WriteLine("4. Exit");

    Console.Write("Choose an option: ");

    int option = Convert.ToInt32(Console.ReadLine());

    switch (option)
    {
        case 1:

            Student student = new Student();

            Console.Write("Name: ");
            student.Name = Console.ReadLine();

            Console.Write("Last Name: ");
            student.LastName = Console.ReadLine();

            Console.Write("Email: ");
            student.Email = Console.ReadLine();

            Console.Write("Phone Number: ");
            student.PhoneNumber = Console.ReadLine();

            Console.Write("Career: ");
            student.Career = Console.ReadLine();

            dataContext.Students.Add(student);

            dataContext.SaveChanges();

            Console.WriteLine("Student saved.");

            break;


        case 2:

            var students = dataContext.Students.ToList();

            foreach (var item in students)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine($"ID: {item.Id}");
                Console.WriteLine($"Name: {item.Name} {item.LastName}");
                Console.WriteLine($"Career: {item.Career}");
            }

            break;


        case 3:

            Console.Write("Enter student ID: ");

            int id = Convert.ToInt32(Console.ReadLine());

            var studentDelete = dataContext.Students.FirstOrDefault(x => x.Id == id);

            if (studentDelete != null)
            {
                dataContext.Students.Remove(studentDelete);

                dataContext.SaveChanges();

                Console.WriteLine("Student deleted.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }

            break;


        case 4:

            exit = true;

            Console.WriteLine("Closing...");
            break;


        default:

            Console.WriteLine("Invalid option.");
            break;
    }
}
