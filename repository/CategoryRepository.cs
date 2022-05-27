using CRUDoperationmvc.Models.Models_cat;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUDoperationmvc.ProductRepository.Category_Repository
{
    public class CategoryRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = "Data Source=DESKTOP13\\MSSQLSERVER2019;Initial Catalog=Project;Integrated Security=True";//ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Employee details    
        public bool AddCategory(CategoryModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddCategory", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CategoryID", obj.CategoryID);
            com.Parameters.AddWithValue("@CategoryName", obj.CategoryName);

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
        public List<CategoryModel> GetAllCategory()
        {
            connection();
            List<CategoryModel> ProductList = new List<CategoryModel>();


            SqlCommand com = new SqlCommand("GetCategory", con);
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

                    new CategoryModel
                    {

                       
                        CategoryID = Convert.ToInt32(dr["CategoryID"]),
                        CategoryName = Convert.ToString(dr["CategoryName"])

                    }
                    );
            }

            return ProductList;
        }
        //To Update Employee details    
        public bool UpdateCategory(CategoryModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateCategory", con);

            com.CommandType = CommandType.StoredProcedure;
           
            com.Parameters.AddWithValue("@CategoryID", obj.CategoryID);
            com.Parameters.AddWithValue("@CategoryName", obj.CategoryName);
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
        public bool DeleteCategory(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteCategory", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CategoryId", Id);

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

    
