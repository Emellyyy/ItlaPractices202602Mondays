using PatientRegistry.Data;
using PatientRegistry.Entities;

var dataContext = new DataContext();

Console.WriteLine("==============================");
Console.WriteLine("      Patient Registry");
Console.WriteLine("==============================");

bool exit = false;

while (!exit)
{
    try
    {
        Console.WriteLine();
        Console.WriteLine("1. Add Patient");
        Console.WriteLine("2. Show Patients");
        Console.WriteLine("3. Search Patient");
        Console.WriteLine("4. Delete Patient");
        Console.WriteLine("5. Exit");

        Console.Write("Choose an option: ");

        int option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:

                Patient patient = new Patient();

                Console.Write("Name: ");
                patient.Name = Console.ReadLine();

                Console.Write("Last Name: ");
                patient.LastName = Console.ReadLine();

                Console.Write("Age: ");
                patient.Age = Convert.ToInt32(Console.ReadLine());

                Console.Write("Gender: ");
                patient.Gender = Console.ReadLine();

                Console.Write("Phone Number: ");
                patient.PhoneNumber = Console.ReadLine();

                Console.Write("Address: ");
                patient.Address = Console.ReadLine();

                Console.Write("Medical Condition: ");
                patient.MedicalCondition = Console.ReadLine();

                dataContext.Patients.Add(patient);

                dataContext.SaveChanges();

                Console.WriteLine("Patient saved successfully.");

                break;


            case 2:

                var patients = dataContext.Patients.ToList();

                Console.WriteLine();
                Console.WriteLine("----- Patient List -----");

                foreach (var item in patients)
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine($"ID: {item.Id}");
                    Console.WriteLine($"Name: {item.Name} {item.LastName}");
                    Console.WriteLine($"Age: {item.Age}");
                    Console.WriteLine($"Gender: {item.Gender}");
                    Console.WriteLine($"Phone: {item.PhoneNumber}");
                    Console.WriteLine($"Condition: {item.MedicalCondition}");
                }

                break;


            case 3:

                Console.Write("Enter patient ID: ");

                int searchId = Convert.ToInt32(Console.ReadLine());

                var patientSearch = dataContext.Patients
                    .FirstOrDefault(x => x.Id == searchId);

                if (patientSearch != null)
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine($"Name: {patientSearch.Name} {patientSearch.LastName}");
                    Console.WriteLine($"Age: {patientSearch.Age}");
                    Console.WriteLine($"Condition: {patientSearch.MedicalCondition}");
                }
                else
                {
                    Console.WriteLine("Patient not found.");
                }

                break;


            case 4:

                Console.Write("Enter patient ID to delete: ");

                int deleteId = Convert.ToInt32(Console.ReadLine());

                var patientDelete = dataContext.Patients
                    .FirstOrDefault(x => x.Id == deleteId);

                if (patientDelete != null)
                {
                    dataContext.Patients.Remove(patientDelete);

                    dataContext.SaveChanges();

                    Console.WriteLine("Patient deleted.");
                }
                else
                {
                    Console.WriteLine("Patient not found.");
                }

                break;


            case 5:

                exit = true;

                Console.WriteLine("Closing program...");
                break;


            default:

                Console.WriteLine("Invalid option.");
                break;
        }
    }
    catch (Exception error)
    {
        Console.WriteLine("An error occurred:");
        Console.WriteLine(error.Message);
    }
}