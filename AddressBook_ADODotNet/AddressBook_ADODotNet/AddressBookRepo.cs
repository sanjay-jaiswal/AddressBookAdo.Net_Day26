using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AddressBook_ADODotNet
{
    public class AddressBookRepo
    {
        public static string connectionString = @"Data Source=desktop-049svlj;Initial Catalog=AddressBookADO;Integrated Security=True";
        //Data Source = desktop - 049svlj;Initial Catalog = AddressBookADODotNet; Integrated Security = True
        //SqlConnection connection;
        List<AddressBookModel> contacList = new List<AddressBookModel>();

        public void EtablishConnection()
        {
            SqlConnection sqConnection = new SqlConnection(connectionString);
            try
            {
                using (sqConnection)
                {
                    sqConnection.Open();
                    Console.WriteLine("Connection is established!!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                sqConnection.Close();
            }
        }

        public bool RetrieveFromDatabase()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    //Fetched data table using stored procedure.
                    SqlCommand command = new SqlCommand("spRetriveAllRecords",connection);

                    connection.Open();

                    ///Using sql data reader for fetch the records.
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            AddressBookModel c = new AddressBookModel();
                            c.FirstName = reader.GetString(1);
                            c.LastName = reader.GetString(2);
                            c.Address = reader.GetString(3);
                            c.City = reader.GetString(4);
                            c.State = reader.GetString(5);

                            c.Zip = reader.GetString(6);
                            c.PhoneNumber = reader.GetString(7);
                            c.Email = reader.GetString(8);
                            c.AddressBookName = reader.GetString(9);
                            c.AddressBookType = reader.GetString(10);

                            contacList.Add(c);

                            Console.WriteLine(c.FirstName + "  " + c.LastName + "  " + c.Address + "  " + c.City + "  " +
                                c.State + "  " + c.Zip + "  " + c.PhoneNumber + "  " + c.Email + "  " + c.AddressBookName+ "  "+ c.AddressBookType);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data in table!!");
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        /// <summary>
        /// Adding records into database. 
        /// </summary>
        /// <param name="addressBookModel"></param>
        /// <returns></returns>
        public bool AddContactsInAddressBook(AddressBookModel addressBookModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("StoredProcedure_AddressBook",connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

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
                    connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    connection.Close();
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
                connection.Close();
            }
        }

        public bool UpdateContactByName(AddressBookModel addressBookModel, string firstName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = @"update AddressBookDetails set LastName=@LastName,Address=@Address,City=@City,
                    State=@State,Zip=@Zip,PhoneNumber=@PhoneNumber,Email=@Email,AddressBookName=@AddressBookName,
                    AddressBookType=@AddressBookType  where FirstName=@FirstName";
                    SqlCommand cmd = new SqlCommand(query,connection);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", addressBookModel.LastName);
                    cmd.Parameters.AddWithValue("@Address", addressBookModel.Address);
                    cmd.Parameters.AddWithValue("@City", addressBookModel.City);
                    cmd.Parameters.AddWithValue("@State", addressBookModel.State);
                    cmd.Parameters.AddWithValue("@Zip", addressBookModel.Zip);
                    cmd.Parameters.AddWithValue("@PhoneNumber", addressBookModel.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", addressBookModel.Email);
                    cmd.Parameters.AddWithValue("@AddressBookName", addressBookModel.AddressBookName);
                    cmd.Parameters.AddWithValue("@AddressBookType", addressBookModel.AddressBookType);
                    connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    connection.Close();
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
                connection.Close();
            }
        }

        public bool deleteContactsFromDatabaseUsingFirstName(string FirstName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("spCRUDoperations", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    connection.Close();
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
                connection.Close();
            }
        }

        public void RetriveRecordsByCityOrState()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                AddressBookModel addressBookModel = new AddressBookModel();
                using (connection)
                {
                    string query = @"select * from AddressBookDetails where city='Margao' Or state='Goa';";
                    SqlCommand cmd = new SqlCommand(query,connection);
                    connection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            addressBookModel.FirstName = sqlDataReader.GetString(0); ;
                            addressBookModel.LastName = sqlDataReader.GetString(1);
                            addressBookModel.Address = sqlDataReader.GetString(2);
                            addressBookModel.City = sqlDataReader.GetString(3);
                            addressBookModel.State = sqlDataReader.GetString(4);
                            addressBookModel.Zip = sqlDataReader.GetString(5);
                            addressBookModel.PhoneNumber = sqlDataReader.GetString(6);
                            addressBookModel.Email = sqlDataReader.GetString(7);
                            addressBookModel.AddressBookName = sqlDataReader.GetString(8);
                            addressBookModel.AddressBookType = sqlDataReader.GetString(9);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", addressBookModel.FirstName, addressBookModel.LastName, addressBookModel.Address, addressBookModel.City, addressBookModel.State, addressBookModel.Zip, addressBookModel.PhoneNumber, addressBookModel.Email, addressBookModel.AddressBookName, addressBookModel.AddressBookType);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is no data.");
                    }
                    sqlDataReader.Close();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void CountByCityAndState()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                AddressBookModel addressBookModel = new AddressBookModel();
                using (connection)
                {
                    using (SqlCommand command = new SqlCommand(
                        @"select City,COUNT(City)from AddressBookDetails group by City;
                        select State, COUNT(State)from AddressBookDetails group by State; ", connection))
                    {
                        connection.Open();
                        using (SqlDataReader sqlDataReader = command.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                addressBookModel.City = sqlDataReader.GetString(0);
                                int countCIty = sqlDataReader.GetInt32(1);
                                Console.WriteLine("{0},{1}", addressBookModel.City, countCIty);
                                Console.WriteLine("\n");
                            }
                            if (sqlDataReader.NextResult())
                            {
                                while (sqlDataReader.Read())
                                {
                                    addressBookModel.State = sqlDataReader.GetString(0);
                                    int stateCount = sqlDataReader.GetInt32(1);
                                    Console.WriteLine("{0},{1}", addressBookModel.State, stateCount);
                                    Console.WriteLine("\n");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void SortedRecordsAlphabeticallyByFirstName()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                AddressBookModel addressBookModel = new AddressBookModel();
                using (connection)
                {
                    string query = @"select * from AddressBookDetails where City='Margao' order by FirstName;";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            addressBookModel.FirstName = sqlDataReader.GetString(0); ;
                            addressBookModel.LastName = sqlDataReader.GetString(1);
                            addressBookModel.Address = sqlDataReader.GetString(2);
                            addressBookModel.City = sqlDataReader.GetString(3);
                            addressBookModel.State = sqlDataReader.GetString(4);
                            addressBookModel.Zip = sqlDataReader.GetString(5);
                            addressBookModel.PhoneNumber = sqlDataReader.GetString(6);
                            addressBookModel.Email = sqlDataReader.GetString(7);
                            addressBookModel.AddressBookName = sqlDataReader.GetString(8);
                            addressBookModel.AddressBookType = sqlDataReader.GetString(9);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", addressBookModel.FirstName, addressBookModel.LastName, addressBookModel.Address, addressBookModel.City, addressBookModel.State, addressBookModel.Zip, addressBookModel.PhoneNumber, addressBookModel.Email, addressBookModel.AddressBookName, addressBookModel.AddressBookType);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public bool FindAddressBookWithNameAndType(string firstName, string addressType, string addressName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = @"update AddressBookDetails set AddressBookName=@AddressBookName , AddressBookType=@AddressBookType where FirstName=@FirstName;";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@AddressBookType", addressType);
                    cmd.Parameters.AddWithValue("@AddressBookName", addressName);
                    connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    connection.Close();
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
                connection.Close();
            }
        }

        public void CountPersonByType()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                AddressBookModel addressBookModel = new AddressBookModel();
                using (connection)
                {
                    using (SqlCommand command = new SqlCommand(
                        @"select count(AddressBookDetails) as 'number_of_contacts' from AddressBookDetails where AddressBookType='Friends';
                        select count(AddressBookDetails) as 'number_of_contacts' from AddressBookDetails where AddressBookType='Family';", connection))
                    {
                        connection.Open();
                        using (SqlDataReader sqlDataReader = command.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                var count = sqlDataReader.GetInt32(0);
                                Console.WriteLine("Total number of person belonging to address book type friend are :  {0}", count);
                                Console.WriteLine("\n");
                            }
                            if (sqlDataReader.NextResult())
                            {
                                while (sqlDataReader.Read())
                                {
                                    var count = sqlDataReader.GetInt32(0);
                                    Console.WriteLine("Total number of person belonging to adress book type family are :  {0}", count);
                                    Console.WriteLine("\n");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
