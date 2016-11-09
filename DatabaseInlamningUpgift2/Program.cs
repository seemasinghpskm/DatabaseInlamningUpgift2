using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseInlamningUpgift2
{
    class Program
    {
        static void Main(string[] args)
        {
            UpdateProductPrice();
            UpdateContactNameCustomers();
            InsertCustomer();
            InsertProduct();
        }
        private static void UpdateContactNameCustomers()
        {
            string str = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NORTHWND;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection cn = new SqlConnection(str))
            {


                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE[dbo].[Customers]
                                    SET [ContactName] = @ContactName
                                    WHERE [CustomerID] = @CustomerID";

                cmd.Parameters.AddWithValue("@ContactName", "Divya Bharati");
                cmd.Parameters.AddWithValue("@CustomerID", "ANATR");
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        private static void UpdateProductPrice()
        {
            string str = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NORTHWND;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection cn = new SqlConnection(str))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdateProductPrice";
                cmd.Parameters.AddWithValue("@UnitPrice", 20.00);
                cmd.Parameters.AddWithValue("@ProductID", 1);

                cmd.ExecuteNonQuery();


            }
        }

        static void InsertCustomer()
        {
            string str = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NORTHWND;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection cn = new SqlConnection(str);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "InsertCustomer";
            cmd.Parameters.AddWithValue("@CustomerId", 1);
            cmd.Parameters.AddWithValue("@CompanyName", "ACS");
            cmd.Parameters.AddWithValue("@ContactName", "Nandu Dsousa");
            cmd.Parameters.AddWithValue("@ContactTitle", "Security Person");
            cmd.Parameters.AddWithValue("@Address", "Whitefield");
            cmd.Parameters.AddWithValue("@City", "Bangalore");
            cmd.Parameters.AddWithValue("@Region", "Karnataka");
            cmd.Parameters.AddWithValue("@PostalCode", "111111111");
            cmd.Parameters.AddWithValue("@Country", "India");
            cmd.Parameters.AddWithValue("@Phone", "987654321");
            cmd.Parameters.AddWithValue("@Fax", "12121212");

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        static void InsertProduct()
        {
            string str = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NORTHWND;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection cn = new SqlConnection(str);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "InsertProduct";
            cmd.Parameters.AddWithValue("@ProductName", "Bread");
            cmd.Parameters.AddWithValue("@SupplierID", 1);
            cmd.Parameters.AddWithValue("@CategoryID", 1);
            cmd.Parameters.AddWithValue("@QuantityPerUnit", "1");
            cmd.Parameters.AddWithValue("@UnitPrice", 100);
            cmd.Parameters.AddWithValue("@UnitsInStock", 1);
            cmd.Parameters.AddWithValue("@UnitsOnOrder", 1);
            cmd.Parameters.AddWithValue("@ReorderLevel", 1);
            cmd.Parameters.AddWithValue("@Discontinued", 1);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
