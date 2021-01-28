using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using CShap_MVC_VuDoan.Models;

namespace CShap_MVC_VuDoan.DAO
{
    public class BlogsDAO
    {
        private const int SEARCH = 1;
        private const int INSERT = 2;
        private const int UPDATE = 3;
        private const int DELETE = 4;
        private const int LIST = 5;
        private const int SELECT_DATA = 6;

        public string InsertData(Blogs blog)
        {
            SqlConnection con = null;
            string result = "";

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_Blogs_2", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TITLE", blog.Title);
                cmd.Parameters.AddWithValue("@DESCRIPTION_SHORT", blog.DescriptionShort);
                cmd.Parameters.AddWithValue("@DETAIL", blog.Detail);
                cmd.Parameters.AddWithValue("@IMAGE", blog.Image);
                cmd.Parameters.AddWithValue("@CATEGORY", blog.Category);
                cmd.Parameters.AddWithValue("@LOCATION", blog.Locations);
                cmd.Parameters.AddWithValue("@PUBLICS", blog.Publics);
                cmd.Parameters.AddWithValue("@QUERY", INSERT);
                con.Open();
                result = cmd.ExecuteScalar().ToString();

                return result;
            }
            catch (Exception ex)
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        public string UpdateData(Blogs blog)
        {
            SqlConnection con = null;
            string result = "";

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_Blogs_2", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TITLE", blog.Title);
                cmd.Parameters.AddWithValue("@Description_Short", blog.DescriptionShort);
                cmd.Parameters.AddWithValue("@Detail", blog.Detail);
                cmd.Parameters.AddWithValue("@Image", blog.Image);
                cmd.Parameters.AddWithValue("@Category", blog.Category);
                cmd.Parameters.AddWithValue("@Location", blog.Locations);
                cmd.Parameters.AddWithValue("@Public", blog.Publics);
                cmd.Parameters.AddWithValue("@Date_Public", blog.DatePublic);
                cmd.Parameters.AddWithValue("@ID", blog.Id);
                cmd.Parameters.AddWithValue("@Query", UPDATE);
                con.Open();
                result = cmd.ExecuteScalar().ToString();

                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        public int DeleteData(String Id)
        {
            SqlConnection con = null;
            int result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_Blogs_2", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", Id);
                cmd.Parameters.AddWithValue("@Query", DELETE);
                con.Open();
                result = cmd.ExecuteNonQuery();

                return result;
            }
            catch
            {
                return result = 0;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Blogs> SearchData(string titleInput)
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<Blogs> custlist = null;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_Blogs_2", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TITLE_INPUT", titleInput);
                cmd.Parameters.AddWithValue("@Query", SEARCH);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                custlist = new List<Blogs>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Blogs blogs = new Blogs();
                    blogs.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                    blogs.Title = ds.Tables[0].Rows[i]["TITLE"].ToString();
                    blogs.DescriptionShort = ds.Tables[0].Rows[i]["DESCRIPTION_SHORT"].ToString();
                    blogs.Detail = ds.Tables[0].Rows[i]["DETAIL"].ToString();
                    blogs.Category = ds.Tables[0].Rows[i]["CATEGORY"].ToString();
                    blogs.Locations = ds.Tables[0].Rows[i]["LOCATIONS"].ToString();
                    blogs.Publics = ds.Tables[0].Rows[i]["PUBLICS"].ToString();
                    blogs.DatePublic = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATE_PUBLIC"].ToString());
                    blogs.Image = ds.Tables[0].Rows[i]["IMAGE"].ToString();

                    custlist.Add(blogs);
                }
                return custlist;
            }
            catch
            {
                return custlist;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Blogs> ListData()
        {
            SqlConnection con = null;
            List<Blogs> custlist = null;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_Blogs_2", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@QUERY", LIST);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                custlist = new List<Blogs>();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Blogs blogs = new Blogs();
                    blogs.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                    blogs.Title = ds.Tables[0].Rows[i]["Title"].ToString();
                    blogs.DescriptionShort = ds.Tables[0].Rows[i]["DESCRIPTION_SHORT"].ToString();
                    blogs.DescriptionShort = ds.Tables[0].Rows[i]["DETAIL"].ToString();
                    blogs.Category = ds.Tables[0].Rows[i]["CATEGORY"].ToString();
                    blogs.Locations = ds.Tables[0].Rows[i]["LOCATIONS"].ToString();
                    blogs.Publics = ds.Tables[0].Rows[i]["PUBLICS"].ToString();
                    blogs.DatePublic = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATE_PUBLIC"].ToString());
                    blogs.Image = ds.Tables[0].Rows[i]["IMAGE"].ToString();

                    custlist.Add(blogs);
                }
                //string test = custlist[2].Title;
                return custlist;
            }
            catch (Exception ex)
            {
                string error = ex.Message + ", " + ex.StackTrace;
                return custlist;
            }
            finally
            {
                con.Close();
            }
        }

        public Blogs SelectDataByID(string id)
        {
            SqlConnection con = null;
            DataSet ds = null;
            Blogs blogs = null;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_Blogs_2", con);
                SqlDataAdapter da = new SqlDataAdapter();
                ds = new DataSet();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_INPUT", id);
                cmd.Parameters.AddWithValue("@QUERY", SELECT_DATA);
                da.SelectCommand = cmd;
                da.Fill(ds);
                string t = ds.Tables[0].Rows[0][0].ToString();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["ID"].ToString() == id)
                    {
                        blogs = new Blogs();
                        blogs.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                        blogs.Title = ds.Tables[0].Rows[i]["Title"].ToString();
                        blogs.DescriptionShort = ds.Tables[0].Rows[i]["DESCRIPTION_SHORT"].ToString();
                        blogs.Detail = ds.Tables[0].Rows[i]["DETAIL"].ToString();
                        blogs.Category = ds.Tables[0].Rows[i]["CATEGORY"].ToString();
                        blogs.Locations = ds.Tables[0].Rows[i]["LOCATIONS"].ToString();
                        blogs.Publics = ds.Tables[0].Rows[i]["PUBLICS"].ToString();
                        blogs.DatePublic = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATE_PUBLIC"].ToString());
                        blogs.Image = ds.Tables[0].Rows[i]["IMAGE"].ToString();
                    }
                }

                return blogs;
            }
            catch (Exception ex)
            {
                return blogs;
            }
            finally
            {
                con.Close();
            }
        }
    }
}