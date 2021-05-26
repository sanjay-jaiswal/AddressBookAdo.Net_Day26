using System;
using System.Collections.Generic;

namespace AddressBook_ADODotNet
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("================= Welcome To Address Book Using ADO Dot Net =======================");

            List<AddressBookModel> contactList = new List<AddressBookModel>();

            AddressBookRepo addressBookRepo = new AddressBookRepo();
            AddressBookModel addressBookModel = new AddressBookModel();
            //addressBookRepo.AddContactsInAddressBook(addressBookModel);

            addressBookRepo.UpdateExiContactToDataBase(addressBookModel,"Sanju");


            addressBookModel.FirstName = "Sanju";
            addressBookModel.LastName = "Jaiswal";
            addressBookModel.Address = "Madgaon";
            addressBookModel.City = "Margao";
            addressBookModel.State = "Goa";
            addressBookModel.Zip = "413512";
            addressBookModel.PhoneNumber = "9975776600";
            addressBookModel.Email = "sanju@gmail.com";
            addressBookModel.AddressBookName = "Friend address book";
            addressBookModel.AddressBookType = "Friends";
            // addressBookRepo.checkConnection();
            //addressBookRepo.AddContactInAddressBook(addressBookModel);


            addressBookRepo.RetrieveFromDatabase();

            // addressBookRepo.EditContactUsingName(addressBookModel, "Sanju");
            // addressBookRepo.DeleteContactUsingFirstName("Sanju");



            AddressBookModel contact = new AddressBookModel();
            Console.WriteLine("Enter First Name");
            contact.FirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            contact.LastName = Console.ReadLine();
            Console.WriteLine("Enter Address");
            contact.Address = Console.ReadLine();
            Console.WriteLine("Enter City");
            contact.City = Console.ReadLine();
            Console.WriteLine("Enter State");
            contact.State = Console.ReadLine();
            Console.WriteLine("Enter ZipCode");
            contact.Zip = Console.ReadLine();
            
            Console.WriteLine("Enter Phone number");
            contact.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Email");
            contact.Email = Console.ReadLine();
            Console.WriteLine("Enter Address book name");
            contact.AddressBookName = Console.ReadLine();
            Console.WriteLine("Enter Address book type");
            contact.AddressBookType = Console.ReadLine();

            contactList.Add(contact);

        }
    }
}
