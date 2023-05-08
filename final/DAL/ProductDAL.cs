using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using final.Models;
using System.Diagnostics;
using System.Drawing;
using System.Web.Mvc;

namespace final.DAL
{
    public class ProductDAL
    {
        string conString = ConfigurationManager.ConnectionStrings["Database_cs"].ToString();
        public List<Product> GetAllProducts()
        {
            List<Product> productList = new List<Product>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetAllProducts1";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtProducts = new DataTable();
                connection.Open();
                sqlDA.Fill(dtProducts);
                connection.Close(); 

                foreach (DataRow dr in dtProducts.Rows)
                {
                    productList.Add(new Product
                    {
                        product_code = Convert.ToInt32(dr["product_code"]),
                        product_name = Convert.ToString(dr["product_name"]),
                        product_cost = Convert.ToInt32(dr["product_cost"]),
                        product_expiry = Convert.ToDateTime(dr["product_expiry"]),
                        product_type = Convert.ToString(dr["product_type"]),
                        product_color = Convert.ToString(dr["product_color"]),
                        product_weight = Convert.ToInt32(dr["product_weight"]),
                        product_final_price = Convert.ToInt32(dr["product_final_price"])
                    });


                }
            }
            return productList;
        }


        //Inserting Products
         public bool InsertProduct(Product product)
        {
            int id = 0;
            using(SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_InsertProducts",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", product.product_code);
                command.Parameters.AddWithValue("@ProductName", product.product_name);
                command.Parameters.AddWithValue("@Price", product.product_cost);
                command.Parameters.AddWithValue("@Expiry", product.product_expiry);
                command.Parameters.AddWithValue("@Type", product.product_type);
                command.Parameters.AddWithValue("@Color", product.product_color);
                command.Parameters.AddWithValue("@Weight", product.product_weight);
                command.Parameters.AddWithValue("@FinalPrice", product.product_final_price);
                connection.Open();
                id = command.ExecuteNonQuery();
                connection.Close();

            }
            if (id > 0)
            {
                return true;
            }
            else { 
                return false; 
            }

        }

        //get product by id
        public List<Product> GetProductByID(int ProductID)
        {
            List<Product> productList = new List<Product>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetProductByID";
                command.Parameters.AddWithValue("@ProductID", ProductID);
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtProducts = new DataTable();
                connection.Open();
                sqlDA.Fill(dtProducts);
                connection.Close();

                foreach (DataRow dr in dtProducts.Rows)
                {
                    productList.Add(new Product
                    {
                        product_code = Convert.ToInt32(dr["product_code"]),
                        product_name = Convert.ToString(dr["product_name"]),
                        product_cost = Convert.ToInt32(dr["product_cost"]),
                        product_expiry = Convert.ToDateTime(dr["product_expiry"]),
                        product_type = Convert.ToString(dr["product_type"]),
                        product_color = Convert.ToString(dr["product_color"]),
                        product_weight = Convert.ToInt32(dr["product_weight"]),
                        product_final_price = Convert.ToInt32(dr["product_final_price"])
                    });


                }
            }
            return productList;
        }

        //update products
        public bool UpdateProduct(Product product)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_UpdateProducts", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", product.product_code);
                command.Parameters.AddWithValue("@ProductName", product.product_name);
                command.Parameters.AddWithValue("@Price", product.product_cost);
                command.Parameters.AddWithValue("@Expiry", product.product_expiry);
                command.Parameters.AddWithValue("@Type", product.product_type);
                command.Parameters.AddWithValue("@Color", product.product_color);
                command.Parameters.AddWithValue("@Weight", product.product_weight);
                command.Parameters.AddWithValue("@FinalPrice", product.product_final_price);
                connection.Open();
                i = command.ExecuteNonQuery();
                connection.Close();

            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //delete product
        public string DeleteProduct(int productid)
        {
            string result = "";
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_deleteproduct", connection);
                command.CommandType= CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductID", productid);
                command.Parameters.Add("@OutputMessage", SqlDbType.VarChar,50).Direction = ParameterDirection.Output;
                connection.Open();
                command.ExecuteNonQuery();  
                result = command.Parameters["@OutputMessage"].Value.ToString();
                connection.Close();
            }
            return result;
        }

        public string Login(Account acc)
        {
           
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_CheckLogin";
                    command.Parameters.AddWithValue("@username", acc.Name);
                    command.Parameters.AddWithValue("@password", acc.Password);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    connection.Close();

                    if (result != null && result.ToString() == "Success")
                    {
                        return "Success";
                    }
                    else
                    {
                        return "Failed";
                    }
                }
            
        }
    }
}