using System;

namespace AddressBook_ADODotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("================= Welcome To Address Book Using ADO Dot Net =======================");

            AddressBookRepo addressBookRepo = new AddressBookRepo();
            addressBookRepo.checkConnection();
        }
    }
}
