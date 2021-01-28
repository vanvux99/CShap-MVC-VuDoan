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
        private string error = "";

        public string CovertCategory(int category)
        {
            string result = "";

            switch (category)
            {
                case 1:
                    result = "Thời sự";
                    break;
                case 2:
                    result = "Thế giới";
                    break;
                case 3:
                    result = "Kinh doanh";
                    break;
                case 4:
                    result = "Giải trí";
                    break;
                case 5:
                    result = "Thể thao";
                    break;
                case 6:
                    result = "Pháp luật";
                    break;
                default:
                    result = null;
                    break;
            }

            return result;
        }

        public string InsertData(Blogs blog)
        {
            /*SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_Blogs", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Titile", blog.TITLE);
                cmd.Parameters.AddWithValue("@Description_Short", blog.DESCRIPTION_SHORT);
                cmd.Parameters.AddWithValue("@Detail", blog.DETAIL);
                cmd.Parameters.AddWithValue("@Image", blog.IMAGE);
                cmd.Parameters.AddWithValue("@Category", blog.CATEGORY);
                cmd.Parameters.AddWithValue("@Location", blog.LOCATIONS);
                cmd.Parameters.AddWithValue("@Public", blog.PUBLICS);
                cmd.Parameters.AddWithValue("@Date_Public", null);
                cmd.Parameters.AddWithValue("@ID", null);
                cmd.Parameters.AddWithValue("@Query", 2);
                con.Open();
                result = cmd.ExecuteScalar().ToString();

                return result;
            }
            catch (Exception ex)
            {
                return result = "";
                error = ex.Message + ", " + ex.StackTrace;
            }
            finally
            {
                con.Close();
            }*/

            SqlConnection con = new SqlConnection(@"Data Source =.;Initial Catalog = BLOG;Integrated Security = True");

            string t = "proc_CRUD_Blogs @ID = NULL, @TITLE = 1, @Description_Short = 1, @Detail = 1, @IMAGE = 1, @CATEGORY = 1, @LOCATION = 1, @PUBLICS = 1, @Date_Public = NULL, @TITLE_INPUT = NULL, @Query = 2 ";

            SqlDataAdapter sda = new SqlDataAdapter(t, con);
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                sda.Fill(dt);
            }
            catch (Exception q)
            {
                string er = q.Message;
            }
            finally
            {
                con.Close();
            }
            return dt.Rows[0][0].ToString();
        }

        public string UpdateData(Blogs blog)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_Blogs", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Titile", blog.TITLE);
                cmd.Parameters.AddWithValue("@Description_Short", blog.DESCRIPTION_SHORT);
                cmd.Parameters.AddWithValue("@Detail", blog.DETAIL);
                cmd.Parameters.AddWithValue("@Image", blog.IMAGE);
                cmd.Parameters.AddWithValue("@Category", blog.CATEGORY);
                cmd.Parameters.AddWithValue("@Location", blog.LOCATIONS);
                cmd.Parameters.AddWithValue("@Public", blog.PUBLICS);
                cmd.Parameters.AddWithValue("@Date_Public", blog.DATE_PUBLIC);
                cmd.Parameters.AddWithValue("@ID", blog.ID);
                cmd.Parameters.AddWithValue("@Query", 3);
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

        public int DeleteData(String ID)
        {
            SqlConnection con = null;
            int result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_Blogs", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Titile", null);
                cmd.Parameters.AddWithValue("@Description_Short", null);
                cmd.Parameters.AddWithValue("@Detail", null);
                cmd.Parameters.AddWithValue("@Image", null);
                cmd.Parameters.AddWithValue("@Category", null);
                cmd.Parameters.AddWithValue("@Location", null);
                cmd.Parameters.AddWithValue("@Public", null);
                cmd.Parameters.AddWithValue("@Date_Public", null);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Query", 4);
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

        public List<Blogs> SearchData()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<Blogs> custlist = null;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_Blogs @ID, @TITLE, @DESCRIPTION_SHORT, @DETAIL, @IMAGE, @CATEGORY, @LOCATION, @PUBLICS, @DATE_PUBLIC, @TITLE_INPUT, @QUERY", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Titile", null);
                cmd.Parameters.AddWithValue("@Description_Short", null);
                cmd.Parameters.AddWithValue("@Detail", null);
                cmd.Parameters.AddWithValue("@Image", null);
                cmd.Parameters.AddWithValue("@Category", null);
                cmd.Parameters.AddWithValue("@Location", null);
                cmd.Parameters.AddWithValue("@Public", null);
                cmd.Parameters.AddWithValue("@Date_Public", null);
                cmd.Parameters.AddWithValue("@ID", null);
                cmd.Parameters.AddWithValue("@Query", 1);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds, "BLOGS");
                custlist = new List<Blogs>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Blogs blogs = new Blogs();
                    blogs.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                    blogs.TITLE = ds.Tables[0].Rows[i]["TITLE"].ToString();
                    blogs.DESCRIPTION_SHORT = ds.Tables[0].Rows[i]["DESCRIPTION_SHORT"].ToString();
                    blogs.DETAIL = ds.Tables[0].Rows[i]["DETAIL"].ToString();
                    blogs.CATEGORY = int.Parse(ds.Tables[0].Rows[i]["CATEGORY"].ToString());
                    blogs.LOCATIONS = ds.Tables[0].Rows[i]["LOCATIONS"].ToString();
                    blogs.PUBLICS = int.Parse(ds.Tables[0].Rows[i]["PUBLICS"].ToString());
                    blogs.DATE_PUBLIC = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATE_PUBLIC"].ToString());
                    blogs.IMAGE = ds.Tables[0].Rows[i]["IMAGE"].ToString();

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
                //con = new SqlConnection(@"Data Source =.;Initial Catalog = BLOG;Integrated Security = True");
                SqlCommand cmd = new SqlCommand("proc_CRUD_Blogs", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@ID", null);
                cmd.Parameters.AddWithValue("@TITLE", null);
                cmd.Parameters.AddWithValue("@DESCRIPTION_SHORT", null);
                cmd.Parameters.AddWithValue("@DETAIL", null);
                cmd.Parameters.AddWithValue("@IMAGE", null);
                cmd.Parameters.AddWithValue("@CATEGORY", null);
                cmd.Parameters.AddWithValue("@LOCATION", null);
                cmd.Parameters.AddWithValue("@PUBLICS", null);
                cmd.Parameters.AddWithValue("@DATE_PUBLIC", null);
                cmd.Parameters.AddWithValue("@TITLE_INPUT", null);
                cmd.Parameters.AddWithValue("@QUERY", 5);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                /*SqlDataReader sqlData = cmd.ExecuteReader();
                while (sqlData.Read())
                {
                    Blogs blogs = new Blogs();
                    blogs.ID = int.Parse(sqlData["ID"].ToString());
                    blogs.TITLE = sqlData["TITLE"].ToString();
                    blogs.DESCRIPTION_SHORT = sqlData["DESCRIPTION_SHORT"].ToString();
                    blogs.DETAIL = sqlData["DETAIL"].ToString();
                    blogs.CATEGORY = int.Parse(sqlData["CATEGORY"].ToString());
                    blogs.LOCATIONS = sqlData["LOCATIONS"].ToString();
                    blogs.PUBLICS = int.Parse(sqlData["PUBLICS"].ToString());
                    blogs.DATE_PUBLIC = Convert.ToDateTime(sqlData["DATE_PUBLIC"].ToString());
                    blogs.IMAGE = sqlData["IMAGE"].ToString();

                    custlist.Add(blogs);
                }*/

                /*DataTable dt = new DataTable();
                string t = "proc_CRUD_Blogs '"+null+"' '"+null+ "' '" + null + "' '" + null + "' '" + null + "' '" + null + "' '" + null + "' '" + null + "' '" + null + "' '5'";
                SqlDataAdapter sda = new SqlDataAdapter(t, con);
                sda.Fill(dt);*/


                DataSet ds = new DataSet();
                da.Fill(ds);
                custlist = new List<Blogs>();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Blogs blogs = new Blogs();
                    blogs.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                    blogs.TITLE = ds.Tables[0].Rows[i]["TITLE"].ToString();
                    blogs.DESCRIPTION_SHORT = ds.Tables[0].Rows[i]["DESCRIPTION_SHORT"].ToString();
                    blogs.DETAIL = ds.Tables[0].Rows[i]["DETAIL"].ToString();
                    blogs.CATEGORY = int.Parse(ds.Tables[0].Rows[i]["CATEGORY"].ToString());
                    blogs.LOCATIONS = ds.Tables[0].Rows[i]["LOCATIONS"].ToString();
                    blogs.PUBLICS = int.Parse(ds.Tables[0].Rows[i]["PUBLICS"].ToString());
                    blogs.DATE_PUBLIC = Convert.ToDateTime(ds.Tables[0].Rows[i]["DATE_PUBLIC"].ToString());
                    blogs.IMAGE = ds.Tables[0].Rows[i]["IMAGE"].ToString();

                    custlist.Add(blogs);
                }
                //string test = custlist[2].TITLE;
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
    }
}