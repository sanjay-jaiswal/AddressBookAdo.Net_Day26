using System;

namespace AddressBook_ADODotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("================= Welcome To Address Book Using ADO Dot Net =======================");

            AddressBookRepo addressBookRepo = new AddressBookRepo();
            AddressBookModel addressBookModel = new AddressBookModel();
            addressBookModel.FirstName = "Sanju";
            addressBookModel.LastName = "Jaiswal";
            addressBookModel.Address = "Madgaon";
            addressBookModel.City = "Margao";
            addressBookModel.State = "Goa";
            addressBookModel.Zip = 413512;
            addressBookModel.PhoneNumber = 9975776600;
            addressBookModel.Email = "sanju@gmail.com";
            addressBookModel.AddressBookName = "Friend address book";
            addressBookModel.AddressBookType = "Friends";
            addressBookRepo.checkConnection();
            addressBookRepo.AddContactInAddressBook(addressBookModel);

            addressBookRepo.EditContactUsingName(addressBookModel, "Sanju");
        }
    }
}
