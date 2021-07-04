using System;

namespace AddressBookService_ADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBook Service");
            PersonRepo repo = new PersonRepo();
            repo.GetSize();
            Console.ReadKey();
        }
    }
}
