using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2804___AppConfig_And_Entity_Framework
{
    class Program
    {
        static void Main(string[] args)
        {

            //Connection To DB With AppConfig ConnectionStrings(Connect To Manageorders DB).

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ManageOrdersDBLocal"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * From Customers", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            Console.WriteLine($"\nUserName: {reader["UserName"]}.\nPassword: {reader["Password"]}.\n");
                        }
                    }
                }
            }


            //Entity Framwork Connect To ManageOrders DB With Customers Table Take The Value By 4 Ways.

            using (ManageOrdersEntities ManageEF = new ManageOrdersEntities())
            {
                //1. Query Syntax With List Of Customers.
                List<Customer> customersList1 = (from c in ManageEF.Customers
                                                 select c).ToList();
            
                //2. Query Syntax With Var.
                var customersList2 = (from c in ManageEF.Customers
                                      select c).ToList();


                //3. Method Syntax With List Of Customers.
                List<Customer> customersList3 = ManageEF.Customers.ToList();

                //4. Method Syntax With Var.
                var customersList4 = ManageEF.Customers.ToList();
            }
        }
    }
}

