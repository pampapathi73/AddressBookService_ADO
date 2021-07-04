using System;

namespace AddressBookService_ADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBook Service");
            PersonRepo repo = new PersonRepo();
            PersonModel employee = new PersonModel();
            employee.FirstName = "Mukti";
            employee.LastName = "hk";
            employee.Address = "House no 22";
            employee.PhoneNumber = "6302907678";
            employee.zip = 894523;
            employee.City = "Tsk";
            employee.State = "Tripura";
            employee.Email = "muktihk@gmail.com";
            employee.AddressBookName = "book4";
            employee.Type = "Family";

            if (repo.AddEmployee(employee))
                Console.WriteLine("Records added successfully");
            Console.ReadKey();
        }
    }
    
}
