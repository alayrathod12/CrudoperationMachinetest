using CRUDoperationmvc.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUDoperationmvc.ProductRepository
{
    public class ProductRespository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = "Data Source=DESKTOP13\\MSSQLSERVER2019;Initial Catalog=Project;Integrated Security=True";//ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Employee details    
        public bool AddProduct(ProductModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddNewProduct", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProductName", obj.ProductName);
            

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
        //To view employee details with generic list     
        public List<ProductModel> GetAllProduct()
        {
            connection();
            List<ProductModel> ProductList = new List<ProductModel>();


            SqlCommand com = new SqlCommand("GetProduct", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                ProductList.Add(

                    new ProductModel
                    {

                        ProductID = Convert.ToInt32(dr["ProductId"]),
                        ProductName = Convert.ToString(dr["ProductName"]),
                        

                    }
                    );
            }

            return ProductList;
        }
        //To Update Employee details    
        public bool UpdateProduct(ProductModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateProduct", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProductID", obj.ProductID);
            com.Parameters.AddWithValue("@ProductName", obj.ProductName);
           
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        //To delete Employee details    
        public bool DeleteProduct(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteproById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProductId", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
    }
}
