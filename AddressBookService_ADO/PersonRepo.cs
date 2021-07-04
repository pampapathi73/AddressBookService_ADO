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

        public bool DeleteEmployee(PersonModel model)
        {
            try
            {
                using (this.connection)
                {

                    SqlCommand command = new SqlCommand("delete from AddressBookDB where firstname='Mohan'", this.connection);
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

        public void GetAllEmployee()
        {
            try
            {
                PersonModel personModel = new PersonModel();
                using (this.connection)
                {

                    SqlCommand cmd = new SqlCommand(@"select * from AddressBookDB where state='assam'", this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            personModel.FirstName = dr.GetString(0);
                            personModel.LastName = dr.GetString(1);
                            personModel.Address = dr.GetString(2);
                            personModel.PhoneNumber = dr.GetString(6);
                            personModel.zip = dr.GetInt32(5);
                            personModel.City = dr.GetString(3);
                            personModel.State = dr.GetString(4);
                            personModel.AddressBookName = dr.GetString(8);
                            personModel.Email = dr.GetString(7);
                            personModel.Type = dr.GetString(9);

                            System.Console.WriteLine(personModel.FirstName + " " + personModel.LastName + " " + personModel.Address + " " + personModel.City + " " + personModel.zip + " " + personModel.State + " " + personModel.PhoneNumber + " " + personModel.AddressBookName + " " + personModel.Type);
                            System.Console.WriteLine("\n");

                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");

                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}
