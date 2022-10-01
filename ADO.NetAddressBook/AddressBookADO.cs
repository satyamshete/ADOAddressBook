using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NetAddressBook
{
    internal class AddressBookADO
    {
        public static string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=AddressBookService;";
        Contact person = new Contact();

        public void GetContactDetails()
        {

            SqlConnection sqlConnect = new SqlConnection(connectionString);
            try
            {
                using (sqlConnect)
                {
                    sqlConnect.Open();

                    SqlCommand com = new SqlCommand("GetContactDetails", sqlConnect);
                    //query, sqlconnection
                    com.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = com.ExecuteReader();

                    if (dr.HasRows)
                    {
                        Console.WriteLine("\n Person contacts Contents : \n");
                        Console.WriteLine();
                        while (dr.Read())
                        {
                            person.FirstName = dr.GetString(0);
                            person.LastName = dr.GetString(1);
                            person.Address = dr.GetString(2);
                            person.City = dr.GetString(3);
                            person.State = dr.GetString(4);
                            person.ZipCode = dr.GetInt32(5);
                            person.PhoneNumber = dr.GetInt64(6);
                            person.EmailId = dr.GetString(7);
                            person.Type = dr.GetString(8);


                            Console.WriteLine(" {0} {1} {2} {3} {4} {5} {6} {7} {8}", person.FirstName, person.LastName, person.Address, person.City, person.State, person.ZipCode, person.PhoneNumber, person.EmailId, person.Type);
                        }
                    }
                    dr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            finally
            {
                sqlConnect.Close();
            }
        }
    }
}
