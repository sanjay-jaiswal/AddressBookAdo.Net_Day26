﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AddressBook_ADODotNet
{
    class AddressBookRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookADODotNet;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public void checkConnection()
        {
            try
            {
                this.connection.Open();
                Console.WriteLine("Connection Established!!");
                this.connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addressBookModel"></param>
        /// <returns></returns>
        public bool AddContactInAddressBook(AddressBookModel addressBookModel)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("SpAddAddressBookDetails", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", addressBookModel.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", addressBookModel.LastName);
                    cmd.Parameters.AddWithValue("@Address", addressBookModel.Address);
                    cmd.Parameters.AddWithValue("@City", addressBookModel.City);
                    cmd.Parameters.AddWithValue("@State", addressBookModel.State);
                    cmd.Parameters.AddWithValue("@Zip", addressBookModel.Zip);
                    cmd.Parameters.AddWithValue("@PhoneNumber", addressBookModel.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", addressBookModel.Email);
                    cmd.Parameters.AddWithValue("@AddressBookName", addressBookModel.AddressBookName);
                    cmd.Parameters.AddWithValue("@AddressBookType", addressBookModel.AddressBookType);
                    this.connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
