using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookService_ADO
{
    class PersonRepo
    {
        public static string connectionString = @"Data Source=DESKTOP-F351DOC;Initial Catalog=Address_Book_ServiceDB;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        public bool AddEmployee(PersonModel model)
        {
            try
            {
                using (this.connection)
                {

                    SqlCommand command = new SqlCommand("update AddressBookDB set city='dib' where firstname='Mukti'", this.connection);
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@zip", model.zip);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@AddressBookName", model.AddressBookName);
                    command.Parameters.AddWithValue("@Type", model.Type);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
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
            finally
            {
                this.connection.Close();
            }
            return false;
        }
    }
}
