using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AddressBook_ADO.NET
{
    public class AddressBookData
    {
        public void Create_Database()
        {
            try
            {
                SqlConnection Connection = new SqlConnection(@"Data Source=BridgeLabz; Initial Catalog =master; Integrated Security = True;");
                Connection.Open();
                SqlCommand command = new SqlCommand("Create database AddressbookADO;", Connection);
                command.ExecuteNonQuery();
                Console.WriteLine("AddressbookService Database created successfully!");
                Connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured while creating database:" + e.Message + "\t");
            }
        }
        public void CreateTables()
        {
            try
            {
                SqlConnection Connection = new SqlConnection(@"Data Source=BridgeLabz; Initial Catalog =AddressbookADO; Integrated Security = True;");
                Connection.Open();
                SqlCommand command = new SqlCommand("Create table AddressBook(id int identity(1,1)primary key,FirstName varchar(200),LastName varchar(200),Address varchar(200), City varchar(200), State varchar(200), Zip varchar(200), PhoneNumber varchar(50), Email varchar(200)); ", Connection);
                command.ExecuteNonQuery();
                Console.WriteLine("AddressBook table has been  created successfully!");
                Connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception occured while creating table:" + e.Message + "\t");
            }
        }
        public const string ConnFile = @"Data Source=BridgeLabz; Initial Catalog =AddressbookADO; Integrated Security = True;";
        SqlConnection connection = new SqlConnection(ConnFile);
        /// <summary>
        /// Method to insert data in database
        /// </summary>
        /// <param name="model"></param>
        public bool AddContact(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("SpAddressBook", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@Address", model.Address);
                    cmd.Parameters.AddWithValue("@City", model.City);
                    cmd.Parameters.AddWithValue("@State", model.State);
                    cmd.Parameters.AddWithValue("@Zip", model.Zip);
                    cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", model.Email);


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
                Console.WriteLine(e.Message);
            }

            return false;
        }


        public void GetAllContact()
        {
            try
            {
                AddressBookModel addressmodel = new AddressBookModel();
                using (this.connection)
                {
                    string Query = @"Select * from AddressBook";
                    SqlCommand cmd = new SqlCommand(Query, this.connection);
                    this.connection.Open();
                    SqlDataReader datareader = cmd.ExecuteReader();
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {
                            addressmodel.AddressBookId = datareader.GetInt32(0);
                            addressmodel.FirstName = datareader.GetString(1);
                            addressmodel.LastName = datareader.GetString(2);
                            addressmodel.Address = datareader.GetString(3);
                            addressmodel.City = datareader.GetString(4);
                            addressmodel.State = datareader.GetString(5);
                            addressmodel.Zip = datareader.GetString(6);
                            addressmodel.PhoneNumber = datareader.GetString(7);
                            addressmodel.Email = datareader.GetString(8);

                            Console.WriteLine(addressmodel.FirstName + " " +
                                addressmodel.LastName + " " +
                                addressmodel.Address + " " +
                                addressmodel.City + " " +
                                addressmodel.State + " " +
                                addressmodel.Zip + " " +
                                addressmodel.PhoneNumber + " " +
                                addressmodel.Email + " "

                                );
                            Console.WriteLine();

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public string updateEmployeeDetails()
        {
            AddressBookModel addressmodel = new AddressBookModel();

            SqlConnection Connection = new SqlConnection(@"Data Source=BridgeLabz; Initial Catalog =AddressBookADO; Integrated Security = True;");
            connection.Open();
            SqlCommand command = new SqlCommand("update AddressBook set Address='Delhi' where FirstName='Ramesh'", connection);

            int effectedRow = command.ExecuteNonQuery();
            if (effectedRow == 1)
            {
                string query = @"Select Address from AddressBook where FirstName='Rakesh';";
                SqlCommand cmd = new SqlCommand(query, connection);
                object res = cmd.ExecuteScalar();
                connection.Close();
                addressmodel.Address = (string)res;
            }
            connection.Close();
            return (addressmodel.Address);
        }
        public void deleteEmployeeDetails()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=BridgeLabz; Initial Catalog =AddressBookForADO; Integrated Security = True; TrustServerCertificate=True;");
            connection.Open();
            string query = @"DELETE FROM AddressBook where FirstName = 'Prajna'";
            SqlCommand cmd = new SqlCommand(query, connection);
            object res = cmd.ExecuteScalar();
            connection.Close();

        }
        public void GetAllContactByCity()
        {
            try
            {
                AddressBookModel addressmodel = new AddressBookModel();
                SqlConnection Connection = new SqlConnection(@"Data Source=BridgeLabz; Initial Catalog =AddressBookADO; Integrated Security = True;");
                using (this.connection)
                {
                    string Query = @"Select * from AddressBook where City='Bdk';";
                    SqlCommand cmd = new SqlCommand(Query, this.connection);
                    this.connection.Open();
                    SqlDataReader datareader = cmd.ExecuteReader();
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {
                            addressmodel.ID = datareader.GetInt32(0);
                            addressmodel.FirstName = datareader.GetString(1);
                            addressmodel.LastName = datareader.GetString(2);
                            addressmodel.Address = datareader.GetString(3);
                            addressmodel.City = datareader.GetString(4);
                            addressmodel.State = datareader.GetString(5);
                            addressmodel.Zip = datareader.GetString(6);
                            addressmodel.PhoneNumber = datareader.GetString(7);
                            addressmodel.Email = datareader.GetString(8);

                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", addressmodel.ID, addressmodel.FirstName, addressmodel.LastName, addressmodel.Address, addressmodel.City, addressmodel.State, addressmodel.Zip, addressmodel.PhoneNumber, addressmodel.Email);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void GetAllContactByState()
        {
            try
            {
                AddressBookModel addressmodel = new AddressBookModel();
                SqlConnection Connection = new SqlConnection(@"Data Source=BridgeLabz; Initial Catalog =AddressBookForADO; Integrated Security = True;");
                using (this.connection)
                {
                    string Query = @"Select * from AddressBook where State='Odisha';";
                    SqlCommand cmd = new SqlCommand(Query, this.connection);
                    this.connection.Open();
                    SqlDataReader datareader = cmd.ExecuteReader();
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {
                            addressmodel.ID = datareader.GetInt32(0);
                            addressmodel.FirstName = datareader.GetString(1);
                            addressmodel.LastName = datareader.GetString(2);
                            addressmodel.Address = datareader.GetString(3);
                            addressmodel.City = datareader.GetString(4);
                            addressmodel.State = datareader.GetString(5);
                            addressmodel.Zip = datareader.GetString(6);
                            addressmodel.PhoneNumber = datareader.GetString(7);
                            addressmodel.Email = datareader.GetString(8);

                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", addressmodel.ID, addressmodel.FirstName, addressmodel.LastName, addressmodel.Address, addressmodel.City, addressmodel.State, addressmodel.Zip, addressmodel.PhoneNumber, addressmodel.Email);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public int CountOfEmployeeDetailsByCity()
        {
            int count;
            SqlConnection Connection = new SqlConnection(@"Data Source=BridgeLabz; Initial Catalog =AddressBookForADO; Integrated Security = True;");
            connection.Open();
            string query = @"Select count(*) from AddressBook where City='Bdk';";
            SqlCommand command = new SqlCommand(query, connection);
            object res = command.ExecuteScalar();
            connection.Close();
            int Count = (int)res;
            return Count;
        }
        public int CountOfEmployeeDetailsByState()
        {
            int count;
            SqlConnection Connection = new SqlConnection(@"Data Source=BridgeLabz; Initial Catalog =AddressBookForADO; Integrated Security = True;");
            connection.Open();
            string query = @"Select count(*) from AddressBook where State='Odisha';";
            SqlCommand command = new SqlCommand(query, connection);
            object res = command.ExecuteScalar();
            connection.Close();
            int Count = (int)res;
            return Count;
        }
    }
}
   