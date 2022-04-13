using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class APIHandler
    {
        public void CreateData(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                string constr = @"Server=(localdb)\ProjectsV13;database=TEST;";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        SqlDataReader Reader = null;
                        cmd.Connection = con;
                        cmd.CommandText = "select * from disbursed_amount";
                        Reader = cmd.ExecuteReader();

                        if (Reader.HasRows == false)
                        {
                            Reader.Close();

                            int i = 0;
                            foreach (DataRow dr in dt.Rows)
                            {
                                i += 1;
                                cmd.CommandText = "INSERT INTO disbursed_amount VALUES(@Id, @Month, @disbursed_number, @disbursed_amount, @remarks)";

                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@Id", i);
                                cmd.Parameters.AddWithValue("@Month", dr["Month"].ToString());
                                cmd.Parameters.AddWithValue("@disbursed_number", dr["disbursed_number"].ToString());
                                cmd.Parameters.AddWithValue("@disbursed_amount", dr["disbursed_amount"].ToString());
                                cmd.Parameters.AddWithValue("@remarks", dr["remarks"].ToString());
                                cmd.Connection = con;

                                cmd.ExecuteNonQuery();

                            }
                        }
                        con.Close();
                    }
                }
            }
        }
    }
}