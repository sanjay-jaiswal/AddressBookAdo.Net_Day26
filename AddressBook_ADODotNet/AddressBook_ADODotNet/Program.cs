using System;
using System.Collections.Generic;

namespace AddressBook_ADODotNet
{
    public class Program
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
            addressBookModel.Zip = "413512";
            addressBookModel.PhoneNumber = "9975776600";
            addressBookModel.Email = "sanju@gmail.com";
            addressBookModel.AddressBookName = "Friend address book";
            addressBookModel.AddressBookType = "Friends";

            //addressBookRepo.checkConnection();
            //addressBookRepo.AddContactInAddressBook(addressBookModel);
            addressBookRepo.UpdateContactByName(addressBookModel, "Sanju");
            addressBookRepo.RetrieveFromDatabase();

            // addressBookRepo.EditContactUsingName(addressBookModel, "Sanju");
            // addressBookRepo.DeleteContactUsingFirstName("Sanju");

            addressBookRepo.AddContactsInAddressBook(addressBookModel);
            addressBookRepo.UpdateContactByName(addressBookModel, "Sachin");
            addressBookRepo.deleteContactsFromDatabaseUsingFirstName("Tushar");
            addressBookRepo.RetriveRecordsByCityOrState();
            addressBookRepo.CountByCityAndState();
            addressBookRepo.SortedRecordsAlphabeticallyByFirstName();
            addressBookRepo.FindAddressBookWithNameAndType("Sachin","Friends","Friends Book");
            addressBookRepo.CountPersonByType();

            AddressBookModel addressBookModel2 = new AddressBookModel();
            addressBookModel2.FirstName = "Rahul";
            addressBookModel2.LastName = "Tripathi";
            addressBookModel2.Address = "Jabalpur";
            addressBookModel2.City = "Bhopal";
            addressBookModel2.State = "Madhya Pradesh";
            addressBookModel2.Zip = "423344";
            addressBookModel2.PhoneNumber = "8887131570";
            addressBookModel2.Email = "rahul11@gmail.com";
            addressBookModel2.AddressBookName = "Friends book";
            addressBookModel2.AddressBookType = "Friend";

            addressBookModel2.FirstName = "Rahul";
            addressBookModel2.LastName = "Tripathi";
            addressBookModel2.Address = "Jabalpur";
            addressBookModel2.City = "Bhopal";
            addressBookModel2.State = "Madhya Pradesh";
            addressBookModel2.Zip = "423344";
            addressBookModel2.PhoneNumber = "8887131570";
            addressBookModel2.Email = "rahul11@gmail.com";
            addressBookModel2.AddressBookName = "Family book";
            addressBookModel2.AddressBookType = "Family";
            addressBookRepo.AddPersonAsFriendAndFamily(addressBookModel2);

        }
    }
}
